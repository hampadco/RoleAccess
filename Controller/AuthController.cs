
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


[Route("[Action]")]
[ApiController]

public class AuthController: Controller
{

    Context db=new Context();

    [HttpGet]
    public string Login(string username, string password)
    {

        if (db.Users.Any(u => u.Username == username && u.Password == password))
        {

            int userId=db.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault().Id;

           // int UserRole=db.UserRoles.Where(ur => ur.UserId == userId).FirstOrDefault().RoleId;
           //list of roles
              List<int> UserRoles=db.UserRoles.Where(ur => ur.UserId == userId).Select(ur => ur.RoleId).ToList();

            //if user has multiple roles use , to separate them else use single role not use array
            List<string> role=new List<string>();

            foreach (var item in UserRoles)
            {
                role.Add(db.Roles.Where(r => r.Id == item).FirstOrDefault().Name);
            }
            

           

            var token = GenerateToken(username,role.ToArray());
            return token;
        }
        else
        {
            return "Login Failed";
        }
    }


    //generate token
    private string GenerateToken(string username, string[] role)
    {

        //secret key
        var secretKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345hampadco5656hastalavista")) ;

        var Credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };
         claims.AddRange(role.Select(role => new Claim(ClaimTypes.Role, role)));

        var token = new JwtSecurityToken(
            issuer: "http://localhost:5110",
            audience: "http://localhost:5110",
            claims: claims,         
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: Credentials
        ); 

        

        return new JwtSecurityTokenHandler().WriteToken(token);


    }

   
    
}