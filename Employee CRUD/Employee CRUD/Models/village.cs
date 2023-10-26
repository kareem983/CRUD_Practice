namespace Employee_CRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("village")]
    public partial class village
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public village()
        {
            Employees = new HashSet<Employee>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int? dept_id { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
