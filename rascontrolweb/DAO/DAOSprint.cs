using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IDAO;
using ClassesBasicas;
using Genericas;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DAOSprint : IDAOSprint
    {
        public List<Sprint> ConsultarAllSprint()
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                List<Sprint> lista = new List<Sprint>();
                string sql = GenericaSQL.ConsultarAllSprint();

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                while (dr.Read())
                {
                    Sprint sprint = new Sprint();
                    sprint.Id_Sprint = (int)dr["ID_SPRINT"];
                    sprint.Id_Projeto = (int)dr["ID_PROJETO"];
                    sprint.Descricao = (string)dr["DESCRICAO"];
                    sprint.Data_Inicio = (DateTime)dr["DATA_INICIO"];
                    sprint.Data_Fim = (DateTime)dr["DATA_FIM"];
                    sprint.Qtd_Dias = (int)dr["QTD_DIAS"];
                    sprint.Ind_Ativo = (char)dr["IND_ATIVO"];
                    lista.Add(sprint);
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

        public Sprint ConsultarSprintCodigo(int id_sprint)
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {

                Sprint sprint = null;
                string sql = GenericaSQL.ConsultarSprintCodigo(id_sprint);

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                dr.Read();

                sprint = new Sprint();
                sprint.Id_Sprint = (int)dr["ID_SPRINT"];
                sprint.Id_Projeto = (int)dr["ID_PROJETO"];
                sprint.Descricao = (string)dr["DESCRICAO"];
                sprint.Data_Inicio = (DateTime)dr["DATA_INICIO"];
                sprint.Data_Fim = (DateTime)dr["DATA_FIM"];
                sprint.Qtd_Dias = (int)dr["QTD_DIAS"];
                sprint.Ind_Ativo = (char)dr["IND_ATIVO"];

                dr.Close();

                return sprint;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public List<Sprint> ConsultarAllSprintFiltros(int id_sprint, string descricao)
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                List<Sprint> lista = new List<Sprint>();
                string sql = GenericaSQL.ConsultarAllSprintFiltros(id_sprint, descricao);

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                while (dr.Read())
                {
                    Sprint sprint = new Sprint();
                    sprint.Id_Sprint = (int)dr["ID_SPRINT"];
                    sprint.Id_Projeto = (int)dr["ID_PROJETO"];
                    sprint.Descricao = (string)dr["DESCRICAO"];
                    sprint.Data_Inicio = (DateTime)dr["DATA_INICIO"];
                    sprint.Data_Fim = (DateTime)dr["DATA_FIM"];
                    sprint.Qtd_Dias = (int)dr["QTD_DIAS"];
                    sprint.Ind_Ativo = (char)dr["IND_ATIVO"];
                    lista.Add(sprint);
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

        public void CadastrarSprint(Sprint sprint)
        {
            string sql = GenericaSQL.CadastrarSprint(sprint);
            GenericaDAO dao = GenericaDAO.getInstancia();

            dao.ExecuteNonQuery(CommandType.Text, sql);
        }

        public void UpdateSprint(Sprint sprint)
        {
            string sql = GenericaSQL.UpdateSprint(sprint);
            GenericaDAO dao = GenericaDAO.getInstancia();
            dao.ExecuteNonQuery(CommandType.Text, sql);
        }

        public void DeleteSprint(int id_sprint)
        {
            string sql = GenericaSQL.DeleteSprint(id_sprint);
            GenericaDAO dao = GenericaDAO.getInstancia();
            dao.ExecuteNonQuery(CommandType.Text, sql);
        }
    }
}