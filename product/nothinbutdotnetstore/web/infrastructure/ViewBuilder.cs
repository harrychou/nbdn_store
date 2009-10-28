namespace nothinbutdotnetstore.web.infrastructure
{
    public interface ViewBuilder 
    {
        ViewForModel<ViewModel> build_view<ViewModel>(ViewModel model);
    }
}