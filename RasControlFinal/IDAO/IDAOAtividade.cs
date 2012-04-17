using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace IDAO
{
  public interface IDAOAtividade
  {
    List<Atividade> ConsultarAllAtividade();
    Atividade ConsultarAtividadeCodigo(int codigo);
    List<Atividade> ConsultarAllAtividadeFiltros(int codigo, string descricao);
    void CadastrarAtividade(Atividade atividade);
    void UpdateAtividade(Atividade atividade);
    void DeleteAtividade(int id); 
  }
}
