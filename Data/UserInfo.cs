using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Data.Helper;

namespace Data
{
    public class UserInfo
    {
        public string ConnectionString { get; set; } = "EPrescription";
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public byte[] Signature { get; set; }
        public string Location { get; set; }
        public bool IsDisabled { get; set; } = false;
        public byte[] Avatar { get; set; }
        public string MobilePhone { get; set; }

        public UserInfo()
        {
            
        }
        public UserInfo Get(string userName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userName", userName);
            return
                SqlHelper.GetObjects<UserInfo>("SELECT * FROM dbo.Users WHERE UserName = @userName", ConnectionString, parameters)
                    .FirstOrDefault();
        }

        public bool Login(string userName, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userName", userName);
            parameters.Add("@password", password);
            return
                SqlHelper.GetObjects<UserInfo>("SELECT * FROM dbo.Users WHERE UserName = @userName AND Password = @password AND IsDisabled = 0", ConnectionString, parameters)
                    .FirstOrDefault() != null;
        }

        public IEnumerable<UserInfo> List()
        {
            return
                SqlHelper.GetObjects<UserInfo>("SELECT * FROM dbo.Users", ConnectionString);
        }
    }
}
