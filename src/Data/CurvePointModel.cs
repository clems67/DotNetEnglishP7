using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data
{
    public class CurvePointModel
    {
        [Key]
        public int ID { get; set; }
        public int cureveId { get; set; }
        public DateTime asOfDate { get; set; }
        public double term { get; set; }
        public double value { get; set; }
        public DateTime creationDate { get; set; }
    }
}
