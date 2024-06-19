
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


[Route("[Action]")]
[ApiController]

public class AuthController: Controller
{

    [HttpGet]
    public string Login(string username, string password)
    {
        if (username == "admin" && password == "admin")
        {
            var token = GenerateToken(username);
            return token;
        }
        else
        {
            return "Login Failed";
        }
    }


    //generate token
    private string GenerateToken(string username)
    {

        //secret key
        var secretKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345hampadco5656hastalavista")) ;

        var Credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "http://localhost:5110",
            audience: "http://localhost:5110",
            claims: new Claim[] { new Claim(ClaimTypes.Name, username) },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: Credentials
        ); 

        return new JwtSecurityTokenHandler().WriteToken(token);


    }

   
    
}