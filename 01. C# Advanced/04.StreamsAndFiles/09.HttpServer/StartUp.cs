namespace _09.HttpServer
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;

    internal class StartUp
    {
        private const int Port = 8081;
        private static TcpListener Listener = new TcpListener(IPAddress.Any, Port);

        private static void Main()
        {
            Listener.Start();

            while (true)
            {
                Console.WriteLine($"Listening on port {Port}...{Environment.NewLine}");

                TcpClient tpcClient = Listener.AcceptTcpClient();

                using (StreamReader reader = new StreamReader(tpcClient.GetStream()))
                {
                    using (StreamWriter writer = new StreamWriter(tpcClient.GetStream()))
                    {
                        try
                        {
                            string request = reader.ReadLine();

                            Console.WriteLine(request);

                            string[] requestArgs = request.Split(' ');
                            string page = requestArgs[1];

                            if (page == "/")
                            {
                                writer.WriteLine($"HTTP/1.0 200 OK{Environment.NewLine}");

                                string html = "<!doctype html> " +
                                              "<html> " +
                                              "<head> " +
                                              "<title>Home Page</title> " +
                                              "</head> " +
                                              "<body> " +
                                              "<h1>Welcome to our test page.</h1> <h4>You can check the server information <a href=\"/info\">here</a></h4>" +
                                              "</body> " +
                                              "</html>";

                                writer.Write(html);
                            }
                            else if (page == "/info")
                            {
                                writer.WriteLine($"HTTP/1.0 200 OK{Environment.NewLine}");

                                CultureInfo cultureInfo = new CultureInfo("en-US");

                                string html = "<!doctype html> " +
                                              "<html> " +
                                              "<head> " +
                                              "<title>Info Page</title> " +
                                              "</head> " +
                                              $"<body> <h2>Current Time: {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss", cultureInfo)}</h2> " +
                                              $"<h2>Logical Processors: {Environment.ProcessorCount}</h2><h4>Back to <a href=\"/\">homepage</a></h4> " +
                                              "</body> " +
                                              "</html>";

                                writer.Write(html);
                            }
                            else
                            {
                                writer.WriteLine($"HTTP/1.0 200 OK{Environment.NewLine}");

                                string html = "<!doctype html> " +
                                              "<html> " +
                                              "<head> " +
                                              "<title>Error Page</title> " +
                                              "</head> " +
                                              "<body> <h2 style=\"color: red\">Error! Try going to the <a href=\" / \">home page</a></h2></body> " +
                                              "</html>";

                                writer.Write(html);
                            }
                        }
                        catch (Exception e)
                        {
                            using (writer)
                            {
                                writer.WriteLine($"HTTP/1.0 404 Not Found{Environment.NewLine}");
                                Console.WriteLine($"Exception: {e.Message}{Environment.NewLine}");
                            }
                        }
                    }
                }
            }
        }
    }
}