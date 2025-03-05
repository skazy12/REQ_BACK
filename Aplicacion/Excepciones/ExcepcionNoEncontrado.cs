using System;
using System.Net;

namespace Aplicacion.Excepciones
{
    public class ExcepcionNoEncontrado : ExcepcionBase
    {
        public HttpStatusCode CodigoEstado { get; }

        public ExcepcionNoEncontrado(string mensaje)
            : base(mensaje)
        {
            CodigoEstado = HttpStatusCode.NotFound;
        }
    }
}
