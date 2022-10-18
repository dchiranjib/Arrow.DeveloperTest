using Arrow.DeveloperTest.Data;
using Arrow.DeveloperTest.Services;
using Arrow.DeveloperTest.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arrow.DeveloperTest.Tests
{
    [TestClass]
    public class ArrowTests
    {
        private IAccountDataStore _accountDataStore;
        private MakePaymentResult _makePaymentResult;
        private IPaymentService _service;
        private MakePaymentRequest _request;

        [TestInitialize]
        public void Setup()
        {
            _accountDataStore = new AccountDataStore();
            _makePaymentResult = new MakePaymentResult();
            _service = new PaymentService(_accountDataStore, _makePaymentResult);
            _request = new MakePaymentRequest();
        }

        [TestMethod]
        public void MakeFastPayment()
        {
            _request.PaymentScheme = PaymentScheme.FasterPayments;
            _request.DebtorAccountNumber = "FASTAC00001";
            _request.Amount = 100;
            Account account = _accountDataStore.GetAccount(_request.DebtorAccountNumber);
            decimal previousBalance = account.Balance;

            _makePaymentResult = _service.MakePayment(_request);
            Assert.AreEqual(true, _makePaymentResult.Success);

            Assert.AreEqual(true, previousBalance - _request.Amount == account.Balance);
        }

        [TestMethod]
        public void MakeBacsPayment()
        {
            _request.PaymentScheme = PaymentScheme.Bacs;
            _request.DebtorAccountNumber = "BACSAC00001";
            _request.Amount = 100;
            Account account = _accountDataStore.GetAccount(_request.DebtorAccountNumber);
            decimal previousBalance = account.Balance;

            _makePaymentResult = _service.MakePayment(_request);
            Assert.AreEqual(true, _makePaymentResult.Success);

            Assert.AreEqual(true, previousBalance - _request.Amount == account.Balance);
        }

        [TestMethod]
        public void MakeChapsPayment()
        {
            _request.PaymentScheme = PaymentScheme.Chaps;
            _request.DebtorAccountNumber = "CHAPSAC00001";
            _request.Amount = 100;
            Account account = _accountDataStore.GetAccount(_request.DebtorAccountNumber);
            decimal previousBalance = account.Balance;

            _makePaymentResult = _service.MakePayment(_request);
            Assert.AreEqual(true, _makePaymentResult.Success);

            Assert.AreEqual(true, previousBalance - _request.Amount == account.Balance);
        }

        [TestMethod]
        public void MakeAnonymousPayment()
        {
            _request.PaymentScheme = PaymentScheme.Chaps;
            _request.DebtorAccountNumber = "BACSAC00001";
            _request.Amount = 100;
            Account account = _accountDataStore.GetAccount(_request.DebtorAccountNumber);
            decimal previousBalance = account.Balance;

            _makePaymentResult = _service.MakePayment(_request);
            Assert.AreEqual(false, _makePaymentResult.Success);

            Assert.AreEqual(false, previousBalance - _request.Amount == account.Balance);
        }
    }
}
