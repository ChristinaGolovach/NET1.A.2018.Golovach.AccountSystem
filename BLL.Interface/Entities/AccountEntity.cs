namespace BLL.Interface.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public int BonusPoints { get; set; }
        public bool IsOponed { get; set; }
        public OwnerEntity Owner { get; set; }
        public AccountTypeEntity AccountType { get; set; }
    }
}
