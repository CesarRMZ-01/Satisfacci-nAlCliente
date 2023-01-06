using Cliente.Models;
using Cliente.Services;
using Cliente.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Cliente.ViewModels
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        ClienteService service = new ClienteService();

        public Votos voto { get; set; }
        public string Error { get; set; }

        public Preguntas p { get; set; } = new Preguntas();

        private int votP1 = 1;

        public int VotP1
        {
            get { return votP1; }
            set { votP1 = value; Actualizar(nameof(VotP3)); }
        }
        private int votP2 = 1;

        public int VotP2
        {
            get { return votP2; }
            set { votP2 = value; Actualizar(nameof(VotP3)); }
        }
        private int votP3 = 1;

        public int VotP3
        {
            get { return votP3; }
            set { votP3 = value; Actualizar(nameof(VotP3)); }
        }


        public Command VotarCommand { get; set; }

        public Command Votar1Command { get; set; }
        public Command Votar2Command { get; set; }
        public Command Votar3Command { get; set; }


        public bool Votado { get; set; }

        public ClienteViewModel()
        {
            voto = new Votos();
            VotarCommand = new Command(Votar);

            Votar1Command = new Command<int>(Votar1);
            Votar2Command = new Command<int>(Votar2);
            Votar3Command = new Command<int>(Votar3);
        }


        private void Votar1(int obj)
        {
            votP1 = obj;
        }

        private void Votar2(int obj)
        {
            votP2 = obj;
        }
        private void Votar3(int obj)
        {
            votP3 = obj;
        }
        private async void Votar()
        {
            try
            {
                voto.Vot1 = votP1;
                voto.Vot2 = votP2;
                voto.Vot3 = votP3;

                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {

                    await service.VotarPost(voto);
                    Votado = false;
                    Actualizar();

                    GraciasView gracias = new GraciasView();
                    await Application.Current.MainPage.Navigation.PushAsync(gracias);

                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Actualizar(nameof(Error));
            }

        }

        public void Actualizar(string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
