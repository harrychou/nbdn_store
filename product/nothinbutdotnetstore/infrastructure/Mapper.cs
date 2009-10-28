namespace nothinbutdotnetstore.infrastructure
{
    public interface Mapper<Input, Output> 
    {
        Output map(Input obj);
    }
}