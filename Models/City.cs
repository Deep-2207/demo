using System;
using System.Collections.Generic;

#nullable disable

namespace KendoUiPractice.Models
{
    public partial class City
    {
        public City()
        {
            Contacts = new HashSet<Contact>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Pincode { get; set; }
        public string Stdcode { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
