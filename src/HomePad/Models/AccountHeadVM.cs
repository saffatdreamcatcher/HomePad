namespace HomePad.Models
{
    public class AccountHeadVM
    {
        public AccountHeadVM(int id)
        {
            Id = id;
        }

        public AccountHeadVM()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
