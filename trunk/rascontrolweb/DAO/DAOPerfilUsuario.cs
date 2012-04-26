using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Genericas;
using System.Data.SqlClient;
using System.Data;
using IDAO;
using ClassesBasicas;


namespace DAO
{
  public class DAOPerfilUsuario : IDAOPerfilUsuario
  {
    
    public List<PerfilUsuario> ConsultarAllPerfilUsuario()    
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {
        List<PerfilUsuario> lista = new List<PerfilUsuario>();
        string sql = GenericaSQL.ConsultarAllPerfilUsuario();

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        while (dr.Read())
        {
          PerfilUsuario perfil = new PerfilUsuario();
          perfil.Codigo = (int)dr["ID_PERFIL_USUARIO"];
          perfil.Descricao = (string)dr["DESCRICAO"].ToString();
         
          lista.Add(perfil);
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
    

   
    public PerfilUsuario ConsultarPerfilUsuarioCodigo(int codigo) 
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {

        PerfilUsuario perfil = null;
        string sql = GenericaSQL.ConsultarPerfilUsuarioCodigo(codigo);

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        dr.Read();

        perfil = new PerfilUsuario();
        perfil.Codigo = (int)dr["ID_PERFIL_USUARIO"];
        perfil.Descricao = dr["DESCRICAO"].ToString();


        dr.Close();

        return perfil;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {

      }
    }
   

    public List<PerfilUsuario> ConsultarAllPerfilUsuarioFiltros(int codigo, string descricao) 
    {
      GenericaDAO dao = GenericaDAO.getInstancia();

      try
      {
        List<PerfilUsuario> lista = new List<PerfilUsuario>();
        string sql = GenericaSQL.ConsultarAllPerfilUsuarioFiltros(codigo, descricao);

        SqlDataReader dr = dao.ExecuteReader(CommandType.Text, sql);

        while (dr.Read())
        {
          PerfilUsuario perfil = new PerfilUsuario();
          perfil.Codigo = (int)dr["ID_PERFIL_USUARIO"];
          perfil.Descricao = (string)dr["DESCRICAO"].ToString();
          lista.Add(perfil);
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

    //CADASTRAR PERFIL USUARIO
    public void CadastrarPerfilUsuario(PerfilUsuario perfilUsuario)
    {
      string sql = GenericaSQL.CadastrarPerfilUsuario(perfilUsuario);
      GenericaDAO dao = GenericaDAO.getInstancia();

      dao.ExecuteNonQuery(CommandType.Text, sql);
    }

    //UPDATE PERFIL USUARIO
    public void UpdatePerfilUsuario(PerfilUsuario perfilUsuario) 
    {
      string sql = GenericaSQL.UpdatePerfilUsuario(perfilUsuario);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }

    //DELETAR PERFIL USUARIO
    public void DeletePerfilUsuario(int id)
    {
      string sql = GenericaSQL.DeletePerfilUsuario(id);
      GenericaDAO dao = GenericaDAO.getInstancia();
      dao.ExecuteNonQuery(CommandType.Text, sql);
    }
   
  }
}