using System.Security.Claims;
using Core.Models;
using Core.Repositories;
using Core.Service;

namespace Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly TokenService _tokenService;

        public AuthService(IAuthRepository authRepository, TokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public async Task<string> Login(string UsernameOrEmail, string senha)
        {
            Usuario usuario = await GetUserByEmailOrUsernameAndPassword(UsernameOrEmail, senha);

            string token = _tokenService.CreateToken(usuario);

            return token;
        }

        public async Task<Usuario> GetUserByEmailOrUsernameAndPassword(string UsernameOrEmail, string senha)
        {
            Usuario? usuario = await _authRepository.GetUserByEmailOrUsernameAndPassword(UsernameOrEmail, senha);

            if (usuario == null)
            {
                throw new Exception("Dados inválidos. Por favor verifique os dados digitados e tente novamente");
            }

            return usuario;
        }

        public string GetAuthenticatedUserId(ClaimsPrincipal User)
        {
            string? userId = User.Claims.First(c => c.Type == "id")?.Value;
            if (userId == null)
            {
                throw new Exception("User not found on token JWT");
            }

            return userId;
        }
    }
}
