using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMoq1
{
    public interface ICreditDecisionService
    {
        string GetCreditDecision(int creditscore);
    }
}
