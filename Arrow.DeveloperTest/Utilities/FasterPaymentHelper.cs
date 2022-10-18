using Arrow.DeveloperTest.Types;

namespace Arrow.DeveloperTest.Utilities
{
    public class FasterPaymentHelper : PaymentHelper
    {

        public override bool PaymentSuccess(Account account)
        {
            if (account == null || !account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
                return false;
            return true;
        }
        public override bool CheckAmount(Account account, decimal amount)
        {
            if (account.Balance < amount)
                return false;
            return true;
        }
    }
}
