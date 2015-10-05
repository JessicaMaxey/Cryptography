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

    //the shifted alphabet after using the key on it
    static char[] with_key_alph = new char[26];

    //the raw characters inside of the file the user provided
    static char[] user_file;
    //the characters from the user file that have been transposed
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

        reader.Close();

    }

    static void WriteFile (string filepath)
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

    static void Encryption ()
    {
        cryp_file = new char[user_file.Length];

        int i = 0;
        int j = 0;

        //loops through and does a shifted based on the key
        while (i != user_file.Length && j != 26)
        {
            //if the char is a letter then is does the shift
            if (Char.IsLetter(user_file[i]))
            {
                //during the compare it makes sure that both sides are uppercase
                if (Char.ToUpper(user_file[i]) == Char.ToUpper(alphabet[j]))
                {
                    //make ciphertext all UPPERCASE
                    cryp_file[i] = Char.ToUpper(with_key_alph[j]);
                    i++;
                    j = -1;
                }
            }
            //if it is not a letter it keeps it in the array and does not do a shift on it
            //this way we can write the file back and it will still have spaces and punt.
            else if (!Char.IsLetter(user_file[i]))
            {
                cryp_file[i] = user_file[i];
                i++;
                j = -1;
            }
            else
            {
                i++;
                j = -1;
            }

            j++;  
        }
    }

    static void Decryption()
    {
        cryp_file = new char[user_file.Length];

        int i = 0;
        int j = 0;
        
        //loops through and does a shifted based on the key
        while (i != user_file.Length && j != 26)
        {
            //if the char is a letter then is does the shift
            if (Char.IsLetter(user_file[i]))
            {
                //during the compare it makes sure that both sides are lowercase
                if (Char.ToLower(user_file[i]) == Char.ToLower(with_key_alph[j]))
                {
                    //make plantext all lowercase
                    cryp_file[i] = Char.ToLower(alphabet[j]);
                    i++;
                    j = -1;
                }
            }
            //if it is not a letter it keeps it in the array and does not do a shift on it
            //this way we can write the file back and it will still have spaces and punt.
            else if (!Char.IsLetter(user_file[i]))
            {
                cryp_file[i] = user_file[i];
                i++;
                j = -1;
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
        } while (!(key >= 0 && key <= 25));

        //creates a alphbet array with a shift based on the number from the key
        CreateCaesarCipher(key);


        //Promt user for path to plan text file or ciphertext file
        Console.WriteLine("Enter file path to get file from: ");
        string getfilepath = Console.ReadLine();


        //Promt user for path to plan text file or ciphertext file to save it to
        Console.WriteLine("Enter file path to send file to: ");
        string setfilepath = Console.ReadLine();


        if (choice == '1')
        {
            //sends file off to be stored in a array
            ReadFile(getfilepath);
            //the array containing the file will be encrypted
            Encryption();

        }
        else
        {
            //sends file off to be stored in a array
            ReadFile(getfilepath);
            //the array containing the file will be decrypted
            Decryption();

        }


        //promt user for path and file name to save the plan text or cipher file
        WriteFile(setfilepath);

        
    }
}

