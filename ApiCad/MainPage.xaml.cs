using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ApiCad.Entidades;
using System.ComponentModel;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;

namespace ApiCad
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }


        public MainPage()
        {
            InitializeComponent();
        }

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            var emailPattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
            if (Regex.IsMatch(mailEntry.Text, emailPattern))
            {
                RestUser client = new RestUser();
                var usuario = await client.Get_user<User>("https://apicad.herokuapp.com/api/v1/usuarios/connect?email=" + mailEntry.Text + "&contraseña=" + passwordEntry.Text);
              
                if (usuario.Any() && usuario.First().usuario.email.Equals(mailEntry.Text) && usuario.First().usuario.contraseña.Equals(passwordEntry.Text))
                {
                    HomePage home_ = new HomePage();
                    await Application.Current.MainPage.Navigation.PushModalAsync(new HomePage());
                }
                else
                {
                    await DisplayAlert("Not match", "Oops, that's not a match", "OK");
                }
            }
            else
            {
                await DisplayAlert("Invalid", "E-Mail is invalid", "OK");
            }

        }

    }
}
