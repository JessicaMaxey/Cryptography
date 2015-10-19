using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw2
{
    class Program
    {
        //the raw characters inside of the file the user provided
        static char[] user_file;

        //the characters from the user file that have been transposed
        static char[] cryp_file;

        //holds the key for the vignere table
        static char[] key;

        //stores the vignere table to do encryption and decrypiton with
        static char[,] vignere_table = new char[,] {  {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'},
                                                      {'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a'},
                                                      {'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b'},
                                                      {'d', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c'},
                                                      {'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd'},
                                                      {'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e'},
                                                      {'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f'},
                                                      {'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g'},
                                                      {'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'},
                                                      {'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i'},
                                                      {'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'},
                                                      {'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k'},
                                                      {'m', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l'},
                                                      {'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm'},
                                                      {'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n'},
                                                      {'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o'},
                                                      {'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p'},
                                                      {'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q'},
                                                      {'s', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r'},
                                                      {'t', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's'},
                                                      {'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't'},
                                                      {'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u'},
                                                      {'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v'},
                                                      {'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w'},
                                                      {'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x'},
                                                      {'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y'}, };

        //This is read the file and store it into a char array
        static void ReadFile(string filepath)
        {
            int num_of_letters = 0;
            StreamReader reader;

            //gets the stream
            reader = new StreamReader(filepath);

            //finds out how many letters are in the file to set the size of the array
            while (!reader.EndOfStream)
            {
                reader.Read();
                num_of_letters++;
            }

            //resets the stream to the beginning
            reader = new StreamReader(filepath);
            //sets the size of the array to however many characters there are in the file
            user_file = new char[num_of_letters];

            //reads through the file and stores each letter into a array
            int i = 0;
            do
            {
                user_file[i] = (char)reader.Read();
                i++;

            } while (i != num_of_letters);

            reader.Close();

        }

        static void WriteFile(string filepath)
        {
            StreamWriter writer;

            writer = new StreamWriter(filepath);

            int i = 0;

            //loops through the char[] and creates the new file
            while (i != user_file.Length)
            {
                writer.Write(cryp_file[i]);
                i++;
            }

            writer.Close();
        }

        static void Encryption(char [] key)
        {
            cryp_file = new char[user_file.Length];

            int x_coord = 0;
            int y_coord = 0;
            int j = 0;

            for (int i = 0; i < user_file.Length; i++)
            {
                //this well get the left side index
                for (int y = 0; y < 25; y++)
                {
                    if (Char.ToUpper(vignere_table[y, 0]) == Char.ToUpper(key[j]))
                    {
                        y_coord = y;
                        break;
                    }
                }


                //this well get the top index
                for (int x = 0; x < 25; x++)
                {
                    if (Char.ToUpper(vignere_table[0, x]) == Char.ToUpper(user_file[i]))
                    {
                        x_coord = x;
                        break;
                    }
                }

                //stores the letter at the location found above
                cryp_file[i] = Char.ToUpper(vignere_table[y_coord, x_coord]);

                //next letter in key
                if (j < (key.Length - 1))
                {
                    j++;
                }
                //if at end of key, restart from beginning
                else
                {
                    j = 0;
                }


            }


            //locate the letter of the word on top
            //find where they intersect
            //save the letter
        }

        static void Decryption (char [] key)
        {
            cryp_file = new char[user_file.Length];
            //located the letter of the key on the left side
            //move across from there until hit letter in ciphertext
            //move up from there, that's the plaintext
            //save the letter


            int x_coord = 0;
            int y_coord = 0;
            int j = 0;
            int y = 0;

            for (int i = 0; i < user_file.Length; i++)
            {
                y = 0;
                //this well get the left side index
                for (; y < 25; y++)
                {
                    if (Char.ToLower(vignere_table[y, 0]) == Char.ToLower(key[j]))
                    {
                        y_coord = y;
                        break;
                    }
                }



                //this well get the top index
                for (int x = 0; x < 25; x++)
                {
                    if (Char.ToLower(vignere_table[y, x]) == Char.ToLower(user_file[i]))
                    {
                        x_coord = x;
                        break;
                    }
                }

                //stores the letter at the location found above
                cryp_file[i] = Char.ToLower(vignere_table[0, x_coord]);

                //next letter in key
                if (j < (key.Length - 1))
                {
                    j++;
                }
                //if at end of key, restart from beginning
                else
                {
                    j = 0;
                }


            }
        }

        static void Main(string[] args)
        {

            string get_file;
            string set_file;
            string str_key;
            //get encryption or decryption
            //get key

            //get file location
            //get_file = (@"en.txt");
            get_file = (@"de.txt");
            //get where to make the new file
            set_file = ("C:/Users/Jess/Desktop/finished.txt");

            Console.WriteLine("Enter key: ");
            str_key = Console.ReadLine();

            char[] key = str_key.ToCharArray();

            //do the encryption
            ReadFile(get_file);
            //Encryption(key);
            //or
            //do the decryption
            Decryption(key);

            //save that bad boy
            WriteFile(set_file);
            //done
        }
    }
}
