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
    public class DAOBurnDown : IDAOBurnDown
    {

        public int SelectQtdDiasSprint(int idProjeto, int idSprint)
        {

            GenericaDAO dao = GenericaDAO.getInstancia();
            try
            {
                int qtdDias = 0;
                string sql = GenericaSQL.SelectQtdDiasSprint(idProjeto,idSprint);

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                dr.Read();

                qtdDias = (int)dr["QTD_DIAS"];

                dr.Close();

                return qtdDias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public double SelectQtdHorasPlanejadaSprint(int idProjeto, int idSprint)
        {
            GenericaDAO dao = GenericaDAO.getInstancia();
            try
            {
                double qtdHoras = 0;
                string sql = GenericaSQL.SelectQtdHorasPlanejadaSprint(idProjeto, idSprint);

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                dr.Read();

                qtdHoras = (double)dr["DURACAO_ESTIMADA"];

                dr.Close();

                return qtdHoras;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public double SelectTamanhoRealizadoDia(int idProjeto, int idSprint, int dia)
        {
            GenericaDAO dao = GenericaDAO.getInstancia();
            try
            {
                double qtdHoraRealizada = 0;
                string sql = GenericaSQL.SelectTamanhoRealizadoDia(idProjeto, idSprint,dia);

                SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

                dr.Read();

                try
                {
                    qtdHoraRealizada = (double)dr["DURACAO_ESTIMADA"];
                }
                catch
                {
                    qtdHoraRealizada = 0;
                }

                dr.Close();

                return qtdHoraRealizada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}