using System;

namespace Hahn.ApplicationProcess.December2020.Domain.Models.PersonModels
{
    public class PersonModel
    {
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string Address { get; set; }
        
        public string CountryOfOrigin { get; set; }

        public string EMailAddress  { get; set; }

        public int Age { get; set; }
        
        public bool Hired { get; set; }
    }
}