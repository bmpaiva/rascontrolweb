using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassesBasicas;

namespace IDAO
{
    public interface IDAOSprint
    {
        List<Sprint> ConsultarAllSprint();
        Sprint ConsultarSprintCodigo(int id_sprint);
        List<Sprint> ConsultarAllSprintFiltros(int idProjeto, string descricao);
        void CadastrarSprint(Sprint sprint);
        void UpdateSprint(Sprint sprint);
        void DeleteSprint(int id_sprint);
    }
}