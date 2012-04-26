using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassesBasicas;

namespace IDAO
{
    public interface IDAOPermissao
    {
        List<Permissao> ConsultarAllPermissao();
        Permissao ConsultarPermissaoCodigo(int codigo);
        List<Permissao> ConsultarAllPermissaoFiltros(int codigo, string descricao);
        void CadastrarPermissao(Permissao permissao);
        void UpdatePermissao(Permissao permissao);
        void DeletePermissao(int id);
    }
}