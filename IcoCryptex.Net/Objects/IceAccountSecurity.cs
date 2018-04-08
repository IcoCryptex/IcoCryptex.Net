using IcoCryptex.Net.Objects.Enums;

namespace IcoCryptex.Net.Objects
{
    public class IceAccountSecurity
    {
        public SecurityState Account { get; set; }
        public SecurityState Email { get; set; }
        public SecurityState Mobile { get; set; }
        public SecurityState Identity { get; set; }
        public SecurityState TwoFact { get; set; }
        public SecurityState IpWhiteListing { get; set; }
    }
}