namespace Assignment.Model
{
    public class Contact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryEmail { get; set; }
        public ICollection<SecondaryEmail> SecondaryEmails { get; set; }
    }
}
