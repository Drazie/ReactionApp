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
            
            var btn = sender as Button;
            btn.IsVisible = false;
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {

                btn.IsVisible = true;
                return false;
            });
        }

        public class ReactionTest
        {
            //var tapGestureRecognizer = new TapGestureRecognizer();
            //tapGestureRecognizer.Tapped += (s, e) => {
                // handle the tap
            //};
        }
    }
}
