using System;
using System.Collections.Generic;

#nullable disable

namespace KendoUiPractice.Models
{
    public partial class BloodGroup
    {
        public BloodGroup()
        {
            Contacts = new HashSet<Contact>();
        }

        public int BloodGroupId { get; set; }
        public string BloodGroupName { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
