using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw3
{
    public partial class Form1 : Form
    {
        int[] original_eight = new int[8];
        int[] right_four = new int[4];
        int[] left_four = new int[4];
        int[] key_one = new int[8];
        int[] key_two = new int[8];

        int[] P10 = { 3, 5, 2, 7, 4, 10, 1, 9, 8, 6 };
        int[] P8 = { 6, 3, 7, 4, 8, 5, 10, 9 };
        int[] starting_8bits = { 1, 2, 3, 4, 5, 6, 7, 8 };
        int[] starting_10bits = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] IP_box = { 2, 6, 3, 1, 4, 8, 5, 7 };
        int[] IP_inverse_box = { 4, 1, 3, 5, 7, 2, 8, 6 };
        int[] EP_box = { 4, 1, 2, 3, 2, 3, 4, 1 };

        public Form1()
        {
            InitializeComponent();
            run();
        }

        public void GenerateKey(int [] key)
        {
            int[] new_key = new int[10];
            int[] left_shift = new int[5];
            int[] right_shift = new int[5];
            int[] first_left_shift = new int[5];
            int[] first_right_shift = new int[5];
            int[] second_left_shift = new int[5];
            int[] second_right_shift = new int[5];
            int[] first_P8 = new int[8];
            int[] second_P8 = new int[8];
            int[] five_starting_bits = { 1, 2, 3, 4, 5 };
            int[] shift_one_bits = { 2, 3, 4, 5, 1 };
            int[] shift_two_bits = { 3, 4, 5, 1, 2 };
            int count = 0;

            //Do a P10
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        if (starting_10bits[i] == P10[j])
            //        {
            //            new_key[j] = key[i];
            //        }
            //    }
            //}

            new_key = PermutationBox(10, starting_10bits, P10, key);

            //take output from that  and spilt into 5 bits
            for (int i = 0; i < 5; i++)
            {
                left_shift[count++] = new_key[i];
            }

            count = 0;

            for (int i = 5; i < 5; i++)
            {
                right_shift[count++] = new_key[i];
            }


            //

            //then and do a 1 bit circular left shift on both
            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        if (five_starting_bits[i] == shift_one_bits[j])
            //        {
            //            first_left_shift[j] = left_shift[i];
            //        }
            //    }
            //}

            first_left_shift = PermutationBox(5, five_starting_bits, shift_one_bits, left_shift);

            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        if (five_starting_bits[i] == shift_one_bits[j])
            //        {
            //            first_right_shift[j] = right_shift[i];
            //        }
            //    }
            //}

            first_right_shift = PermutationBox(5, five_starting_bits, shift_one_bits, right_shift);


            //take out put of that, recombine into 8 bits, take off the first 2 bits
            //break down the IP'd plaintext into 2 sets of 4 bits
            count = 2;
            for (int i = 0; i < 3; i++)
            {
                first_P8[i] = first_left_shift[count++];
            }

            count = 0;

            for (int i = 3; i < 8; i++)
            {
                first_P8[i] = first_right_shift[count++];
            }



            //Do a P8 {6 3 7 4 8 5 10 9}
            key_one = PermutationBox(8, starting_8bits, P8, first_P8);


            //output that key

            //with the output of the first LS-1, do a LS-2
            second_left_shift = PermutationBox(5, five_starting_bits, shift_two_bits, first_left_shift);
            second_right_shift = PermutationBox(5, five_starting_bits, shift_two_bits, first_right_shift);

            //recombine and do another P8 {6 3 7 4 8 5 10 9}
            count = 2;
            for (int i = 0; i < 3; i++)
            {
                second_P8[i] = second_left_shift[count++];
            }

            count = 0;

            for (int i = 3; i < 8; i++)
            {
                second_P8[i] = second_right_shift[count++];
            }

            key_two = PermutationBox(8, starting_8bits, P8, second_P8);

        }

        public int[] PermutationBox (int count, int[] starting_bits, int[] comparitor, int[] data_array)
        {
            int[] permutated_data = new int[count];

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (starting_bits[i] == comparitor[j])
                    {
                        permutated_data[j] = data_array[i];
                    }
                }
            }

            return permutated_data;
        }

        public void StartEncryption (int[] plaintext)
        {
            int count = 0;

            //Do the first IP on the original 
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (starting_8bits[i] == IP_box[j])
                    {
                        original_eight[j] = plaintext[i];
                    }
                }
            }



            //break down the IP'd plaintext into 2 sets of 4 bits
            for (int i = 0; i < 4; i++)
            {
                left_four[count++] = original_eight[i];
            }

            count = 0;

            for (int i = 4; i < original_eight.Length; i++)
            {
                 right_four[count++] = original_eight[i];
            }




            //send to recursive function
            Encryption(left_four, right_four);

        }

        public void Encryption(int[] left_four, int[] right_four)
        {
            //take in 8 bit plaintext
            //split into 2 sets of 4 bits
            //LS will be stored for later
            //RS is sent to E/P for expansion 
            //E/P {4 1 2 3 2 3 4 1}
            //that is then xOR'd with the K1
            //split into 2 sets of 4 bits
            //send through sboxs
            //then do P4 {2 4 3 1}
            //and xOR with the LS



        }

        public void Decryption ()
        {

        }

        public void run ()
        {
            int[] plaintext = { 0, 0, 0, 0, 1, 1, 1, 1 };
            int[] key = { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };

            GenerateKey(key);

            StartEncryption(plaintext);


        }
    }
}
