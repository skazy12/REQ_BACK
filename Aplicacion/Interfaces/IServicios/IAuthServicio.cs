using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.IServicios
{
    public interface IAuthServicio
    {
        Task<string> LoginAsync(string username, string password);
    }

}
