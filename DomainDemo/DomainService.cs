using DomainChecker;
using DomainChecker.Models;
using System.Collections.Generic;

namespace DomainDemo
{
    public class DomainService
    {
        private readonly Checker _domainChecker;
        public DomainService()
        {
            _domainChecker = new Checker();
        }
        public bool IsDomainUsing(string domain)
        {
            return _domainChecker.IsDomainUsing(domain);
        }
        public DomainResponse DomainUsingDetail(string domain)
        {
            return _domainChecker.DomainUsingDetail(domain);
        }
        public IEnumerable<DomainResponse> GetDomainSuggestions(string domain, int pageNumber)
        {
            return _domainChecker.GetDomainSuggestions(domain, pageNumber);
        }

    }
}
