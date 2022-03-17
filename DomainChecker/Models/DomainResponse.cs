using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainChecker.Models
{
   public class DomainResponse
    {
        public string DomainName { get; set; }
        public string Idn { get; set; }
        public string Tld { get; set; }
        public DomainStatus StatusInfo { get; set; }
        public string Price { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsDocumentRequired { get; set; }
        public bool IsPremium { get; set; }
    }
}
