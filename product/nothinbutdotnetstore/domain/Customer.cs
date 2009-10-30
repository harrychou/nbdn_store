namespace nothinbutdotnetstore.domain
{
    public class Customer
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email_address { get; set; }
        public Address Address { get; set; }
    }
}