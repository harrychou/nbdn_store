namespace nothinbutdotnetstore.web.infrastructure
{
    public interface Request
    {
        string action_name { get; set; }
    }

    public interface Request<InputModel> : Request
    {
        InputModel model { get; set; }
    }

}