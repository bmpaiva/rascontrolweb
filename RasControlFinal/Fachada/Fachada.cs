using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Controlador;
using ClassesBasicas;

namespace Fachada
{
    public class Fachada
    {
        private static Fachada fachada;
        private Controlador.Controlador controlador;

        private Fachada()
        {
            controlador = new Controlador.Controlador();
        }

        
        public static Fachada Instancia
        {
            get
            {
                if (fachada == null)
                {
                    fachada = new Fachada();
                }
                return fachada;
            }
        }

        #region Permissao

        public void CadastrarPermissao(Permissao permissao)
        {
            try
            {
                controlador.CadastrarPermissao(permissao);

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
                controlador.AlterarPermissao(permissao);

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
                controlador.DeletarPermissao(idPermissao);
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

                return controlador.ConsultarPermissaoPorId(idPermissao);
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
                return controlador.ConsultarAllPermissaoFiltros(codigo,descricao);
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
                return controlador.ListarPermissoes();
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
            return controlador.SelectQtdDiasSprint(idProjeto, idSprint);
        }

        public double SelectQtdHorasPlanejadaSprint(int idProjeto, int idSprint)
        {
            return controlador.SelectQtdHorasPlanejadaSprint(idProjeto, idSprint);
        }

        public double SelectTamanhoRealizadoDia(int idProjeto, int idSprint, int dia)
        {
            return controlador.SelectTamanhoRealizadoDia(idProjeto, idSprint,dia);
        }

        #endregion

      #region PerfilUsuario
        public void CadastrarPerfilUsuario(PerfilUsuario perfil)
        {
          try
          {
            controlador.CadastrarPerfilUsuario(perfil);

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
            controlador.AlterarPerfilUsuario(perfil);

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
            controlador.DeletarPerfilUsuario(idPerfil);
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

            return controlador.ConsultarPerfilUsuarioPorId(idPerfil);
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
            return controlador.ConsultarAllPerfilUsuarioFiltros(codigo, descricao);
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
            return controlador.ListarPerfilUsuario();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      #endregion

      #region TipoAtividade
        public void CadastrarTipoAtividade(TipoAtividade ta)
        {
          try
          {
            controlador.CadastrarTipoAtividade(ta);

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
            controlador.AlterarTipoAtividade(ta);

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
            controlador.DeletarTipoAtividade(idTipoAtividade);
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

            return controlador.ConsultarTipoAtividadePorId(idTipoAtividade);
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
            return controlador.ConsultarAllTipoAtividadeFiltros(codigo, descricao);
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
            return controlador.ListarTipoAtividade();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      #endregion

      #region Atividade

        public void CadastrarAtividade(Atividade a)
        {
          try
          {
            controlador.CadastrarAtividade(a);

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
            controlador.AlterarAtividade(a);

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
            controlador.DeletarAtividade(idAtividade);
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

            return controlador.ConsultarAtividadePorId(idAtividade);
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
            return controlador.ConsultarAllAtividadeFiltros(codigo, descricao);
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
            return controlador.ListarAtividade();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

      #endregion

      #region Estoria

        public void CadastrarEstoria(Estoria e)
        {
          try
          {
            controlador.CadastrarEstoria(e);

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
            controlador.AlterarEstoria(e);

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
            controlador.DeletarEstoria(idEstoria);
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

            return controlador.ConsultarEstoriaPorId(idEstoria);
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
            return controlador.ConsultarAllEstoriaFiltros(codigo, descricao);
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
            return controlador.ListarEstoria();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

      #endregion

      #region Projeto

        public void CadastrarProjeto(Projeto p)
        {
          try
          {
            controlador.CadastrarProjeto(p);

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
            controlador.AlterarProjeto(p);

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
            controlador.DeletarProjeto(idProjeto);
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

            return controlador.ConsultarProjetoPorId(idProjeto);
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
            return controlador.ConsultarAllProjetoFiltros(codigo, descricao);
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
            return controlador.ListarProjeto();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

      #endregion

      #region Avaliacao360

        public void CadastrarAvaliacao360(Avaliacao360 av)
        {
          try
          {
            controlador.CadastrarAvaliacao360(av);

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
            controlador.AlterarAvaliacao360(av);

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
            controlador.DeletarAvaliacao360(idAvaliacao360);
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

            return controlador.ConsultarAvaliacao360PorId(idAvaliacao);
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
            return controlador.ConsultarAllAvaliacao360Filtros(codigo, justificativa);
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
            return controlador.ListarAvaliacao360();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

      #endregion

    }
}