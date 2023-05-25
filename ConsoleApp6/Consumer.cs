internal class Consumer
{
    private readonly IEnumerable<ILogger> loggers;
    public Consumer(IEnumerable<ILogger> loggers)
    {
        // Calling ToArray will cause the warning
        this.loggers = loggers;
        //this.loggers = loggers.ToArray();
    }
}

internal class ListConsumer
{
    private readonly List<ILogger> loggers;

    public ListConsumer(List<ILogger> loggers)
    {
        // Calling ToArray will cause the warning
        this.loggers = loggers;
    }
}

internal class ListConsumerByBase
{
    private readonly List<MyLoggerBase> loggers;

    public ListConsumerByBase(List<MyLoggerBase> loggers)
    {
        // Calling ToArray will cause the warning
        this.loggers = loggers;
    }
}



internal abstract class ConsumerBase
{

}
