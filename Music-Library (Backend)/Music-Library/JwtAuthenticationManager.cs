using Microsoft.IdentityModel.Tokens;
using Music_Library.Data;
using Music_Library.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Music_Library
{
    public class JwtAuthenticationManager
    {
        private DataContext _dataContext;

        public JwtAuthenticationManager(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public UserResponse Authenticate(string email, string password)
        {
            var userInfo = _dataContext.User.Where(user => user.Email == email).FirstOrDefault();
            if (userInfo?.Password != password)
            {
                return null;
            }
            if (email == null || password == null)
            {
                return null;
            }
            if (userInfo == null)
            {
                return null;
            }
            if (userInfo.Email != email && userInfo.Password != password)
            {
                return null;
            }

            if (userInfo == null)
            {
                return new UserResponse() { IsError = true, Message = "User does not exist." };
            }

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Constants.JWT_TOKEN_VALIDITY_MIN);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(Constants.JWT_SECURITY_KEY);
            var securitytokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim("email", email),
                    new Claim(ClaimTypes.PrimaryGroupSid, "User Group 01")
                }),
                Expires = DateTime.Now.AddMinutes(Constants.JWT_TOKEN_VALIDITY_MIN),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = jwtSecurityTokenHandler.CreateToken(securitytokendescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new UserResponse
            {
                id = userInfo.ID,
                token = token,
                email = userInfo.Email,
                username = userInfo.Username,
                TokenExpiration = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }
    }
}
