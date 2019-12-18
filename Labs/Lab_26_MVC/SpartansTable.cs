namespace Lab_26_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpartansTable")]
    public partial class SpartansTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SpartaId { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string University { get; set; }
    }
}
