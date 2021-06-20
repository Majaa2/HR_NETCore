using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class CompetitorLanguage
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
        public int? CompetitorId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Competitor Competitor { get; set; }
    }
}
