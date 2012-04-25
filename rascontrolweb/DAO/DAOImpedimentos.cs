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
    public class DAOImpedimentos : IDAOImpedimentos
    {
        public List<Impedimentos> ConsultarAllImpedimentos()
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                List<Impedimentos> lista = new List<Impedimentos>();
                string sql = GenericaSQL.ConsultarAllImpedimentos();

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                while (dr.Read())
                {
                    Impedimentos impedimentos = new Impedimentos();
                    impedimentos.Id_Impedimento = (int)dr["ID_IMPEDIMENTO"];
                    impedimentos.Id_Sprint = (int)dr["ID_SPRINT"];
                    impedimentos.Descricao = (string)dr["DESCRICAO"];
                    impedimentos.Ind_Ativo = (string)dr["IND_ATIVO"];
                    lista.Add(impedimentos);
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

        public Impedimentos ConsultarImpedimentoCodigo(int id_impedimento)
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                Impedimentos impedimentos = null;
                string sql = GenericaSQL.ConsultarImpedimentoCodigo(id_impedimento);

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                dr.Read();

                impedimentos = new Impedimentos();
                impedimentos.Id_Impedimento = (int)dr["ID_IMPEDIMENTO"];
                impedimentos.Id_Sprint = (int)dr["ID_SPRINT"];
                impedimentos.Descricao = (string)dr["DESCRICAO"];
                impedimentos.Ind_Ativo = (string)dr["IND_ATIVO"];

                dr.Close();

                return impedimentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public List<Impedimentos> ConsultarAllImpedimentoFiltros(int id_impedimento, int id_sprint, string descricao)
        {
            GenericaDAO dao = GenericaDAO.getInstancia();

            try
            {
                List<Impedimentos> lista = new List<Impedimentos>();
                string sql = GenericaSQL.ConsultarAllImpedimentoFiltros(id_impedimento, id_sprint, descricao);

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                while (dr.Read())
                {
                    Impedimentos impedimentos = new Impedimentos();
                    impedimentos.Id_Impedimento = (int)dr["ID_IMPEDIMENTO"];
                    impedimentos.Id_Sprint = (int)dr["ID_SPRINT"];
                    impedimentos.Descricao = (string)dr["DESCRICAO"];
                    lista.Add(impedimentos);
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

        public void CadastrarImpedimento(Impedimentos impedimentos)
        {
            string sql = GenericaSQL.CadastrarImpedimento(impedimentos);
            GenericaDAO dao = GenericaDAO.getInstancia();

            dao.ExecuteNonQuery(CommandType.Text, sql);
        }

        public void UpdateImpedimento(Impedimentos impedimentos)
        {
            string sql = GenericaSQL.UpdateImpedimento(impedimentos);
            GenericaDAO dao = GenericaDAO.getInstancia();
            dao.ExecuteNonQuery(CommandType.Text, sql);
        }

        public void DeleteImpedimento(int id_impedimento)
        {
            string sql = GenericaSQL.DeleteImpedimento(id_impedimento);
            GenericaDAO dao = GenericaDAO.getInstancia();
            dao.ExecuteNonQuery(CommandType.Text, sql);
        }
    }
}