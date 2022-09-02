using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingPairsGame
{
    public partial class UserControl1: UserControl
    {
        Label firstLabel = null;
        Label secondLabel = null;
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!","!","c","c","a","a","d","d",
            "k","k","x","x","s","s","z","z"
        };
        
        public UserControl1()
        {
            InitializeComponent();
            assignSymbols();
        }

        public void assignSymbols() {

            foreach (Control control in tableLayoutPanel1.Controls) {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomnumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomnumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomnumber);
                }
            }
        }

        private void labelClick(object sender, EventArgs e)
        {
            if (timer.Enabled == true)
                return;


            Label clickedLabel = sender as Label;

            if (clickedLabel != null) {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                //clickedLabel.ForeColor = Color.Black;

                if (firstLabel == null)
                {
                    firstLabel = clickedLabel;
                    firstLabel.ForeColor = Color.Black;

                    return;
                }

                secondLabel = clickedLabel;
                secondLabel.ForeColor = Color.Black;

                checkWinner();

                timer.Start();

            }

            
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            timer.Stop();
            if (firstLabel.Text != secondLabel.Text)
            {
                firstLabel.ForeColor = firstLabel.BackColor;
                secondLabel.ForeColor = secondLabel.BackColor;
            }
            firstLabel = null;
            secondLabel = null;
        }

        private void checkWinner()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label iconlabel = control as Label;

                if (iconlabel != null)
                {
                    if (iconlabel.ForeColor == iconlabel.BackColor)
                        return;
                }

            }

            MessageBox.Show("   You WON!!   ");
        }
    }
}
