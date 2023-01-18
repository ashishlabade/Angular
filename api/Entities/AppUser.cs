using System.ComponentModel.DataAnnotations;
namespace api.Entities
{
    public class AppUser
    {
        public int Id { get; set; } // database column of table users
        public string UserName { get; set; } // database column of table users
    }
}