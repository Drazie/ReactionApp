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
                    Main.BackgroundColor = Color.AliceBlue;
                    var timeOfClick = DateTime.Now;
                    var result = timeOfClick - timeOfStart;
                    resultLabel.Text = $"Your time is {result.Seconds}.{result.Milliseconds}";
                    resultLabel.IsVisible = true;
                    AppLabel.IsVisible = true;
                    sizeGridRow1.IsVisible = true;
                    NewTestButton.IsVisible = true;
                    Main.GestureRecognizers.Remove(tapGestureRecognizer);
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
            StartTestButton.IsVisible = true;
        }

    }
}
