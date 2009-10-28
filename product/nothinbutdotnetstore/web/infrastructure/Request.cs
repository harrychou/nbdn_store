namespace nothinbutdotnetstore.web.infrastructure
{
    public interface Request 
    {
        InputModel map<InputModel>();
        string action_name { get; set; }
    }

}