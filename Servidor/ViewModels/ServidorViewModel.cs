using Servidor.Models;
using Servidor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.ViewModels
{
    public class ServidorViewModel : INotifyPropertyChanged
    {

        public Preguntas preguntas { get; set; } = new();

        private int Res1 { get; set; }
        private int Res2 { get; set; }
        private int Res3 { get; set; }

        //private int vot1P1 = 32;
        //public int Vot1P1
        //{
        //    get { return vot1P1; }
        //    set { vot1P1 = value; Actualizar(nameof(Vot1P1));}
        //}
        //private int vot2P1;
        //public int Vot2P1
        //{
        //    get { return vot2P1; }
        //    set { vot2P1 = value; Actualizar(nameof(Vot2P1));}
        //}
        //private int vot3P1;
        //public int Vot3P1
        //{
        //    get { return vot3P1; }
        //    set { vot3P1 = value; Actualizar(nameof(Vot3P1));}
        //}
        //private int vot4P1;
        //public int Vot4P1
        //{
        //    get { return vot4P1; }
        //    set { vot4P1 = value; Actualizar(nameof(Vot4P1));}
        //}
        //private int vot5P1;
        //public int Vot5P1
        //{
        //    get { return vot5P1; }
        //    set { vot5P1 = value; Actualizar(nameof(Vot5P1));}
        //}
        public int Vot1P1 { get; set; }
        public int Vot2P1 { get; set; }
        public int Vot3P1 { get; set; }
        public int Vot4P1 { get; set; }
        public int Vot5P1 { get; set; }

        public int Vot1P2 { get; set; }
        public int Vot2P2 { get; set; }
        public int Vot3P2 { get; set; }
        public int Vot4P2 { get; set; }
        public int Vot5P2 { get; set; }

        public int Vot1P3 { get; set; }
        public int Vot2P3 { get; set; }
        public int Vot3P3 { get; set; }
        public int Vot4P3 { get; set; }
        public int Vot5P3 { get; set; }

        public int Total => Vot1P1 + Vot2P1 + Vot3P1 + Vot4P1 + Vot5P1;

        ServidorService service = new();

        public ServidorViewModel()
        {
            service.Iniciar();
            service.VotoRecibido += Service_VotoRecibido; ;
        }

        private void Service_VotoRecibido(Votos obj)
        {
            Res1 = obj.Vot1;
            Res2 = obj.Vot2;
            Res3 = obj.Vot3;

            switch (Res1)
            {
                case 1: Vot1P1++; break;
                case 2: Vot2P1++; break;
                case 3: Vot3P1++; break;
                case 4: Vot4P1++; break;
                case 5: Vot5P1++; break;
            }
            switch (Res2)
            {
                case 1: Vot1P2++; break;
                case 2: Vot2P2++; break;
                case 3: Vot3P2++; break;
                case 4: Vot4P2++; break;
                case 5: Vot5P2++; break;
            }
            switch (Res3)
            {
                case 1: Vot1P3++; break;
                case 2: Vot2P3++; break;
                case 3: Vot3P3++; break;
                case 4: Vot4P3++; break;
                case 5: Vot5P3++; break;
            }

            Actualizar();
        }

        public void Actualizar(string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
