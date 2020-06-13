using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Paycompute.Services.Implementation
{
    public class TaxService : ITaxService
    {
        private decimal taxRate;
        private decimal tax;
        public decimal TaxAmount(decimal totalAmount)
        {
            if (totalAmount <= 9875)
            {
                //Tax rate 10%
                taxRate = .10m;
                tax = totalAmount * taxRate;
            }
            else if (totalAmount > 9875 && totalAmount <= 40125)
            {
                //Tax rate 12%
                taxRate = .12m;
                tax = (9875 * .10m) + ((totalAmount - 9875) * taxRate);
            }
            else if (totalAmount > 40125 && totalAmount <= 85525)
            {
                //Tax rate 22%
                taxRate = .22m;
                tax = (9875 * .10m) + ((40125 - 9875) * .12m) + ((totalAmount - 40125) * taxRate);
            }
            else if (totalAmount > 85525 && totalAmount <= 163300)
            {
                //Tax rate 24%
                taxRate = .24m;
                tax = (9875 * .10m) + ((40125 - 9875) * .12m) + ((85525 - 40125) * .22m) + ((totalAmount - 85525) * taxRate);
            }
            else if (totalAmount > 163300 && totalAmount <= 207350)
            {
                //Tax rate 32%
                taxRate = .32m;
                tax = (9875 * .10m) + ((40125 - 9875) * .12m) + ((85525 - 40125) * .22m) + ((163300 - 85525) * .24m) + ((totalAmount - 163300) * taxRate);
            }
            else if (totalAmount > 207350 && totalAmount <= 518400)
            {
                //Tax rate 35%
                taxRate = .35m;
                tax = (9875 * .10m) + ((40125 - 9875) * .12m) + ((85525 - 40125) * .22m) + ((163300 - 85525) * .24m) + ((207350 - 163300) * .32m) + ((totalAmount - 207350) * taxRate);
            }
            else if (totalAmount > 518400)
            {
                //Tax rate 37%
                taxRate = .37m;
                tax = (9875 * .10m) + ((40125 - 9875) * .12m) + ((85525 - 40125) * .22m) + ((163300 - 85525) * .24m) + ((207350 - 163300) * .32m) + ((518400 - 207350) * .35m) + ((totalAmount - 518400) * taxRate);
            }
            return tax;
        }
    }
}
