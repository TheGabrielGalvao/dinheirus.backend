using Domain.Model.Auth;

namespace Domain.Interface.Service
{
    public interface IAuthService
    {
        Task<AuthResponse> ExecuteAuth(AuthRequest request);

        Task<AuthResponse> ExecuteInternalAuth(AuthRequest request);
    }
}
