using PlayAudio_XF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlayAudio_XF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdPage : ContentPage
    {
        public ThirdPage()
        {
            InitializeComponent();
        }

        private void btnPlayLocal_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAudio>().PlayLocalFile(3);

            //await Navigation.PushAsync(new ThirdPage());

            DisplayAlert("Fin", "Fin de la presentacion", "OK");

        }
    }
}