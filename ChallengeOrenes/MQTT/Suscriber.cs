using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using ChallengeOrenes.DTO;
using System;
using System.Text;




namespace ChallengeOrenes.MQTT
{
    public class Suscriber
    {
        private IMqttClient client;

        public Suscriber()
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

            client.UseConnectedHandler(async e =>
            {
                Console.WriteLine("Suscriber connected to the broker successfully");

                var topicFilter = new MqttTopicFilterBuilder()
                .WithTopic("newLocation")
                .Build();

                await client.SubscribeAsync(topicFilter);
            });

            client.UseApplicationMessageReceivedHandler(e =>
            {
                Console.WriteLine("NEW MESSAGE");
                var msg = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                string[] splitted = msg.Split(',');

                LocationDTO location = new LocationDTO
                {
                    coordX = Convert.ToInt32(splitted[0]),
                    coordY = Convert.ToInt32(splitted[1]),
                    vehicleId = Convert.ToInt32(splitted[2]),
                };

                Console.WriteLine(location.ToString());
                
            });

            client.UseDisconnectedHandler(e =>
            {
                Console.WriteLine("Suscriber disconnected from the broker successfully");
            });

            await client.ConnectAsync(options);

        }
    }
}
