using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace IDAO
{
  public interface IDAOProjeto
  {
    List<Projeto> ConsultarAllProjeto();
    Projeto ConsultarProjetoCodigo(int codigo);
    List<Projeto> ConsultarAllProjetoFiltros(int codigo, string descricao);
    void CadastrarProjeto(Projeto projeto);
    void UpdateProjeto(Projeto projeto);
    void DeleteProjeto(int id);
  }
}
