using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KaniniStock.Domain.IRepoInterfaces;
using KaniniStock.Domain.Models.SourceModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace KaniniStock.Infrastructure.Repositories;

public class LoginRepo : ILogin
{
    private readonly KaninistockPickerContext dbcontext;
    private readonly IConfiguration configuration;

    public LoginRepo(KaninistockPickerContext dbcontext, IConfiguration configuration)
    {
        this.configuration = configuration;
        this.dbcontext = dbcontext;
    }
    public string Login(UserLogin user)
    {
        if (user.Email != null && user.Password != null)
        {
            var users = GetUser(user.Email, user.Password);

            if (users != null)
            {
                //create claims details based on the user information
                var claims = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Email",user.Email)
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    configuration["Jwt:Issuer"],
                    configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                string tokenvalue = new JwtSecurityTokenHandler().WriteToken(token);
                return tokenvalue;
            }
            else
            {
                return string.Empty;
            }
        }
        else
        {
            return "Invalid credentials";
        }

    }

    private UserLogin GetUser(string email, string password)
    {
        return dbcontext.UserLogins.FirstOrDefault(u => u.Email == email && u.Password == password);
    }

}
