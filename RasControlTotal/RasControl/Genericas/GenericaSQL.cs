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

        //Consultar os usuarios pelo codigo
        public static string ConsultarUsuarioCodigo(int codigo)
        {
            StringBuilder query = new StringBuilder();
            //Quais os dados que serão selecionados
            query.Append(" SELECT ID_USUARIO, NOME, OBSERVACAO, TELEFONE, CELULAR, CPF, RG, LOGIN, SENHA, EMAIL, ID_PERFILUSUARIO");
            //Qual a tabela de onde será buscado
            query.Append(" FROM TBUSUARIO ");
            //e quando o indice for "S"
            query.Append(" Where IND_ATIVO = 'S'");
            //Se o codigo tiver sido declarado
            if (codigo.ToString() != "")
            {
                //Deverá ser puxado a partir do codigo
                query.Append(" And ID_USUARIO = " + codigo.ToString());
            }
            return query.ToString();
        }

        //Consultar os usuarios pelo codigo e pelo cpf
        public static string ConsultarAllUsuarioFiltros(int codigo, string cpf)
        {
            StringBuilder query = new StringBuilder();
            //Quais os dados que serão selecionados
            query.Append(" SELECT ID_USUARIO, NOME, OBSERVACAO, TELEFONE, CELULAR, CPF, RG, LOGIN, SENHA, EMAIL, ID_PERFILUSUARIO");
            //Qual a tabela de onde será buscado
            query.Append(" FROM TBUSUARIO ");
            //e quando o indice for "S"
            query.Append(" Where IND_ATIVO = 'S'");
            if (cpf != "")
            {
                query.Append(" And CPF = '" + cpf + "'");
            }
            if (codigo >= 0)
            {
                query.Append(" And ID_USUARIO = " + codigo.ToString());
            }
            return query.ToString();
        }

        //Consultar todos os usuarios
        public static string ConsultarAllUsuario()
        {
            StringBuilder query = new StringBuilder();
            //Quais os dados que serão selecionados
            query.Append(" SELECT ID_USUARIO, NOME, OBSERVACAO, TELEFONE, CELULAR, CPF, RG, LOGIN, SENHA, EMAIL, ID_PERFILUSUARIO");
            //Qual a tabela de onde será buscado
            query.Append(" FROM TBUSUARIO ");
            //e quando o indice for "S"
            query.Append(" Where IND_ATIVO = 'S'");

            return query.ToString();
        }

        //Metodo para cadastrar
        public static string CadastrarUsuario(Usuario usuario)
        {
            return "INSERT INTO TBUSUARIO " +
                   " ( NOME, TELEFONE,  CELULAR,  CPF,  RG, EMAIL, LOGIN, SENHA, OBSERVACAO, IND_ATIVO, ID_PERFILUSUARIO  ) " +
                   " VALUES (" +
                   " '" + usuario.Nome + "', '" + usuario.Telefone + "',  '" + usuario.Celular + "',  '" + usuario.Cpf + "', '" + usuario.Rg + "', " +
                   " '" + usuario.Email + "', '" + usuario.Login + "', '" + usuario.Senha + "', '" + usuario.Observacao + "', 'S', " + usuario.PerfilUsuario.Codigo + " );";
        }

        //Metodo para alterar
        public static string UpdateUsuario(Usuario usuario)
        {
            return "UPDATE TBUSUARIO SET "
            + "NOME = '" + usuario.Nome + "' , "
            + "CELULAR = '" + usuario.Nome + "' , "
            + "TELEFONE = '" + usuario.Telefone + "' , "
            + "CPF = '" + usuario.Cpf + "' , "
            + "RG = '" + usuario.Rg + "' , "
            + "EMAIL = '" + usuario.Email + "' , "
            + "LOGIN = '" + usuario.Login + "' , "
            + "SENHA = '" + usuario.Senha + "' , "
            + "OBSERVACAO = '" + usuario.Observacao + "', "
            + "ID_PERFILUSUARIO = " + usuario.PerfilUsuario.Codigo + " "            
            + " WHERE ID_USUARIO = " + usuario.Codigo + " AND  IND_ATIVO = 'S'";
        }

        //"Deletar" o Usuario
        public static string DeleteUsuario(int idUsuario)
        {
            return "UPDATE TBUSUARIO SET IND_ATIVO = 'N' WHERE ID_USUARIO = " + idUsuario + " AND  IND_ATIVO = 'S'";
        }

        //Consultar os usuarios pelo codigo e pelo cpf
        public static string ValidarLogin(string login, string senha)
        {
            StringBuilder query = new StringBuilder();          
            query.Append(" SELECT LOGIN, SENHA");
            query.Append(" FROM TBUSUARIO ");           
            query.Append(" Where IND_ATIVO = 'S'");
            if (login != "")
            {
                query.Append(" And LOGIN = '" + login + "'");
            }
            if (senha != "")
            {
                query.Append(" And SENHA = '" + senha + "'");
            }
            return query.ToString();
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
            if (descricao != "" && descricao != null)
            {
                query.Append(" And DESCRICAO = '" + descricao + "'");
            }
            if (codigo >= 0)
            {
                query.Append(" And ID_PERMISSAO = " + codigo.ToString());
            }
            return query.ToString();
        }


        public static string ConsultarAllPermissaoPerfil(int idPerfil)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_PERMISSAO ");
            query.Append(" FROM TBPERFILPERMISSAO ");
            
            if (idPerfil >= 0)
            {
                query.Append(" Where ID_PERFIL = " + idPerfil.ToString());
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

        public static string CadastrarPermissaoPerfil(int idPerfil, Permissao permissao)
        {
            return "INSERT INTO TBPERFILPERMISSAO " +
                   " ( ID_PERFIL, " +
                   " ID_PERMISSAO) " +
                   " VALUES (" +
                   " " + idPerfil.ToString() + ", " +
                   " " + permissao.Codigo.ToString() + "); ";
          
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

        public static string DeletePerfilPermissao(int idPerfil,int idPermissao)
        {
            return "DELETE FROM TBPERFILPERMISSAO WHERE ID_PERMISSAO = " + idPermissao.ToString() + " AND  ID_PERFIL = " + idPerfil.ToString();
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
            + "DATA_INCLUSAO = '" + projeto.DtInclusao + "' "         
            + " WHERE ID_PROJETO = " + projeto.Codigo + " AND  IND_ATIVO = 'S'";
        }

        public static string DeleteProjeto(int idProjeto)
        {
            return "UPDATE TBPROJETO SET IND_ATIVO = 'N' WHERE ID_PROJETO = " + idProjeto + " AND  IND_ATIVO = 'S'";
        }


        #endregion

        #region Atividade

        public static string ConsultarAtividadeCodigo(int id_atividade)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_ATIVIDADE, ID_TIPO_ATIVIDADE, ID_ESTORIA_SPRINT, DESCRICAO, OBSERVACAO, DURACAO_ESTIMADA, DURACAO_REALIZADA , STATUS ");
            query.Append(" FROM TBATIVIDADE ");
            query.Append(" Where IND_ATIVO = 'S'");
            if (id_atividade.ToString() != "")
            {
                query.Append(" And ID_ATIVIDADE = " + id_atividade.ToString());
            }
            return query.ToString();
        }

        public static string ConsultarAllAtividadeFiltros(int id_atividade, int id_tipo_atividade, int id_estoria_sprint, string descricao, double duracao_estimada, double duracao_realizada)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_ATIVIDADE,ID_TIPO_ATIVIDADE, ID_ESTORIA_SPRINT, DESCRICAO, DURACAO_ESTIMADA, DURACAO_REALIZADA");
            query.Append(" FROM TBATIVIDADE ");
            query.Append(" Where IND_ATIVO = 'S'");
            if (descricao != "")
            {
                query.Append(" And DESCRICAO = '" + descricao + "'");
            }
            if (id_atividade >= 0)
            {
                query.Append(" And ID_ATIVIDADE = " + id_atividade.ToString());
            }
            if (id_tipo_atividade >= 0)
            {
                query.Append("And ID_TIPO_ATIVIDADE = " + id_tipo_atividade.ToString());
            }
            if (id_estoria_sprint >= 0)
            {
                query.Append("And ID_ESTORIA_SPRINT = " + id_estoria_sprint.ToString());
            }
            if (duracao_estimada >= 0)
            {
                query.Append("And DURACAO_ESTIMADA = " + duracao_estimada.ToString());
            }
            if (duracao_realizada >= 0)
            {
                query.Append("And DURACAO_REALIZADA = " + duracao_realizada.ToString());
            }

            return query.ToString();
        }

        public static string ConsultarAllAtividade()
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_ATIVIDADE, ID_TIPO_ATIVIDADE, ID_ESTORIA_SPRINT, DESCRICAO, OBSERVACAO, DURACAO_ESTIMADA, DURACAO_REALIZADA , STATUS ");
            query.Append(" FROM TBATIVIDADE ");
            query.Append(" Where IND_ATIVO = 'S'");

            return query.ToString();
        }

        public static string CadastrarAtividade(Atividade atividade)
        {
            return "INSERT INTO TBATIVIDADE " +
                   " ( ID_TIPO_ATIVIDADE, " +
                   " ID_ESTORIA_SPRINT, " +
                   " DESCRICAO," +
                   " OBSERVACAO, " +
                   " DURACAO_ESTIMADA, " +
                   " DURACAO_REALIZADA, " +
                   " STATUS, " +
                   " IND_ATIVO  ) " +
                   " VALUES (" +
                   " '" + atividade.Id_Tipo_Atividade + "', " +
                   " '" + atividade.Id_Estoria_Sprint + "', " +
                   " '" + atividade.Descricao + "', " +
                   " '" + atividade.Observacao + "', " +
                   " '" + atividade.Duracao_Estimada + "', " +
                   " '" + atividade.Duracao_Estimada + "', " +
                   " '" + atividade.Status + "', " +
                    " 'S' " +
                   " );";
        }

        public static string UpdateAtividade(Atividade atividade)
        {
            return "UPDATE TBATIVIDADE SET "
            + "ID_TIPO_ATIVIDADE = " + atividade.Id_Tipo_Atividade + ", "
            + "ID_ESTORIA_SPRINT = " + atividade.Id_Estoria_Sprint + " , "
            + "DESCRICAO = '" + atividade.Descricao + "' , "
            + "DURACAO_ESTIMADA = " + atividade.Duracao_Estimada + ", "
            + "DURACAO_REALIZADA = " + atividade.Duracao_Realizada + " "
            + " WHERE ID_ATIVIDADE = " + atividade.Id_Atividade + " AND  IND_ATIVO = 'S'";
        }

        public static string DeleteAtividade(int id_atividade)
        {
            return "UPDATE TBATIVIDADE SET IND_ATIVO = 'N' WHERE ID_ATIVIDADE = " + id_atividade + " AND  IND_ATIVO = 'S'";
        }

        #endregion

        #region Impedimentos

        public static string ConsultarImpedimentoCodigo(int id_impedimento)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_IMPEDIMENTO, ID_SPRINT, DESCRICAO, IND_ATIVO ");
            query.Append(" FROM TBIMPEDIMENTOS ");
            query.Append(" Where IND_ATIVO = 'S'");
            if (id_impedimento.ToString() != "")
            {
                query.Append(" And ID_IMPEDIMENTO = " + id_impedimento.ToString());
            }
            return query.ToString();
        }

        public static string ConsultarAllImpedimentoFiltros(int id_impedimento, int id_sprint, string descricao)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_IMPEDIMENTO, ID_SPRINT, DESCRICAO ");
            query.Append(" FROM TBIMPEDIMENTOS ");
            query.Append(" Where IND_ATIVO = 'S'");
            if (descricao != "")
            {
                query.Append(" And DESCRICAO = '" + descricao + "'");
            }
            if (id_impedimento >= 0)
            {
                query.Append(" And ID_IMPEDIMENTO = " + id_impedimento.ToString());
            }
            if (id_sprint >= 0)
            {
                query.Append("And ID_SPRINT = " + id_sprint.ToString());
            }
            return query.ToString();
        }

        public static string ConsultarAllImpedimentos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_IMPEDIMENTO, ID_SPRINT, DESCRICAO, IND_ATIVO ");
            query.Append(" FROM TBIMPEDIMENTOS ");
            query.Append(" Where IND_ATIVO = 'S'");

            return query.ToString();
        }

        public static string CadastrarImpedimento(Impedimentos impedimentos)
        {
            return "INSERT INTO TBIMPEDIMENTOS " +
                   " ( ID_SPRINT, " +
                   " DESCRICAO, " +
                   " IND_ATIVO  ) " +
                   " VALUES (" +
                   " '" + impedimentos.Id_Sprint + "', " +
                   " '" + impedimentos.Descricao + "', " +
                    " 'S' " +
                   " );";
        }

        public static string UpdateImpedimento(Impedimentos impedimentos)
        {
            return "UPDATE TBIMPEDIMENTOS SET "
            + "ID_SPRINT = '" + impedimentos.Id_Sprint + "' , "
            + "DESCRICAO = '" + impedimentos.Descricao + "' , "
            + " WHERE ID_IMPEDIMENTO = " + impedimentos.Id_Impedimento + " AND  IND_ATIVO = 'S'";
        }

        public static string DeleteImpedimento(int id_impedimento)
        {
            return "UPDATE TBIMPEDIMENTOS SET IND_ATIVO = 'N' WHERE ID_IMPEDIMENTO = " + id_impedimento + " AND  IND_ATIVO = 'S'";
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
            if (descricao != "" && descricao != null)
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
          query.Append(" SELECT ID_ESTORIA, ID_PROJETO, DESCRICAO, SP, BV, ROI");
          //query.Append(" SELECT ID_ESTORIA, DESCRICAO");
          query.Append(" FROM TBESTORIA ");
          query.Append(" Where IND_ATIVO = 'S'");
          if (descricao != "" && descricao != null)
          {
            query.Append(" And DESCRICAO = '" + descricao + "'");
          }
          if (codigo >= 0)
          {
              query.Append(" And ID_PROJETO = " + codigo.ToString());
          }
          return query.ToString();
        }

        public static string ConsultarAllEstoria()
        {
          StringBuilder query = new StringBuilder();
          query.Append(" SELECT ID_ESTORIA, ID_PROJETO, DESCRICAO, SP, BV, ROI ");
          query.Append(" FROM TBESTORIA ");
          query.Append(" Where IND_ATIVO = 'S'");

          return query.ToString();
        }

        public static string CadastrarEstoria(Estoria estoria)
        {
          return "INSERT INTO TBESTORIA " +
                 "(ID_PROJETO, " +
                 "DESCRICAO, " +
                 "SP, " +
                 "BV, " +
                 "ROI, " +
                 "IND_ATIVO) " +
                 "VALUES (" +
                 estoria.IdProjeto.Codigo +
                 ",'" + estoria.Descricao + "', " +
                 estoria.Sp + "," +
                 estoria.Bv + "," +
                 estoria.Roi + "," +
                 " 'S' " +
                 " );";
        }

        public static string UpdateEstoria(Estoria estoria)
        {
          return "UPDATE TBESTORIA SET "
          + "DESCRICAO = '" + estoria.Descricao + "' , "
          + "SP = '" + estoria.Sp + "' , "
          + "BV = " + estoria.Bv + ", "
          + "ROI = " + estoria.Roi

          + " WHERE ID_ESTORIA = " + estoria.Codigo + " AND  IND_ATIVO = 'S'";
        }

        public static string DeleteEstoria(int idEstoria)
        {
          return "UPDATE TBESTORIA SET IND_ATIVO = 'N' WHERE ID_ESTORIA = " + idEstoria + " AND  IND_ATIVO = 'S'";
        }


      #endregion

        #region Sprint

        public static string ConsultarSprintCodigo(int id_sprint)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_SPRINT, ID_PROJETO, DESCRICAO, DATA_INICIO, DATA_FIM, QTD_DIAS, IND_ATIVO ");
            query.Append(" FROM TBSPRINTS ");
            query.Append(" Where IND_ATIVO = 'S'");
            if (id_sprint.ToString() != "")
            {
                query.Append(" And ID_SPRINT = " + id_sprint.ToString());
            }
            return query.ToString();
        }

        public static string ConsultarAllSprintFiltros(int idProjeto, string descricao)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_SPRINT, ID_PROJETO, DESCRICAO, DATA_INICIO, DATA_FIM, QTD_DIAS ");
            query.Append(" FROM TBSPRINTS ");
            query.Append(" Where IND_ATIVO = 'S'");
            if (descricao != "" && descricao != null)
            {
                query.Append(" And DESCRICAO = '" + descricao + "'");
            }
            if (idProjeto >= 0)
            {
                query.Append(" And ID_PROJETO = " + idProjeto.ToString());
            }
            return query.ToString();
        }

        public static string ConsultarAllSprint()
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_SPRINT, ID_PROJETO, DESCRICAO, DATA_INICIO, DATA_FIM, QTD_DIAS, IND_ATIVO ");
            query.Append(" FROM TBSPRINTS ");
            query.Append(" Where IND_ATIVO = 'S'");

            return query.ToString();
        }

        public static string ConsultarAllSprintEstoria(int idSprint)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_ESTORIA_SPRINT ");
            query.Append(" FROM TBESTORIASPRINT ");

            if (idSprint >= 0)
            {
                query.Append(" Where ID_ESTORIA_SPRINT = " + idSprint.ToString());
            }
            return query.ToString();
        }

        public static string CadastrarSprint(Sprint sprint)
        {
            return "INSERT INTO TBSPRINTS " +
                   " ( ID_PROJETO, " +
                   " DESCRICAO, " +
                   " DATA_INICIO, " +
                   " DATA_FIM, " +
                   " QTD_DIAS, " +
                   " IND_ATIVO  ) " +
                   " VALUES (" +
                   " " + sprint.Id_Projeto + ", " +
                   " '" + sprint.Descricao + "', " +
                   " '" + sprint.Data_Inicio + "', " +
                   " '" + sprint.Data_Fim + "', " +
                   " '" + sprint.Qtd_Dias + "', " +
                    " 'S' " +
                   " );";
        }

        public static string UpdateSprint(Sprint sprint)
        {
            return "UPDATE TBSPRINTS SET "
            + "ID_PROJETO = '" + sprint.Id_Projeto + "' , "
            + "DESCRICAO = '" + sprint.Descricao + "' , "
            + "DATA_INICIO = '" + sprint.Data_Inicio + "' , "
            + "DATA_FIM = '" + sprint.Data_Fim + "' , "
            + "QTD_DIAS = '" + sprint.Qtd_Dias + "' ,"
            + " WHERE ID_SPRINT = " + sprint.Id_Sprint + " AND  IND_ATIVO = 'S'";
        }

        public static string DeleteSprint(int id_sprint)
        {
            return "UPDATE TBSPRINTS SET IND_ATIVO = 'N' WHERE ID_SPRINT = " + id_sprint + " AND  IND_ATIVO = 'S'";
        }

        public static string CadastrarSprintEstoria(int idSprint, Estoria estoria)
        {
            return "INSERT INTO TBESTORIASPRINT " +
                   " ( ID_SPRINT, " +
                   " ID_ESTORIA) " +
                   " VALUES (" +
                   " " + idSprint.ToString() + ", " +
                   " " + estoria.Codigo.ToString() + "); ";
        }

        public static string DeleteSprintEstoria(int idEstoria, int idSprint)
        {
            return "DELETE FROM TBESTORIASPRINT WHERE ID_SPRINT = " + idSprint.ToString() + " AND  ID_ESTORIA = " + idEstoria.ToString();
        }

        #endregion

        #region TipoAtividade

        public static string ConsultarTipoAtividadeCodigo(int id_tipoatividade)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_TIPOATIVIDADE, DESCRICAO");
            query.Append(" FROM TBTIPOATIVIDADE ");
            query.Append(" Where IND_ATIVO = 'S'");
            if (id_tipoatividade.ToString() != "")
            {
                query.Append(" And ID_TIPOATIVIDADE = " + id_tipoatividade.ToString());
            }
            return query.ToString();
        }

        public static string ConsultarAllTipoAtividadeFiltros(int id_tipoatividade, string descricao)
        {
            StringBuilder query = new StringBuilder();
            query.Append(" SELECT ID_TIPOATIVIDADE, DESCRICAO");
            query.Append(" FROM TBTIPOATIVIDADE ");
            query.Append(" Where IND_ATIVO = 'S'");
            if (descricao != "")
            {
                query.Append(" And DESCRICAO = '" + descricao + "'");
            }
            if (id_tipoatividade >= 0)
            {
                query.Append(" And ID_TIPOATIVIDADE = " + id_tipoatividade.ToString());
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

        public static string CadastrarTipoAtividade(TipoAtividade tipoAtividade)
        {
            return "INSERT INTO TBTIPOATIVIDADE " +
                   " ( DESCRICAO, " +
                   " IND_ATIVO  ) " +
                   " VALUES (" +
                   " '" + tipoAtividade.Descricao + "', " +
                   " 'S' " +
                   " );";
        }

        public static string UpdateTipoAtividade(TipoAtividade tipoAtividade)
        {
            return "UPDATE TBTIPOATIVIDADE SET "
            + "DESCRICAO = '" + tipoAtividade.Descricao + "'  "
            + " WHERE ID_TIPOATIVIDADE = " + tipoAtividade.Codigo + " AND  IND_ATIVO = 'S'";
        }

        public static string DeleteTipoAtividade(int id_tipoatividade)
        {
            return "UPDATE TBTIPOATIVIDADE SET IND_ATIVO = 'N' WHERE ID_TIPOATIVIDADE = " + id_tipoatividade + " AND  IND_ATIVO = 'S'";
        }


        #endregion
    }
   
}