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
  public class DAOTipoAtividade:IDAOTipoAtividade
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



    public TipoAtividade ConsultarTipoAtividadeCodigo(int codigo)
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {

        TipoAtividade ta = null;
        string sql = GenericaSQL.ConsultarTipoAtividadeCodigo(codigo);

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


    public List<TipoAtividade> ConsultarAllTipoAtividadeFiltros(int codigo, string descricao)
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {
        List<TipoAtividade> lista = new List<TipoAtividade>();
        string sql = GenericaSQL.ConsultarAllTipoAtividadeFiltros(codigo, descricao);

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


    public void CadastrarTipoAtividade(TipoAtividade tAtividade)
    {
      string sql = GenericaSQL.CadastrarTipoAtividade(tAtividade);
      GenericaDAO dao = GenericaDAO.getInstancia();

      dao.ExecuteNonQuery(CommandType.Text, sql);
    }


    public void UpdateTipoAtividade(TipoAtividade tAtividade)
    {
      string sql = GenericaSQL.UpdateTipoAtividade(tAtividade);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }


    public void DeleteTipoAtividade(int id)
    {
      string sql = GenericaSQL.DeleteTipoAtividade(id);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }
   
  }
}