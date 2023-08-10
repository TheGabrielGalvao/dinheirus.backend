using Newtonsoft.Json;

namespace Domain.Model.Auth
{
    public class AuthRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
