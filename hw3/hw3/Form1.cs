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
        public Form1()
        {
            InitializeComponent();
        }




        public void run ()
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
    }
}
