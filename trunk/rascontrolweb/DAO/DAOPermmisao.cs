using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IDAO;
using ClassesBasicas;
using Genericas;
using System.Data;

namespace DAO
{
    public class DAOPermmisao : IDAOPermissao
    {

        public List<Permissao> SelectAllPermissao()
        {
            throw new NotImplementedException();
        }

        public List<Permissao> SelectAllPermissaoUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public List<Permissao> ConsultarPermissao(Permissao permissao)
        {
            throw new NotImplementedException();
        }

        public int VerificarPermissaoExistePorDescricao(string descricao)
        {
            throw new NotImplementedException();
        }

        public void InsertPermissao(Permissao permissao)
        {
            string sql = GenericaSQL.CadastrarPermissao(permissao);
            GenericaDAO dao = GenericaDAO.getInstancia();

            dao.ExecuteNonQuery(CommandType.Text, sql);
           
        }

        public void UpdatePermissao(Permissao permissao)
        {
            throw new NotImplementedException();
        }

        public ClassesBasicas.Permissao SelectPermissaoPorCodigo(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletePermissaoPorCodigo(int id)
        {
            throw new NotImplementedException();
        }

        public Permissao SelectPermissaoPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}