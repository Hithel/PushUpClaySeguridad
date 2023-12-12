
using Domain.Entities;

namespace Domain.Interfaces;
    public interface IPersona : IGenericRepo<Persona>
    {
        Task<IEnumerable<Object>> GetEmpleadosSeguridad();
        Task<(int totalRegistros, IEnumerable<Object> registros)> GetEmpleadosSeguridadPaginado(int pageIndex, int pageSize, string search = null);

         
        Task<IEnumerable<Object>> GetVigilantes();
        Task<(int totalRegistros, IEnumerable<Object> registros)> GetVigilantesPaginado(int pageIndex, int pageSize, string search = null);


        Task<IEnumerable<Object>> GetNumerosEmpleados();
        Task<(int totalRegistros, IEnumerable<Object> registros)> GetNumerosEmpleadosPaginados(int pageIndex, int pageSize, string search = null);
    }
