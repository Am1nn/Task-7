using System.Net;
using System.Net.Sockets;
#pragma warning disable

TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 27001);
server.Start();
Console.WriteLine("Server Otagi Onlineeee");
Dictionary<string, TcpClient> Users = new Dictionary<string, TcpClient>();
while (true)
{

    var client = server.AcceptTcpClient();


    Task.Run(() => {

        bool isRegistration = true;
        Console.WriteLine($"Qosulan EndPoint: {client.Client.LocalEndPoint}");
        var stream = client.GetStream();

        var binaryReader = new BinaryReader(stream);
        var binaryWriter = new BinaryWriter(stream);

        if (isRegistration)
        {
            var username = binaryReader.ReadString();
            Users.Add(username, client);
            isRegistration = false;
        }
        while (true)
        {
            string readString = binaryReader.ReadString();
            int index = readString.IndexOf(' ');
            string whom = readString.Substring(0, index);
            string message = readString.Substring(index + 1);
            foreach (var key in Users)
            {
                if (key.Key == whom)
                {






                    stream = key.Value.GetStream();
                    binaryWriter = new BinaryWriter(stream);
                    binaryWriter.Write(readString);
                    break;
                }
            }
        }
    });
}
