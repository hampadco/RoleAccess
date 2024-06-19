

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("[Action]")]
[ApiController]
public class UserController:Controller
{
    [HttpGet]
    [Authorize]
    public string Index()
    {
        return  "This is the default action";
    }

    [HttpGet]
     [Authorize]
    public string Add(int a , int b)
    {
        return  (a+b).ToString();

    }
    
}