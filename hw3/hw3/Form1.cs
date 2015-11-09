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
        int[] ending_eight = new int[8];
        int[] second_ending_eight = new int[8];
        int[] right_four = new int[4];
        int[] left_four = new int[4];
        int[] key_one = new int[8];
        int[] key_two = new int[8];
        int[] first_left_ending_value = new int[4];
        int[] first_right_ending_value = new int[4];
        int[] second_left_ending_value = new int[4];
        int[] second_right_ending_value = new int[4];
        int[] P4 = { 2, 4, 3, 1 };
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
            Split(5, ref new_key, ref left_shift, ref right_shift);

            //then and do a 1 bit circular left shift on both
            first_left_shift = PermutationBox(5, five_starting_bits, shift_one_bits, left_shift);
            first_right_shift = PermutationBox(5, five_starting_bits, shift_one_bits, right_shift);


            //recombine into 10 bits, take off the first 2 bits
            first_P8 = RecombineBoxbits(2, 3, 8, first_P8, first_left_shift, first_right_shift);


            //Do a P8 {6 3 7 4 8 5 10 9}
            key_one = PermutationBox(8, P8_starting_bits, P8, first_P8);


            //with the output of the first LS-1, do a LS-2
            second_left_shift = PermutationBox(5, five_starting_bits, shift_two_bits, first_left_shift);
            second_right_shift = PermutationBox(5, five_starting_bits, shift_two_bits, first_right_shift);

            //recombine and split off the leading 2 bits
            second_P8 = RecombineBoxbits(2, 3, 8, second_P8, second_left_shift, second_right_shift);

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

        public int[] RecombineBoxbits (int num_bits_off_front, int first_loop_start, int second_loop_start, int[] combined_array, int[] left_array, int[] right_array)
        {
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

        public void Split (int array_size, ref int[] data_array, ref int[] left_shift, ref int[] right_shift)
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
            Split(4, ref original_eight, ref left_four, ref right_four);


            //send to recursive function
            CryptionBox(left_four, right_four, key_one, ref first_left_ending_value, ref first_right_ending_value);

            //when sending the int arrays to encrypt again, make sure to do the switch 
            //(left ending array goes to right, and right goes to left)
            CryptionBox(first_right_ending_value, first_left_ending_value, key_two, ref second_left_ending_value, ref second_right_ending_value);

            //recombine into 8 bit array from the 2 4bit array results
            for (int i = 0; i < 4; i++)
            {
                ending_eight[count++] = second_left_ending_value[i];
            }

            for (int i = 0; i < 4; i++)
            {
                ending_eight[count++] = second_right_ending_value[i];
            }

            //after second time through the encryption box, send to permutation box to be IP invertered
            ending_eight = PermutationBox(8, starting_8bits, IP_inverse_box, ending_eight);
        }

        public void CryptionBox(int[] left_four, int[] right_four, int[] key, ref int[] ending_left, ref int[] ending_right)
        {
            int[] top_bits_xOR = new int[4];
            int[] bottom_bits_xOR = new int[4];
            int[] key_top_bits = new int[4];
            int[] key_bottom_bits = new int[4];
            int[] to_P4_array = new int[4];
            int[] left_ending_value = new int[4];
            int S0_row_index = 0;
            int S0_col_index = 0;
            int S1_row_index = 0;
            int S1_col_index = 0;
            int S0_value = 0;
            int S1_value = 0;

            //send the right 4 bits to the expander
            int[] EP_top_bits = PermutationBox(4, four_starting_bits, EP_first_bits, right_four);
            int[] EP_bottom_bits = PermutationBox(4, four_starting_bits, EP_second_bits, right_four);

            //split the key into 2 sets of 4 bits and
            //xOR the top expanded bits with the first 4 of key one's bits
            Split(4, ref key, ref key_top_bits, ref key_bottom_bits);

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

            S0_row_index = ConvertStringtoInt(top_row);
            S0_col_index = ConvertStringtoInt(top_col);
            S1_row_index = ConvertStringtoInt(bottom_row);
            S1_col_index = ConvertStringtoInt(bottom_col);

            S0_value = S0_box[S0_row_index, S0_col_index];
            S1_value = S1_box[S1_row_index, S1_col_index];

            //convert back into bits
            int[] left_P4_value = ConvertInttoIntArray(S0_value);
            int[] right_P4_value = ConvertInttoIntArray(S1_value);


            //combine back into 4 bits
            int count = 0;

            for (int i = 0; i < 2; i++)
            {
                to_P4_array[count++] = left_P4_value[i];
            }

            for (int i = 0; i < 2; i++)
            {
                to_P4_array[count++] = right_P4_value[i];
            }


            //do P4 on them
            to_P4_array = PermutationBox(4, four_starting_bits, P4, to_P4_array);

            //xOR the result from P4 with the starting left bits from the beginning
            for (int i = 0; i < 4; i++)
            {
                left_ending_value[i] = left_four[i] ^ to_P4_array[i];
            }

            //store ending values
            ending_left = left_ending_value;
            ending_right = right_four;
        }


        public int ConvertStringtoInt (string data)
        {
            int int_value = 0;


            if (data == "00")
                int_value = 0;
            else if (data == "01")
                int_value = 1;
            else if (data == "10")
                int_value = 2;
            else if (data == "11")
                int_value = 3;


            return int_value;
        }

        public int[] ConvertInttoIntArray (int data)
        {
            int[] new_array = new int[2];

            if (data == 0)
            {
                new_array[0] = 0;
                new_array[1] = 0;
            }
            else if (data == 1)
            {
                new_array[0] = 0;
                new_array[1] = 1;
            }
            else if (data == 2)
            {
                new_array[0] = 1;
                new_array[1] = 0;
            }
            else if (data == 3)
            {
                new_array[0] = 1;
                new_array[1] = 1;
            }

            return new_array;

        }

        public void StartDecryption (int[] ciphertext)
        {
            int count = 0;

            //Do the first IP on the original 
            original_eight = PermutationBox(8, starting_8bits, IP_box, ciphertext);

            //break down the IP'd plaintext into 2 sets of 4 bits
            Split(4, ref original_eight, ref left_four, ref right_four);


            //send to recursive function
            CryptionBox(left_four, right_four, key_two, ref first_left_ending_value, ref first_right_ending_value);

            //when sending the int arrays to encrypt again, make sure to do the switch 
            //(left ending array goes to right, and right goes to left)
            CryptionBox(first_right_ending_value, first_left_ending_value, key_one, ref second_left_ending_value, ref second_right_ending_value);

            //recombine into 8 bit array from the 2 4bit array results
            for (int i = 0; i < 4; i++)
            {
                ending_eight[count++] = second_left_ending_value[i];
            }

            for (int i = 0; i < 4; i++)
            {
                ending_eight[count++] = second_right_ending_value[i];
            }

            //after second time through the encryption box, send to permutation box to be IP invertered
            ending_eight = PermutationBox(8, starting_8bits, IP_inverse_box, ending_eight);
        }

        public void run_encryption()
        {
            try
            { 
                result_txtbx.Clear();

                int[] plaintext = new int[8];
                int[] start_key = new int[10];
                //{ 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 };

                char[] get_plaintext_text = text_txtbx.Text.ToCharArray();

                for (int i = 0; i < 8; i++)
                {
                    plaintext[i] = (int)Char.GetNumericValue(get_plaintext_text[i]);
                }

                char[] get_key_text = key_txtbx.Text.ToCharArray();

                for (int i = 0; i < 10; i++)
                {
                    start_key[i] = (int)Char.GetNumericValue(get_key_text[i]);
                }

                GenerateKey(start_key);

                StartEncryption(plaintext);

                second_ending_eight = ending_eight;

                for (int i = 0; i < 8; i++)
                {
                    result_txtbx.Text += second_ending_eight[i].ToString();
                }

                original_eight = new int[8];
                ending_eight = new int[8];
                second_ending_eight = new int[8];
                right_four = new int[4];
                left_four = new int[4];
                key_one = new int[8];
                key_two = new int[8];
                first_left_ending_value = new int[4];
                first_right_ending_value = new int[4];
                second_left_ending_value = new int[4];
                second_right_ending_value = new int[4];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Encryption", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        public void run_decryption()
        {
            try
            {
                result_txtbx.Clear();

                int[] plaintext = new int[8];
                int[] start_key = new int[10];
                //{ 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 };

                char[] get_plaintext_text = text_txtbx.Text.ToCharArray();

                for (int i = 0; i < 8; i++)
                {
                    plaintext[i] = (int)Char.GetNumericValue(get_plaintext_text[i]);
                }

                char[] get_key_text = key_txtbx.Text.ToCharArray();

                for (int i = 0; i < 10; i++)
                {
                    start_key[i] = (int)Char.GetNumericValue(get_key_text[i]);
                }

                GenerateKey(start_key);

                StartDecryption(plaintext);


                for (int i = 0; i < 8; i++)
                {
                    result_txtbx.Text += ending_eight[i].ToString();
                }

                original_eight = new int[8];
                ending_eight = new int[8];
                second_ending_eight = new int[8];
                right_four = new int[4];
                left_four = new int[4];
                key_one = new int[8];
                key_two = new int[8];
                first_left_ending_value = new int[4];
                first_right_ending_value = new int[4];
                second_left_ending_value = new int[4];
                second_right_ending_value = new int[4];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Decryption", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void encryption_btn_Click(object sender, EventArgs e)
        {
            run_encryption();
        }

        private void decryption_btn_Click(object sender, EventArgs e)
        {
            run_decryption();

        }
    }
}
