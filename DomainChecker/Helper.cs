using DomainChecker.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainChecker
{
   public static class Helper
    {
    
        public static DomainResponse DomainResponseMapper(this MainDomainResponseModel mainDomainResponseModel)
        {
            return new DomainResponse()
            {
                CurrencyCode = mainDomainResponseModel.CurrencyCode,
                DomainName = mainDomainResponseModel.DomainName,
                Idn = mainDomainResponseModel.Idn,
                IsDocumentRequired = mainDomainResponseModel.IsDocumentRequired,
                IsPremium = mainDomainResponseModel.IsPremium,
                Price = mainDomainResponseModel.Price,
                Tld = mainDomainResponseModel.Tld,
                StatusInfo = mainDomainResponseModel.StatusInfo is "AVAILABLE" ? DomainStatus.Available : mainDomainResponseModel.StatusInfo is "NOTAVAILABLE" ? DomainStatus.NotAvailable : DomainStatus.Unknown
            };
        }
        public static IEnumerable<DomainResponse> DomainResponseMapper(this IEnumerable<MainDomainResponseModel> mainDomainResponseModels)
        {
            List<DomainResponse> responses = new List<DomainResponse>();
            foreach(var item in mainDomainResponseModels)
            {
                responses.Add(item.DomainResponseMapper());
            }
            return responses;
        }
        public static RestRequest RestRequestPrepare(this RestRequest restRequest,string endpoint)
        {
            restRequest.AddHeader("authority", "www.domainnameapi.com");
            restRequest.AddHeader("method", "POST");
            restRequest.AddHeader("scheme", "https");
            restRequest.AddHeader("languagebypass", "true");
            restRequest.AddHeader("origin", "https://www.domainnameapi.com");
            restRequest.AddHeader("refereer", "https://www.domainnameapi.com/domain-search");
            restRequest.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.104 Safari/537.36");
            restRequest.AddHeader("path", endpoint);
            restRequest.Resource = endpoint;
            return restRequest;
        }
    }
}
