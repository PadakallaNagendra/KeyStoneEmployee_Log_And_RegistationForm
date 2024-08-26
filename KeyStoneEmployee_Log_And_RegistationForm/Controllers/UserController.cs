using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.InterFace;
using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeyStoneEmployee_Log_And_RegistationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("UserSignIn")]
        public async Task<IActionResult> post([FromBody] UserSignInDTO userSignInDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var res = await _userService.UserSignIn(userSignInDTO);
                    // return StatusCode(StatusCodes.Status200OK, "User Details Inserted");
                    return Ok(res);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("UserSignUp")]
        public async Task<IActionResult> post([FromBody] UserSignUpDTO userSignUpDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var res = await _userService.UserSignUp(userSignUpDTO);
                    return Ok(res);
                    //return StatusCode(StatusCodes.Status200OK, "User Details Inserted");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
