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

        private string _id { get; set; }

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
                BaseAddress = new Uri("https://api.gotinder.com")
            };
            this._http.DefaultRequestHeaders.Add("accept", "application/json");
        }

        /// <summary>
        /// Get auth code from Tinder, call this method first
        /// </summary>
        /// <param name="phone_number">Your Phone Number</param>
        /// <param name="area_code">Phone Area Code</param>
        /// <param name="auth_type">Type of auth</param>
        /// <param name="locale">Locale</param>
        /// <returns></returns>
        private async Task<TinderResponse<OtpExpectation>> GetAuthCodeAsync(ulong phone_number, int area_code = 44, string auth_type = "sms", string locale = "en-GB")
        {
            if (auth_type != "sms")
            {
                this.TinderClientErrored?.Invoke("Only SMS auth is supported");
                return null;
            }
            var numstr = phone_number.ToString();
            if(!numstr.StartsWith(area_code.ToString()) && numstr.Length != 13)
            {
                if (area_code == 44)
                {
                    if (numstr.Length == 11) numstr = $"{area_code}{numstr}";
                    else if (numstr.Length == 10) numstr = $"{area_code}0{numstr}";
                    else
                    {
                        this.TinderClientErrored?.Invoke("Invalid phone number supplied");
                        return null;
                    }
                }
                else
                {
                    this.TinderClientErrored?.Invoke("Invalid phone number supplied");
                    return null;
                }
            }
            this._phoneNumber = ulong.Parse(numstr);
            var res = await _http.PostAsync($"{_http.BaseAddress}/v2/auth/sms/send?auth_type={auth_type}&locale={locale}", new StringContent(string.Concat(@"{""phone_number"":""", this._phoneNumber,@"""}"), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var cont = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<TinderResponse<OtpExpectation>>(cont);
            if (!data.Data.HasSmsSent) TinderClientErrored?.Invoke("Otp Token has not been sent");
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
            var res = await _http.PostAsync(new Uri($"{_http.BaseAddress}/v2/auth/sms/validate?auth_type={auth_type}&locale={locale}"), new StringContent(JsonConvert.SerializeObject(new ValidatePayload()
            {
                IsUpdate = false,
                OtpCode = auth_code.ToString(),
                PhoneNumber = this._phoneNumber.ToString()
            }), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var cont = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<TinderResponse<ValidationData>>(cont);
            if (!data.Data.Validated) TinderClientErrored?.Invoke("Validation has Failed");
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
            var res = await _http.PostAsync(new Uri($"{_http.BaseAddress}/v2/auth/login/sms?locale={locale}"), new StringContent(JsonConvert.SerializeObject(new LoginPayload()
            {
                PhoneNumber = this._phoneNumber,
                RefreshToken = this._refreshToken
            }), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var cont = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<TinderResponse<LoginData>>(cont);
            this._authToken = data.Data.ApiToken;
            this._id = data.Data.Id;
            this._http.DefaultRequestHeaders.Add("X-Auth-Token", this._authToken);
            return data;
        }

        /// <summary>
        /// Single method to auth and log into Tinder
        /// </summary>
        /// <param name="auth_code">User defined method to get the auth code</param>
        /// <param name="phone_number">Your phone number</param>
        /// <param name="area_code">Phone Area Code</param>
        /// <param name="auth_type">Authentication Type</param>
        /// <param name="locale">Locale</param>
        /// <returns>LoginData</returns>
        public async Task StartTinderAsync(Func<Task<int>> auth_code, ulong phone_number, int area_code = 44, string auth_type = "sms", string locale = "en-GB")
        {
            var otpe = await GetAuthCodeAsync(phone_number, area_code, auth_type, locale).ConfigureAwait(false);
            var veri = await VerifyCodeAsync(otpe.Data, await auth_code(), auth_type, locale).ConfigureAwait(false);
            var log = await LoginAsync(locale).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the profile of the logged in user
        /// </summary>
        /// <param name="locale">Locale</param>
        /// <returns>User profile</returns>
        public async Task<TinderResponse<UserProfile>> GetProfileAsync(string locale = "en-GB")
        {
            var res = await _http.GetAsync(new Uri($"{_http.BaseAddress}/v2/profile?include=account%2Cemail_settings%2Clikes%2Cnotifications%2Csuper_likes%2Ctinder_u%2Ctravel%2Cuser&locale={locale}")).ConfigureAwait(false);
            var cont = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<TinderResponse<UserProfile>>(cont);
            return data;
        }

        /// <summary>
        /// Get a set of users to match with
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public async Task<TinderResponse<Annoyance>> GetCardsAsync(string locale="en-GB")
        {
            var res = await _http.GetAsync(new Uri($"{_http.BaseAddress}/v2/recs/core?locale={locale}")).ConfigureAwait(false);
            var cont = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<TinderResponse<Annoyance>>(cont);
            return data;
        }

        /// <summary>
        /// Swipe on a user
        /// </summary>
        /// <param name="swipe_type">Type of swipe</param>
        /// <param name="s_number">User's Sequence Number</param>
        /// <param name="locale">Locale</param>
        /// <returns>True, if successful</returns>
        public async Task<bool> SwipeAsync(SwipeType swipe_type, ulong s_number, string locale = "en-GB")
        {
            var res = await _http.GetAsync($"{this._http.BaseAddress}/{swipe_type}/{this._id}?locale={locale}&s_number={s_number}").ConfigureAwait(false);
            return res.IsSuccessStatusCode;
        }
    }
}
