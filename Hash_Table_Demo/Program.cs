namespace Hash_Table_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create data to put into hash table later
            List<string[]> data = new List<string[]>();

            data.Add(new string[] { "a", "1" });
            data.Add(new string[] { "ab", "12" });
            data.Add(new string[] { "abc", "123" });
            data.Add(new string[] { "car", "3118" });
            data.Add(new string[] { "bac", "213" });
            data.Add(new string[] { "az", "126" });
            data.Add(new string[] { "abf", "126" });
            data.Add(new string[] { "cab", "312" });
            data.Add(new string[] { "pee", "1655" });
            data.Add(new string[] { "poop", "16151516" });
            data.Add(new string[] { "try", "201825" });
            data.Add(new string[] { "ah", "18" });
            data.Add(new string[] { "cc", "33" });
            data.Add(new string[] { "bb", "22" });
            data.Add(new string[] { "dii", "499" });
            data.Add(new string[] { "tag", "2017" });
            data.Add(new string[] { "golf", "715126" });
            data.Add(new string[] { "see", "1955" });
            data.Add(new string[] { "cat", "3120" });
            data.Add(new string[] { "water", "23120518" });

            // dynamic array for the hash table
            List<object> hashTable = new List<object>();

            // Loop through initial data set
            // Add key/value pairs to hash table
            int arrayIndex = 0;
            int maxIndex = -1;

            foreach (string[] item in data)
            {
                // Calculate our "hash", i.e., our array index
                arrayIndex = calculateArrayIndex(item[0]);

                // If next key produces a hash value greater than any
                // previous index
                if (arrayIndex > maxIndex)
                {
                    // Fill hash table with null values up to new max index
                    for (int i = maxIndex + 1; i < arrayIndex; i++)
                    {
                        hashTable.Add(null);
                    }

                    hashTable.Add(item);

                    maxIndex = arrayIndex;
                }
                else
                {
                    // If no data has been stored at this index
                    if (hashTable[arrayIndex] == null)
                    {
                        hashTable[arrayIndex] = item;
                    }
                    else
                    {
                        // If there is just one string[] in this index
                        if (hashTable[arrayIndex].GetType().IsArray)
                        {
                            LinkedList<string[]> tempList = new LinkedList<string[]>();
                            tempList.AddLast((string[])hashTable[arrayIndex]);
                            tempList.AddLast(item);
                            hashTable[arrayIndex] = tempList;
                        }
                        // If there is already a linked list in this index
                        else
                        {
                            ((LinkedList<string[]>)hashTable[arrayIndex]).AddLast(item);
                        }
                    }
                }
            }

            Console.WriteLine();

            // Print hash table to ensure accuracy
            foreach (var item in hashTable)
            {
                if (item == null)
                {
                    continue;
                }
                else
                {
                    if (item.GetType().IsArray)
                    {
                        Console.Write($"   Key {((string[])item)[0]}, Value {((string[])item)[1]}.");
                    }
                    else
                    {
                        Console.Write("   Collision has occurred ...");
                        Console.WriteLine(" Multiple key/value pairs stored in bucket.");

                        foreach (string[] stringArray in (LinkedList<string[]>)item)
                        {
                            Console.Write($"   Key {stringArray[0]}, Value {stringArray[1]}. ");
                        }
                    }
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Calculates the index of our hash table by summing
        /// the ASCII values of the letters (subtract 97 from
        /// each letter in order to find the zero-based
        /// position of the letter in the alphabet)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int calculateArrayIndex(string key)
        {
            int total = 0;

            foreach (char c in key)
            {
                total += (int)(c) - 97;
            }

            return total;
        }
    }
}