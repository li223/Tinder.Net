namespace Tinder.Net.Objects
{
    internal class CurrentUser
    {
        internal int AreaCode { get; set; }

        internal ulong PhoneNumber { get; set; }

        internal string AuthToken { get; set; }

        internal string RefreshToken { get; set; }

        internal string Id { get; set; }
    }
}
