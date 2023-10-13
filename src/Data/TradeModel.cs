﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data
{
    public class TradeModel
    {
        [Key]
        public int Id { get; set; }
        public string account { get; set; }
        public string type { get; set; }
        public Double buyQuantity { get; set; }
        public Double sellQuantity { get; set; }
        public Double buyPrice { get; set; }
        public Double sellPrice { get; set; }
        public string benchmark { get; set; }
        public DateTime tradeDate { get; set; }
        public string security { get; set; }
        public string status { get; set; }
        public string trader { get; set; }
        public string book { get; set; }
        public string creationName { get; set; }
        public DateTime creationDate { get; set; }
        public string revisionName { get; set; }
        public DateTime revisionDate { get; set; }
        public string dealName { get; set; }
        public string dealType { get; set; }
        public string sourceListId { get; set; }
        public string side { get; set; }
    }
}
