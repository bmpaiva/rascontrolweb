using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace IDAO
{
  public interface IDAOTipoAtividade
  {
    List<TipoAtividade> ConsultarAllTipoAtividade();
    TipoAtividade ConsultarTipoAtividadeCodigo(int codigo);
    List<TipoAtividade> ConsultarAllTipoAtividadeFiltros(int codigo, string descricao);
    void CadastrarTipoAtividade(TipoAtividade tAtividade);
    void UpdateTipoAtividade(TipoAtividade tAtividade);
    void DeleteTipoAtividade(int id); 
  }
}
