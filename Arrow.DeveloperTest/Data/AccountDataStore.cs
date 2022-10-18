using Arrow.DeveloperTest.Types;
using System;
using System.Linq;

namespace Arrow.DeveloperTest.Data
{
    public class AccountDataStore: IAccountDataStore
    {
        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return DataSample.AccountDataList.Where(a => a.AccountNumber.Equals(accountNumber, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }

        public void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
            DataSample.AccountDataList.RemoveAt(DataSample.AccountDataList.FindIndex(a => a.AccountNumber.Equals(account.AccountNumber)));
            DataSample.AccountDataList.Add(account);
        }
    }
}
