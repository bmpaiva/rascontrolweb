using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassesBasicas;
using System.Text;

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
            " INNER JOIN TBHISTORIASPRINT AS TBHI ON TBA.ID_ESTORIA_SPRINTS = TBHI.ID_ESTORIA_SPRINT " +
            " INNER JOIN TBSPRINTS AS TBS ON TBHI.ID_ESTORIA_SPRINT = TBS.ID_SPRINT " +
            " WHERE  (TBS.ID_PROJETO = " + idProjeto.ToString() + ") AND (TBS.ID_SPRINT = " + idSprint.ToString() + ") ";
        }

        public static string SelectTamanhoRealizadoDia(int idProjeto, int idSprint, int dia)
        {
            return 
            " SELECT TBA.DURACAO_ESTIMADA "+
            " FROM TBENVOLVIDOS AS TBE INNER JOIN "+
            " TBATIVIDADE AS TBA ON TBE.ID_ATIVIDADE = TBA.ID_ATIVIDADE INNER JOIN "+
            " TBHISTORIASPRINT AS TBHI ON TBA.ID_ESTORIA_SPRINTS = TBHI.ID_ESTORIA_SPRINT INNER JOIN "+
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

        public static string ConsultarPermissaoDescricao(string descricao)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_PERMISSAO, DESCRICAO, OBSERVACAO ");
            query.Append(" FROM TBPERMISSOES ");
            query.Append(" Where IND_ATIVO = 'S'");
            if (descricao != "")
            {
                query.Append(" And DESCRICAO = " + descricao);
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
            return "INSERT INTO tbpermissoes " +
                   " (ID_PERMISSAO, " +
                   " DESCRICAO, " +
                   " OBSERVACAO) " +                   
                   " VALUES (" +
                   + permissao.Codigo + ", " +
                   " '" + permissao.Descricao + "', " +
                   " '" + permissao.Observacao + "' " +                  
                   " );";
        }

        public static string UpdatePermissao(Permissao permissao)
        {
            return "UPDATE TBPERMISSAO SET "
            + "DESCRICAO = '" + permissao.Descricao + "' "
             + "OBSERVACAO = '" + permissao.Observacao + "' "
            + " WHERE ID_PERMISSAO = " + permissao.Codigo + " AND  IND_ATIVO = 'S'";
        }

        public static string DeletePermissao(int idPermissao)
        {
            return "UPDATE TBPERMISSAO SET IND_ATIVO = 'N' WHERE ID_PERMISSAO = " + idPermissao + " AND  IND_ATIVO = 'S'";
        }


    #endregion
    }
}