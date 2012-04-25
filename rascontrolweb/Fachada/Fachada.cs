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
            controlador.CadastrarPermissao(permissao);
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

        public void DeletarTipoAtividade(int codigo)
        {
            try
            {
                controlador.DeletarTipoAtividade(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TipoAtividade ConsultarTipoAtividadePorId(int codigo)
        {
            try
            {

                return controlador.ConsultarTipoAtividadePorId(codigo);
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

        public List<Atividade> ConsultarAllAtividadeFiltros(int id_atividade, string descricao)
        {
            try
            {
                return controlador.ConsultarAllAtividadeFiltros(id_atividade, descricao);
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

        public List<Sprint> ConsultarAllSprintFiltros(int id_sprint, string descricao)
        {
            try
            {
                return controlador.ConsultarAllSprintFiltros(id_sprint, descricao);
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


    }
}