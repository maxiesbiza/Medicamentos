using System;
using Xamarin.Forms;
using Plugin.LocalNotifications;
using System.Threading.Tasks;

namespace Notificaciones
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => InitializeComponent();

        void BtnNotification_Clicked(object seder, EventArgs e)
        {
            var time = _timePicker.Time;
            var date = _datePicker.Date;

            DateTime dateOnly = date.Date;
            var taim = dateOnly.ToString("d") + " " + time.ToString();

            detail1.Text = taim;

            DateTime dateTime = DateTime.Parse(taim, System.Globalization.CultureInfo.InvariantCulture);

            int lapso = 0;
            bool bande = true;
           
            if (Int32.TryParse(_entryLapso.Text, out lapso) && Int32.TryParse(_entryLapso.Text, out lapso))
            {
                lapso = Int32.Parse(_entryLapso.Text);
                detail2.Text = lapso.ToString();
            }
            else
            {
                DisplayAlert("ERROR", "Debe ingresar solo nuemeros enteros", "Aceptar");
                bande = false;
            }

            if (_entryMed.Text == null || dateTime < DateTime.Now || bande == false)
            {
                DisplayAlert("ERROR", "Algun valor fue mal asignado", "Aceptar");
            }            
            else
            {
                for (int i = 0; i < Int32.Parse(_entryInter.Text); i++)
                {
                    CrossLocalNotifications.Current.Show("Fundacion Ser Activo", _entryMed.Text, i, dateTime);
                    dateTime = dateTime.AddMinutes(lapso);
                }
            }
        }
    }
}
