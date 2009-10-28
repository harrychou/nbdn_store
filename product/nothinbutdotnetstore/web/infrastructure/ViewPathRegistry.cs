namespace nothinbutdotnetstore.web.infrastructure
{
    public interface ViewPathRegistry
    {
        string get_path_for_view_that_can_render<ViewModel>();
    }
}