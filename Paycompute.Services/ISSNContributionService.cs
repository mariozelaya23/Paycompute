using System;
using System.Collections.Generic;
using System.Text;

namespace Paycompute.Services
{
    public interface ISSNContributionService
    {
        decimal SSNContribution(decimal totalAmount);
    }
}
