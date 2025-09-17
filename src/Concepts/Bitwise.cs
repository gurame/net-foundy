class Bitwise
{
    public static void Run()
    {
        int a = 5;   // 0101
        int b = 3;   // 0011

        Console.WriteLine(a & b);   // 1  -> 0001
        Console.WriteLine(a | b);   // 7  -> 0111
        Console.WriteLine(a ^ b);   // 6  -> 0110
        Console.WriteLine(~a);      // -6 -> complemento a dos
        Console.WriteLine(a << 1);  // 10 -> 1010
        Console.WriteLine(a >> 1);  // 2  -> 0010        
    }
}