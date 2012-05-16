using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassesBasicas;

namespace IDAO
{
    public interface IDAOBurnDown
    {
        int SelectQtdDiasSprint(int idProjeto, int idSprint);
        double SelectQtdHorasPlanejadaSprint(int idProjeto, int idSprint);
        double SelectTamanhoRealizadoDia(int idProjeto, int idSprint, int dia);
    }
}