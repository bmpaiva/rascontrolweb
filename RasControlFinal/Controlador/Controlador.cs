using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IDAO;
using DAO;
using Exceptions;
using ClassesBasicas;



namespace Controlador
{
    public class Controlador
    {
        IDAOPermissao iDaoPermissao;
        IDAOBurnDown iDAOBurnDown;
        IDAOPerfilUsuario iDaoPerfilUsuario;
        IDAOTipoAtividade iDaoTipoAtividade;
        IDAOAtividade iDaoAtividade;
        IDAOEstoria iDaoEstoria;
        IDAOProjeto iDaoProjeto;
        IDAOAvaliacao360 iDaoAvaliacao360;
     
        public Controlador()
        {
            try
            {
                iDaoPermissao = new DAOPermissao();
                iDAOBurnDown = new DAOBurnDown();
                iDaoPerfilUsuario = new DAOPerfilUsuario();
                iDaoTipoAtividade = new DAOTipoAtividade();
                iDaoAtividade = new DAOAtividade();
                iDaoEstoria = new DAOEstoria();
                iDaoProjeto = new DAOProjeto();
                iDaoAvaliacao360 = new DAOAvaliacao360();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Permissao

        public void ValidarPermissao(Permissao permissao)
        {
            if (permissao.Descricao == "")
            {
                throw new ExceptionGeral("A descrição da permissão não pode ser nula");
            }
            else if (permissao.Observacao == "")
            {
                throw new ExceptionGeral("A observação da permissão não pode ser nula");
            }            
        }
        
        public void CadastrarPermissao(Permissao permissao)
        {

            try
            {
                ValidarPermissao(permissao);
                iDaoPermissao.CadastrarPermissao(permissao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarPermissao(Permissao permissao)
        {
            try
            {
                ValidarPermissao(permissao);
                iDaoPermissao.UpdatePermissao(permissao);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarPermissao(int idPermissao)
        {
            try
            {
                iDaoPermissao.DeletePermissao(idPermissao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Permissao ConsultarPermissaoPorId(int idPermissao)
        {
            try
            {
                if (idPermissao.ToString() == "")
                {
                    throw new ExceptionGeral("O Código da permissão não pode ser nulo");
                } 
                return iDaoPermissao.ConsultarPermissaoCodigo(idPermissao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Permissao> ConsultarAllPermissaoFiltros(int codigo, string descricao)
        {
            try
            {                
                return iDaoPermissao.ConsultarAllPermissaoFiltros(codigo,descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Permissao> ListarPermissoes()
        {
            try
            {
                return iDaoPermissao.ConsultarAllPermissao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion

        #region BurnDown

        public int SelectQtdDiasSprint(int idProjeto, int idSprint)
        {
            int qtdDias = 0;
            if (idProjeto < 1)
            {
                throw new ExceptionGeral("O código do projeto não pode ser nulo");
            }
            else if (idSprint < 1 )
            {
                throw new ExceptionGeral("O código da sprint não pode ser nulo");
            }
            else
            {
                qtdDias = iDAOBurnDown.SelectQtdDiasSprint(idProjeto, idSprint);                
            }
            return qtdDias;
        }

        public double SelectQtdHorasPlanejadaSprint(int idProjeto, int idSprint)
        {
            double qtdHoras = 0;
            if (idProjeto < 1)
            {
                throw new ExceptionGeral("O código do projeto não pode ser nulo");
            }
            else if (idSprint < 1)
            {
                throw new ExceptionGeral("O código da sprint não pode ser nulo");
            }
            else
            {
                qtdHoras = iDAOBurnDown.SelectQtdHorasPlanejadaSprint(idProjeto, idSprint);
            }
            return qtdHoras;
        }

        public double SelectTamanhoRealizadoDia(int idProjeto, int idSprint, int dia)
        {
            double qtdHoras = 0;
            if (idProjeto < 1)
            {
                throw new ExceptionGeral("O código do projeto não pode ser nulo");
            }
            else if (idSprint < 1)
            {
                throw new ExceptionGeral("O código da sprint não pode ser nulo");
            }
            else if (dia < 1)
            {
                throw new ExceptionGeral("O dia da sprint não pode ser nulo");
            }
            else
            {
                qtdHoras = iDAOBurnDown.SelectTamanhoRealizadoDia(idProjeto, idSprint,dia);
            }
            return qtdHoras;
        }
            

        #endregion

      #region PerfilUsuario
        public void ValidarPerfilUsuario(PerfilUsuario perfil)
        {
          if (perfil.Descricao == "")
          {
            throw new ExceptionGeral("A descrição do perfil do usuário não pode ser nula");
          }
        }

        public void CadastrarPerfilUsuario(PerfilUsuario perfil)
        {

          try
          {
            ValidarPerfilUsuario(perfil);
            iDaoPerfilUsuario.CadastrarPerfilUsuario(perfil);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void AlterarPerfilUsuario(PerfilUsuario perfil)
        {
          try
          {
            ValidarPerfilUsuario(perfil);
            iDaoPerfilUsuario.UpdatePerfilUsuario(perfil);

          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void DeletarPerfilUsuario(int idPerfil)
        {
          try
          {
            iDaoPerfilUsuario.DeletePerfilUsuario(idPerfil);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public PerfilUsuario ConsultarPerfilUsuarioPorId(int idPerfil)
        {
          try
          {
            if (idPerfil.ToString() == "")
            {
              throw new ExceptionGeral("O Código do perfil do usuário não pode ser nulo");
            }
            return iDaoPerfilUsuario.ConsultarPerfilUsuarioCodigo(idPerfil);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<PerfilUsuario> ConsultarAllPerfilUsuarioFiltros(int codigo, string descricao)
        {
          try
          {
            return iDaoPerfilUsuario.ConsultarAllPerfilUsuarioFiltros(codigo, descricao);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<PerfilUsuario> ListarPerfilUsuario()
        {
          try
          {
            return iDaoPerfilUsuario.ConsultarAllPerfilUsuario();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      #endregion

      #region TipoAtividade

        public void ValidarTipoAtividade(TipoAtividade ta)
        {
          if (ta.Descricao == "")
          {
            throw new ExceptionGeral("A descrição do tipo atividade não pode ser nula");
          }
        }

        public void CadastrarTipoAtividade(TipoAtividade ta)
        {

          try
          {
            ValidarTipoAtividade(ta);
            iDaoTipoAtividade.CadastrarTipoAtividade(ta);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void AlterarTipoAtividade(TipoAtividade ta)
        {
          try
          {
            ValidarTipoAtividade(ta);
            iDaoTipoAtividade.UpdateTipoAtividade(ta);

          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void DeletarTipoAtividade(int idTipoAtividade)
        {
          try
          {
            iDaoTipoAtividade.DeleteTipoAtividade(idTipoAtividade);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public TipoAtividade ConsultarTipoAtividadePorId(int idTipoAtividade)
        {
          try
          {
            if (idTipoAtividade.ToString() == "")
            {
              throw new ExceptionGeral("O Código do tipo atividade não pode ser nulo");
            }
            return iDaoTipoAtividade.ConsultarTipoAtividadeCodigo(idTipoAtividade);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<TipoAtividade> ConsultarAllTipoAtividadeFiltros(int codigo, string descricao)
        {
          try
          {
            return iDaoTipoAtividade.ConsultarAllTipoAtividadeFiltros(codigo, descricao);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<TipoAtividade> ListarTipoAtividade()
        {
          try
          {
            return iDaoTipoAtividade.ConsultarAllTipoAtividade();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

      #endregion

      #region Atividade

        public void ValidarAtividade(Atividade a)
        {
          if (a.Descricao == "")
          {
            throw new ExceptionGeral("A descrição da atividade não pode ser nula");
          }
        }

        public void CadastrarAtividade(Atividade a)
        {

          try
          {
            ValidarAtividade(a);
            iDaoAtividade.CadastrarAtividade(a);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void AlterarAtividade(Atividade a)
        {
          try
          {
            ValidarAtividade(a);
            iDaoAtividade.UpdateAtividade(a);

          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void DeletarAtividade(int idAtividade)
        {
          try
          {
            iDaoAtividade.DeleteAtividade(idAtividade);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public Atividade ConsultarAtividadePorId(int idAtividade)
        {
          try
          {
            if (idAtividade.ToString() == "")
            {
              throw new ExceptionGeral("O Código da atividade não pode ser nulo");
            }
            return iDaoAtividade.ConsultarAtividadeCodigo(idAtividade);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<Atividade> ConsultarAllAtividadeFiltros(int codigo, string descricao)
        {
          try
          {
            return iDaoAtividade.ConsultarAllAtividadeFiltros(codigo, descricao);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<Atividade> ListarAtividade()
        {
          try
          {
            return iDaoAtividade.ConsultarAllAtividade();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

      #endregion

      #region Estoria

        public void ValidarEstoria(Estoria e)
        {
          if (e.Descricao == "")
          {
            throw new ExceptionGeral("A descrição da estoria não pode ser nula");
          }
        }

        public void CadastrarEstoria(Estoria e)
        {

          try
          {
            ValidarEstoria(e);
            iDaoEstoria.CadastrarEstoria(e);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void AlterarEstoria(Estoria e)
        {
          try
          {
            ValidarEstoria(e);
            iDaoEstoria.UpdateEstoria(e);

          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void DeletarEstoria(int idEstoria)
        {
          try
          {
            iDaoEstoria.DeleteEstoria(idEstoria);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public Estoria ConsultarEstoriaPorId(int idEstoria)
        {
          try
          {
            if (idEstoria.ToString() == "")
            {
              throw new ExceptionGeral("O Código da estoria não pode ser nulo");
            }
            return iDaoEstoria.ConsultarEstoriaCodigo(idEstoria);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<Estoria> ConsultarAllEstoriaFiltros(int codigo, string descricao)
        {
          try
          {
            return iDaoEstoria.ConsultarAllEstoriaFiltros(codigo, descricao);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<Estoria> ListarEstoria()
        {
          try
          {
            return iDaoEstoria.ConsultarAllEstoria();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

      #endregion

      #region Projeto

        public void ValidarProjeto(Projeto p)
        {
          if (p.Descricao == "")
          {
            throw new ExceptionGeral("A descrição do projeto não pode ser nula");
          }
        }

        public void CadastrarProjeto(Projeto p)
        {

          try
          {
            ValidarProjeto(p);
            iDaoProjeto.CadastrarProjeto(p);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void AlterarProjeto(Projeto p)
        {
          try
          {
            ValidarProjeto(p);
            iDaoProjeto.UpdateProjeto(p);

          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void DeletarProjeto(int idProjeto)
        {
          try
          {
            iDaoProjeto.DeleteProjeto(idProjeto);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public Projeto ConsultarProjetoPorId(int idProjeto)
        {
          try
          {
            if (idProjeto.ToString() == "")
            {
              throw new ExceptionGeral("O Código do projeto não pode ser nulo");
            }
            return iDaoProjeto.ConsultarProjetoCodigo(idProjeto);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<Projeto> ConsultarAllProjetoFiltros(int codigo, string descricao)
        {
          try
          {
            return iDaoProjeto.ConsultarAllProjetoFiltros(codigo, descricao);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<Projeto> ListarProjeto()
        {
          try
          {
            return iDaoProjeto.ConsultarAllProjeto();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

      #endregion

      #region Avaliacao360

        public void ValidarAvaliacao360(Avaliacao360 av)
        {
          if (av.Justificativa == "")
          {
            throw new ExceptionGeral("A justificativa da avaliação não pode ser nula");
          }
        }

        public void CadastrarAvaliacao360(Avaliacao360 av)
        {

          try
          {
            ValidarAvaliacao360(av);
            iDaoAvaliacao360.CadastrarAvaliacao360(av);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void AlterarAvaliacao360(Avaliacao360 av)
        {
          try
          {
            ValidarAvaliacao360(av);
            iDaoAvaliacao360.UpdateAvaliacao360(av);

          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void DeletarAvaliacao360(int idAvaliacao360)
        {
          try
          {
            iDaoAvaliacao360.DeleteAvaliacao360(idAvaliacao360);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public Avaliacao360 ConsultarAvaliacao360PorId(int idAvaliacao)
        {
          try
          {
            if (idAvaliacao.ToString() == "")
            {
              throw new ExceptionGeral("O Código da Avaliação não pode ser nulo");
            }
            
            return iDaoAvaliacao360.ConsultarAvaliacao360Codigo(idAvaliacao);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<Avaliacao360> ConsultarAllAvaliacao360Filtros(int codigo, string justificativa)
        {
          try
          {
            return iDaoAvaliacao360.ConsultarAllAvaliacao360Filtros(codigo, justificativa);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public List<Avaliacao360> ListarAvaliacao360()
        {
          try
          {
            return iDaoAvaliacao360.ConsultarAllAvaliacao360();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

      #endregion
    }
}