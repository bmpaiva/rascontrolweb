using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Genericas;
using ClassesBasicas;
using System.Data;
using System.Data.SqlClient;
using IDAO;

namespace DAO
{
    public class DAOUsuario : IDAOUsuario
    {
        //Metodo de Consultar todos os usuario
        public List<Usuario> ConsultarAllUsuario()
        {
            //Instancia a classe GENERICADAO para poder puxar os dados
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                //Verifica no banco se existe algum dado e cria uma lista com esses dados encontrados
                List<Usuario> lista = new List<Usuario>();
                string sql = GenericaSQL.ConsultarAllUsuario();

                //Executa a função SQL para puxar esses dados e lista em texto
                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                while (dr.Read())
                {
                    //Instancia um usuario e Lista tudo
                    Usuario usuario = new Usuario();
                    usuario.Codigo = (int)dr["ID_USUARIO"];
                    usuario.Nome = (string)dr["NOME"].ToString();
                    usuario.Telefone = (string)dr["TELEFONE"].ToString();
                    usuario.Celular = (string)dr["CELULAR"].ToString();
                    usuario.Cpf = (string)dr["CPF"].ToString();
                    usuario.Email = (string)dr["EMAIL"].ToString();
                    usuario.Login = (string)dr["LOGIN"].ToString();
                    usuario.Rg = (string)dr["RG"].ToString();
                    usuario.Senha = (string)dr["SENHA"].ToString();
                    usuario.Observacao = (string)dr["OBSERVACAO"].ToString();
                    usuario.PerfilUsuario = new DAOPerfilUsuario().ConsultarPerfilUsuarioCodigo((int)dr["ID_PERFILUSUARIO"]);
                    lista.Add(usuario);
                }
                dr.Close();

                return lista;
            }
            //Caso tenha algum problema, será exibido uma exceção
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        //Metodo de Consultar usuario pelo codigo
        public Usuario ConsultarUsuarioCodigo(int codigo)
        {
            //Instancia a classe GENERICADAO para poder puxar os dados
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                //Verifica no banco se existe algum dado e cria uma lista com esses dados encontrados
                Usuario usuario = null;
                string sql = GenericaSQL.ConsultarUsuarioCodigo(codigo);

                //Executa a função SQL para puxar esses dados e lista em texto
                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                dr.Read();

                //Instancia um usuario e Lista tudo
                usuario = new Usuario();
                usuario.Codigo = (int)dr["ID_USUARIO"];
                usuario.Nome = (string)dr["NOME"].ToString();
                usuario.Telefone = (string)dr["TELEFONE"].ToString();
                usuario.Celular = (string)dr["CELULAR"].ToString();
                usuario.Cpf = (string)dr["CPF"].ToString();
                usuario.Email = (string)dr["EMAIL"].ToString();
                usuario.Login = (string)dr["LOGIN"].ToString();
                usuario.Rg = (string)dr["RG"].ToString();
                usuario.Senha = (string)dr["SENHA"].ToString();
                usuario.Observacao = (string)dr["OBSERVACAO"].ToString();
                usuario.PerfilUsuario = new DAOPerfilUsuario().ConsultarPerfilUsuarioCodigo((int)dr["ID_PERFILUSUARIO"]);


                dr.Close();

                return usuario;
            }
            //Caso tenha algum problema, será exibido uma exceção
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        //Metodo de Consultar usuario pelo codigo e cpf
        public List<Usuario> ConsultarAllUsuarioFiltros(int codigo, string cpf)
        {
            //Instancia a classe GENERICADAO para poder puxar os dados
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                //Verifica no banco se existe algum dado e cria uma lista com esses dados encontrados
                List<Usuario> lista = new List<Usuario>();
                string sql = GenericaSQL.ConsultarAllUsuarioFiltros(codigo, cpf);

                //Executa a função SQL para puxar esses dados e lista em texto
                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                while (dr.Read())
                {
                    //Instancia um usuario e Lista tudo
                    Usuario usuario = new Usuario();
                    usuario.Codigo = (int)dr["ID_USUARIO"];
                    usuario.Nome = (string)dr["NOME"].ToString();
                    usuario.Telefone = (string)dr["TELEFONE"].ToString();
                    usuario.Celular = (string)dr["CELULAR"].ToString();
                    usuario.Cpf = (string)dr["CPF"].ToString();
                    usuario.Email = (string)dr["EMAIL"].ToString();
                    usuario.Login = (string)dr["LOGIN"].ToString();
                    usuario.Rg = (string)dr["RG"].ToString();
                    usuario.Senha = (string)dr["SENHA"].ToString();
                    usuario.Observacao = (string)dr["OBSERVACAO"].ToString();
                    usuario.PerfilUsuario = new DAOPerfilUsuario().ConsultarPerfilUsuarioCodigo((int)dr["ID_PERFILUSUARIO"]);
                    lista.Add(usuario);
                }
                dr.Close();

                return lista;
            }
            //Caso tenha algum problema, será exibido uma exceção
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        //Cadastrar o usuario
        public void CadastrarUsuario(Usuario usuario)
        {
            //utiliza o metodo declarado na Generica SQL para puxar do banco e logo depois executa-lo
            string sql = GenericaSQL.CadastrarUsuario(usuario);
            GenericaDAO dao = GenericaDAO.getInstancia();
            dao.ExecuteNonQuery(CommandType.Text, sql);

        }

        //Alterar o usuario
               
        public void UpdateUsuario(Usuario usuario)
        {
            //utiliza o metodo declarado na Generica SQL para puxar do banco e logo depois executa-lo
            string sql = GenericaSQL.UpdateUsuario(usuario);
            GenericaDAO dao = GenericaDAO.getInstancia();
            dao.ExecuteNonQuery(CommandType.Text, sql);

        }

        //Deletar o usuario
        public void DeleteUsuario(int idUsuario)
        {
            //utiliza o metodo declarado na Generica SQL para puxar do banco e logo depois executa-lo
            string sql = GenericaSQL.DeleteUsuario(idUsuario);
            GenericaDAO dao = GenericaDAO.getInstancia();
            dao.ExecuteNonQuery(CommandType.Text, sql);
        }


      //testando
        public List<Usuario> ConsultarAllUsuarioProjeto(int idProjeto)
        {
          GenericaDAO dao = GenericaDAO.getInstancia();

          try
          {
            List<Usuario> lista = new List<Usuario>();
            string sql = GenericaSQL.ConsultarAllUsuarioProjeto(idProjeto);

            SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

            while (dr.Read())
            {
              int idUsuario = (int)dr["ID_USUARIO"];
              Usuario usuario = ConsultarUsuarioCodigo(idUsuario);
              lista.Add(usuario);
            }
            dr.Close();

            return lista;
          }
          catch (Exception ex)
          {
            throw ex;
          }
          finally
          {

          }
        }
      //fimteste
    }
}