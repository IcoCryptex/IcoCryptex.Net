namespace IcoCryptex.Net.InternalObjects
{
    public class ApiIdentity
    {
        public readonly string Key;
        public readonly string Secret;

        public ApiIdentity(string key, string secret)
        {
            Key = key;
            Secret = secret;
        }
    }
}