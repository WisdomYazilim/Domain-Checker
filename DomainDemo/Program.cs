using System;
using System.Threading;

namespace DomainDemo
{
    class Program
    {
        public Program()
        {

        }
        static void Main(string[] args)
        {
            var domainService = new DomainService();

            var responseBool = domainService.IsDomainUsing("sistempatent.com.tr");
            Thread.Sleep(3000);

            var responseDetail = domainService.DomainUsingDetail("sistempatent.com.tr");
            Thread.Sleep(3000);

            var responseSuggestions = domainService.GetDomainSuggestions("sistempatent.com.tr", 0);


            Console.ReadLine();
        }
    }
}
