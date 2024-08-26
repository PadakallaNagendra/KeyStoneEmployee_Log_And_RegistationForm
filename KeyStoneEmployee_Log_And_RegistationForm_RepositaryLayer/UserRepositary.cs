using Dapper;
using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.Entities;
using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.InterFace;
using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.ModelDTO;
using KeyStoneEmployee_Log_And_RegistationForm_DataBaseLogic.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStoneEmployee_Log_And_RegistationForm_RepositaryLayer
{
    public class UserRepositary : IUserRepositary
    {
        IKeystoneConfigurationFactory _ConfigurationFactory;
        public UserRepositary(IKeystoneConfigurationFactory configurationFactory)
        {
            _ConfigurationFactory = configurationFactory;
        }

        public async Task<UserSignInResponse> UserSignIn(UserSignIn userSignIn)
        {
           using(IDbConnection con = _ConfigurationFactory.UserLogAndRegistaer())
            {
                var p = new DynamicParameters();
                p.Add("@Username", userSignIn.Username);
                p.Add("@Password", userSignIn.Password);
                var res = await con.QueryAsync<UserSignInResponse>(StoreProcedureStatusMessages.SignIn, p, commandType: CommandType.StoredProcedure);
                var status = res.FirstOrDefault();
                return status;
            }
        }

        public async Task<UserSignUpResponse> UserSignUp(UserSignUp userSignUp)
        {
            using(IDbConnection con = _ConfigurationFactory.UserLogAndRegistaer())
            {
                var p = new  DynamicParameters();
                p.Add("@Username",userSignUp.Username);
                p.Add("@Email", userSignUp.Email);
                p.Add("@FullName", userSignUp.FullName);
                p.Add("@Password", userSignUp.Password);
                var res = await con.QueryAsync<UserSignUpResponse>(StoreProcedureStatusMessages.Signup, p, commandType: CommandType.StoredProcedure);
                var status = res.FirstOrDefault();
                return status;
            }
        }
    }
}
