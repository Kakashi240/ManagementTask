

using ManagementTask.DataAccess.Models;
using ManagementTask.Domain.ModelsDTO.TokenDTO;
using ManagementTask.Domain.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManagementTask.Business.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TokenResponse> GetToken(Credentials credentials)
        {
            var userResponse = (await _unitOfWork.Repository<TblUser>().GetAllAsync(x => x.Email == credentials.Email)).FirstOrDefault();
            if (userResponse == null) throw new Exception("El usuario no existe.");

            if (userResponse.Password != credentials.Password) throw new Exception("Contraseña incorrecta");

            var Token = GenerateToken(userResponse);

            return new() { APPToken = Token };
        }

        private string GenerateToken(TblUser tblUser)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, tblUser.Document),
                new Claim(ClaimTypes.Name, tblUser.FullName),
                new Claim(ClaimTypes.Email, tblUser.Email)
            };

            var Handler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("asdfgDHJFDSKAJYTRQBFIgfkdjbvifdgvbbnkjhkijsdgfaksjdfhknsbvilasg")), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = Handler.CreateToken(descriptor);

            return Handler.WriteToken(token);
        }
    }
}
