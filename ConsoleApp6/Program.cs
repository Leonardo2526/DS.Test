using SimpleInjector;

// Registrations
var container = new Container();

container.Collection.Append<ILogger, MyLogger>(Lifestyle.Singleton);
//container.Register<ListConsumer>(Lifestyle.Singleton);
container.Register<Consumer>(Lifestyle.Singleton);

container.Verify();

Console.WriteLine("Verified successfully!");
Console.ReadLine();