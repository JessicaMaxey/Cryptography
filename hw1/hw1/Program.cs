using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class Program
{
    const int TOTAL_ALPH_NUM = 26;

    static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e',
                                          'f', 'g', 'h', 'i', 'j',
                                          'k', 'l', 'm', 'n', 'o',
                                          'p', 'q', 'r', 's', 't',
                                          'u', 'v', 'w', 'x', 'y',
                                          'z'};

    static char[] with_key_alph = new char[26];

    static char[] user_file;
    static char[] cryp_file;

    static public void CreateCaesarCipher (int key)
    {
        //starting place for the shifted char array
        int count = 0;

        for(; count < TOTAL_ALPH_NUM;)
        {
            //algorithm for looping back to the beginning once you go passed the
            //end of the alphabet if there are any letters left that need to be
            //shifted
            int i = ((count + key) % TOTAL_ALPH_NUM);

            //adds them to a new array with the shift build in
            with_key_alph[count] =  alphabet[i];

            count++;
        }
    }

    //This is read the file and store it into a char array
    static void ReadFile (string filepath)
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

    }

    static void Encryption ()
    {
        cryp_file = new char[user_file.Length];

        int i = 0;
        int j = 0;

        while (i != user_file.Length && j != 26)
        {
            if (Char.IsLetter(user_file[i]))
            {
                if (user_file[i] == alphabet[j])
                {
                    cryp_file[i] = with_key_alph[j];
                    i++;
                    j = -1;
                }
            }
            else
            {
                i++;
                j = -1;
            }

            j++;  
        }
    }

    static void Main(string[] args)
    {
        char choice = ' ';
        int key = 0;


        //Read in if user wants a encryption or decryption
        do
        {
            Console.WriteLine("Please enter 1 for encryption or 2 for decryption: ");
            choice = Convert.ToChar(Console.ReadLine());
        } while (!(choice == '1' || choice == '2'));

        //Read in the key (no less than 0, no greater than 25, and only numbers)
        //if not within the restraints, repromt
        do
        {
            Console.WriteLine("Enter a number between 0 and 25 for the key: ");
            key = Convert.ToInt32(Console.ReadLine());
        } while (!(key >= 0 || key <= 25));

        //converts the char key into a int for better useablitly 

        //creates a alphbet array with a shift based on the number from the key
        CreateCaesarCipher(key);


        //Promt user for path to plan text file or ciphertext file
        string filepath = (@"C:\Users\Jess\Documents\Repos\Cryptography\hw1\hw1\test.txt");

        //sends file off to be stored in a array
        ReadFile(filepath);


        //the array containing the file will be encrypted
        Encryption();


        //the array containing the file will be decrypted



        //promt user for path and file name to save the plan text or cipher file



        //make ciphertext all UPPERCASE



        //make plantext all lowercase



    }
}

