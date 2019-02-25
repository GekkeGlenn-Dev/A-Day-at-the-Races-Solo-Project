using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRace
{
    public partial class MainForm : Form
    { 
        Greyhound hound1 = new Greyhound();
        Greyhound hound2 = new Greyhound();
        Greyhound hound3 = new Greyhound();
        Greyhound hound4 = new Greyhound();

        Guy joe = new Guy();
        Guy bob = new Guy();
        Guy al = new Guy();
        
        Bet joeBet = new Bet();
        Bet bobBet = new Bet();
        Bet alBet = new Bet();

        int minimumBet = 5;
        int maximumBet = 15;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //create profile of joe
            joe.Name = "Joe";
            joe.Cash = 50;
            joe.MyRadioButton = joeRadioButton;
            joe.MyLabel = joeBetsLabel;
            joe.UpdateLabel();

            //create profile of Bob
            bob.Name = "Bob";
            bob.Cash = 50;
            bob.MyRadioButton = bobRadioButton;
            bob.MyLabel = bobBetsLabel;
            bob.UpdateLabel();

            //create profile of Al
            al.Name = "Al";
            al.Cash = 50;
            al.MyRadioButton = alRadioButton;
            al.MyLabel = alBetsLabel;
            al.UpdateLabel();

            betAmmountUpAndDown.Minimum = minimumBet;
            betAmmountUpAndDown.Maximum = maximumBet;

        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedGuyLabel.Text = joe.Name;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedGuyLabel.Text = bob.Name;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedGuyLabel.Text = al.Name;
        }

        private void submitBet_Click(object sender, EventArgs e)
        {
            
            if (selectedGuyLabel.Text == "Joe")
            {
                joeBet.PlaceBet(Convert.ToInt32(betAmmountUpAndDown.Value), Convert.ToInt32(dogUpDown.Value));
            //    joeBet.Bettor = joe;
            //    joeBet.Amount = Convert.ToInt32(betAmmountUpAndDown.Value);
            //    joeBet.Dog = Convert.ToInt32(dogUpDown.Value);
            //    joeBet.GetDescription();
            }
            else if (selectedGuyLabel.Text == "Bob")
            {
            //    bobBet.Bettor = bob;
            //    bobBet.Amount = Convert.ToInt32(betAmmountUpAndDown.Value);
            //    bobBet.Dog = Convert.ToInt32(dogUpDown.Value);
            //    bobBet.GetDescription();
            }
            else if (selectedGuyLabel.Text == "Al")
            {
            //    alBet.Bettor = al;
            //    alBet.Amount = Convert.ToInt32(betAmmountUpAndDown.Value);
            //    alBet.Dog = Convert.ToInt32(dogUpDown.Value);
            //    alBet.GetDescription();
            }
            else
            {

            }
        }
    }
}
