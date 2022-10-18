using Arrow.DeveloperTest.Types;
using Arrow.DeveloperTest.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Factory
{
    public class MakePaymentFactory
    {
        public PaymentHelper GetPayment(MakePaymentRequest request)
        {
            PaymentHelper result = null;
            switch (request.PaymentScheme)
            {
                case PaymentScheme.Bacs:
                    result = new BacsPaymentHelper();
                    break;

                case PaymentScheme.FasterPayments:
                    result = new FasterPaymentHelper();
                    break;

                case PaymentScheme.Chaps:
                    result = new ChapsPaymentHelper();
                    break;
            }
            return result;
        }
    }
}
