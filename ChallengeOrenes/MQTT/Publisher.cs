using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using ChallengeOrenes.DTO;

namespace ChallengeOrenes.MQTT
{
    public class Publisher
    {

        private IMqttClient client;

        public Publisher()
        {
            var mqttFactory = new MqttFactory();
            this.client = mqttFactory.CreateMqttClient();
        }

        public async Task Connect()
        {
         
            var options = new MqttClientOptionsBuilder()
                                .WithClientId(Guid.NewGuid().ToString())
                                .WithTcpServer("test.mosquitto.org", 1883)
                                .WithCleanSession()
                                .Build();

            client.UseConnectedHandler(e =>
            {
                Console.WriteLine("Publisher connected to the broker successfully");

            });

            client.UseDisconnectedHandler(e =>
            {
                Console.WriteLine("Publisher disconnected from the broker successfully");
            });

            await client.ConnectAsync(options);

        }

        public async Task PublishMessageAsync(LocationDTO newLocation)
        {
            
            var locationMessage = new MqttApplicationMessageBuilder()
                .WithTopic("newLocation")
                .WithPayload(newLocation.ToString())
                .WithAtLeastOnceQoS()
                .Build();

            if (client.IsConnected)
            {
                await client.PublishAsync(locationMessage);
                await client.DisconnectAsync();
            }


        }
    }

    

    
}
