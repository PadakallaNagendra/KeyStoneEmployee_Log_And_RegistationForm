using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.InterFace;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyStoneEmployee_Log_And_RegistationForm_DataBaseLogic.Data
{
    public class KeystoneConfigurationFactory : IKeystoneConfigurationFactory
    {
        private readonly IOptions<KeystoneConfiguration> _options;
        private readonly IConfiguration _config;
        public KeystoneConfigurationFactory(IOptions<KeystoneConfiguration> options, IConfiguration config)
        {
            _options = options;
            _config = config;
        }

        public IDbConnection UserLogAndRegistaer()
        {
            IDbConnection _connection = new SqlConnection(Convert.ToString(_config.GetSection("ConnectionStrings:UserLogAndRegistaer").Value));
            return _connection;
        }
    }
}
