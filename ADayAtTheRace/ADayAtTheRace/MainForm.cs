using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRace
{
    public partial class MainForm : Form
    {
        Greyhound[] Greyhound = new Greyhound[4];
        Guy[] Guy = new Guy[3];
        Bet[] Bet = new Bet[3];

        //Guy joe = new Guy();
        Guy bob = new Guy();
        Guy al = new Guy();

        //Bet joeBet = new Bet();
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

        int selectedGuy = 0;

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
           

            //Create profile Joe
            Guy[0] = new Guy() { Name = "Joe", Cash = joeStartCash, MyRadioButton = joeRadioButton, MyLabel = joeBetsLabel, MyBet = Bet[0] };
            Bet[0] = new Bet() { Amount = 0, Bettor = Guy[0] };
            //Create profile Bob
            Guy[1] = new Guy() { Name = "Bob", Cash = bobStartCash, MyRadioButton = bobRadioButton, MyLabel = bobBetsLabel, MyBet = Bet[1] };
            Bet[1] = new Bet() { Amount = 0, Bettor = Guy[1] };
            //Create profile Al
            Guy[2] = new Guy() { Name = "Al", Cash = alStartCash, MyRadioButton = alRadioButton, MyLabel = alBetsLabel, MyBet = Bet[2] };
            Bet[2] = new Bet() { Amount = 0, Bettor = Guy[2] };

            //create hounds 1, 2, 3 and 4
            Greyhound[0] = new Greyhound() { StartingPosition = houndStartLocation, RacetrackLength = raceTrackLength, MyPictureBox = grayHound1ImageBox };
            Greyhound[1] = new Greyhound() { StartingPosition = houndStartLocation, RacetrackLength = raceTrackLength, MyPictureBox = grayHound2ImageBox };
            Greyhound[2] = new Greyhound() { StartingPosition = houndStartLocation, RacetrackLength = raceTrackLength, MyPictureBox = grayHound3ImageBox };
            Greyhound[3] = new Greyhound() { StartingPosition = houndStartLocation, RacetrackLength = raceTrackLength, MyPictureBox = grayHound4ImageBox };

            //set the bet minimum and maximum amount
            betAmmountUpAndDown.Minimum = minimumBet;
            betAmmountUpAndDown.Maximum = maximumBet;


            //add text in textboxes
            for (int i = 0; i < Guy.Length; i++)
            {
                Guy[i].MyLabel.Text = string.Format("{0} Heeft nog niks ingezet!", Guy[i].Name);
                Guy[i].UpdateLabel();
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedGuyLabel.Text = Guy[0].Name;
            selectedGuy = 0;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedGuyLabel.Text = Guy[1].Name;
            selectedGuy = 1;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedGuyLabel.Text = Guy[2].Name;
            selectedGuy = 2;
        }

        private void submitBet_Click(object sender, EventArgs e)
        {
            BetSystem(selectedGuy, (int)betAmmountUpAndDown.Value, (int)dogUpDown.Value);
        
        }

        private void startRaceButton_Click(object sender, EventArgs e)
        {
            while (true)
            {
                for (int i = 0; i < Greyhound.Length; i++)
                {
                    Thread.Sleep(6);
                    Random randomizer = new Random();
                    Greyhound[randomizer.Next(0, 4)].Run();
                    if (Greyhound[i].Run() == true)
                    {
                        SelectWinner(i + 1);
                        return;
                    }
                }
            }
        }
        
        private void SelectWinner(int Winner)
        {
            MessageBox.Show("Dog " + Winner + " is the Winner!");
            for (int i = 0; i < 3; i++)
            {
                Guy[i].Collect(Winner);
                Guy[i].UpdateLabel();
                for (int a = 0; a < Greyhound.Length; a++)
                {
                    Greyhound[i].TakeStartingPosition();
                }
                for (int j = 0; j < Guy.Length; j++)
                {
                    Guy[i].ClearBet();
                }
            }
        }

        private void BetSystem(int bettor, int newBetAmount, int chosenDog)
        {
            if (Guy[bettor].MyRadioButton.Checked)
            {
                int amountChange;

                int oldBetAmount = Bet[bettor].Amount;

                if (Guy[bettor].PlaceBet(newBetAmount, chosenDog) == true)
                {
                    //checks of the new bet is smaller then the old bet
                    if (oldBetAmount > newBetAmount)
                    {
                        amountChange = oldBetAmount - newBetAmount;
                        Guy[bettor].Cash += amountChange;
                        Bet[bettor].Amount = newBetAmount;
                        Guy[bettor].UpdateLabel();
                        Guy[bettor].MyLabel.Text = Bet[bettor].GetDescription();
                    }
                    //checks of the new bet is greater then the old bet
                    else if (oldBetAmount <= newBetAmount)
                    {
                        amountChange = newBetAmount - oldBetAmount;
                        Guy[bettor].Cash -= amountChange;
                        Bet[bettor].Amount = newBetAmount;
                        Guy[bettor].UpdateLabel();
                        Guy[bettor].MyLabel.Text = Bet[bettor].GetDescription();
                    }
                    else
                    {
                        MessageBox.Show("er is iets fout gegeaan");
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("{0} heeft niet genoeg om het geld bedrag (€ {1},-) in te zetten", Guy[bettor].Name, (int)betAmmountUpAndDown.Value));
                }
            }
            else
            {
                MessageBox.Show("Er is niemand geselecteerd!");
            
            }
        }
    }
}
