﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Domain.Models
{
    public class Product
    {
        [Key] //VS will automatically set Id names proprty to PK but if you need a different firld to be PK this is needed
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   //This will not work
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}
