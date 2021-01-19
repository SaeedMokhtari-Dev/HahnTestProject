using System;
using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicationProcess.December2020.Data.Entities.Base
{
    public class EntityBase: IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdated { get; set; }
        
    }
}