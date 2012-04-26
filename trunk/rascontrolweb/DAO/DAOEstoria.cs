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
  public class DAOEstoria:IDAOEstoria
  {
    public List<Estoria> ConsultarAllEstoria()
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {
        List<Estoria> lista = new List<Estoria>();
        string sql = GenericaSQL.ConsultarAllEstoria();

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        while (dr.Read())
        {
          Estoria e = new Estoria();
          e.Codigo = (int)dr["ID_ESTORIA"];
          IDAOProjeto iDaoProjeto = new DAOProjeto();
          e.IdProjeto = iDaoProjeto.ConsultarProjetoCodigo(int.Parse(dr["ID_PROJETO"].ToString()));       
          e.Descricao = (string)dr["DESCRICAO"].ToString();         
          e.Sp = double.Parse(dr["SP"].ToString());
          e.Bv = double.Parse(dr["BV"].ToString());
          e.Roi = double.Parse(dr["ROI"].ToString());

          lista.Add(e);
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



    public Estoria ConsultarEstoriaCodigo(int codigo)
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {

        Estoria e = null;
        string sql = GenericaSQL.ConsultarEstoriaCodigo(codigo);

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        dr.Read();

        e = new Estoria();
        e.Codigo = (int)dr["ID_ESTORIA"];
        IDAOProjeto iDaoProjeto = new DAOProjeto();
        e.IdProjeto = iDaoProjeto.ConsultarProjetoCodigo(int.Parse(dr["ID_PROJETO"].ToString()));
        e.Descricao = (string)dr["DESCRICAO"].ToString();
        e.Sp = double.Parse(dr["SP"].ToString());
        e.Bv = double.Parse(dr["BV"].ToString());
        e.Roi = double.Parse(dr["ROI"].ToString());


        dr.Close();

        return e;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {

      }
    }


    public List<Estoria> ConsultarAllEstoriaFiltros(int codigo, string descricao)
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {
        List<Estoria> lista = new List<Estoria>();
        string sql = GenericaSQL.ConsultarAllEstoriaFiltros(codigo, descricao);

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        while (dr.Read())
        {
          Estoria e = new Estoria();
          e.Codigo = (int)dr["ID_ESTORIA"];
          IDAOProjeto iDaoProjeto = new DAOProjeto();
          e.IdProjeto = iDaoProjeto.ConsultarProjetoCodigo(int.Parse(dr["ID_PROJETO"].ToString()));
          e.Descricao = (string)dr["DESCRICAO"].ToString();
          e.Sp = double.Parse(dr["SP"].ToString());
          e.Bv = double.Parse(dr["BV"].ToString());
          e.Roi = double.Parse(dr["ROI"].ToString());
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


    public void CadastrarEstoria(Estoria estoria)
    {
      string sql = GenericaSQL.CadastrarEstoria(estoria);
      GenericaDAO dao = GenericaDAO.getInstancia();

      dao.ExecuteNonQuery(CommandType.Text, sql);
    }


    public void UpdateEstoria(Estoria estoria)
    {
      string sql = GenericaSQL.UpdateEstoria(estoria);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }


    public void DeleteEstoria(int id)
    {
      string sql = GenericaSQL.DeleteEstoria(id);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }
  }
}