using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client =  new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "Client" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Enter First Number: ");
            double num1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Second Number: ");
            double num2 = Double.Parse(Console.ReadLine()); 
            var result = await client.AddNumbersAsync(new AddRequest{Num1=num1,Num2=num2});
            Console.WriteLine("Result: "+result.Result);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}