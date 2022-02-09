


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
        public async Task<string> Signup(UserModel value)
        {
            SignUp sp = new SignUp();

            var result = context.SignUps.FirstOrDefault(X => X.UserName == value.UserName);
            if (result != null)
            {
                throw new ArgumentException("User Name Already Exist");
            }
            else
            {
                sp.UserName = value.UserName;
                sp.Password = value.Password;

                context.SignUps.InsertOnSubmit(sp);
                context.SubmitChanges();
                return "SignUp Successfully";
            }
        }

        public async Task<string> Login(UserModel value)
        {
            SignUp sp = new SignUp();

            var result = (from data in context.SignUps
                          where data.UserName == value.UserName && data.Password == value.Password
                          select data).ToList();

            if (result.Count() == 1)
            {

                var authclaims = new List<Claim>
                  {
                 new Claim(ClaimTypes.Name,value.UserName),
                 new Claim(ClaimTypes.Name,value.Password),
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

