using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassesBasicas;

namespace IDAO
{
    public interface IDAOImpedimentos
    {
        List<Impedimentos> ConsultarAllImpedimentos();
        Impedimentos ConsultarImpedimentoCodigo(int id_impedimento);
        List<Impedimentos> ConsultarAllImpedimentoFiltros(int id_impedimento, int id_sprint, string descricao);

        void CadastrarImpedimento(Impedimentos impedimentos);
        void UpdateImpedimento(Impedimentos impedimentos);
        void DeleteImpedimento(int id_impedimento);
    }
}