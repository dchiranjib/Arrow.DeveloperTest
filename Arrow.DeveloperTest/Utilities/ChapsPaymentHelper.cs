using Arrow.DeveloperTest.Types;

namespace Arrow.DeveloperTest.Utilities
{
    public class ChapsPaymentHelper : PaymentHelper
    {
        public override bool PaymentSuccess(Account account)
        {
            if (account == null || !account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps) || account.Status != AccountStatus.Live)
                return false;
            return true;
        }
        public override bool CheckAmount(Account account, decimal amount)
        {
            return true;
        }
    }
}
