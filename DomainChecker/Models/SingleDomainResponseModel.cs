using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainChecker.Models
{
    public class SingleDomainResponseModel
    {
        public bool Success { get; set; }
        public object Message { get; set; }
        public MainDomainResponseModel MainDomain { get; set; }
        public object Domains { get; set; }

    }
}
