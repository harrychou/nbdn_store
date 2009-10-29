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

        class StubMapper<T, T1> : Mapper<T, T1>
        {
            public T1 map(T obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}