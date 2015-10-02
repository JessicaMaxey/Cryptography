using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    const int TOTAL_ALPH_NUM = 26;

    static char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e',
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
    static void Main(string[] args)
    {
        //need to read in dictionary from file, store in list of strings
        //need to read in users file once char at a time
        //create alphabet
        //create all shifted alphabets (all possible keys)
        //decrypt file with 1st shifted key alphabet
        //store as strings
        //check dictionary for words
        //repeat until correct key is found
        //store correct file

    }
}

