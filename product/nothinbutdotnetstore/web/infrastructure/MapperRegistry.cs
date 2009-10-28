using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface MapperRegistry {
        Mapper<Input, Output> get_mapper<Input, Output>(); 
    }
}