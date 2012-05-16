using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassesBasicas;
using Genericas;
using System.Data.SqlClient;
using System.Data;
using IDAO;

namespace DAO
{
    public class DAOTipoAtividade : IDAOTipoAtividade
    {
        public List<TipoAtividade> ConsultarAllTipoAtividade()
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                List<TipoAtividade> lista = new List<TipoAtividade>();
                string sql = GenericaSQL.ConsultarAllTipoAtividade();

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                while (dr.Read())
                {
                    TipoAtividade ta = new TipoAtividade();
                    ta.Codigo = (int)dr["ID_TIPOATIVIDADE"];
                    ta.Descricao = (string)dr["DESCRICAO"].ToString();

                    lista.Add(ta);
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



        public TipoAtividade ConsultarTipoAtividadeCodigo(int id_tipoatividade)
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {

                TipoAtividade ta = null;
                string sql = GenericaSQL.ConsultarTipoAtividadeCodigo(id_tipoatividade);

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                dr.Read();

                ta = new TipoAtividade();
                ta.Codigo = (int)dr["ID_TIPOATIVIDADE"];
                ta.Descricao = dr["DESCRICAO"].ToString();


                dr.Close();

                return ta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }


        public List<TipoAtividade> ConsultarAllTipoAtividadeFiltros(int id_tipoatividade, string descricao)
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                List<TipoAtividade> lista = new List<TipoAtividade>();
                string sql = GenericaSQL.ConsultarAllTipoAtividadeFiltros(id_tipoatividade, descricao);

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                while (dr.Read())
                {
                    TipoAtividade ta = new TipoAtividade();
                    ta.Codigo = (int)dr["ID_TIPOATIVIDADE"];
                    ta.Descricao = (string)dr["DESCRICAO"].ToString();
                    lista.Add(ta);
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


        public void CadastrarTipoAtividade(TipoAtividade tipoAtividade)
        {
            string sql = GenericaSQL.CadastrarTipoAtividade(tipoAtividade);
            GenericaDAO dao = GenericaDAO.getInstancia();

            dao.ExecuteNonQuery(CommandType.Text, sql);
        }


        public void UpdateTipoAtividade(TipoAtividade tipoAtividade)
        {
            string sql = GenericaSQL.UpdateTipoAtividade(tipoAtividade);
            GenericaDAO dao = GenericaDAO.getInstancia();
            dao.ExecuteNonQuery(CommandType.Text, sql);
        }


        public void DeleteTipoAtividade(int id_tipoatividade)
        {
            string sql = GenericaSQL.DeleteTipoAtividade(id_tipoatividade);
            GenericaDAO dao = GenericaDAO.getInstancia();
            dao.ExecuteNonQuery(CommandType.Text, sql);
        }
    }
}