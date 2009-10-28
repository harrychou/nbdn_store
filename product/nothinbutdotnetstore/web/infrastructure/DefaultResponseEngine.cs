namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultResponseEngine : ResponseEngine
    {
        ViewFactory renderer;
        TransferBehaviour transfer_behaviour;


        public DefaultResponseEngine(ViewFactory renderer, TransferBehaviour transfer_behaviour)
        {
            this.renderer = renderer;
            this.transfer_behaviour = transfer_behaviour;
        }

        public void display<ViewModel>(ViewModel model)
        {
            transfer_behaviour(renderer.create_view_for(model), true);
        }
    }
}