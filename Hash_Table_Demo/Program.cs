namespace Hash_Table_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hard-coded key/value pairs
            // Insert into a hash table later
            string[,] data = new string[,]
            {
                { "a", "1" },
                { "ab", "12" },
                { "abc", "123" }, // Collisions with "bac" and "cab"
                { "car", "3118" }, // Colision with "dii"
                { "bac", "213" }, // Collisions with "abc" and "cab"
                { "az", "126" }, // Collision with "tag"
                { "abf", "126" },
                { "cab", "312" }, // Collisions with "abc" and "bac"
                { "pee", "1655" },
                { "poop", "16151516" },
                { "try", "201825" },
                { "ah", "18" },
                { "cc", "33" },
                { "bb", "22" },
                { "dii", "499" }, // Collision with "car"
                { "tag", "2017" }, // Collision with "az"
                { "golf", "715126" },
                { "see", "1955" },
                { "cat", "3120" },
                { "water", "23120518" }
            };

            // Test to make sure our ascii sums are correct
            for (int i = 0; i < data.Length / 2; i++)
            {
                Console.WriteLine($"The string {data[i, 0]} sums to {calculateIndex(data[i, 0])}");
            }

            // Step 1, calculate sum of ascii values minus 97
            // to get a zero based index
            // These sums become our hash table's array indeces


            // Create hash table
            // string[,,] hashTable = new string[,,];
        }

        static int calculateIndex(string key)
        {
            int total = 0;

            // ascii sum of lower case letters minus 97 to
            // get a zero based count for our indeces
            foreach (char c in key)
            {
                total += (int)(c) - 97;
            }

            return total;
        }
    }
}