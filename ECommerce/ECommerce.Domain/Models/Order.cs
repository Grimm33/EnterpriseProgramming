using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Domain.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public virtual Member Member { get; set; }

        [ForeignKey("Member")]
        public string MemberEmail { get; set; }

    }
}
