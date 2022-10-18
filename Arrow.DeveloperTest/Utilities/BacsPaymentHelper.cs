using Arrow.DeveloperTest.Types;

namespace Arrow.DeveloperTest.Utilities
{
    public class BacsPaymentHelper : PaymentHelper
    {

        public override bool PaymentSuccess(Account account)
        {
            if (account == null || !account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
                return false;
            return true;
        }
        public override bool CheckAmount(Account account, decimal amount)
        {
            return true;
        }
    }
}
