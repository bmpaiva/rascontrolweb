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
  public class DAOProjeto:IDAOProjeto
  {
    public List<Projeto> ConsultarAllProjeto()
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {
        List<Projeto> lista = new List<Projeto>();
        string sql = GenericaSQL.ConsultarAllProjeto();

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        while (dr.Read())
        {
          Projeto p = new Projeto();
          p.Codigo = (int)dr["ID_PROJETO"];
          p.Descricao = (string)dr["DESCRICAO"].ToString();
          

          lista.Add(p);
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



    public Projeto ConsultarProjetoCodigo(int codigo)
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {

        Projeto p = null;
        string sql = GenericaSQL.ConsultarProjetoCodigo(codigo);

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        dr.Read();

        p = new Projeto();
        p.Codigo = (int)dr["ID_PROJETO"];
        p.Descricao = (string)dr["DESCRICAO"].ToString();
        p.Nome = (string)dr["NOME"].ToString();
        p.DtInclusao = (DateTime)dr["DATA_INCLUSAO"];
        p.Status = (string)dr["STATUS"].ToString();


        dr.Close();

        return p;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {

      }
    }


    public List<Projeto> ConsultarAllProjetoFiltros(int codigo, string descricao)
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {
        List<Projeto> lista = new List<Projeto>();
        string sql = GenericaSQL.ConsultarAllProjetoFiltros(codigo, descricao);

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        while (dr.Read())
        {
          Projeto p = new Projeto();
          p.Codigo = (int)dr["ID_PROJETO"];
          p.Descricao = (string)dr["DESCRICAO"];
          lista.Add(p);
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


    public void CadastrarProjeto(Projeto projeto)
    {
      string sql = GenericaSQL.CadastrarProjeto(projeto);
      GenericaDAO dao = GenericaDAO.getInstancia();

      dao.ExecuteNonQuery(CommandType.Text, sql);
    }


    public void UpdateProjeto(Projeto projeto)
    {
      string sql = GenericaSQL.UpdateProjeto(projeto);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }


    public void DeleteProjeto(int id)
    {
      string sql = GenericaSQL.DeleteProjeto(id);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }
  }
}