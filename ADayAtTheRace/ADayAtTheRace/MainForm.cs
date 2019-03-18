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

        int minimumBet = 5;
        int maximumBet = 15;
        int raceTrackLength;
        int houndStartLocation;

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
            Guy[0] = new Guy() { Name = "Joe", Cash = 50, MyRadioButton = joeRadioButton, MyLabel = joeBetsLabel };
            //Create profile Bob
            Guy[1] = new Guy() { Name = "Bob", Cash = 75, MyRadioButton = bobRadioButton, MyLabel = bobBetsLabel };
            //Create profile Al
            Guy[2] = new Guy() { Name = "Al", Cash = 45, MyRadioButton = alRadioButton, MyLabel = alBetsLabel };
            

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
                Guy[i].PlaceBet(0, 0);
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
            int betAmount = (int)betAmmountUpAndDown.Value;
            int choosedDog = (int)dogUpDown.Value;

            //BetSystem(selectedGuy, betAmount, choosedDog);
            Guy[selectedGuy].PlaceBet((int)betAmmountUpAndDown.Value, (int)dogUpDown.Value);
            Guy[selectedGuy].UpdateLabel();
        }

        private void startRaceButton_Click(object sender, EventArgs e)
        {
            startRaceButton.Enabled = false;
            submitBet.Enabled = false;
            while (true)
            {
                for (int i = 0; i < Greyhound.Length; i++)
                {
                    Thread.Sleep(6);
                    Random randomizer = new Random();
                    Greyhound[randomizer.Next(0, 4)].Run();
                    if (Greyhound[i].Run())
                    {
                        SelectWinner(i + 1);
                        return;
                    }
                }
            }
        }
        
        private void SelectWinner(int Winner)
        {
            MessageBox.Show("Hond " + Winner + " is de Winnaar!");
                
            for (int i = 0; i < Guy.Length; i++)
            {
                Guy[i].Collect(Winner);
                Guy[i].UpdateLabel();
                Guy[i].ClearBet();
            }
            for (int i = 0; i < Greyhound.Length; i++)
            {
                Greyhound[i].TakeStartingPosition();
            }
            submitBet.Enabled = true;
            startRaceButton.Enabled = true;
        }

        private void bettorParlorGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
