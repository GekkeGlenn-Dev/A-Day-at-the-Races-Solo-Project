using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ADayAtTheRace
{
    class Greyhound
    {
        public int StartingPosition { get; set; } // Where my PictureBox starts
        public int RacetrackLength { get; set; } // How long the racetrack is
        public PictureBox MyPictureBox { get; set; } // My PictureBox object
        public int Location = 0; // My Location on the racetrack
        public Random Randomizer = new Random(); // An instance of Random

        public bool Run()
        {
            // Move forward either 1, 2, 3 or 4 spaces at random
            // Update the position of my PictureBox on the form
            // Return true if I won the race

            int moveFoward = Randomizer.Next(1, 4);

            Point p = this.MyPictureBox.Location;
            p.X += moveFoward;
            this.MyPictureBox.Location = p;

            if (p.X >= RacetrackLength) return true;
            else return false;
        }

        public void TakeStartingPosition()
        {
            this.MyPictureBox.Left = this.StartingPosition;
        }
    }
}
