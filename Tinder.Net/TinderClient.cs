using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tinder.Net.Objects;

namespace Tinder.Net
{
    /// <summary>
    /// Main Client
    /// </summary>
    public class TinderClient
    {
        private HttpClient _http { get; set; }

        private ulong _phoneNumber { get; set; }

        private string _authToken { get; set; }

        private string _refreshToken { get; set; }

        private string _wsToken { get; set; }

        /// <summary>
        /// Tinder Error Delegate
        /// </summary>
        /// <param name="message">The error message</param>
        /// <returns></returns>
        public delegate Task TinderError(string message);

        /// <summary>
        /// Tinder Error Event
        /// </summary>
        public event TinderError TinderClientErrored;

        /// <summary>
        /// Tinder Client Ctor
        /// </summary>
        public TinderClient()
        {
            _http = new HttpClient()
            {
                BaseAddress = new Uri("https://api.gotinder.com/v2")
            };
        }
        
        /// <summary>
        /// Get auth code from Tinder, call this method first
        /// </summary>
        /// <param name="phone_number">Your Phone Number</param>
        /// <param name="auth_type">Type of auth</param>
        /// <param name="locale">Locale</param>
        /// <returns></returns>
        private async Task<TinderResponse<OtpExpectation>> GetAuthCodeAsync(ulong phone_number, string auth_type = "sms", string locale = "en-GB")
        {
            if (auth_type != "sms")
            {
                this.TinderClientErrored?.Invoke("Only SMS auth is supported");
                return null;
            }
            var numstr = phone_number.ToString();
            if(!numstr.StartsWith("44") && numstr.Length != 13)
            {
                if (numstr.Length == 11) numstr = $"44{numstr}";
                else if (numstr.Length == 10) numstr = $"440{numstr}";
                else
                {
                    this.TinderClientErrored?.Invoke("Invalid phone number supplied");
                    return null;
                }
            }
            this._phoneNumber = ulong.Parse(numstr);
            var res = await _http.PostAsync($"{_http.BaseAddress}/auth/sms/send?auth_type={auth_type}&locale={locale}", new StringContent(string.Concat(@"{""phone_number"":""", this._phoneNumber,@"""}"), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var cont = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<TinderResponse<OtpExpectation>>(cont);
            return data;
        }

        /// <summary>
        /// Verify the auth code, call this method second
        /// </summary>
        /// <param name="expectation">"Data" member from the object that is returned after invoking GetAuthCodeAsync</param>
        /// <param name="auth_code">The received auth code</param>
        /// <param name="auth_type">Type of auth</param>
        /// <param name="locale">Locale</param>
        /// <returns></returns>
        private async Task<TinderResponse<ValidationData>> VerifyCodeAsync(OtpExpectation expectation, int auth_code, string auth_type = "sms", string locale = "en-GB")
        {
            if(auth_type != "sms")
            {
                this.TinderClientErrored?.Invoke("Only SMS auth is supported");
                return null;
            }
            if (expectation.Length != auth_code.ToString().Length)
            {
                this.TinderClientErrored?.Invoke("Auth Code is not the expected Length");
                return null;
            }
            var res = await _http.PostAsync(new Uri($"{_http.BaseAddress}/auth/sms/validate?auth_type={auth_type}&locale={locale}"), new StringContent(JsonConvert.SerializeObject(new ValidatePayload()
            {
                IsUpdate = false,
                OtpCode = auth_code.ToString(),
                PhoneNumber = this._phoneNumber.ToString()
            }), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var cont = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<TinderResponse<ValidationData>>(cont);
            this._refreshToken = data.Data.RefreshToken;
            return data;
        }

        /// <summary>
        /// Login into Tinder, call this method last
        /// </summary>
        /// <param name="locale">Locale</param>
        /// <returns></returns>
        private async Task<TinderResponse<LoginData>> LoginAsync(string locale = "en-GB")
        {
            if(this._phoneNumber == 0 || this._refreshToken == null)
            {
                this.TinderClientErrored?.Invoke("GetAuthCodeAsync and VerifyAsync must be called before invoking this method");
                return null;
            }
            var res = await _http.PostAsync(new Uri($"{_http.BaseAddress}/auth/login/sms?locale={locale}"), new StringContent(JsonConvert.SerializeObject(new LoginPayload()
            {
                PhoneNumber = this._phoneNumber,
                RefreshToken = this._refreshToken
            }), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var cont = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<TinderResponse<LoginData>>(cont);
            this._authToken = data.Data.ApiToken;
            this._http.DefaultRequestHeaders.Add("X-Auth-Token", this._authToken);
            return data;
        }

        /// <summary>
        /// Single method to auth and log into Tinder
        /// </summary>
        /// <param name="auth_code">User defined method to get the auth code</param>
        /// <param name="phone_number">Your phone number</param>
        /// <returns>LoginData</returns>
        public async Task StartTinderAsync(Func<Task<int>> auth_code, ulong phone_number, string auth_type = "sms", string locale = "en-GB")
        {
            var otpe = await GetAuthCodeAsync(phone_number, auth_type, locale).ConfigureAwait(false);
            var veri = await VerifyCodeAsync(otpe.Data, await auth_code(), auth_type, locale).ConfigureAwait(false);
            var log = await LoginAsync(locale).ConfigureAwait(false);
        }
    }
}
