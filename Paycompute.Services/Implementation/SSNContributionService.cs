using System;
using System.Collections.Generic;
using System.Text;

namespace Paycompute.Services.Implementation
{
    public class SSNContributionService : ISSNContributionService
    {
        private decimal SSNRate;
        private decimal SSNC;
        public decimal SSNContribution(decimal totalAmount)
        {
            if (totalAmount > 0)
            {
                SSNRate = .062m;
                SSNC = (totalAmount * SSNRate);
            }
            return SSNC;
        }
    }
}
