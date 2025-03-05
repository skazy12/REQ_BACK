using System;

namespace Aplicacion.Excepciones
{
    public abstract class ExcepcionBase : Exception
    {
        protected ExcepcionBase(string mensaje) : base(mensaje) { }
    }
}
