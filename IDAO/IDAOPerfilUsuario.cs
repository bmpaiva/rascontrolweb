using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;


namespace IDAO
{
  public interface IDAOPerfilUsuario
  {
    List<PerfilUsuario> ConsultarAllPerfilUsuario();
    PerfilUsuario ConsultarPerfilUsuarioCodigo(int codigo);
    List<PerfilUsuario> ConsultarAllPerfilUsuarioFiltros(int codigo, string descricao);
    void CadastrarPerfilUsuario(PerfilUsuario perfilUsuario);
    void UpdatePerfilUsuario(PerfilUsuario perfilUsuario);
    void DeletePerfilUsuario(int id);     
  }
}
