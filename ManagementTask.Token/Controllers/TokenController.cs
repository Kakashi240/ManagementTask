using ManagementTask.Business.TokenService;
using ManagementTask.Domain.ModelsDTO.TokenDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTask.Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<TokenResponse>> GetToken(Credentials credentials) => Ok(await _tokenService.GetToken(credentials));
    }
}
