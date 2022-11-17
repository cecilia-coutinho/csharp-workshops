// Koden genererar fel och körs inte.
//solution:
//add ++ in i and j ---> i++, j++
//for (int i = 1; i <= 5; i++);
//for (int j = 1; j <= i; j);
//the last console.writeline is empty

for (int i = 1; i <= 5; i)
{
    for (int j = 1; j <= i; j)
    {
        Console.Write(j + " ");
    }
    Console.WriteLine();
}