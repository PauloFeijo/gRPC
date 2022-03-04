using Grpc.Net.Client;
using GrpcServiceBusinessDay;
using System.Diagnostics;
using GrpcServiceGreet;

using var channel = GrpcChannel.ForAddress("https://localhost:7267");

Console.Write("Type your name: ");
var name = Console.ReadLine();

var clientGreet = new Greeter.GreeterClient(channel);
var replyGreet = await clientGreet.SayHelloAsync(new HelloRequest() { Name = name });
Console.WriteLine($"Greetings: {replyGreet.Message}");

Console.WriteLine("Press any key to continue");
Console.ReadLine();

var clientBusinessDay = new BusinessDay.BusinessDayClient(channel);

var watch = new Stopwatch();
watch.Start();

for (int i = 0; i < 10_000; i++)
{
    var reply = await clientBusinessDay.GetNowAsync(new EmptyRequest());
    Console.WriteLine($"[{i}] Now is: {reply.Time}");
}

watch.Stop();
var time = watch.Elapsed;

Console.WriteLine($"Elapsed time: {time}");


