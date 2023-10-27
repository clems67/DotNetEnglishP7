using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class BidModel
    {
        [Key]
        public int Id { get; set; }
        public string account { get; set; }
        public string type { get; set; }
        public double bidQuantity { get; set; }
        public double askQuantity { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
        public string benchmark;
        public DateTime bidListDate;
        public string commentary;
        public string security;
        public string status;
        public string trader;
        public string book;
        public string creationName;
        public DateTime creationDate;
        public string revisionName;
        public DateTime revisionDate;
        public string dealName;
        public string dealType;
        public string sourceListId;
        public string side;

    }
}
