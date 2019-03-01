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
        private Random random = new Random();

        Greyhound[] Greyhound = new Greyhound[4];

        Guy joe = new Guy();
        Guy bob = new Guy();
        Guy al = new Guy();

        Bet joeBet = new Bet();
        Bet bobBet = new Bet();
        Bet alBet = new Bet();

        int minimumBet = 5;
        int maximumBet = 15;
        int raceTrackLength;
        int houndStartLocation;
        bool raceIsRunning;

        int joeStartCash = 50;
        int bobStartCash = 75;
        int alStartCash = 45;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //set the lengt of the race track and the start location of al dogs
            houndStartLocation = grayHound1ImageBox.Left;
            raceTrackLength = raceTrackImageBox.Width - grayHound1ImageBox.Right;

            minimumBetLabel.Text = string.Format("Minimale inzet: €{0},-",minimumBet);
            
            //create profile of joe
            joe.Name = "Joe";
            joe.Cash = joeStartCash;
            joe.MyRadioButton = joeRadioButton;
            joe.MyLabel = joeBetsLabel;
            joe.MyBet = joeBet;
            joe.UpdateLabel();
            joeBet.Bettor = joe;

            //create profile of Bob
            bob.Name = "Bob";
            bob.Cash = bobStartCash;
            bob.MyRadioButton = bobRadioButton;
            bob.MyLabel = bobBetsLabel;
            bob.MyBet = bobBet;
            bob.UpdateLabel();
            bobBet.Bettor = bob;

            //create profile of Al
            al.Name = "Al";
            al.Cash = alStartCash;
            al.MyRadioButton = alRadioButton;
            al.MyLabel = alBetsLabel;
            al.MyBet = alBet;
            al.UpdateLabel();
            alBet.Bettor = al;

            //create hounds 1, 2, 3 and 4
            Greyhound[0] = new Greyhound() { StartingPosition = houndStartLocation, RacetrackLength = raceTrackLength, MyPictureBox = grayHound1ImageBox };
            Greyhound[1] = new Greyhound() { StartingPosition = houndStartLocation, RacetrackLength = raceTrackLength, MyPictureBox = grayHound2ImageBox };
            Greyhound[2] = new Greyhound() { StartingPosition = houndStartLocation, RacetrackLength = raceTrackLength, MyPictureBox = grayHound3ImageBox };
            Greyhound[3] = new Greyhound() { StartingPosition = houndStartLocation, RacetrackLength = raceTrackLength, MyPictureBox = grayHound4ImageBox };

            //set the bet minimum and maximum amount
            betAmmountUpAndDown.Minimum = minimumBet;
            betAmmountUpAndDown.Maximum = maximumBet;


            //add text in textboxes
            joe.MyLabel.Text = string.Format("{0} Heeft nog niks ingezet!", joe.Name);
            bob.MyLabel.Text = string.Format("{0} Heeft nog niks ingezet!", bob.Name);
            al.MyLabel.Text = string.Format("{0} Heeft nog niks ingezet!", al.Name);
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
            int newBetAmount = (int)betAmmountUpAndDown.Value;

            if (joe.MyRadioButton.Checked)
            {
                int amountChange;

                int oldBetAmount = joeBet.Amount;

                if (joe.PlaceBet(newBetAmount, (int)dogUpDown.Value) == true)
                {
                    //checks of the new bet is smaller then the old bet
                    if (oldBetAmount > newBetAmount)
                    {
                        amountChange = oldBetAmount - newBetAmount;
                        joe.Cash += amountChange;
                        joeBet.Amount = newBetAmount;
                        joe.UpdateLabel();
                        joe.MyLabel.Text = joeBet.GetDescription();
                    }
                    //checks of the new bet is greater then the old bet
                    else if (oldBetAmount <= newBetAmount)
                    {
                        amountChange = newBetAmount - oldBetAmount;
                        joe.Cash -= amountChange;
                        joeBet.Amount = newBetAmount;
                        joe.UpdateLabel();
                        joe.MyLabel.Text = joeBet.GetDescription();
                    }
                    else
                    {
                        MessageBox.Show("er is iets fout gegeaan");
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("{0} heeft niet genoeg geld om het € {1},- in te zetten",joe.Name, (int)betAmmountUpAndDown.Value));
                }
            }
            else if (bob.MyRadioButton.Checked)
            {
                int amountChange;

                int oldBetAmount = bobBet.Amount;

                if (bob.PlaceBet(newBetAmount, (int)dogUpDown.Value) == true)
                {
                    //checks of the new bet is smaller then the old bet
                    if (oldBetAmount > newBetAmount)
                    {
                        amountChange = oldBetAmount - newBetAmount;
                        bob.Cash += amountChange;
                        bobBet.Amount = newBetAmount;
                        bob.UpdateLabel();
                        bob.MyLabel.Text = bobBet.GetDescription();
                    }
                    //checks of the new bet is greater then the old bet
                    else if (oldBetAmount <= newBetAmount)
                    {
                        amountChange = newBetAmount - oldBetAmount;
                        bob.Cash -= amountChange;
                        bobBet.Amount = newBetAmount;
                        bob.UpdateLabel();
                        bob.MyLabel.Text = bobBet.GetDescription();
                    }
                    else
                    {
                        MessageBox.Show("er is iets fout gegeaan");
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("{0} heeft niet genoeg geld om het € {1},- in te zetten", bob.Name, (int)betAmmountUpAndDown.Value));
                }
            }
            else if (al.MyRadioButton.Checked)
            {
                int amountChange;

                int oldBetAmount = alBet.Amount;

                if (al.PlaceBet(newBetAmount, (int)dogUpDown.Value) == true)
                {
                    //checks of the new bet is smaller then the old bet
                    if (oldBetAmount > newBetAmount)
                    {
                        amountChange = oldBetAmount - newBetAmount;
                        al.Cash += amountChange;
                        alBet.Amount = newBetAmount;
                        al.UpdateLabel();
                        al.MyLabel.Text = alBet.GetDescription();
                    }
                    //checks of the new bet is greater then the old bet
                    else if (oldBetAmount <= newBetAmount)
                    {
                        amountChange = newBetAmount - oldBetAmount;
                        al.Cash -= amountChange;
                        alBet.Amount = newBetAmount;
                        al.UpdateLabel();
                        al.MyLabel.Text = alBet.GetDescription();
                    }
                    else
                    {
                        MessageBox.Show("er is iets fout gegeaan");
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("{0} heeft niet genoeg geld om het € {1},- in te zetten", joe.Name, betAmmountUpAndDown.Value));
                }
            }
            else
            {
                MessageBox.Show("Er is niemand geselecteerd!");
            }
        }

        private void startRaceButton_Click(object sender, EventArgs e)
        {
            raceIsRunning = true;
            while (raceIsRunning == true)
            {
                for (int i = 0; i < Greyhound.Length; i++)
                {
                    //Thread.Sleep(6);
                    Greyhound[random.Next(0, 4)].Run();
                    if (Greyhound[i].Run())
                    {
                        raceIsRunning = false;
                    }
                }
            }
        }
    }
}
