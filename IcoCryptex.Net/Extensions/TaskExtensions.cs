using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IcoCryptex.Net.Extensions
{
    internal static class TaskExtensions
    {
        public static async Task<T> ThenDeserializeAs<T>(this Task<string> jsonSourceTask)
        {
            var json = await jsonSourceTask;
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}