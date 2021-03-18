namespace OnlineShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_StatusHistory
    {
        [Key]
        public long StatusHistoryId { get; set; }

        public int StatusId { get; set; }

        public long OrderId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual M_Status M_Status { get; set; }

        public virtual T_Order T_Order { get; set; }
    }
}
