namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_Employee
    {
        [Key]
        public long EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(12)]
        public string Mobile { get; set; }

        public string Address { get; set; }

        public bool? Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
