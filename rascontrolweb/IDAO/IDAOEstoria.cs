using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace IDAO
{
    public interface IDAOEstoria
    {
        List<Estoria> ConsultarAllEstoria();
        Estoria ConsultarEstoriaCodigo(int codigo);
        List<Estoria> ConsultarAllEstoriaFiltros(int codigo, string descricao);
        void CadastrarEstoria(Estoria estoria);
        void UpdateEstoria(Estoria estoria);
        void DeleteEstoria(int id);
    }
}
