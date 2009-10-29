using System;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubMapperRegistry : MapperRegistry
    {
        public Mapper<Input, Output> get_mapper<Input, Output>()
        {
            return new StubMapper<Input, Output>();
        }
    }

    public class StubMapper<Input, Output> : Mapper<Input, Output>
    {
        public Output map(Input obj)
        {
            throw new NotImplementedException();
        }
    }
}