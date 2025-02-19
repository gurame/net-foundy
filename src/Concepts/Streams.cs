using System.Text;

namespace NetFoundy.Concepts;

class Streams
{
    public static void Run()
    {
        // Streams are a sequence of bytes that can be read or written to
        // Streams are used to read or write data to a source or destination
        string text = "Hello, World!";
        byte[] buffer = Encoding.UTF8.GetBytes(text);
        MemoryStream memoryStream = new MemoryStream();
        memoryStream.Write(buffer, 0, buffer.Length);

        Console.WriteLine("Memory Stream Position: {0}", memoryStream.Position);
        Console.WriteLine("Memory Stream Length: {0}", memoryStream.Length);
        Console.WriteLine("Memory Stream Capacity: {0}", memoryStream.Capacity);

        memoryStream.Position = 0; // Reset the position to the beginning of the stream
        memoryStream.Seek(0, SeekOrigin.Begin); // Reset the position to the beginning of the stream

        byte[] readBuffer = new byte[memoryStream.Length];
        memoryStream.Read(readBuffer, 0, readBuffer.Length);
        string readText = Encoding.UTF8.GetString(readBuffer);
        Console.WriteLine("Read Text: {0}", readText);

        var otherBuffer = memoryStream.ToArray(); // Returns the entire stream as a byte array
        var otherText = Encoding.UTF8.GetString(otherBuffer);
        Console.WriteLine("Other Text: {0}", otherText);
    }
}