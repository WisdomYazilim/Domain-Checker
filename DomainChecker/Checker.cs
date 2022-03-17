using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainChecker.Models;
using RestSharp;

namespace DomainChecker
{
    public class Checker
    {
        private readonly RestClient _client;
        private const string MainUri = "https://www.domainnameapi.com";
        private const string SingleDomainSearchUri = "/SingleDomainSearch";
        private const string DomainSearchSuggestionUri = "/DomainSearchSuggestion";
        private RestRequest _restRequest;
        public Checker()
        {
            _client = new RestClient();
            _client.BaseUrl = new Uri(MainUri);
            CreateCookies();
        }
        private void CreateCookies()
        {
            _restRequest = new RestRequest(Method.GET);
            _client.Get(_restRequest);
        }
        /// <summary>
        /// Domainin kullanılıp kullanılmadığının bilgisini döndürür
        /// </summary>
        /// <param name="domain">örnek : ornek.com.tr</param>
        /// <returns></returns>
        public bool IsDomainUsing(string domain)
        {
            if (string.IsNullOrEmpty(domain))
                throw new Exception("Domain boş bırakılamaz");

            _restRequest = new RestRequest(Method.POST);
            _restRequest.RestRequestPrepare(SingleDomainSearchUri);
            _restRequest.AddJsonBody(new SingleDomainInputModel()
            {
                DomainName = domain
            });
            var response = _client.Post<SingleDomainResponseModel>(_restRequest);
            if (response.Content is "The page was not displayed because there was a conflict.")
                throw new Exception("Bu kadar sık istek gönderemezsin");
            if (response.Data.MainDomain.StatusInfo is "NOTAVAILABLE")
                return true;
            else
                return false;
        }
        /// <summary>
        /// Domainin kullanılıp kullanılmadığının bilgisinin yanında ek olarak domain ile alakalı bilgiler verir.
        /// </summary>
        /// <param name="domain">örnek : ornek.com.tr</param>
        /// <returns></returns>
        public DomainResponse DomainUsingDetail(string domain)
        {
            if (string.IsNullOrEmpty(domain))
                throw new Exception("Domain boş bırakılamaz");

            _restRequest = new RestRequest(Method.POST);
            _restRequest.RestRequestPrepare(SingleDomainSearchUri);
            _restRequest.AddJsonBody(new SingleDomainInputModel()
            {
                DomainName = domain
            });
            var response = _client.Post<SingleDomainResponseModel>(_restRequest);
            if (response.Content is "The page was not displayed because there was a conflict.")
                throw new Exception("Bu kadar sık istek gönderemezsin");
            return response.Data.MainDomain.DomainResponseMapper();
        }
        /// <summary>
        /// Domain'in diğer tld'lerdeki kullanılabilirlik durumunu verir.
        /// </summary>
        /// <param name="domain">örnek : ornek.com.tr</param>
        /// <param name="pageNumber">başlangıç değeri 0'dır pagination amacı ile kullanılmaktadır.</param>
        /// <returns></returns>
        public IEnumerable<DomainResponse> GetDomainSuggestions(string domain, int pageNumber)
        {
            if (string.IsNullOrEmpty(domain))
                throw new Exception("Domain boş bırakılamaz");

            pageNumber = pageNumber < 0 ? 0 : pageNumber;
            _restRequest = new RestRequest(Method.POST);
            _restRequest.RestRequestPrepare(DomainSearchSuggestionUri);
            _restRequest.AddJsonBody(new DomainSuggestionInputModel()
            {
                DomainName = domain,
                Page = pageNumber
            });
            var response = _client.Post<DomainSuggestionResponseModel>(_restRequest);
            if (response.Content is "The page was not displayed because there was a conflict.")
                throw new Exception("Bu kadar sık istek gönderemezsin");
            return response.Data.Domains.DomainResponseMapper();

        }
    }
}
