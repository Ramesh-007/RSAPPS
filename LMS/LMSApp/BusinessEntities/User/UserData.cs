namespace BusinessEntities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public int IsLead { get; set; }
        public int IsManager { get; set; }
        public int IsAdmin { get; set; }
    }
}