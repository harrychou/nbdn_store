namespace nothinbutdotnetstore.web.infrastructure
{
    public interface Mapper<Input, Output> 
    {
        Output map(Input obj);
    }
}