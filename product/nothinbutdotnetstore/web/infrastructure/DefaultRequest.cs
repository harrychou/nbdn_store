namespace nothinbutdotnetstore.web.infrastructure
{
    public class DefaultRequest : Request
    {
        MapperRegistry mapper_registry;

        public DefaultRequest(MapperRegistry mapper_registry)
        {
            this.mapper_registry = mapper_registry;
        }

        public InputModel map<InputModel>()
        {
            var mapper = mapper_registry.get_mapper<Request, InputModel>();
            return mapper.map(this);
        }
    }
}