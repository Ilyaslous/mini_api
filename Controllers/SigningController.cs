using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mini_api.DTOs;
using mini_api.Services;

namespace mini_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigningController : ControllerBase
    {
        private readonly ISigningServ _signingServ;
        public SigningController(ISigningServ signingServ)
        {
            _signingServ = signingServ;
        }
        [HttpPost("sign")]
        public IActionResult SignContent([FromBody] SignReq req)
        {
            string dataToSign = $"{req.Auth}:{req.Msg}";
            string signature = _signingServ.SignData(dataToSign);
            return Ok(new {
                OriginalData = req,
                Signature = signature
            });
        
        }
        [HttpPost("verify")]
        public IActionResult VerifyContent([FromBody] VerifyReq req)
        {
            string dataToVerify = $"{req.Auth}:{req.Msg}";
            bool isValid = _signingServ.VerifyData(dataToVerify, req.Sig);
            return Ok(new {
                OriginalData = req,
                IsValid = isValid
            });
        }
    }
}
