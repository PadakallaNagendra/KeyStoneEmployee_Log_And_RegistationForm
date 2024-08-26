using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.Entities;
using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.InterFace;
using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.ModelDTO;
using KeyStoneEmployee_Log_And_RegistationForm_RepositaryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStoneEmployee_Log_And_RegistationForm_ServiceLayer
{
    public class userService : IUserService
    {
        public IUserRepositary _userRepositary;
        public userService(IUserRepositary userRepositary)
        {
            _userRepositary = userRepositary;
        }
        public async Task<UserSignInResponse> UserSignIn(UserSignInDTO userSignInDto)
        {
            UserSignIn obj = new UserSignIn();
            obj.Username = userSignInDto.Username;
            obj.Password = userSignInDto.Password;
            var res=await _userRepositary.UserSignIn(obj);
            return res;
        }

        public async Task<UserSignUpResponse> UserSignUp(UserSignUpDTO userSignUpDto)
        {
            UserSignUp obj = new UserSignUp();
            obj.Username=userSignUpDto.Username;
            obj.Password=userSignUpDto.Password;
            obj.FullName = userSignUpDto.FullName;
            obj.Email = userSignUpDto.Email;
            var res= await _userRepositary.UserSignUp(obj);
            return res;
        }
    }
}
