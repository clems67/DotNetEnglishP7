using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data
{
    public class BidModel
    {
        [Key]
        public int Id { get; set; }
        public string account { get; set; }
        public String type { get; set; }
        public Double bidQuantity { get; set; }
        public Double askQuantity { get; set; }
        public Double bid { get; set; }
        public Double ask { get; set; }
        public String benchmark;
        public DateTime bidListDate;
        public String commentary;
        public String security;
        public String status;
        public String trader;
        public String book;
        public String creationName;
        public DateTime creationDate;
        public String revisionName;
        public DateTime revisionDate;
        public String dealName;
        public String dealType;
        public String sourceListId;
        public String side;

    }
}
