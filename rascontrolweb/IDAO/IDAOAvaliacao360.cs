using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace IDAO
{
    public interface IDAOAvaliacao360
    {
        List<Avaliacao360> ConsultarAllAvaliacao360();
        Avaliacao360 ConsultarAvaliacao360Codigo(int codigo);
        List<Avaliacao360> ConsultarAllAvaliacao360Filtros(int codigo, string justificativa);
        void CadastrarAvaliacao360(Avaliacao360 avaliacao);
        void UpdateAvaliacao360(Avaliacao360 avaliacao);
        void DeleteAvaliacao360(int id);
    }
}
