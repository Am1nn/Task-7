using System.Net.Sockets;
#pragma warning disable
var port = 27001;
var client = new TcpClient("127.0.0.1", port);
var stream = client.GetStream();
var binaryReader = new BinaryReader(stream);
var binaryWriter = new BinaryWriter(stream);

Task.Run(async () => {

    Console.Write("Salam Qaqaw Adin Nece Oldu??: ");

    var name = Console.ReadLine();
    binaryWriter.Write(name!);

    while (true)
    {

        Console.Write($"Mesaji Kime yazirsansa onun adini di qaqa: ");
        var whom = Console.ReadLine();
        Console.Write($"Ozel Birsey yoxdusa yaz server otagi gorura: ");
        var message = Console.ReadLine();
        binaryWriter.Write(whom + " " + message);
    }
});
while (true)
{
    var readString = binaryReader.ReadString();
    var index = readString.IndexOf(' ');
    var whom = readString.Substring(0, index);
    var message = readString.Substring(index + 1);
    if (!string.IsNullOrEmpty(message)) Console.WriteLine($"\n{whom}-den Mesaj Gelib " + "\nDeyirki: "+ message );
}