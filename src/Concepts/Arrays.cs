class Arrays
{
    public static void Run()
    {
        int[] numbers = [1, 2, 3, 4, 5];
        Console.WriteLine("Array elements:");
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }

        string[][] matrix =
        [
            ["a1", "a2", "a3"],
            ["b1", "b2", "b3"],
            ["c1", "c2", "c3"]
        ];

        Console.WriteLine("2D Array elements:");
        foreach (var row in matrix)
        {
            foreach (var element in row)
            {
                Console.WriteLine(element);
            }
        }
        Console.WriteLine(matrix[0][0]); // Accessing element "a1"

        // multi-dimensional array
        int[,] multiDimArray = new int[3, 3]
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9},
        };

        Console.WriteLine("Multi-dimensional Array elements:");
        for (int i = 0; i < multiDimArray.GetLength(0); i++)
        {
            for (int j = 0; j < multiDimArray.GetLength(1); j++)
            {
                Console.Write("Element at ({0},{1}): ", i, j);
                Console.WriteLine(multiDimArray[i, j]);
            }
        }  
    }
}