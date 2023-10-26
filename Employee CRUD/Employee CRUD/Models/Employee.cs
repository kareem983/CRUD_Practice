namespace Employee_CRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(14)]
        public string national_id { get; set; }

        [Required]
        [StringLength(11)]
        public string phone_number { get; set; }

        public int age { get; set; }

        public double salary { get; set; }

        public bool married { get; set; }

        public int? gov_id { get; set; }

        public int? dept_id { get; set; }

        public int? village_id { get; set; }

        public virtual Department Department { get; set; }

        public virtual Government Government { get; set; }

        public virtual village village { get; set; }
    }
}
