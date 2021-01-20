using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hahn.ApplicationProcess.December2020.Data.Entities.Base;

namespace Hahn.ApplicationProcess.December2020.Data.Entities
{
    [Table("Employee")]
    public class Employee: EntityBase
    {
        
        [Required]
        [MinLength(5, ErrorMessage = "{0} must be larger than {1} character")]
        [MaxLength(50, ErrorMessage = "{0} must be smaller than {1} character")]
        public string Name { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "{0} must be larger than {1} character")]
        [MaxLength(50, ErrorMessage = "{0} must be smaller than {1} character")]
        public string FamilyName { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "{0} must be larger than {1} character")]
        [MaxLength(500, ErrorMessage = "{0} must be smaller than {1} character")]
        public string Address { get; set; }
        
        [Required]
        [MaxLength(500, ErrorMessage = "{0} must be smaller than {1} character")]
        public string CountryOfOrigin { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "{0} must be smaller than {1} character")]
        [EmailAddress]
        public string EMailAddress  { get; set; }

        [Required]
        public int Age { get; set; }
        
        [Required]
        public bool Hired { get; set; }
    }
}