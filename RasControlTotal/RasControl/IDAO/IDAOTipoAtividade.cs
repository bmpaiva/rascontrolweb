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
        TipoAtividade ConsultarTipoAtividadeCodigo(int id_tipoatividade);
        List<TipoAtividade> ConsultarAllTipoAtividadeFiltros(int id_tipoatividade, string descricao);
        void CadastrarTipoAtividade(TipoAtividade tipoAtividade);
        void UpdateTipoAtividade(TipoAtividade tipoAtividade);
        void DeleteTipoAtividade(int id_tipoatividade);
    }
}
