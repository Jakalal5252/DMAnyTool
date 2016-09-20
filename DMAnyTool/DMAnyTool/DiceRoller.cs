using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DMAnyTool
{
    class DiceRoller : ContentPage
    {
        public DiceRoller()
        {
            Button rollDiceButton = new Button
            {
                Text = "Roll",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand

            };
            rollDiceButton.Clicked += RollDiceButton_Clicked;
            Content = new StackLayout
            {
                Children =
                {rollDiceButton }
            };
        }

        private void RollDiceButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
