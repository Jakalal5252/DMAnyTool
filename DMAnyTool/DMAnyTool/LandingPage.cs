using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DMAnyTool
{
    class LandingPage : ContentPage
    {
        public LandingPage()
        {
            Padding = new Thickness(20, 20, 20, 20);

            Label title = new Label
            {
                Text = "DM Any Tool",
                 HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };

            Button calcCRButton = new Button
            {
                Text = "Calculate CR",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            Button diceRollerButton = new Button
            {
                Text = "Dice Roller",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            calcCRButton.Clicked += calcButton_Clicked;
            diceRollerButton.Clicked += diceRollerButton_Clicked;

            Content = new StackLayout
            {
                Children =
                {title, calcCRButton, diceRollerButton }
            };

        }

        void calcButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new CRCalcPage());
        }

        void diceRollerButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new DiceRoller());
        }
    }
}
