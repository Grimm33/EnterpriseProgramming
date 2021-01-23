using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Domain.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public virtual Member Member { get; set; }

        [ForeignKey("Member")]
        public string MemberEmail { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
