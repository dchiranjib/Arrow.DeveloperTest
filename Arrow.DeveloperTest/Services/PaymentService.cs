using Arrow.DeveloperTest.Data;
using Arrow.DeveloperTest.Factory;
using Arrow.DeveloperTest.Types;
using Arrow.DeveloperTest.Utilities;
using System.Configuration;

namespace Arrow.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private IAccountDataStore _accountDataStore;
        private MakePaymentResult _makePaymentResult;

        public PaymentService(IAccountDataStore accountDataStore, MakePaymentResult makePaymentResult)
        {
            _accountDataStore = accountDataStore;
            _makePaymentResult = makePaymentResult;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            Account account = _accountDataStore.GetAccount(request.DebtorAccountNumber);

            MakePaymentFactory makePaymentFactory = new MakePaymentFactory();
            PaymentHelper paymentHelper = makePaymentFactory.GetPayment(request);
            _makePaymentResult.Success = paymentHelper.PaymentSuccess(account) && paymentHelper.CheckAmount(account, request.Amount);

            if (_makePaymentResult.Success)
            {
                account.Balance -= request.Amount;

                _accountDataStore.UpdateAccount(account);
            }

            return _makePaymentResult;
        }
    }
}
