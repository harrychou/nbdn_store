namespace nothinbutdotnetstore.domain
{
    public class Address
    {
        public string street { get; set; }
        public City city { get; set; }
        public State state { get; set; }
        public string zip_code { get; set; }
    }
}