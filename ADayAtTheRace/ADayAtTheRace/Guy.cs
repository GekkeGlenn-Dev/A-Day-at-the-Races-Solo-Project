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
        public Bet MyBet { get; set; }// An instance of Bet() that has his bet
        public int Cash { get; set; } // How much cash he has
                                      
        // The last two fields are the guy’s GUI controls on the form
        public RadioButton MyRadioButton { get; set; } // My RadioButton
        public Label MyLabel { get; set; } // My Label

        public void UpdateLabel()
        {
            //set my label to my bet's description, and the label on my
            //radio button to show my cash ("Joe, Geld: € 43,00")
            //this.MyLabel.Text = MyBet.GetDescription();
            MyBet.Bettor = this;
            this.MyLabel.Text = this.MyBet.GetDescription();
            this.MyRadioButton.Text = string.Format("{0}, Geld: €{1},-", this.Name, this.Cash);
            
        }

        public bool PlaceBet(int amount, int dog)
        {
            // Place a new bet and store it in my bet field
            // Return true if the guy had enough money to bet
            
            if (this.Cash >= amount)
            {
                MyBet = new Bet();
                this.MyBet.Amount = amount;
                this.MyBet.Dog = dog;
                return true;
            }
            else
            {
                MessageBox.Show(string.Format("{0} heeft niet genoeg geld om in te zetten",this.Name));
                return false;
            }
        }

        public void ClearBet() //reset my bet so it's zero
        {
            this.MyBet.Amount = 0;
            this.MyBet.GetDescription();
        }

        public void Collect(int Winner) { this.MyBet.PayOut(Winner); } // Ask my bet to pay out
    }
}
