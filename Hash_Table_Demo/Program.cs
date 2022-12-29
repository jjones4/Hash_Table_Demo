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

            // Create hash table
            // Hash table is an array of 130 arrays each of 3 arrays
            // with 2 strings in each of those arrays
            // [  [  [s1,s2][s1,s2][s1,s2]  ]  [  [s1,s2][s1,s2][s1,s2]  ]  ...  [  [s1,s2][s1,s2][s1,s2]  ]  ]
            //           1     2      3              1      2      3                   1      2      3
            //    1                            2 ...                             130
            // Note that 130 is the largest sum of 5 letters "zzzzz"
            // with ascii values of z = 122 - 96 for each "z"
            // We could have up to 130 for an index
            string[,,] hashTable = new string[130, 3, 2];

            // Initialize hashTable to "-"
            for (int i = 0; i < 130; i++)
            {
                hashTable[i, 0, 0] = "-";
                hashTable[i, 0, 1] = "-";
                hashTable[i, 1, 0] = "-";
                hashTable[i, 1, 1] = "-";
                hashTable[i, 2, 0] = "-";
                hashTable[i, 2, 1] = "-";
            }

            // Put the data from our data array into the hash table
            // at the correct indeces (calculated by our calculateIndex
            // method
            for (int i = 0; i < data.Length / 2; i++)
            {
                // Check for collisions

                // Check to make sure the first array of the three isn't filled
                if (hashTable[calculateIndex(data[i, 0]), 0, 0] == "-")
                {
                    hashTable[calculateIndex(data[i, 0]), 0, 0] = data[i, 0];
                    hashTable[calculateIndex(data[i, 0]), 0, 1] = data[i, 1];
                }
                // Check to make sure the second array of the three isn't filled
                else if (hashTable[calculateIndex(data[i, 0]), 1, 0] == "-")
                {
                    hashTable[calculateIndex(data[i, 0]), 1, 0] = data[i, 0];
                    hashTable[calculateIndex(data[i, 0]), 1, 1] = data[i, 1];

                }
                // Put the data in the third array (we don't have more than 3
                // collisions per index
                else
                {
                    hashTable[calculateIndex(data[i, 0]), 2, 0] = data[i, 0];
                    hashTable[calculateIndex(data[i, 0]), 2, 1] = data[i, 1];
                }
            }

            // Test some searching of the hash table by key from the original data set
            for (int i = 0; i < data.Length / 2; i++)
            {
                Console.Write($"{hashTable[calculateIndex(data[i, 0]), 0, 0]} " +
                              $"{hashTable[calculateIndex(data[i, 0]), 0, 1]} " +
                              $"{hashTable[calculateIndex(data[i, 0]), 1, 0]} " +
                              $"{hashTable[calculateIndex(data[i, 0]), 1, 1]} " +
                              $"{hashTable[calculateIndex(data[i, 0]), 2, 0]} " +
                              $"{hashTable[calculateIndex(data[i, 0]), 2, 1]} ");

                Console.WriteLine();
            }
        }

        static int calculateIndex(string key)
        {
            int total = 0;

            // ascii sum of lower case letters minus 96 to
            // get a one-based count for our
            // hash table array indeces
            foreach (char c in key)
            {
                total += (int)(c) - 96;
            }

            return total;
        }
    }
}