using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMoq1
{
   public class CreditDecision
    {
        //actual implementation where the creditscore status is returned by a service
        //the external dependency is not supported in unit testing
        //public string MakeCreditDecision(int creditScore)
        //{
        //    var service = new CreditDecisionService();
        //    return service.GetCreditDecision(creditScore);
        //}

        ICreditDecisionService creditDecisionService;
        public CreditDecision(ICreditDecisionService creditDecisionService)
        {
            this.creditDecisionService = creditDecisionService;
        }
        public string MakeCreditDecision(int creditScore)
        {
            return creditDecisionService.GetCreditDecision(creditScore);
        }

    }
}
