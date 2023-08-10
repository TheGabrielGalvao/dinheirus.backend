using Newtonsoft.Json;

namespace Domain.Model.Auth
{
    public class AuthResponse
    {
        public bool Success { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        public string Message { get; set; }
    }
}
