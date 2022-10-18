using Arrow.DeveloperTest.Types;

namespace Arrow.DeveloperTest.Utilities
{
    public abstract class PaymentHelper
    {
        public abstract bool PaymentSuccess(Account account);

        public abstract bool CheckAmount(Account account, decimal amount);
    }
}
