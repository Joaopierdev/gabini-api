using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using usuario.DTOs;
using usuario.Models;
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

        public async Task<string> Login(string username, string email, string senha)
        {
            Usuario usuario = await GetUserByEmailOrUsernameAndPassword(username, email, senha);

            string token = _tokenService.CreateToken(usuario);

            return token;
        }

        public async Task<Usuario> GetUserByEmailOrUsernameAndPassword(string? username, string? email, string senha)
        {
            Usuario? usuario =  await _authRepository.GetUserByEmailOrUsernameAndPassword(username, email, senha);

            if(usuario == null)
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
