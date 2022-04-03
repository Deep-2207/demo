using System;
using System.Collections.Generic;

#nullable disable

namespace KendoUiPractice.Models
{
    public partial class ContactWiseContactCategory
    {
        public int ContactWiseContactCategoryId { get; set; }
        public int? ContactId { get; set; }
        public int? ContactCategoryId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual ContactCategory ContactCategory { get; set; }
    }
}
