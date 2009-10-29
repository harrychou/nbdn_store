using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class ActivatorCreationException : Exception
    {
        public ActivatorCreationException(Exception inner_exception, Type type_that_could_not_be_created):base(String.Empty,inner_exception)
        {
            this.type_that_could_not_be_created = type_that_could_not_be_created; 
        }

        public Type type_that_could_not_be_created { get; private set; }
    }
}