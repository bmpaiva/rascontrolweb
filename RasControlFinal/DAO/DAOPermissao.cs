using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IDAO;
using ClassesBasicas;
using Genericas;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOPermissao : IDAOPermissao
    {       

        public List<Permissao> ConsultarAllPermissao()
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                List<Permissao> lista = new List<Permissao>();
                string sql = GenericaSQL.ConsultarAllPermissao();
                
                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                while (dr.Read())
                {
                    Permissao permissao = new Permissao();
                    permissao.Codigo = (int)dr["ID_PERMISSAO"];
                    permissao.Descricao = (string)dr["DESCRICAO"].ToString();
                    permissao.Observacao = (string)dr["OBSERVACAO"].ToString();
                    lista.Add(permissao);
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

        public Permissao ConsultarPermissaoCodigo(int codigo)
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {      

                Permissao permissao = null;
                string sql = GenericaSQL.ConsultarPermissaoCodigo(codigo);
                
                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                dr.Read();
                
                permissao = new Permissao();
                permissao.Codigo = (int)dr["ID_PERMISSAO"];
                permissao.Descricao = dr["DESCRICAO"].ToString();
                permissao.Observacao = dr["OBSERVACAO"].ToString();
           
                
                dr.Close();

                return permissao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public List<Permissao> ConsultarAllPermissaoFiltros(int codigo, string descricao)
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                List<Permissao> lista = new List<Permissao>();
                string sql = GenericaSQL.ConsultarAllPermissaoFiltros(codigo,descricao);

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                while (dr.Read())
                {
                    Permissao permissao = new Permissao();
                    permissao.Codigo = (int)dr["ID_PERMISSAO"];
                    permissao.Descricao = (string)dr["DESCRICAO"].ToString();
                    permissao.Observacao = (string)dr["OBSERVACAO"].ToString();
                    lista.Add(permissao);
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

        public void CadastrarPermissao(Permissao permissao)
        {
            string sql = GenericaSQL.CadastrarPermissao(permissao);
            GenericaDAO dao = GenericaDAO.getInstancia();

            dao.ExecuteNonQuery(CommandType.Text, sql);
           
        }

        public void UpdatePermissao(Permissao permissao)
        {
            string sql = GenericaSQL.UpdatePermissao(permissao);
            GenericaDAO dao = GenericaDAO.getInstancia();         
            dao.ExecuteNonQuery(CommandType.Text, sql);
     
        }

        public void DeletePermissao(int idPermissao)
        {
            string sql = GenericaSQL.DeletePermissao(idPermissao);
            GenericaDAO dao = GenericaDAO.getInstancia();  
            dao.ExecuteNonQuery(CommandType.Text, sql);
        }   
    }
}