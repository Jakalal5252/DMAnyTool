using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DMAnyTool
{
    class CRCalcPage : ContentPage
    {
        Picker partySizePicker0;
        Picker partySizePicker1;
        Picker partySizePicker2;
        Picker partySizePicker3;

        Picker partyLevelPicker0;
        Picker partyLevelPicker1;
        Picker partyLevelPicker2;
        Picker partyLevelPicker3;

        Picker monsterNumberPicker0;
        Picker monsterNumberPicker1;
        Picker monsterNumberPicker2;
        Picker monsterNumberPicker3;

        Picker monsterCRPicker0;
        Picker monsterCRPicker1;
        Picker monsterCRPicker2;
        Picker monsterCRPicker3;

        Label partyLevelResult;
        Label monsterCRResult;
        Label difficultyResult;


        public CRCalcPage()
        {
            const int MAX_PARTY_SIZE = 8;
            const int MAX_PLAYER_LEVEL = 20;
            const int MAX_MONSTER_COUNT = 10;
            const int MAX_MONSTER_CR = 25;

            string[] monsterFractionCRs = new string[6] { "1/10", "1/8", "1/6", "1/4", "1/3", "1/2" };
            Padding = new Thickness(20, 20, 20, 20);

            #region PartyInputs

            Label partyHeader = new Label
            {
                Text = "Party Composition",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            Label partySizeInputLabel = new Label
            {
                Text = "Number:",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            };
            Label partyLevelInputLabel = new Label
            {
                Text = "Level:",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            };
            partySizePicker0 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            partySizePicker1 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            partySizePicker2 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            partySizePicker3 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            int i;
            for (i = 0; i <= MAX_PARTY_SIZE; i++)
            {
                if (i != 0)
                {
                    partySizePicker0.Items.Add(i.ToString());
                }
                partySizePicker1.Items.Add(i.ToString());
                partySizePicker2.Items.Add(i.ToString());
                partySizePicker3.Items.Add(i.ToString());
            }
            partySizePicker0.SelectedIndex = 3;
            partySizePicker1.SelectedIndex = 0;
            partySizePicker2.SelectedIndex = 0;
            partySizePicker3.SelectedIndex = 0;
            partyLevelPicker0 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            partyLevelPicker1 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            partyLevelPicker2 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            partyLevelPicker3 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            for (i = 1; i <= MAX_PLAYER_LEVEL; i++)
            {
                partyLevelPicker0.Items.Add(i.ToString());
                partyLevelPicker1.Items.Add(i.ToString());
                partyLevelPicker2.Items.Add(i.ToString());
                partyLevelPicker3.Items.Add(i.ToString());
            }

            partyLevelPicker0.SelectedIndex = 0;
            partyLevelPicker1.SelectedIndex = 1;
            partyLevelPicker2.SelectedIndex = 2;
            partyLevelPicker3.SelectedIndex = 3;
            #endregion PartyInputs

            #region MonsterInputs
            Label monsterHeader = new Label
            {
                Text = "Monsters",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            monsterNumberPicker0 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            monsterNumberPicker1 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            monsterNumberPicker2 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            monsterNumberPicker3 = new Picker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            for (i = 0; i <= MAX_MONSTER_COUNT; i++)
            {
                if (i != 0)
                {
                    monsterNumberPicker0.Items.Add(i.ToString());
                }
                monsterNumberPicker1.Items.Add(i.ToString());
                monsterNumberPicker2.Items.Add(i.ToString());
                monsterNumberPicker3.Items.Add(i.ToString());
            }
            monsterNumberPicker0.SelectedIndex = 0;
            monsterNumberPicker1.SelectedIndex = 0;
            monsterNumberPicker2.SelectedIndex = 0;
            monsterNumberPicker3.SelectedIndex = 0;

            Label monsterNumberInputLabel = new Label
            {
                Text = "Number:",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            };
            Label monsterLevelInputLabel = new Label
            {
                Text = "Level:",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            };
            monsterCRPicker0 = new Picker
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,

            };
            monsterCRPicker1 = new Picker
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            monsterCRPicker2 = new Picker
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            monsterCRPicker3 = new Picker
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            foreach (string s in monsterFractionCRs)
            {
                monsterCRPicker0.Items.Add(s);
                monsterCRPicker1.Items.Add(s);
                monsterCRPicker2.Items.Add(s);
                monsterCRPicker3.Items.Add(s);
            }

            for (i = 1; i <= MAX_MONSTER_CR; i++)
            {
                monsterCRPicker0.Items.Add(i.ToString());
                monsterCRPicker1.Items.Add(i.ToString());
                monsterCRPicker2.Items.Add(i.ToString());
                monsterCRPicker3.Items.Add(i.ToString());
            }
            monsterCRPicker0.SelectedIndex = 6;
            monsterCRPicker1.SelectedIndex = 6;
            monsterCRPicker2.SelectedIndex = 6;
            monsterCRPicker3.SelectedIndex = 6;
            #endregion MonsterInputs

            Button calcButton = new Button
            {
                Text = "Calculate CR",
                HorizontalOptions = LayoutOptions.Start,
            };

            Label resultsHeader = new Label
            {
                Text = "Results-",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label partyLevelLabel = new Label
            {
                Text = "Party Level:",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            partyLevelResult = new Label
            {
                Text = "0",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            Label monsterNumberLabel = new Label
            {
                Text = "Monster CR:",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            monsterCRResult = new Label
            {
                Text = "0",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            Label difficultyLabel = new Label
            {
                Text = "Difficulty:",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            difficultyResult = new Label
            {
                Text = string.Empty,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };

            // Build the page.
            Content = new StackLayout
            {
                Children =
                {
                    partyHeader,
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { partySizeInputLabel, partyLevelInputLabel}
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = {partySizePicker0, partyLevelPicker0}
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = {partySizePicker1, partyLevelPicker1 }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = {partySizePicker2, partyLevelPicker2 }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = {partySizePicker3, partyLevelPicker3 }
                    },
                    monsterHeader,
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { monsterNumberInputLabel, monsterLevelInputLabel }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { monsterNumberPicker0, monsterCRPicker0 },
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { monsterNumberPicker1, monsterCRPicker1 }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { monsterNumberPicker2, monsterCRPicker2 }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { monsterNumberPicker3, monsterCRPicker3 }
                    },
                    calcButton,
                    resultsHeader,
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { partyLevelLabel, partyLevelResult }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { monsterNumberLabel, monsterCRResult }
                    },
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { difficultyLabel, difficultyResult}
                    },
                }
            };


            calcButton.Clicked += OnCalcButtonClicked;
        }

        public void OnCalcButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string[] partySizeArray = new string[] { partySizePicker0.Items[partySizePicker0.SelectedIndex],
                                                            partySizePicker1.Items[partySizePicker1.SelectedIndex],
                                                            partySizePicker2.Items[partySizePicker2.SelectedIndex],
                                                            partySizePicker3.Items[partySizePicker3.SelectedIndex] };
            string[] partyLevelArray = new string[] { partyLevelPicker0.Items[partyLevelPicker0.SelectedIndex],
                                                            partyLevelPicker1.Items[partyLevelPicker1.SelectedIndex],
                                                            partyLevelPicker2.Items[partyLevelPicker2.SelectedIndex],
                                                            partyLevelPicker3.Items[partyLevelPicker3.SelectedIndex]};

            string[] monsterNumberArray = new string[] {monsterNumberPicker0.Items[monsterNumberPicker0.SelectedIndex],
                                                            monsterNumberPicker1.Items[monsterNumberPicker1.SelectedIndex],
                                                            monsterNumberPicker2.Items[monsterNumberPicker2.SelectedIndex],
                                                            monsterNumberPicker3.Items[monsterNumberPicker3.SelectedIndex] };

            string[] monsterCRArray = new string[] { monsterCRPicker0.Items[monsterCRPicker0.SelectedIndex],
                                                            monsterCRPicker1.Items[monsterCRPicker1.SelectedIndex],
                                                            monsterCRPicker2.Items[monsterCRPicker2.SelectedIndex],
                                                            monsterCRPicker3.Items[monsterCRPicker3.SelectedIndex]};


            partyLevelResult.Text = CalcCRMath.CalculatePartyLevel(partySizeArray, partyLevelArray);
            monsterCRResult.Text = CalcCRMath.CalculateMonsterCR(monsterNumberArray, monsterCRArray);
            difficultyResult.Text = CalcCRMath.CalculateDifficulty(partyLevelResult.Text, monsterCRResult.Text);
        }
    }
}
