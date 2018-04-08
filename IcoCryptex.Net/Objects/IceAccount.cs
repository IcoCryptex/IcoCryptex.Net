namespace IcoCryptex.Net.Objects
{
    public class IceAccount
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long UnixBirthDate { get; set; }
        public short? MobileCountryCode { get; set; }
        public string MobileNumber { get; set; }
        public string AddressStreet { get; set; }
        public string AddressHouseNumber { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressCountry { get; set; }
    }
}