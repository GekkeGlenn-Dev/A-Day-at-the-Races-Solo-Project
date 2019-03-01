using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRace
{
    class Guy
    {
        public string Name { get; set; } // The guy's name
        public Bet MyBet { get; set; } // An instance of Bet() that has his bet
        public int Cash { get; set; } // How much cash he has
                                      
        // The last two fields are the guy’s GUI controls on the form
        public RadioButton MyRadioButton { get; set; } // My RadioButton
        public Label MyLabel { get; set; } // My Label

        public void UpdateLabel()
        {
            //set my label to my bet's description, and the label on my
            //radio button to show my cash ("Joe, Geld: € 43,00")
            this.MyRadioButton.Text = string.Format("{0}, Geld: €{1},-", this.Name, this.Cash);
            
        }

        public bool PlaceBet(int amount, int dog)
        {
            // Place a new bet and store it in my bet field
            // Return true if the guy had enough money to bet
            
            if (this.Cash >= amount)
            {
                MyBet.Amount = amount;
                MyBet.Dog = dog - 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearBet() //reset my bet so it's zero
        {
            this.MyBet.Amount = 0;
            this.MyBet.GetDescription();
        }

        public void Collect(int Winner) { } // Ask my bet to pay out
    }
}
