using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class Form1 : Form
    {
        bool turn = true;// true == x turn ,false = o turn;
        int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("made by zhouxiaojie","about");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;

            turn_count++;

            string tmp = turn_count.ToString();
            //MessageBox.Show(tmp);
            checkforWinner();
        }

        private void checkforWinner()
        {
            
            bool haveWinner = false;
            if (a1.Enabled == false && a1.Text == a2.Text && a2.Text == a3.Text)
                haveWinner = true;
            if (b1.Enabled == false && b1.Text == b2.Text && b2.Text == b3.Text)
                haveWinner = true;
            if (c1.Enabled == false && c1.Text == c2.Text && c2.Text == c3.Text)
                haveWinner = true;

            if (a1.Enabled == false && a1.Text == b1.Text && b1.Text == c1.Text)
                haveWinner = true;
            if (a2.Enabled == false && a2.Text == b2.Text && b2.Text == c2.Text)
                haveWinner = true;
            if (a3.Enabled == false && a3.Text == b3.Text && b3.Text == c3.Text)
                haveWinner = true;

            if (a1.Enabled == false && a1.Text == b2.Text && b2.Text == c3.Text)
                haveWinner = true;
            if (a3.Enabled == false && a3.Text == b2.Text && b2.Text == a1.Text)
                haveWinner = true;

            if(haveWinner)
            {
                disablebutton();
                string winner = "";
                if (!turn) winner = "X";
                else winner = "O";

                MessageBox.Show(winner + " wins !", "Yay!");
            }
            else
            {
                if (turn_count >= 9)
                    MessageBox.Show("Draw");
            }

        }

        private void disablebutton()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { };
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                turn = true;
                turn_count = 0;
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Text = "";
                    b.Enabled = true;
                }
            }
            catch { };
        }
    }
}
