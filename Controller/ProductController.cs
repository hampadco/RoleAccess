

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("[Action]")]
[ApiController]
public class ProductController:Controller
{
    [HttpGet]
    [Authorize(Roles="Admin")]
    public string AddProduct()
    {
        return  "Add successsful";
    }

   //update
    [HttpGet]
    [Authorize (Roles="Admin")]
    public string UpdateProduct()
    {
        return  "Update successsful";
    }

    //delete
    [HttpGet]
    [Authorize (Roles="Admin")]
    public string DeleteProduct()
    {
        return  "Delete successsful";
    }

    //view
    [HttpGet]
    [Authorize (Roles="Admin,clinet")]

    public string ViewProduct()
    {
        return  "View successsful";
    }

    //search
    [HttpGet]
    [Authorize (Roles="clinet")]
    public string SearchProduct()
    {
        return  "Search successsful";
    }
    
}