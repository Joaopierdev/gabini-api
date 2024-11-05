using usuario.Repositories;

namespace usuario.Service
{
    public class AuthService
    {
        private readonly AuthRepository _authRepository;
        private readonly TokenService _tokenService;

        public AuthService(AuthRepository authRepository, TokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }
    }
}
