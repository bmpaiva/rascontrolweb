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
  public class DAOAtividade : IDAOAtividade
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
                  Atividade atividade = new Atividade();
                  atividade.Id_Atividade = (int)dr["ID_ATIVIDADE"];
                  atividade.Id_Tipo_Atividade = (int)dr["ID_TIPO_ATIVIDADE"];
                  atividade.Id_Estoria_Sprint = (int)dr["ID_ESTORIA_SPRINT"];
                  atividade.Descricao = (string)dr["DESCRICAO"].ToString();
                  atividade.Observacao = (string)dr["OBSERVACAO"].ToString();
                  atividade.Duracao_Estimada = (float)dr["DURACAO_ESTIMADA"];
                  atividade.Duracao_Realizada = (float)dr["DURACAO_REALIZADA"];
                  atividade.Status = (string)dr["STATUS"].ToString();    
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

      public Atividade ConsultarAtividadeCodigo(int id_atividade)
      {
          GenericaDAO dao = GenericaDAO.getInstancia();

          try
          {
              Atividade atividade = null;
              string sql = GenericaSQL.ConsultarAtividadeCodigo(id_atividade);

              SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

              dr.Read();

              atividade = new Atividade();
              atividade.Id_Atividade = (int)dr["ID_ATIVIDADE"];
              atividade.Id_Tipo_Atividade = (int)dr["ID_TIPO_ATIVIDADE"];
              atividade.Id_Estoria_Sprint = (int)dr["ID_ESTORIA_SPRINT"];
              atividade.Descricao = (string)dr["DESCRICAO"].ToString();
              atividade.Observacao = (string)dr["OBSERVACAO"].ToString();
              atividade.Duracao_Estimada = Convert.ToDouble(dr["DURACAO_ESTIMADA"].ToString());
              atividade.Duracao_Realizada = Convert.ToDouble(dr["DURACAO_REALIZADA"].ToString());
              atividade.Status = (string)dr["STATUS"].ToString();
           
              dr.Close();

              return atividade;
          }
          catch (Exception ex)
          {
              throw ex;
          }
          finally
          {

          }
      }

      public List<Atividade> ConsultarAllAtividadeFiltros(int id_atividade,int id_tipo_atividade ,int id_estoria_sprint, string descricao, double duracao_estimada, double duracao_realizada)
      {
          GenericaDAO dao = GenericaDAO.getInstancia();

          try
          {
              List<Atividade> lista = new List<Atividade>();
              string sql = GenericaSQL.ConsultarAllAtividadeFiltros(id_atividade, id_tipo_atividade, id_estoria_sprint, descricao, duracao_estimada, duracao_realizada);

              SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

              while (dr.Read())
              {
                  Atividade atividade = new Atividade();
                  atividade.Id_Atividade = (int)dr["ID_ATIVIDADE"];
                  atividade.Id_Tipo_Atividade = (int)dr["ID_TIPO_ATIVIDADE"];
                  atividade.Id_Estoria_Sprint = (int)dr["ID_ESTORIA_SPRINT"];
                  atividade.Descricao = (string)dr["DESCRICAO"].ToString();
                  atividade.Duracao_Estimada = (double)dr["DURACAO_ESTIMADA"];
                  atividade.Duracao_Realizada = (double)dr["DURACAO_REALIZADA"];
                  lista.Add(atividade);
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

      public void DeleteAtividade(int id_atividade)
      {
          string sql = GenericaSQL.DeleteAtividade(id_atividade);
          GenericaDAO dao = GenericaDAO.getInstancia();
          dao.ExecuteNonQuery(CommandType.Text, sql);
      }
  }
}