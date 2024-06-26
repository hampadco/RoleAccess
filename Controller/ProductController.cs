

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("[Action]")]
[ApiController]
public class ProductController:Controller
{
    [HttpGet]
    public string AddProduct()
    {
        //check if user has permission to add product

        if(User.HasClaim(c => c.Type == "Permission" && c.Value == "AddProduct"))
        {
            return "Add successsful";
        }
        else
        {
            return "You do not have permission to add product";
        }
       
    }

   //update
    [HttpGet]

    //permission to update product
   
    public string UpdateProduct()
    {
       //check if user has permission to update product
        if(User.HasClaim(c => c.Type == "Permission" && c.Value == "UpdateProduct"))
        {
            return "Update successsful";
        }
        else
        {
            return "You do not have permission to update product";
        }
    }

    //delete
    [HttpGet]

    public string DeleteProduct()
    {
        //check if user has permission to delete product
        if(User.HasClaim(c => c.Type == "Permission" && c.Value == "DeleteProduct"))
        {
            return "Delete successsful";
        }
        else
        {
            return "You do not have permission to delete product";
        }
    }

    //view
    [HttpGet]


    public string ViewProduct()
    {
       //check if user has permission to view product
        if(User.HasClaim(c => c.Type == "Permission" && c.Value == "ViewProduct"))
        {
            return "View successsful";
        }
        else
        {
            return "You do not have permission to view product";
        }
    }

    //search
    [HttpGet]
   
    public string SearchProduct()
    {
        //check if user has permission to search product
        if(User.HasClaim(c => c.Type == "Permission" && c.Value == "SearchProduct"))
        {
            return "Search successsful";
        }
        else
        {
            return "You do not have permission to search product";
        }
    }
    
}