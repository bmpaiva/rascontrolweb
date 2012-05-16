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

        public List<Permissao> ConsultarAllPermissaoPerfil(int idPerfil)
        {
            try
            {
                return controlador.ConsultarAllPermissaoPerfil(idPerfil);
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

        public void CadastrarPermissaoPerfil(int idPerfil, Permissao permissao)
        {
            try
            {
                controlador.CadastrarPermissaoPerfil(idPerfil,permissao);

            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void DeletarPerfilPermissao(int idPerfil,int idPermissao)
        {
            try
            {
                controlador.DeletarPerfilPermissao(idPerfil,idPermissao);
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

        #region Usuario

        public void CadastrarUsuario(Usuario usuario)
        {
            try
            {
                controlador.CadastrarUsuario(usuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarUsuario(Usuario usuario)
        {
            try
            {
                controlador.AlterarUsuario(usuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarUsuario(int idUsuario)
        {
            try
            {
                controlador.DeletarUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario ConsultarUsuarioPorId(int idUsuario)
        {
            try
            {

                return controlador.ConsultarUsuarioPorId(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> ConsultarAllUsuarioFiltros(int codigo, string cpf)
        {
            try
            {
                return controlador.ConsultarAllUsuarioFiltros(codigo, cpf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> ListarUsuario()
        {
            try
            {
                return controlador.ListarUsuario();
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


        public List<Usuario> ConsultarAllUsuarioProjeto(int idProjeto)
        {
          try
          {
            return controlador.ConsultarAllUsuarioProjeto(idProjeto);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void CadastrarUsuarioProjeto(int idProjeto,Usuario usuario)
        {
          try
          {
            controlador.CadastrarUsuarioProjeto(idProjeto, usuario);

          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        public void DeletarUsuarioProjeto(int idUsuario, int idProjeto)
        {
          try
          {
            controlador.DeletarUsuarioProjeto(idUsuario, idProjeto);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }



        #endregion

        #region Atividade

        public void CadastrarAtividade(Atividade atividade)
        {
            try
            {
                controlador.CadastrarAtividade(atividade);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarAtividade(Atividade atividade)
        {
            try
            {
                controlador.AlterarAtividade(atividade);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarAtividade(int id_atividade)
        {
            try
            {
                controlador.DeletarAtividade(id_atividade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Atividade ConsultarAtividadePorId(int id_atividade)
        {
            try
            {

                return controlador.ConsultarAtividadePorId(id_atividade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Atividade> ConsultarAllAtividadeFiltros(int id_atividade, int id_tipo_atividade, int id_estoria_sprint, string descricao, double duracao_estimada, double duracao_realizada)
        {
            try
            {
                return controlador.ConsultarAllAtividadeFiltros(id_atividade, id_tipo_atividade, id_estoria_sprint, descricao, duracao_estimada, duracao_realizada);
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

        #region Impedimento

        public void CadastrarImpedimento(Impedimentos impedimentos)
        {
            try
            {
                controlador.CadastrarImpedimento(impedimentos);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarImpedimento(Impedimentos impedimentos)
        {
            try
            {
                controlador.AlterarImpedimento(impedimentos);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarImpedimento(int id_impedimento)
        {
            try
            {
                controlador.DeletarImpedimento(id_impedimento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Impedimentos ConsultarImpedimentoPorId(int id_impedimento)
        {
            try
            {

                return controlador.ConsultarImpedimentoPorId(id_impedimento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Impedimentos> ConsultarAllImpedimentoFiltros(int id_impedimento, int id_sprint, string descricao)
        {
            try
            {
                return controlador.ConsultarAllImpedimentoFiltros(id_impedimento, id_sprint, descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Impedimentos> ListarImpedimentos()
        {
            try
            {
                return controlador.ListarImpedimentos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        #region Sprint

        public void CadastrarSprint(Sprint sprint)
        {
            try
            {
                controlador.CadastrarSprint(sprint);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarSprint(Sprint sprint)
        {
            try
            {
                controlador.AlterarSprint(sprint);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarSprint(int id_sprint)
        {
            try
            {
                controlador.DeletarSprint(id_sprint);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Sprint ConsultarSprintPorId(int id_sprint)
        {
            try
            {

                return controlador.ConsultarSprintPorId(id_sprint);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sprint> ConsultarAllSprintFiltros(int idProjeto, string descricao)
        {
            try
            {
                return controlador.ConsultarAllSprintFiltros(idProjeto, descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sprint> ListarSprint()
        {
            try
            {
                return controlador.ListarSprint();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sprint> ConsultarAllSprintEstoria(int idSprint)
        {
            try
            {
                return controlador.ConsultarAllSprintEstoria(idSprint);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CadastrarSprintEstoria(int idSprint, Estoria estoria)
        {
            try
            {
                controlador.CadastrarSprintEstoria(idSprint, estoria);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarSprintEstoria(int idEstoria, int idSprint)
        {
            try
            {
                controlador.DeletarSprintEstoria(idEstoria, idSprint);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region TipoAtividade
        public void CadastrarTipoAtividade(TipoAtividade tipoAtividade)
        {
            try
            {
                controlador.CadastrarTipoAtividade(tipoAtividade);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarTipoAtividade(TipoAtividade tipoAtividade)
        {
            try
            {
                controlador.AlterarTipoAtividade(tipoAtividade);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarTipoAtividade(int id_tipoatividade)
        {
            try
            {
                controlador.DeletarTipoAtividade(id_tipoatividade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TipoAtividade ConsultarTipoAtividadePorId(int id_tipoatividade)
        {
            try
            {

                return controlador.ConsultarTipoAtividadePorId(id_tipoatividade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoAtividade> ConsultarAllTipoAtividadeFiltros(int id_tipoatividade, string descricao)
        {
            try
            {
                return controlador.ConsultarAllTipoAtividadeFiltros(id_tipoatividade, descricao);
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

    }
}