using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reaction
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        

        void StartTestButton_Clicked(System.Object sender, System.EventArgs e)
        {
            AppLabel.IsVisible = false;
            StartTestButton.IsVisible = false;
            Random random = new Random();
            var initialTime = DateTime.Now;
            int randomStart = random.Next(1, 5);
            var timeOfStart = initialTime.AddSeconds(randomStart);

            Device.StartTimer(TimeSpan.FromSeconds(randomStart), () =>
            {
                Main.BackgroundColor = Color.Green;

                var tapGestureRecognizer = new TapGestureRecognizer();                              
                tapGestureRecognizer.Tapped += (s, et) => {
                    OnTap(Color.AliceBlue);
                    var timeOfClick = DateTime.Now;
                    var result = timeOfClick - timeOfStart;
                    resultLabel.Text = $"Your time is {result.Seconds}.{result.Milliseconds}";
                    Main.GestureRecognizers.Remove(tapGestureRecognizer);
                    if (result.Milliseconds > 400 && result.Seconds < 1)
                    {
                        resultDescription.Text = "Lol.";
                    }
                    else if (result.Milliseconds > 300 && result.Milliseconds < 400 && result.Seconds < 1)
                    {
                        resultDescription.Text = "I see the silver in the house.";
                    }
                    else if (result.Milliseconds > 180 && result.Milliseconds < 300 && result.Seconds < 1)
                    {
                        resultDescription.Text = "Conformist.";
                    }
                    else if (result.Milliseconds > 90 && result.Milliseconds < 180 && result.Seconds < 1)
                    {
                        resultDescription.Text = "Whait, what?";
                    }
                    else if (result.Milliseconds < 90 && result.Seconds < 1)
                    {
                        resultDescription.Text = "YOOOLOOOO.";
                    }
                    else if (result.Seconds > 1)
                    {
                        resultDescription.Text = "Are you sleeping?";
                    }
                };
                Main.GestureRecognizers.Add(tapGestureRecognizer);
                return false;
            });
            
        }

        

        void NewTestButton_Clicked(System.Object sender, System.EventArgs e)
        {
            NewTestButton.IsVisible = false;
            resultLabel.IsVisible = false;
            sizeGridRow0.IsVisible = false;
            sizeGridRow1.IsVisible = false;
            resultDescription.IsVisible = false;
            StartTestButton.IsVisible = true;
        }


        public void OnTap(Color color)
        {
            Main.BackgroundColor = color;
            resultDescription.IsVisible = true;
            resultLabel.IsVisible = true;
            AppLabel.IsVisible = true;
            sizeGridRow1.IsVisible = true;
            NewTestButton.IsVisible = true;
        }

        void StatsButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new StatsPage());
        }
    }
}
