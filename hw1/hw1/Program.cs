using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

    static char[] user_file = new char[] { };

    static public void CreateCaesarCipher (int key)
    {
        //starting place for the shifted char array
        int count = 0;

        for(; count < TOTAL_ALPH_NUM;)
        {
            int i = ((count + key) % TOTAL_ALPH_NUM);

            with_key_alph[count] =  alphabet[i];

            count++;
        }
    }

    //This is read the file and store it into a char array
    static void ReadFile ()
    {

    }

    static void Main(string[] args)
    {
        //Read in if user wants a encryption or decryption

        //Read in the key (no less than 0, no greater than 25, and only numbers)
        //if not within the restraints, repromt
        int key = 3;
        //creates a alphbet array with a shift based on the number from the key
        CreateCaesarCipher(key);

        //Promt user for path to plan text file or ciphertext file

        //promt user for path and file name to save the plan text or cipher file

        //make ciphertext all UPPERCASE

        //make plantext all lowercase
    }
}

