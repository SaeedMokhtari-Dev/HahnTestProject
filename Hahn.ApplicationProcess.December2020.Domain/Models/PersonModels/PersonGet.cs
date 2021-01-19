using System;

namespace Hahn.ApplicationProcess.December2020.Domain.Models.PersonModels
{
    public class PersonGet: PersonModel
    {
        public int Id { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}