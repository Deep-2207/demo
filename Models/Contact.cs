using System;
using System.Collections.Generic;

#nullable disable

namespace KendoUiPractice.Models
{
    public partial class Contact
    {
        public Contact()
        {
            ContactWiseContactCategories = new HashSet<ContactWiseContactCategory>();
        }

        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Profession { get; set; }
        public int? BloodGroupId { get; set; }

        public virtual BloodGroup BloodGroup { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<ContactWiseContactCategory> ContactWiseContactCategories { get; set; }
    }
}
