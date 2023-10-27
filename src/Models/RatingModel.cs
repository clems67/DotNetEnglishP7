using System.ComponentModel.DataAnnotations;
using System;

namespace WebApi.Models
{
    public class RatingModel
    {
        [Key]
        public int Id { get; set; }
        public string moodysRating { get; set; }
        public string sandPRating { get; set; }
        public string fitchRaing { get; set; }
        public int orderNumber { get; set; }
    }
}
