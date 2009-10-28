namespace nothinbutdotnetstore.web.infrastructure
{
    public interface Result
    {
        void render();
        object data { get; set; }
    }
}