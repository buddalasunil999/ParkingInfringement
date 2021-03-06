﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingInfringement.API.Models
{
    [Table("infringement")]
    public class Infringement
    {
        [Key]
        public int Id { set; get; }
        public string BreachNo { set; get; }
        public string CarRegNo { set; get; }
        public string CarMake { set; get; }
        public string CarModel { set; get; }
        public int CustomerId { set; get; }
        [ForeignKey("CustomerId")]
        public Customer Customer { set; get; }
        public double OffenseAmount { set; get; }
        public int ParkingBuildingId { set; get; }
        [ForeignKey("ParkingBuildingId")]
        public ParkingBuilding ParkingBuilding { set; get; }
        public DateTime BreachDate { set; get; }
        public string TransactionId { set; get; }
        [ForeignKey("TransactionId")]
        public Transaction Transaction { set; get; }
        public string Photo { set; get; }
        public int OfficerId { set; get; }
        public string Comments { set; get; }
        public int OffenseId { set; get; }
        [ForeignKey("OffenseId")]
        public Offense Offense { set; get; }
    }
}

