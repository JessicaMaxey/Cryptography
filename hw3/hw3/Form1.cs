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
        int[] P8_starting_bits = { 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] four_starting_bits = { 1, 2, 3, 4 };
        int[] EP_first_bits = { 4, 1, 2, 3 };
        int[] EP_second_bits = { 2, 3, 4, 1 };
        int[,] S0_box = { { 1, 0, 3, 2 },
                          { 3, 2, 1, 0 },
                          { 0, 2, 1, 3 },
                          { 3, 1, 3, 2 }};

        int[,] S1_box = { { 0, 1, 2, 3 },
                          { 2, 0, 1, 3 },
                          { 3, 0, 1, 0 },
                          { 2, 1, 0, 3 }};

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

            //Do a P10
            new_key = PermutationBox(10, starting_10bits, P10, key);

            //split in half into 2 sets of 5 bits
            Split(5, new_key, left_shift, right_shift);

            //then and do a 1 bit circular left shift on both
            first_left_shift = PermutationBox(5, five_starting_bits, shift_one_bits, left_shift);
            first_right_shift = PermutationBox(5, five_starting_bits, shift_one_bits, right_shift);


            //recombine into 10 bits, take off the first 2 bits
            first_P8 = RecombineBox8bits(3, 8, first_P8, first_left_shift, first_right_shift);


            //Do a P8 {6 3 7 4 8 5 10 9}
            key_one = PermutationBox(8, P8_starting_bits, P8, first_P8);


            //with the output of the first LS-1, do a LS-2
            second_left_shift = PermutationBox(5, five_starting_bits, shift_two_bits, first_left_shift);
            second_right_shift = PermutationBox(5, five_starting_bits, shift_two_bits, first_right_shift);

            //recombine and split off the leading 2 bits
            second_P8 = RecombineBox8bits(3, 8, second_P8, second_left_shift, second_right_shift);

            //do another P8 {6 3 7 4 8 5 10 9}
            key_two = PermutationBox(8, P8_starting_bits, P8, second_P8);

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

        public int[] RecombineBox8bits (int first_loop_start, int second_loop_start, int[] combined_array, int[] left_array, int[] right_array)
        {
            int num_bits_off_front = 2;

            for (int i = 0; i < first_loop_start; i++)
            {
                combined_array[i] = left_array[num_bits_off_front++];
            }

            num_bits_off_front = 0;

            for (int i = 3; i < second_loop_start; i++)
            {
                combined_array[i] = right_array[num_bits_off_front++];
            }

            return combined_array;
        }

        public void Split (int array_size, int[] data_array, int[] left_shift, int[] right_shift)
        {
            int count = 0;

            for (int i = 0; i < array_size; i++)
            {
                left_shift[count++] = data_array[i];
            }

            count = 0;

            for (int i = array_size; i < data_array.Length; i++)
            {
                right_shift[count++] = data_array[i];
            }
        }

        public void StartEncryption (int[] plaintext)
        {
            int count = 0;

            //Do the first IP on the original 
            original_eight = PermutationBox(8, starting_8bits, IP_box, plaintext);

            //break down the IP'd plaintext into 2 sets of 4 bits
            Split(4, original_eight, left_four, right_four);


            //send to recursive function
            Encryption(left_four, right_four, key_one);

        }

        public void Encryption(int[] left_four, int[] right_four, int[]key)
        {
            int[] top_bits_xOR = new int[4];
            int[] bottom_bits_xOR = new int[4];
            int[] key_top_bits = new int[4];
            int[] key_bottom_bits = new int[4];
            int S0_row_index = 0;
            int S0_col_index = 0;
            int S1_row_index = 0;
            int S1_col_index = 0;

            //send the right 4 bits to the expander
            int[] EP_top_bits = PermutationBox(4, four_starting_bits, EP_first_bits, right_four);
            int[] EP_bottom_bits = PermutationBox(4, four_starting_bits, EP_second_bits, right_four);

            //split the key into 2 sets of 4 bits and
            //xOR the top expanded bits with the first 4 of key one's bits
            Split(4, key, key_top_bits, key_bottom_bits);

            for (int i = 0; i < 4; i++)
            {
                top_bits_xOR[i] = EP_top_bits[i] ^ key_top_bits[i];

            }

            for (int i = 0; i < 4; i++)
            {
                bottom_bits_xOR[i] = EP_bottom_bits[i] ^ key_bottom_bits[i];

            }

            //1 and 4 are the rows, 2 and 3 are the col to be sent to the Sbox's
            string top_row =  Convert.ToString(top_bits_xOR[0]) + Convert.ToString(top_bits_xOR[3]);
            string top_col = Convert.ToString(top_bits_xOR[1]) + Convert.ToString(top_bits_xOR[2]);
            string bottom_row = Convert.ToString(bottom_bits_xOR[0])+ Convert.ToString(bottom_bits_xOR[3]);
            string bottom_col = Convert.ToString(bottom_bits_xOR[1])+ Convert.ToString(bottom_bits_xOR[2]);

            for(int i = 0; i < 4; i++)
            {



            }

        }

        public void Decryption ()
        {

        }

        public void run ()
        {
            int[] plaintext = { 1, 1, 1, 1, 0, 0, 1, 1 };
            int[] key = { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 };

            GenerateKey(key);

            StartEncryption(plaintext);


        }
    }
}
