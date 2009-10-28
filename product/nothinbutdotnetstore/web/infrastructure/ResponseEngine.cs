namespace nothinbutdotnetstore.web.infrastructure
{
    public interface ResponseEngine
    {
        void display<ViewModel>(ViewModel details);
    }
}