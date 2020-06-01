using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace producer
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            // If serializers are not specified, default serializers from
            // `Confluent.Kafka.Serializers` will be automatically used where
            // available. Note: by default strings are encoded as UTF8.
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                string message = String.Empty;
                Console.WriteLine("Write message content");

                do
                {
                    message = Console.ReadLine();

                    if (message == "x") continue;

                    try
                    {
                        var dr = await p.ProduceAsync("my-topic", new Message<Null, string> { Value = message });
                        Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                    }
                    catch (ProduceException<Null, string> e)
                    {
                        Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                    }

                } while (message != "x");

                Console.ReadLine();
            }
        }
    }
}
