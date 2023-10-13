using System;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Data
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
