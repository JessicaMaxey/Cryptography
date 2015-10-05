using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

class Program
{
    //the number of all the letters in the alphabet
    const int TOTAL_ALPH_NUM = 26;
    //the number in the list of keys that the original alphabet with no shift is located
    const int ORIGINAL_ALPHABET = 0;
    //the number in the sorted array that equals the lowest amount of falses, which would be the correct key
    const int CORRECT_KEY = 0;

    static char[] alph_0_shift = new char[] {'a', 'b', 'c', 'd', 'e',
                                             'f', 'g', 'h', 'i', 'j',
                                             'k', 'l', 'm', 'n', 'o',
                                             'p', 'q', 'r', 's', 't',
                                             'u', 'v', 'w', 'x', 'y',
                                             'z'};

    static char[] alph_1_shift = new char[] {'b', 'c', 'd', 'e',
                                             'f', 'g', 'h', 'i', 'j',
                                             'k', 'l', 'm', 'n', 'o',
                                             'p', 'q', 'r', 's', 't',
                                             'u', 'v', 'w', 'x', 'y',
                                             'z', 'a'};

    static char[] alph_2_shift = new char[] {'c', 'd', 'e',
                                             'f', 'g', 'h', 'i', 'j',
                                             'k', 'l', 'm', 'n', 'o',
                                             'p', 'q', 'r', 's', 't',
                                             'u', 'v', 'w', 'x', 'y',
                                             'z', 'a', 'b'};

    static char[] alph_3_shift = new char[] {'d', 'e',
                                             'f', 'g', 'h', 'i', 'j',
                                             'k', 'l', 'm', 'n', 'o',
                                             'p', 'q', 'r', 's', 't',
                                             'u', 'v', 'w', 'x', 'y',
                                             'z', 'a', 'b', 'c'};

    static char[] alph_4_shift = new char[] {'e',
                                             'f', 'g', 'h', 'i', 'j',
                                             'k', 'l', 'm', 'n', 'o',
                                             'p', 'q', 'r', 's', 't',
                                             'u', 'v', 'w', 'x', 'y',
                                             'z', 'a', 'b', 'c', 'd'};

    static char[] alph_5_shift = new char[] {'f', 'g', 'h', 'i', 'j',
                                             'k', 'l', 'm', 'n', 'o',
                                             'p', 'q', 'r', 's', 't',
                                             'u', 'v', 'w', 'x', 'y',
                                             'z', 'a', 'b', 'c', 'd',
                                             'e'};

    static char[] alph_6_shift = new char[] {'g', 'h', 'i', 'j',
                                             'k', 'l', 'm', 'n', 'o',
                                             'p', 'q', 'r', 's', 't',
                                             'u', 'v', 'w', 'x', 'y',
                                             'z', 'a', 'b', 'c', 'd',
                                             'e', 'f'};

    static char[] alph_7_shift = new char[] {'h', 'i', 'j',
                                             'k', 'l', 'm', 'n', 'o',
                                             'p', 'q', 'r', 's', 't',
                                             'u', 'v', 'w', 'x', 'y',
                                             'z', 'a', 'b', 'c', 'd',
                                             'e', 'f', 'g'};

    static char[] alph_8_shift = new char[] {'i', 'j',
                                             'k', 'l', 'm', 'n', 'o',
                                             'p', 'q', 'r', 's', 't',
                                             'u', 'v', 'w', 'x', 'y',
                                             'z', 'a', 'b', 'c', 'd',
                                             'e', 'f', 'g', 'h'};

    static char[] alph_9_shift = new char[] {'j',
                                             'k', 'l', 'm', 'n', 'o',
                                             'p', 'q', 'r', 's', 't',
                                             'u', 'v', 'w', 'x', 'y',
                                             'z', 'a', 'b', 'c', 'd',
                                             'e', 'f', 'g', 'h', 'i'};

    static char[] alph_10_shift = new char[] {'k', 'l', 'm', 'n', 'o',
                                              'p', 'q', 'r', 's', 't',
                                              'u', 'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j'};

    static char[] alph_11_shift = new char[] {'l', 'm', 'n', 'o',
                                              'p', 'q', 'r', 's', 't',
                                              'u', 'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j',  'k'};

    static char[] alph_12_shift = new char[] {'m', 'n', 'o',
                                              'p', 'q', 'r', 's', 't',
                                              'u', 'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l'};

    static char[] alph_13_shift = new char[] {'n', 'o',
                                              'p', 'q', 'r', 's', 't',
                                              'u', 'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm'};

    static char[] alph_14_shift = new char[] {'o',
                                              'p', 'q', 'r', 's', 't',
                                              'u', 'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n'};

    static char[] alph_15_shift = new char[] {'p', 'q', 'r', 's', 't',
                                              'u', 'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n',
                                              'o'};

    static char[] alph_16_shift = new char[] {'q', 'r', 's', 't',
                                              'u', 'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n',
                                              'o', 'p'};

    static char[] alph_17_shift = new char[] {'r', 's', 't',
                                              'u', 'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n',
                                              'o', 'p', 'q'};

    static char[] alph_18_shift = new char[] {'s', 't',
                                              'u', 'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n',
                                              'o', 'p', 'q', 'r'};

    static char[] alph_19_shift = new char[] {'t',
                                              'u', 'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n',
                                              'o', 'p', 'q', 'r', 's'};

    static char[] alph_20_shift = new char[] {'u', 'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n',
                                              'o', 'p', 'q', 'r', 's',
                                              't'};

    static char[] alph_21_shift = new char[] {'v', 'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n',
                                              'o', 'p', 'q', 'r', 's',
                                              't', 'u'};

    static char[] alph_22_shift = new char[] {'w', 'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n',
                                              'o', 'p', 'q', 'r', 's',
                                              't', 'u', 'v'};

    static char[] alph_23_shift = new char[] {'x', 'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n',
                                              'o', 'p', 'q', 'r', 's',
                                              't', 'u', 'v', 'w'};

    static char[] alph_24_shift = new char[] {'y',
                                              'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n',
                                              'o', 'p', 'q', 'r', 's',
                                              't', 'u', 'v', 'w', 'x'};

    static char[] alph_25_shift = new char[] {'z', 'a', 'b', 'c', 'd',
                                              'e', 'f', 'g', 'h', 'i',
                                              'j', 'k', 'l', 'm', 'n',
                                              'o', 'p', 'q', 'r', 's',
                                              't', 'u', 'v', 'w', 'x',
                                              'y'};

    //stores all possible keys
    static List<char[]> all_keys_list = new List<char[]>();
    //stores the words in the dictionary
    static List<string> english_dict = new List<string>();
    //store all the chars from the user file into strings
    static List<string> user_word_list = new List<string>();
    //the raw characters inside of the file the user provided
    static char[] user_file;
    //the characters from the user file that have been transposed
    static char[] cryp_file;
    //keeps track of how many falses there are after searching through the dictionary
    static List<bool> found = new List<bool>();
    //keeps the string that is being checked by the dictionary, the number of falses from the dictionary search, and the original char[]
    static List<Tuple<List<string>, int, char[]>> completed_lists = new List<Tuple<List<string>, int, char[]>>();

    //stores all keys into a list
    static void CreateAlphKeyList ()
    {
        all_keys_list.Add(alph_0_shift);
        all_keys_list.Add(alph_1_shift);
        all_keys_list.Add(alph_2_shift);
        all_keys_list.Add(alph_3_shift);
        all_keys_list.Add(alph_4_shift);
        all_keys_list.Add(alph_5_shift);
        all_keys_list.Add(alph_6_shift);
        all_keys_list.Add(alph_7_shift);
        all_keys_list.Add(alph_8_shift);
        all_keys_list.Add(alph_9_shift);
        all_keys_list.Add(alph_10_shift);
        all_keys_list.Add(alph_11_shift);
        all_keys_list.Add(alph_12_shift);
        all_keys_list.Add(alph_13_shift);
        all_keys_list.Add(alph_14_shift);
        all_keys_list.Add(alph_15_shift);
        all_keys_list.Add(alph_16_shift);
        all_keys_list.Add(alph_17_shift);
        all_keys_list.Add(alph_18_shift);
        all_keys_list.Add(alph_19_shift);
        all_keys_list.Add(alph_20_shift);
        all_keys_list.Add(alph_21_shift);
        all_keys_list.Add(alph_22_shift);
        all_keys_list.Add(alph_23_shift);
        all_keys_list.Add(alph_24_shift);
        all_keys_list.Add(alph_25_shift);

    }

    static void CreateDictionary (string filepath)
    {
        StreamReader reader;

        //gets the stream
        reader = new StreamReader(filepath);

        //readers in the list of english words
        while(!reader.EndOfStream)
        {
            //adds one word at a time from the dictionary file
            //to the list
            english_dict.Add(reader.ReadLine());

        }

        //close the stream 
        reader.Close();
    }

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
        while (i != completed_lists[CORRECT_KEY].Item3.Length)
        {
            writer.Write(completed_lists[CORRECT_KEY].Item3[i]);
            i++;
        }


        writer.Close();
    }

    static void Decryption(int num_of_current_key)
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
                if (Char.ToLower(user_file[i]) == Char.ToLower(all_keys_list[num_of_current_key][j]))
                {
                    //make plantext all lowercase
                    cryp_file[i] = Char.ToLower(all_keys_list[ORIGINAL_ALPHABET][j]);
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

    //This will put the decryped list into strings to be check against
    //the dictionary to see if it is the currect list of english words
    static void MakeIntoStrings()
    {
        //temp list to hold chars to be added to the list of strings
        List<char> temp_char_list = new List<char>();
        //loop through the key shifted char array

        for (int i = 0; i < cryp_file.Length; i++)
        {
            //find the dilmater after each word
            if (cryp_file[i] != '\0' && !Char.IsSeparator(cryp_file[i]))
            {
                temp_char_list.Add(cryp_file[i]);

                if(i == (cryp_file.Length - 1))
                {
                    //temp to hold chars found before the space
                    string temp_string = "";


                    for (int j = 0; j < temp_char_list.Count; j++)
                    {
                        //adds the chars to the temp string
                        temp_string += temp_char_list[j];
                    }

                    //adds the string to the list of strings
                    user_word_list.Add(temp_string);

                    //resets the list
                    temp_char_list.Clear();
                }
            }
            //if space is found then add to list of strings
            else
            {
                //temp to hold chars found before the space
                string temp_string = "";


                for (int j = 0; j < temp_char_list.Count; j++)
                {
                    //adds the chars to the temp string
                    temp_string += temp_char_list[j];
                }

                //adds the string to the list of strings
                user_word_list.Add(temp_string);

                //resets the list
                temp_char_list.Clear();
            }
        }
    }

    static void CheckDictionary()
    {
        int num_true = 0;
        int num_false = 0;

        //goes through list of words in user file and 
        //checks to see if they are english words
        for(int i = 0; i < user_word_list.Count(); i++)
        {
            found.Add(english_dict.Contains(user_word_list[i]));

            //counts the number of trues and false
            if (found[i] == true)
                num_true++;

            if (found[i] == false)
                num_false++;
        }

        //add the num of trues and falses into a tuple with 
        //the list of strings to compare the number of falses 
        //later to see which has the least amount of falses. 
        //This will be the correct file
        completed_lists.Add(new Tuple<List<string>, int, char[]>(user_word_list, num_false, cryp_file));

    }

    static void SortLists ()
    {
        //compare the number falses across all keys and does a basic bubble sort to 
        //get the lowest number of falses to the top of the list
        for (int i = 0; i < completed_lists.Count(); i++)
        {
            for (int j = 0; j < completed_lists.Count() - 1; j++)
            {
                if (completed_lists[j].Item2 > completed_lists[j + 1].Item2)
                {
                    Tuple<List<string>, int, char[]> temp = completed_lists[j + 1];
                    completed_lists[j + 1] = completed_lists[j];
                    completed_lists[j] = temp;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        //start at 1 because 0 will always be the original alphabet
        int num_of_current_key = 1;

        //need to read in dictionary from file, store in list of strings
        string dictionarypath = (@"C:\Users\jessica.maxey\Desktop\dictionary.txt");
        CreateDictionary(dictionarypath);

        //need to read in users file once char at a time
        string getfilepath = (@"C:\Users\jessica.maxey\Desktop\test_de.txt");
        string setfilepath = (@"c:\users\jessica.maxey\desktop\finished.txt");

        //reads the users file
        ReadFile(getfilepath);

        //create all shifted alphabets (all possible keys)
        CreateAlphKeyList();

        while (num_of_current_key < TOTAL_ALPH_NUM)
        {
            //decrypt file with 1st shifted key alphabet
            Decryption(num_of_current_key);

            //store as strings
            MakeIntoStrings();

            //check dictionary for words
            CheckDictionary();

            //resets data for next round
            user_word_list = new List<string>();
            found.Clear();
            
            //repeat until correct key is found
            num_of_current_key++;
        };

        //sorts the number of falses, the least amount of falses will be at the top of the list
        SortLists();

        //store correct file
        WriteFile(setfilepath);

    }
}

