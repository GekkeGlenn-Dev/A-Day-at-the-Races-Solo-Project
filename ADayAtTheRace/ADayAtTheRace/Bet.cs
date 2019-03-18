using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRace
{
    class Bet
    {
        public int Amount { get; set; } // The amount of cash that was bet
        public int Dog { get; set; } // The number of the dog the bet is on
        public Guy Bettor { get; set; } // The guy who placed the bet

        public string GetDescription()
        {
            //Return a string that says who placed the bet, how much
            //cash was bet, and which dog he bet on (“Joe bets 8 on
            //dog #4”). If the amount is zero, no bet was placed
            //(“Joe hasn’t placed a bet”).
            
            if (this.Amount == 0)
            {
                return string.Format("{0} heeft niks ingezet!", this.Bettor.Name);
            }
            else
            {
                return string.Format("{0} heeft € {1},- op hond #{2} ingezet", this.Bettor.Name, this.Amount.ToString(), this.Dog);
            }

        }

        public int PayOut(int Winner)
        {
            int WinnerDog = this.Dog;
            int amount = this.Amount;
            if (WinnerDog == Winner)
            {
                MessageBox.Show(string.Format("{0} heeft het geld gewonnen!", this.Bettor.Name));
                this.Bettor.ClearBet();
                return Bettor.Cash += amount * 2;
            }
            else
            {
                this.Bettor.ClearBet();
                return Bettor.Cash -= amount;
            }
        }
    }
}
