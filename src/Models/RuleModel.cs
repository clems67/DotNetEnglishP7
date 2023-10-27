using System.ComponentModel.DataAnnotations;
using System;

namespace WebApi.Models
{
    public class RuleModel
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string descripton { get; set; }
        public string json { get; set; }
        public string template { get; set; }
        public string sqlStr { get; set; }

        public string sqlPart { get; set; }
    }
}
