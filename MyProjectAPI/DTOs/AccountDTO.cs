namespace MyProjectAPI.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal InitialCredit { get; set; }
        public int UserID { get; set; }
    }
}
