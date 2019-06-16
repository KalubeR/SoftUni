using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string NewLine = "\r\n";

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);

            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] requestBytes = new byte[100000];
                    int readBytes = stream.Read(requestBytes, 0, requestBytes.Length);

                    var stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes);

                    Console.WriteLine(new string('=', 70));
                    Console.WriteLine(stringRequest);

                    string responseBody = "<form method='post'><input type='text' name='tweet' placeholder='Enter tweet..' /><input name='name' /><input type='submit' /></form>";
                    string response = "HTTP/1.0 200 OK" + NewLine +
                                      "Content-Type : text/html" + NewLine +
                                      //"Location : https://google.com" + NewLine +
                                      "Server: MyCustomServer/1.0" + NewLine +
                                      //"Content-Disposition: attachment; filename=index.html" + NewLine +
                                      $"Content-Length: {responseBody.Length}" + NewLine + NewLine +
                                      responseBody;

                    var responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
        }
    }
}