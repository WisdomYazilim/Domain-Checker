using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainChecker.Models
{
    public class MainDomainResponseModel
    {
        public string DomainName { get; set; }
        public string Idn { get; set; }
        public string Tld { get; set; }
        public object TldGroup { get; set; }
        public int StatusCode { get; set; }
        public string StatusInfo { get; set; }
        public object OriginalPrice { get; set; }
        public string Price { get; set; }
        public string CurrencyCode { get; set; }
        public bool HasIdnSupport { get; set; }
        public bool HasTrusteeSupport { get; set; }
        public bool IsDocumentRequired { get; set; }
        public bool IsPremium { get; set; }
        public bool IsGift { get; set; }
        public bool IsInCart { get; set; }
    }
}
