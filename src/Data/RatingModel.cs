using System.ComponentModel.DataAnnotations;
using System;

namespace WebApi.Data
{
    public class RatingModel
    {
        [Key]
        public int Id { get; set; }
        public string moodysRating { get; set; }
        public String sandPRating { get; set; }
        public string fitchRaing { get; set; }
        public int orderNumber{ get; set; }
    }
}
