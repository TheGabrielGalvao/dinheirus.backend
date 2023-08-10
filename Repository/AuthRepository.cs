using Domain.Entities.Auth;
using Domain.Interface.Repository;
using Domain.Model.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly HttpClient _httpClient;
        private readonly JwtSettings _jwtSettings;
        private readonly string _autenticacaoUrl;
        private readonly IConfiguration _configuration;

        public AuthRepository(string autenticacaoUrl, IConfiguration configuration, IOptions<JwtSettings> jwtSettings)
        {
            _httpClient = new HttpClient();
            _autenticacaoUrl = autenticacaoUrl;
            _configuration = configuration;
            _jwtSettings = jwtSettings.Value;
            _httpClient.BaseAddress = new Uri(_autenticacaoUrl);
        }

        public async Task<AuthResponse> ExecuteAuth(AuthRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);

                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.PostAsync($"{_autenticacaoUrl}/auth/login", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var resultadoAutenticacao = JsonConvert.DeserializeObject<AuthResponse>(content);

                    resultadoAutenticacao.Success = true;

                    return resultadoAutenticacao;
                }
                else
                {
                    return new AuthResponse { Success = false, Message = "Falha na autenticação" };
                }
            }
            catch (Exception ex)
            {
                return new AuthResponse { Success = false, Message = ex.Message };
            }
        }

        public Task<string> GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Profile.Name),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(tokenHandler.WriteToken(token));
        }
    }
}
