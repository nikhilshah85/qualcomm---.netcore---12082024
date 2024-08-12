namespace WebAPI_DIDemo
{
    public class Bankaccountinfo
    {
        public int AccNo { get; set; }
        public string AccName { get; set; }
        public string Acctype { get; set; }
        public double AccBalance { get; set; }
        public string AccBranch { get; set; }
        public bool AccIsActive { get; set; }


        // Static list to act as in-memory storage
        public static List<Bankaccountinfo> Accounts = new List<Bankaccountinfo>();

        // Method to add a new account (Create)
        public static void AddAccount(Bankaccountinfo account)
        {
            Accounts.Add(account);
        }

        // Method to get all accounts (Read)
        public static List<Bankaccountinfo> GetAllAccounts()
        {
            return Accounts;
        }

        // Method to update an account (Update)
        public static void UpdateAccount(int accountNo, Bankaccountinfo account)
        {
            var index = Accounts.FindIndex(a => a.AccNo == accountNo);
            if (index != -1)
            {
                Accounts[index] = account;
            }
        }

        // Method to delete an account (Delete)
        public static void DeleteAccount(int accountNo)
        {
            var account = Accounts.Find(b => b.AccNo == accountNo);
            if (account != null)
            {
                Accounts.Remove(account);
            }
        }
    }
}
