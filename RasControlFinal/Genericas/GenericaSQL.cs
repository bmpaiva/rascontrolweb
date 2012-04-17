using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using ClassesBasicas;

namespace Genericas
{
    public static class GenericaSQL
    {

        #region Usuario

        public static string SelectUsuario()
        {
            return " SELECT " +
                   " TBUSUARIO.ID_USUARIO, TBUSUARIO.NOME" +
                   " FROM TBUSUARIO ";
        }

        #endregion

        #region Burn_DownUp

        public static string SelectQtdDiasSprint(int idProjeto, int idSprint)
        {
            return 
            " Select Distinct(QTD_DIAS) " +
            " From TBSPRINTS " +
            " Where (ID_SPRINT = " + idProjeto.ToString() + " ) AND (ID_PROJETO =" + idSprint.ToString() + ") ";           
           
        }

        public static string SelectQtdHorasPlanejadaSprint(int idProjeto, int idSprint)
        {
            return
            " SELECT SUM(TBA.DURACAO_ESTIMADA) AS DURACAO_ESTIMADA " +
            " FROM TBATIVIDADE AS TBA " +
            " INNER JOIN TBESTORIASPRINT AS TBHI ON TBA.ID_ESTORIA_SPRINT = TBHI.ID_ESTORIA_SPRINT " +
            " INNER JOIN TBSPRINTS AS TBS ON TBHI.ID_ESTORIA_SPRINT = TBS.ID_SPRINT " +
            " WHERE  (TBS.ID_PROJETO = " + idProjeto.ToString() + ") AND (TBS.ID_SPRINT = " + idSprint.ToString() + ") ";
        }

        public static string SelectTamanhoRealizadoDia(int idProjeto, int idSprint, int dia)
        {
            return 
            " SELECT TBA.DURACAO_ESTIMADA "+
            " FROM TBENVOLVIDOS AS TBE INNER JOIN "+
            " TBATIVIDADE AS TBA ON TBE.ID_ATIVIDADE = TBA.ID_ATIVIDADE INNER JOIN "+
            " TBESTORIASPRINT AS TBHI ON TBA.ID_ESTORIA_SPRINT = TBHI.ID_ESTORIA_SPRINT INNER JOIN "+
            " TBSPRINTS AS TBS ON TBHI.ID_SPRINT = TBS.ID_SPRINT "+
            " WHERE (TBE.STATUS = 'CO') AND (TBS.ID_SPRINT =  " + idSprint.ToString() + ") AND (TBS.ID_PROJETO = " + idProjeto.ToString() + ") AND (TBE.DIA_SPRINT =  " + dia.ToString() + ") ";

        }          

        #endregion

        #region Desempenho Membros

        public static string SelectQtdUsuariosProjeto(int idProjeto)
        {
            return
            " Select Count(Distinct(ID_USUARIO)) " +
            " From TBUSUARIOPROJETO " +
            " Where (ID_PROJETO = " + idProjeto.ToString() + " )";
        }

        public static string SelectIdUsuariosProjeto(int idProjeto)
        {
            return
            " Select ID_USUARIO " +
            " From TBUSUARIOPROJETO " +
            " Where (ID_PROJETO = " + idProjeto.ToString() + " )";
        }

        public static string SelectIdSprintsProjeto(int idProjeto)
        {
            return
            " Select ID_SPRINT " +
            " From TBSPRINTS " +
            " Where (ID_PROJETO = " + idProjeto.ToString() + " )";
        }

        public static string SelectNomeUsuario(int idUsuario)
        {
            return
            " Select NOME " +
            " From TBUSUARIO " +
            " Where (ID_USUARIO = " + idUsuario.ToString() + " )";
        }

        public static string SelectMediaAvaliacaoUsuarioSprint(int idSprint, int idUsuario)
        {
            return
            " Select AVG(NOTA_AVALIADO) AS MEDIA " +
            " From TBAVALIACAO360 " +
            " Where (ID_USUARIO_AVALIADO = " + idUsuario.ToString() + " )"+
            " And (ID_SPRINT = " + idSprint.ToString() + " )";
        }
       


        #endregion

        #region permissao

        public static string ConsultarPermissaoCodigo(int codigo)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_PERMISSAO, DESCRICAO, OBSERVACAO ");
            query.Append(" FROM TBPERMISSOES ");
            query.Append(" Where IND_ATIVO = 'S'");
            if (codigo.ToString() != "")
            {
                query.Append(" And ID_PERMISSAO = " + codigo.ToString());
            }
            return query.ToString();
        }

        public static string ConsultarAllPermissaoFiltros(int codigo, string descricao)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_PERMISSAO, DESCRICAO, OBSERVACAO ");
            query.Append(" FROM TBPERMISSOES ");
            query.Append(" Where IND_ATIVO = 'S'");
            if (descricao != "")
            {
                query.Append(" And DESCRICAO = '" + descricao + "'");
            }
            if (codigo >= 0)
            {
                query.Append(" And ID_PERMISSAO = " + codigo.ToString());
            }
            return query.ToString();
        }

        public static string ConsultarAllPermissao()
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_PERMISSAO, DESCRICAO, OBSERVACAO ");
            query.Append(" FROM TBPERMISSOES ");
            query.Append(" Where IND_ATIVO = 'S'");
           
            return query.ToString();            
        }

        public static string CadastrarPermissao(Permissao permissao)
        {
            return "INSERT INTO TBPERMISSOES " +                
                   " ( DESCRICAO, " +
                   " OBSERVACAO, " +
                   " IND_ATIVO  ) " +                   
                   " VALUES (" +            
                   " '" + permissao.Descricao + "', " +
                   " '" + permissao.Observacao + "', " +
                    " 'S' " +   
                   " );";
        }

        public static string UpdatePermissao(Permissao permissao)
        {
            return "UPDATE TBPERMISSOES SET "
            + "DESCRICAO = '" + permissao.Descricao + "' , "
             + "OBSERVACAO = '" + permissao.Observacao + "' "
            + " WHERE ID_PERMISSAO = " + permissao.Codigo + " AND  IND_ATIVO = 'S'";
        }

        public static string DeletePermissao(int idPermissao)
        {
            return "UPDATE TBPERMISSOES SET IND_ATIVO = 'N' WHERE ID_PERMISSAO = " + idPermissao + " AND  IND_ATIVO = 'S'";
        }


    #endregion

      #region PerfilUsuario
        public static string ConsultarPerfilUsuarioCodigo(int codigo)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_PERFIL_USUARIO, DESCRICAO");
          query.Append(" FROM TBPERFILUSUARIO ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (codigo.ToString() != "")
          {
            query.Append(" And ID_PERFIL_USUARIO = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllPerfilUsuarioFiltros(int codigo, string descricao)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_PERFIL_USUARIO, DESCRICAO ");
          query.Append(" FROM TBPERFILUSUARIO ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (descricao != "")
          {
            query.Append(" And DESCRICAO = '" + descricao + "'");
          }
          if (codigo >= 0)
          {
            query.Append(" And ID_PERFIL_USUARIO = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllPerfilUsuario()
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_PERFIL_USUARIO, DESCRICAO ");
          query.Append(" FROM TBPERFILUSUARIO ");
          query.Append(" Where IND_ATIVO = 'S'");

          return query.ToString();
        }

        public static string CadastrarPerfilUsuario(PerfilUsuario perfilUsuario)
        {
          //return "INSERT INTO TBPERFILUSUARIO (DESCRICAO, IND_ATIVO) VALUES ('"+ perfilUsuario.Descricao + "' , 'S')";
          return "INSERT INTO TBPERFILUSUARIO " +
                 " ( DESCRICAO, " +
                 " IND_ATIVO  ) " +
                 " VALUES (" +
                 " '" + perfilUsuario.Descricao + "', " +
                 " 'S' " +
                 " );";
        }

        public static string UpdatePerfilUsuario(PerfilUsuario perfilUsuario)
        {
          return "UPDATE TBPERFILUSUARIO SET DESCRICAO = '" + perfilUsuario.Descricao + "'"
          + " WHERE ID_PERFIL_USUARIO = " + perfilUsuario.Codigo + " AND  IND_ATIVO = 'S'";
        
        }

        public static string DeletePerfilUsuario(int idPerfilUsuario)
        {
          return "UPDATE TBPERFILUSUARIO SET IND_ATIVO = 'N' WHERE ID_PERFIL_USUARIO = " + idPerfilUsuario + " AND  IND_ATIVO = 'S'";
        }
      #endregion

      #region TipoAtividade

        public static string ConsultarTipoAtividadeCodigo(int codigo)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_TIPOATIVIDADE, DESCRICAO");
          query.Append(" FROM TBTIPOATIVIDADE ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (codigo.ToString() != "")
          {
            query.Append(" And ID_TIPOATIVIDADE = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllTipoAtividadeFiltros(int codigo, string descricao)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_TIPOATIVIDADE, DESCRICAO");
          query.Append(" FROM TBTIPOATIVIDADE ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (descricao != "")
          {
            query.Append(" And DESCRICAO = '" + descricao + "'");
          }
          if (codigo >= 0)
          {
            query.Append(" And ID_TIPOATIVIDADE = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllTipoAtividade()
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_TIPOATIVIDADE, DESCRICAO ");
          query.Append(" FROM TBTIPOATIVIDADE ");
          query.Append(" Where IND_ATIVO = 'S'");

          return query.ToString();
        }

        public static string CadastrarTipoAtividade(TipoAtividade tAtividade)
        {
          return "INSERT INTO TBTIPOATIVIDADE " +
                 " ( DESCRICAO, " +
                 " IND_ATIVO  ) " +
                 " VALUES (" +
                 " '" + tAtividade.Descricao + "', " +
                 " 'S' " +
                 " );";
        }

        public static string UpdateTipoAtividade(TipoAtividade tAtividade)
        {
          return "UPDATE TBTIPOATIVIDADE SET "
          + "DESCRICAO = '" + tAtividade.Descricao + "' , "
          + " WHERE ID_TIPOATIVIDADE = " + tAtividade.Codigo + " AND  IND_ATIVO = 'S'";
        }

        public static string DeleteTipoAtividade(int idtAtividade)
        {
          return "UPDATE TBTIPOATIVIDADE SET IND_ATIVO = 'N' WHERE ID_TIPOATIVIDADE = " + idtAtividade + " AND  IND_ATIVO = 'S'";
        }


      #endregion

      #region Atividade

        public static string ConsultarAtividadeCodigo(int codigo)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_ATIVIDADE, ID_TIPO_ATIVIDADE, ID_ESTORIA_SPRINT, DESCRICAO, OBSERVACAO, DURACAO_ESTIMADA, DURACAO_REALIZADA, STATUS, IND_ATIVO");
          query.Append(" FROM TBATIVIDADE ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (codigo.ToString() != "")
          {
            query.Append(" And ID_ATIVIDADE = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllAtividadeFiltros(int codigo, string descricao)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_ATIVIDADE, DESCRICAO");
          query.Append(" FROM TBATIVIDADE ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (descricao != "")
          {
            query.Append(" And DESCRICAO = '" + descricao + "'");
          }
          if (codigo >= 0)
          {
            query.Append(" And ID_ATIVIDADE = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllAtividade()
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_ATIVIDADE, DESCRICAO ");
          query.Append(" FROM TBATIVIDADE ");
          query.Append(" Where IND_ATIVO = 'S'");

          return query.ToString();
        }

        public static string CadastrarAtividade(Atividade atividade)
        {
          return "INSERT INTO TBATIVIDADE " +
                 " ( ID_TIPO_ATIVIDADE, " +
                 " ID_ESTORIA_SPRINT, " +
                 " DESCRICAO, " +
                 " OBSERVACAO, " +
                 " DURACAO_ESTIMADA, " +
                 " DURACAO_REALIZADA, " +
                 " STATUS, " +
                 " IND_ATIVO  ) " +
                 " VALUES (" +
                 atividade.IdTipoAtividade +
                 atividade.IdEstoriaSprint +
                 " '" + atividade.Descricao + "', " +
                 " '" + atividade.Observacao + "', " +
                 atividade.DuracaoEstimada +
                 atividade.DuracaoRealizada +
                 " '" + atividade.Status + "', " +
                 " 'S' " +
                 " );";
        }

        public static string UpdateAtividade(Atividade atividade)
        {
          return "UPDATE TBATIVIDADE SET "
          + "DESCRICAO = '" + atividade.Descricao + "' , "
          + "OBSERVACAO = '" + atividade.Observacao + "' , "
          + "DURACAO_ESTIMADA = " + atividade.DuracaoEstimada + ", "
          + "DURACAO_REALIZADA = " + atividade.DuracaoRealizada + ", "
          + "STATUS = '" + atividade.Status + "' , "
          + " WHERE ID_ATIVIDADE = " + atividade.Codigo + " AND  IND_ATIVO = 'S'";
        }

        public static string DeleteAtividade(int idAtividade)
        {
          return "UPDATE TBATIVIDADE SET IND_ATIVO = 'N' WHERE ID_ATIVIDADE = " + idAtividade + " AND  IND_ATIVO = 'S'";
        }


      #endregion Atividade


      #region Estoria

        public static string ConsultarEstoriaCodigo(int codigo)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_ESTORIA, ID_PROJETO, DESCRICAO, SP, BV, ROI, IND_ATIVO");
          query.Append(" FROM TBESTORIA ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (codigo.ToString() != "")
          {
            query.Append(" And ID_ESTORIA = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllEstoriaFiltros(int codigo, string descricao)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_ESTORIA, DESCRICAO");
          query.Append(" FROM TBESTORIA ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (descricao != "")
          {
            query.Append(" And DESCRICAO = '" + descricao + "'");
          }
          if (codigo >= 0)
          {
            query.Append(" And ID_ESTORIA = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllEstoria()
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_ESTORIA, DESCRICAO ");
          query.Append(" FROM TBESTORIA ");
          query.Append(" Where IND_ATIVO = 'S'");

          return query.ToString();
        }

        public static string CadastrarEstoria(Estoria estoria)
        {
          return "INSERT INTO TBESTORIA " +
                 " ( ID_PROJETO, " +
                 " DESCRICAO, " +
                 " SP, " +
                 " BV, " +
                 " ROI, " +
                 " IND_ATIVO  ) " +
                 " VALUES (" +
                 estoria.IdProjeto +
                 " '" + estoria.Descricao + "', " +
                 estoria.Sp +
                 estoria.Bv +
                 estoria.Roi +
                 " 'S' " +
                 " );";
        }

        public static string UpdateEstoria(Estoria estoria)
        {
          return "UPDATE TBESTORIA SET "
          + "DESCRICAO = '" + estoria.Descricao + "' , "
          + "SP = '" + estoria.Sp + "' , "
          + "BV = " + estoria.Bv + ", "
          + "ROI = " + estoria.Roi + ", "
          
          + " WHERE ID_ESTORIA = " + estoria.Codigo + " AND  IND_ATIVO = 'S'";
        }

        public static string DeleteEstoria(int idEstoria)
        {
          return "UPDATE TBESTORIA SET IND_ATIVO = 'N' WHERE ID_ESTORIA = " + idEstoria + " AND  IND_ATIVO = 'S'";
        }


      #endregion

      #region Projeto

        public static string ConsultarProjetoCodigo(int codigo)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_PROJETO, DESCRICAO, NOME, DATA_INCLUSAO, STATUS, IND_ATIVO");
          query.Append(" FROM TBPROJETO ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (codigo.ToString() != "")
          {
            query.Append(" And ID_PROJETO = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllProjetoFiltros(int codigo, string descricao)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_PROJETO, DESCRICAO");
          query.Append(" FROM TBPROJETO ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (descricao != "")
          {
            query.Append(" And DESCRICAO = '" + descricao + "'");
          }
          if (codigo >= 0)
          {
            query.Append(" And ID_PROJETO = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllProjeto()
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_PROJETO, DESCRICAO ");
          query.Append(" FROM TBPROJETO");
          query.Append(" Where IND_ATIVO = 'S'");

          return query.ToString();
        }

        public static string CadastrarProjeto(Projeto projeto)
        {
          return "INSERT INTO TBPROJETO " +
                 " (DESCRICAO, " +
                 " NOME, " +
                 " DATA_INCLUSAO, " +
                 " STATUS, " +
                 " IND_ATIVO  ) " +
                 " VALUES (" +
                 " '" + projeto.Descricao + "', " +
                 " '" + projeto.Nome + "', " +
                 " '" + projeto.DtInclusao + "', " +
                 " '" + projeto.Status + "', " +
                 " 'S' " +
                 " );";
        }

        public static string UpdateProjeto(Projeto projeto)
        {
          return "UPDATE TBPROJETO SET "
          + "DESCRICAO = '" + projeto.Descricao + "' , "
          + "NOME = '" + projeto.Nome + "' , "
          + "DATA_INCLUSAO = '" + projeto.DtInclusao + "' , "
          + "STATUS = '" + projeto.Status + "' , "
          + " WHERE ID_PROJETO = " + projeto.Codigo + " AND  IND_ATIVO = 'S'";
        }

        public static string DeleteProjeto(int idProjeto)
        {
          return "UPDATE TBPROJETO SET IND_ATIVO = 'N' WHERE ID_PROJETO = " + idProjeto + " AND  IND_ATIVO = 'S'";
        }


      #endregion

      #region Avaliacao360

        public static string ConsultarAvaliacao360Codigo(int codigo)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_AVALIACAO, ID_SPRINT, ID_USUARIO_AVALIADOR, NOTA_AVALIADO, ID_USUARIO_AVALIADO, JUSTIFICATIVA,  IND_ATIVO");
          query.Append(" FROM TBAVALIACAO360 ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (codigo.ToString() != "")
          {
            query.Append(" And ID_AVALIACAO = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllAvaliacao360Filtros(int codigo, string justificativa)
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_AVALIACAO, JUSTIFICATIVA");
          query.Append(" FROM TBAVALIACAO360 ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (justificativa != "")
          {
            query.Append(" And JUSTIFICATIVA = '" + justificativa + "'");
          }
          if (codigo >= 0)
          {
            query.Append(" And ID_AVALIACAO = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllAvaliacao360()
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT SELECT ID_AVALIACAO, ID_SPRINT, ID_USUARIO_AVALIADOR, NOTA_AVALIADO, ID_USUARIO_AVALIADO, JUSTIFICATIVA,  IND_ATIVO ");
          query.Append(" FROM TBAVALIACAO360");
          query.Append(" Where IND_ATIVO = 'S'");

          return query.ToString();
        }

        public static string CadastrarAvaliacao360(Avaliacao360 avaliacao)
        {
          return "INSERT INTO TBAVALIACAO360 " +
                 " (ID_SPRINT, " +
                 " ID_USUARIO_AVALIADOR, " +
                 " NOTA_AVALIADO, " +
                 " ID_USUARIO_AVALIADO, " +
                 " JUSTIFICATIVA, " +
                 " IND_ATIVO  ) " +
                 " VALUES (" +
                 avaliacao.IdSprint +
                 avaliacao.IdAvaliador +
                 avaliacao.Nota +
                 avaliacao.IdAvaliado +
                 " '" + avaliacao.Justificativa + "', " +
                 " 'S' " +
                 " );";
        }

        public static string UpdateAvaliacao360(Avaliacao360 avaliacao)
        {
          return "UPDATE TBAVALIACAO360 SET "
          + "NOTA_AVALIADO = " + avaliacao.Nota + " , "
          + "JUSTIFICATIVA = '"+ avaliacao.Justificativa + "', "         
          + " WHERE ID_AVALIACAO = " + avaliacao.Codigo + " AND  IND_ATIVO = 'S'";
        }

        public static string DeleteAvaliacao360(int idAvaliacao)
        {
          return "UPDATE TBAVALIACAO360 SET IND_ATIVO = 'N' WHERE ID_AVALIACAO = " + idAvaliacao + " AND  IND_ATIVO = 'S'";
        }


      #endregion
    }
}