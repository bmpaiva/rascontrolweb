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
  public class DAOAtividade:IDAOAtividade
  {
    public List<Atividade> ConsultarAllAtividade()
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {
        List<Atividade> lista = new List<Atividade>();
        string sql = GenericaSQL.ConsultarAllAtividade();

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        while (dr.Read())
        {
          Atividade a = new Atividade();
          a.Codigo = (int)dr["ID_ATIVIDADE"];
          IDAOTipoAtividade iDaoTipoAtividade = new DAOTipoAtividade();
          a.IdTipoAtividade = iDaoTipoAtividade.ConsultarTipoAtividadeCodigo(int.Parse(dr["ID_TIPO_ATIVIDADE"].ToString()));
          a.IdEstoriaSprint = (int)dr["ID_ESTORIA_SPRINT"];
          a.Descricao = (string)dr["DESCRICAO"].ToString();
          a.Observacao = (string)dr["OBSERVACAO"].ToString();
          a.DuracaoEstimada = double.Parse(dr["DURACAO_ESTIMADA"].ToString());
          a.DuracaoRealizada = double.Parse(dr["DURACAO_REALIZADA"].ToString());
          a.Status = (string)dr["STATUS"].ToString();
          

          lista.Add(a);
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



    public Atividade ConsultarAtividadeCodigo(int codigo)
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {

        Atividade a = null;
        string sql = GenericaSQL.ConsultarAtividadeCodigo(codigo);

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        dr.Read();

        a = new Atividade();
        a.Codigo = (int)dr["ID_ATIVIDADE"];
        IDAOTipoAtividade iDaoTipoAtividade = new DAOTipoAtividade();
        a.IdTipoAtividade = iDaoTipoAtividade.ConsultarTipoAtividadeCodigo(int.Parse(dr["ID_TIPO_ATIVIDADE"].ToString()));
        a.IdEstoriaSprint = (int)dr["ID_ESTORIA_SPRINT"];
        a.Descricao = (string)dr["DESCRICAO"].ToString();
        a.Observacao = (string)dr["OBSERVACAO"].ToString();
        a.DuracaoEstimada = double.Parse(dr["DURACAO_ESTIMADA"].ToString());
        a.DuracaoRealizada = double.Parse(dr["DURACAO_REALIZADA"].ToString());
        a.Status = (string)dr["STATUS"].ToString();


        dr.Close();

        return a;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {

      }
    }


    public List<Atividade> ConsultarAllAtividadeFiltros(int codigo, string descricao)
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {
        List<Atividade> lista = new List<Atividade>();
        string sql = GenericaSQL.ConsultarAllAtividadeFiltros(codigo, descricao);

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        while (dr.Read())
        {
          Atividade a = new Atividade();
          a.Codigo = (int)dr["ID_ATIVIDADE"];
          IDAOTipoAtividade iDaoTipoAtividade = new DAOTipoAtividade();
          a.IdTipoAtividade = iDaoTipoAtividade.ConsultarTipoAtividadeCodigo(int.Parse(dr["ID_TIPO_ATIVIDADE"].ToString()));
          a.IdEstoriaSprint = (int)dr["ID_ESTORIA_SPRINT"];
          a.Descricao = (string)dr["DESCRICAO"].ToString();
          a.Observacao = (string)dr["OBSERVACAO"].ToString();
          a.DuracaoEstimada = double.Parse(dr["DURACAO_ESTIMADA"].ToString());
          a.DuracaoRealizada = double.Parse(dr["DURACAO_REALIZADA"].ToString());
          a.Status = (string)dr["STATUS"].ToString();
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


    public void CadastrarAtividade(Atividade atividade)
    {
      string sql = GenericaSQL.CadastrarAtividade(atividade);
      GenericaDAO dao = GenericaDAO.getInstancia();

      dao.ExecuteNonQuery(CommandType.Text, sql);
    }


    public void UpdateAtividade(Atividade atividade)
    {
      string sql = GenericaSQL.UpdateAtividade(atividade);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }


    public void DeleteAtividade(int id)
    {
      string sql = GenericaSQL.DeleteAtividade(id);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }
  }
}