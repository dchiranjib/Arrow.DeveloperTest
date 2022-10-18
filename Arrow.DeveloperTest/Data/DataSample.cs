using Arrow.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Data
{
    public static class DataSample
    {
        public static List<Account> AccountDataList = new List<Account>()
        {
            new Account(){AccountNumber = "FASTAC00001", AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 1000, Status = AccountStatus.Live},
            new Account(){AccountNumber = "BACSAC00001", AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs, Balance = 2000, Status = AccountStatus.Live},
            new Account(){AccountNumber = "CHAPSAC00001", AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Balance = 3000, Status = AccountStatus.Live}
        };
    }
}
