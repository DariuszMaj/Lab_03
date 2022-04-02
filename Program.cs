using System;
using Lab_03.Logger;
namespace Lab_03
{
    public class Program
    {
        public static void Main()
        {
            string host = "google.com";
            int port = 80;

            using (ClientSocket clientSocket = new ClientSocket(host, port))
            {
                // request:

                string requestText = "Message to sent ...";
                byte[] requestBytes = Encoding.UTF8.GetBytes(requestText);

                clientSocket.Send(requestBytes);

                // response:

                byte[] responseBuffer = new byte[1024];
                int responseSize = clientSocket.Receive(responseBuffer);

                string responseText = Encoding.UTF8.GetString(responseBuffer, 0, responseSize); // received message

                // ...

                // cleaning:

                clientSocket.Close();
            }
        }
    }
}
