using Newtonsoft.Json;
using Servidor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.Services
{
    public class ServidorService
    {
        public event Action<Votos>? VotoRecibido;

        public Preguntas preguntas { get; set; }

        HttpListener listener = new();

        //Constructor
        public ServidorService()
        {
            preguntas = new Preguntas();
            listener.Prefixes.Add("http://*:4566/votacion/");

        }

        public void Iniciar()
        {
            if (!listener.IsListening)
            {
                listener.Start();
                listener.BeginGetContext(ContextoRecibido, null);
            }
        }

        private void ContextoRecibido(IAsyncResult ar)
        {
            var context = listener.EndGetContext(ar);
            listener.BeginGetContext(ContextoRecibido, null);

            if (context.Request.Url != null)
            {

                if (context.Request.HttpMethod == "POST" && context.Request.Url.LocalPath == "/votacion/responder")
                {
                    var stream = new StreamReader(context.Request.InputStream);
                    var json = stream.ReadToEnd();

                    Votos? voto = JsonConvert.DeserializeObject<Votos>(json);

                    if (voto != null)
                    {
                        VotoRecibido?.Invoke(voto);
                        context.Response.StatusCode = 200;

                    }
                    else
                    {
                        context.Response.StatusCode = 404;
                    }

                    context.Response.Close();
                }
                else
                {
                    context.Response.StatusCode = 404;
                }
                context.Response.Close();


            }

        }
    }
}
