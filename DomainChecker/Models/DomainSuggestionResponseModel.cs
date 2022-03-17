using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainChecker.Models
{
    public class DomainSuggestionResponseModel
    {
        public bool Success { get; set; }
        public object Message { get; set; }
        public List<MainDomainResponseModel> Domains { get; set; }
        public object MainDomain { get; set; }
    }
}
