namespace CodeSamurai.API.Models
{
    public class WalletModel
    {
        public int Wallet_Id { get; set; }

        public int Balance { get; set; }

        public WalletUserModel Wallet_User { get; set; }
    }

    public class WalletUserModel
    {
        public int User_id { get; set; }
        public string? User_name { get; set; }
    }
}
