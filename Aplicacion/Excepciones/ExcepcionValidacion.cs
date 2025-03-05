using System;
using System.Net;

namespace Aplicacion.Excepciones
{
    public class ExcepcionValidacion : ExcepcionBase
    {
        public HttpStatusCode CodigoEstado { get; }

        public ExcepcionValidacion(string mensaje)
            : base(mensaje)
        {
            CodigoEstado = HttpStatusCode.UnprocessableEntity;
        }
    }
}
