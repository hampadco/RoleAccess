using System.ComponentModel.DataAnnotations;

public class User
{
     [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public string Token  { get; set; }
//relationship

    public ICollection<UserRole> UserRoles { get; set; }
}