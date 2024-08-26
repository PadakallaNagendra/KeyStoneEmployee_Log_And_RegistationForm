using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.Entities;
using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.InterFace
{
    public interface IUserRepositary
    {
        public Task<UserSignInResponse> UserSignIn(UserSignIn userSignIn);
        public Task<UserSignUpResponse> UserSignUp(UserSignUp userSignUp);
    }
}
