using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassesBasicas;

namespace IDAO
{
    public interface IDAOPermissao
    {
        List<Permissao> SelectAllPermissao();
        List<Permissao> SelectAllPermissaoUsuario(int id);
        List<Permissao> ConsultarPermissao(Permissao permissao);
        
        int VerificarPermissaoExistePorDescricao(string descricao);
        void InsertPermissao(Permissao permissao);
        void UpdatePermissao(Permissao permissao);
        Permissao SelectPermissaoPorCodigo(int id);
        void DeletePermissaoPorCodigo(int id);
        Permissao SelectPermissaoPorNome(string nome);
    }
}