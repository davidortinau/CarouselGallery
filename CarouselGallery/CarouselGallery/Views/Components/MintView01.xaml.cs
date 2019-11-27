using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarouselGallery.Views.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MintView01 
    {
        public MintView01()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.DisplayAlert("You Did It!",
                "Thanks for tapping. There is no activity to see at this time. Have a nice day!",
                "Bye!");
        }
    }
}