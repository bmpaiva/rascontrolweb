﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace IDAO
{
  public interface IDAOAtividade
  {
      List<Atividade> ConsultarAllAtividade();
      Atividade ConsultarAtividadeCodigo(int id_atividade);
      List<Atividade> ConsultarAllAtividadeFiltros(int id_atividade,int id_tipo_atividade, int id_estoria_sprint, string descricao, double duracao_estimada, double duracao_realizada);

      void CadastrarAtividade(Atividade atividade);
      void UpdateAtividade(Atividade atividade);
      void DeleteAtividade(int id_atividade);
  }
}
