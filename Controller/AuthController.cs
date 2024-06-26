
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

            //list of permissions
             List<string> permission=new List<string>(); 
            foreach (var item in UserRoles)
            {
                List<int> RolePermissions=db.RolePermissions.Where(rp => rp.RoleId == item).Select(rp => rp.PermissionId).ToList();

                foreach (var item2 in RolePermissions)
                {
                    //not exist in list
                    if(!permission.Contains(db.Permissions.Where(p => p.Id == item2).FirstOrDefault().Name))
                                       
                        permission.Add(db.Permissions.Where(p => p.Id == item2).FirstOrDefault().Name);
                }
            }


            

           

            var token = GenerateToken(username,permission.ToArray());
            return token;
        }
        else
        {
            return "Login Failed";
        }
    }


    //generate token
    private string GenerateToken(string username,  string[] permission)
    {

        //secret key
        var secretKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345hampadco5656hastalavista")) ;

        var Credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };


        //  claims.AddRange(role.Select(role => new Claim(ClaimTypes.Role, role)));

         claims.AddRange(permission.Select(permission => new Claim("Permission", permission)));

         claims.AddRange(permission.Select(permission => new Claim("Permission", permission)));



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