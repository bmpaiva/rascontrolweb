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
  public class DAOAvaliacao360:IDAOAvaliacao360
  {

    public List<Avaliacao360> ConsultarAllAvaliacao360()
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {
        List<Avaliacao360> lista = new List<Avaliacao360>();
        string sql = GenericaSQL.ConsultarAllAvaliacao360();

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        while (dr.Read())
        {
          Avaliacao360 av = new Avaliacao360();

          av.Codigo = (int)dr["ID_AVALIACAO"];
          //IDAOSprint iDaoSprint = new DAOSprint();
          //av.IdSprint = iDaoSprint.ConsultarSprintCodigo(int.Parse(dr["ID_SPRINT"].ToString()));
          //USUARIO AVALIADOR (IGOR)
          av.Nota = double.Parse(dr["NOTA_AVALIADO"].ToString());
          //USUARIO AVALIADO (IGOR)
          av.Justificativa = (string)dr["JUSTIFICATIVA"].ToString();
         
          lista.Add(av);
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



    public Avaliacao360 ConsultarAvaliacao360Codigo(int codigo)
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {

        Avaliacao360 av = null;
        string sql = GenericaSQL.ConsultarAvaliacao360Codigo(codigo);

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        dr.Read();

        av = new Avaliacao360();

        av.Codigo = (int)dr["ID_AVALIACAO"];
        //IDAOSprint iDaoSprint = new DAOSprint();
        //av.IdSprint = iDaoSprint.ConsultarSprintCodigo(int.Parse(dr["ID_SPRINT"].ToString()));
        //USUARIO AVALIADOR (IGOR)
        av.Nota = double.Parse(dr["NOTA_AVALIADO"].ToString());
        //USUARIO AVALIADO (IGOR)
        av.Justificativa = (string)dr["JUSTIFICATIVA"].ToString();


        dr.Close();

        return av;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {

      }
    }


    public List<Avaliacao360> ConsultarAllAvaliacao360Filtros(int codigo, string justificativa)
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {
        List<Avaliacao360> lista = new List<Avaliacao360>();
        string sql = GenericaSQL.ConsultarAllAvaliacao360Filtros(codigo, justificativa);

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        while (dr.Read())
        {
          Avaliacao360 av = new Avaliacao360();

          av.Codigo = (int)dr["ID_AVALIACAO"];
          //IDAOSprint iDaoSprint = new DAOSprint();
          //av.IdSprint = iDaoSprint.ConsultarSprintCodigo(int.Parse(dr["ID_SPRINT"].ToString()));
          //USUARIO AVALIADOR (IGOR)
          av.Nota = double.Parse(dr["NOTA_AVALIADO"].ToString());
          //USUARIO AVALIADO (IGOR)
          av.Justificativa = (string)dr["JUSTIFICATIVA"].ToString();

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


    public void CadastrarAvaliacao360(Avaliacao360 avaliacao)
    {
      string sql = GenericaSQL.CadastrarAvaliacao360(avaliacao);
      GenericaDAO dao = GenericaDAO.getInstancia();

      dao.ExecuteNonQuery(CommandType.Text, sql);
    }


    public void UpdateAvaliacao360(Avaliacao360 avaliacao)
    {
      string sql = GenericaSQL.UpdateAvaliacao360(avaliacao);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }


    public void DeleteAvaliacao360(int id)
    {
      string sql = GenericaSQL.DeleteAvaliacao360(id);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }
  }
}