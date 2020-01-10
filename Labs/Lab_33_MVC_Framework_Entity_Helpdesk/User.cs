namespace Lab_33_MVC_Framework_Entity_Helpdesk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string UserAddress { get; set; }

        public int? CategoryID { get; set; }

        public string NewField { get; set; }

        public virtual Category Category { get; set; }
    }
}
