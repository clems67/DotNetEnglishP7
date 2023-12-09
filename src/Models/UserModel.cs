using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string userName { get; set; }
        public byte[] hashedPassword { get; set; }
        public byte[] salt { get; set; }
    }
}
