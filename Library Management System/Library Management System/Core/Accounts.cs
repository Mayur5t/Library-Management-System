using Library_Management_System.Model.Account;
using LibraryManagementContext;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Core
{
    public class Accounts
    {
        LibraryManagementDataContext context = new LibraryManagementDataContext();
        private readonly IConfiguration _configuration;

        public Accounts(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> Signup(UserModel userModel)
        {
            SignUp sp = new SignUp();

            var result = context.SignUps.FirstOrDefault(X => X.UserName == userModel.UserName);
            if(result !=null)
            {
                throw new ArgumentException("User Name Already Exist");
            }
            else
            {
                sp.UserName = userModel.UserName;
                sp.Password = userModel.Password;

                context.SignUps.InsertOnSubmit(sp);
                context.SubmitChanges();
                return "SignUp Successfully";
            }
        }

        public async Task<string>Login(UserModel userModel)
        {
            SignUp sp = new SignUp();

            var result = (from data in context.SignUps
                          where data.UserName == userModel.UserName && data.Password == userModel.Password
                          select data).ToList();

            if (result.Count() == 1)
            {

                var authclaims = new List<Claim>
                  {
                 new Claim(ClaimTypes.Name,userModel.UserName),
                 new Claim(ClaimTypes.Name,userModel.Password),
                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                  };
                var authsignkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authclaims,
                    signingCredentials: new SigningCredentials(authsignkey, SecurityAlgorithms.HmacSha256Signature)
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
                return "Enter Proper Details";
        }
    }
}
