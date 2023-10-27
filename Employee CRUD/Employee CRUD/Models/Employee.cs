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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "*Required")]
        [StringLength(50)]
        [Display(Name="Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "*Required")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "The Employee National ID must be 14 Digit")]
        [RegularExpression(@"[2-3][0-9]+", ErrorMessage = "The Employee National ID must start with 2 OR 3")]
        [Display(Name = "National ID")]
        public string national_id { get; set; }

        [Required(ErrorMessage = "*Required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "The Employee Phone Number must be 11 Digit")]
        [RegularExpression(@"[0][1][0][0-9]+", ErrorMessage = "The Employee Phone Number must start with 010")]
        [Display(Name = "Phone Number")]
        public string phone_number { get; set; }

        [Required(ErrorMessage = "*Required")]
        [Range(18, 60, ErrorMessage = "The Employee Age must be between 18 and 60")]
        [Display(Name = "Age")]
        public int age { get; set; }

        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Salary")]
        public double salary { get; set; }

        [Display(Name = "Is married")]
        public bool married { get; set; }

        [Display(Name = "Government")]
        public int? gov_id { get; set; }

        [Display(Name = "Department")]
        public int? dept_id { get; set; }

        [Display(Name = "Village")]
        public int? village_id { get; set; }

        public virtual Department Department { get; set; }

        public virtual Government Government { get; set; }

        public virtual village village { get; set; }
    }
}
