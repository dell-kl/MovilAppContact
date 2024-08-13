using FormularioSesion.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FormularioSesion.Services
{
    public interface IPaisesInfo
    {
        Task<ICollection<PaisInfo>> ObtenerPaises();
    }
}
