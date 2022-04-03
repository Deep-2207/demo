using System;
using System.Collections.Generic;

#nullable disable

namespace KendoUiPractice.Models
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
            Contacts = new HashSet<Contact>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
