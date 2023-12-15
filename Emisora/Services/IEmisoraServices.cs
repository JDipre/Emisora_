using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emisora.Services
{
    public interface IEmisoraServices
    {
        public Task<List<Emisora>> Obtener();
    }
}
