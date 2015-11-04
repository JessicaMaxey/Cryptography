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
        int[] IP_box = { 2, 6, 3, 1, 4, 8, 5, 7 };
        int[] IP_inverse_box = { 4, 1, 3, 5, 7, 2, 8, 6 };
        int[] EP_box = { 4, 1, 2, 3, 2, 3, 4, 1 };

        public Form1()
        {
            InitializeComponent();
            run();
        }

        public void GenerateKey()
        {
            //generate key
            //take in 10 bits
            //Do a P10 {3 5 2 7 4 10 1 9 8 6}
            //take output from that  and spilt into 5 bits
            //then and do a 1 bit circular left shift on both
            //store for use in next shift
            //take out put of that, recombine into 10, take off the first 2 bits
            //Do a P8 {6 3 7 4 8 5 10 9}
            //output that key

            //with the output of the first LS-1, do a LS-2
            //recombine and do another P8 {6 3 7 4 8 5 10 9}
        }

        public void StartEncryption (int[] plaintext)
        {
            int count = 0;
            int j = 0;

            //Do the first IP on the original 
            for (int i = 0; i < 8; i++)
            {

                if (plaintext[i] == IP_box[j])
                {
                    original_eight[j] = plaintext[i];
                    j = 0;
                }
            }



            //break down the IP'd plaintext into 2 sets of 4 bits
            for (int i = 0; i < 4; i++)
            {
                right_four[count++] = original_eight[i];
            }

            count = 0;

            for (int i = 4; i < original_eight.Length; i++)
            {
                left_four[count++] = original_eight[i];
            }





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

            StartEncryption(plaintext);


        }
    }
}
