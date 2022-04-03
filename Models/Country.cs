using System;
using System.Collections.Generic;

#nullable disable

namespace KendoUiPractice.Models
{
    public partial class Country
    {
        public Country()
        {
            Contacts = new HashSet<Contact>();
            States = new HashSet<State>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
