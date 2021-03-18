namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_State
    {
        [Key]
        public int StateId { get; set; }

        [StringLength(150)]
        public string StateName { get; set; }

        [StringLength(10)]
        public string StateCode { get; set; }

        public int? CountryId { get; set; }

        public bool? Active { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual M_Country M_Country { get; set; }
    }
}
