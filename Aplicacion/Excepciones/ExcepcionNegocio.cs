using System;
using System.Net;

namespace Aplicacion.Excepciones
{
    public class ExcepcionNegocio : ExcepcionBase
    {
        public HttpStatusCode CodigoEstado { get; }

        public ExcepcionNegocio(string mensaje, HttpStatusCode codigoEstado = HttpStatusCode.BadRequest)
            : base(mensaje)
        {
            CodigoEstado = codigoEstado;
        }
    }
}
