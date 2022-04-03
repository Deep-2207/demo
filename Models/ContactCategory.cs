using System;
using System.Collections.Generic;

#nullable disable

namespace KendoUiPractice.Models
{
    public partial class ContactCategory
    {
        public ContactCategory()
        {
            ContactWiseContactCategories = new HashSet<ContactWiseContactCategory>();
        }

        public int ContactCategoryId { get; set; }
        public string ContactCategoryName { get; set; }

        public virtual ICollection<ContactWiseContactCategory> ContactWiseContactCategories { get; set; }
    }
}
