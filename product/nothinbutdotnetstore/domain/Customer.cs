using nothinbutdotnetstore.infrastructure.validation;

namespace nothinbutdotnetstore.domain
{
    public class Customer
    {
        [RequiredField]
        public string first_name { get; set; }

        [RequiredField]
        public string last_name { get; set; }

        [RequiredField]
        public string email_address { get; set; }

        [RequiredField]
        public Address Address { get; set; }
    }
}