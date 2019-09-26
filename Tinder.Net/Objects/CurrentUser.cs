using System;
using System.Collections.Generic;
using System.Text;

namespace Tinder.Net.Objects
{
    internal class CurrentUser
    {
        internal ulong PhoneNumber { get; set; }

        internal string AuthToken { get; set; }

        internal string RefreshToken { get; set; }

        internal string Id { get; set; }
    }
}
