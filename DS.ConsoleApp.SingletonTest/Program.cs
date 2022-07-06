using DS.ConsoleApp.SingletonTest;

StaticModel staticModel = StaticModel.Create(new CancellationTokenSource());
Console.WriteLine(StaticModel.TotalCancelSource.Token.CanBeCanceled);
