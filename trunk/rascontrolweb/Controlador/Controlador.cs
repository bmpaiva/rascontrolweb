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
        IDAOAtividade iDAOAtividade;
        IDAOEstoria iDaoEstoria;
        IDAOProjeto iDaoProjeto;
        IDAOAvaliacao360 iDaoAvaliacao360;
        IDAOSprint iDAOSprint;
        IDAOImpedimentos iDAOImpedimentos;

        public Controlador()
        {
            try
            {
                iDaoPermissao = new DAOPermmisao();
                iDAOBurnDown = new DAOBurnDown();

                iDaoPerfilUsuario = new DAOPerfilUsuario();
                iDaoTipoAtividade = new DAOTipoAtividade();
                iDAOAtividade = new DAOAtividade();
                iDaoEstoria = new DAOEstoria();
                iDaoProjeto = new DAOProjeto();
                iDaoAvaliacao360 = new DAOAvaliacao360();
                iDAOSprint = new DAOSprint();
                iDAOImpedimentos = new DAOImpedimentos();
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
                iDaoPermissao.InsertPermissao(permissao);
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

        public void ValidarTipoAtividade(TipoAtividade tipoAtividade)
        {
            if (tipoAtividade.Descricao == "")
            {
                throw new ExceptionGeral("A descrição do tipo atividade não pode ser nula");
            }
        }

        public void CadastrarTipoAtividade(TipoAtividade tipoAtividade)
        {

            try
            {
                ValidarTipoAtividade(tipoAtividade);
                iDaoTipoAtividade.CadastrarTipoAtividade(tipoAtividade);
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
                ValidarTipoAtividade(tipoAtividade);
                iDaoTipoAtividade.UpdateTipoAtividade(tipoAtividade);

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
                iDaoTipoAtividade.DeleteTipoAtividade(codigo);
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
                if (codigo.ToString() == "")
                {
                    throw new ExceptionGeral("O Código do tipo atividade não pode ser nulo");
                }
                return iDaoTipoAtividade.ConsultarTipoAtividadeCodigo(codigo);
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

        public void ValidarAtividade(Atividade atividade)
        {
            if (atividade.Id_Tipo_Atividade == null)
            {
                throw new ExceptionGeral("O Id do tipo de atividade não pode ser nulo");
            }
            else if (atividade.Id_Estoria_Sprint == null)
            {
                throw new ExceptionGeral("O Id da estória sprint da atividade não pod ser nula");
            }
            else if (atividade.Descricao == "")
            {
                throw new ExceptionGeral("A descrição da permissão não pode ser nula");
            }
            else if (atividade.Duracao_Estimada == null)
            {
                throw new ExceptionGeral("A duração estimada da atividade não pode ser nula");
            }
            else if (atividade.Duracao_Realizada == null)
            {
                throw new ExceptionGeral("A duração realizada da atividade não pode ser nula");
            }

        }

        public void CadastrarAtividade(Atividade atividade)
        {

            try
            {
                ValidarAtividade(atividade);
                iDAOAtividade.CadastrarAtividade(atividade);
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
                ValidarAtividade(atividade);
                iDAOAtividade.UpdateAtividade(atividade);

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
                iDAOAtividade.DeleteAtividade(id_atividade);
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
                if (id_atividade.ToString() == "")
                {
                    throw new ExceptionGeral("O Código da atividade não pode ser nulo");
                }
                return iDAOAtividade.ConsultarAtividadeCodigo(id_atividade);
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
                return iDAOAtividade.ConsultarAllAtividadeFiltros(id_atividade, descricao);
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
                return iDAOAtividade.ConsultarAllAtividade();
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

        #region Sprint

        public void ValidarSprint(Sprint sprint)
        {
            if (sprint.Id_Projeto == null)
            {
                throw new ExceptionGeral("O Id do projeto da Sprint não pode ser nula");
            }
            else if (sprint.Descricao == "")
            {
                throw new ExceptionGeral("A Descrição da sprint não pode ser nula");
            }
            else if (sprint.Data_Inicio == null)
            {
                throw new ExceptionGeral("A Data de inicio da sprint não pode ser nula");
            }
            else if (sprint.Data_Fim == null)
            {
                throw new ExceptionGeral("A data do fim da sprint não pode ser nula");
            }
            else if (sprint.Qtd_Dias == null)
            {
                throw new ExceptionGeral("A quantidade de dias da sprint não pode ser nula");
            }

        }

        public void CadastrarSprint(Sprint sprint)
        {

            try
            {
                ValidarSprint(sprint);
                iDAOSprint.CadastrarSprint(sprint);
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
                ValidarSprint(sprint);
                iDAOSprint.UpdateSprint(sprint);

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
                iDAOSprint.DeleteSprint(id_sprint);
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
                if (id_sprint.ToString() == "")
                {
                    throw new ExceptionGeral("O Código da sprint não pode ser nulo");
                }
                return iDAOSprint.ConsultarSprintCodigo(id_sprint);
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
                return iDAOSprint.ConsultarAllSprintFiltros(id_sprint, descricao);
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
                return iDAOSprint.ConsultarAllSprint();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Impedimentos

        public void ValidarImpedimento(Impedimentos impedimentos)
        {
            if (impedimentos.Id_Sprint == 0)
            {
                throw new ExceptionGeral("O ID da sprint do impedimento não pode ser nula");
            }
            else if (impedimentos.Descricao == "")
            {
                throw new ExceptionGeral("A descrição do impedimento não pode ser nula");
            }
        }

        public void CadastrarImpedimento(Impedimentos impedimentos)
        {
            try
            {
                ValidarImpedimento(impedimentos);
                iDAOImpedimentos.CadastrarImpedimento(impedimentos);
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
                ValidarImpedimento(impedimentos);
                iDAOImpedimentos.UpdateImpedimento(impedimentos);
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
                iDAOImpedimentos.DeleteImpedimento(id_impedimento);
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
                if (id_impedimento.ToString() == "")
                {
                    throw new ExceptionGeral("O Código do impedimento não pode ser nulo");
                }
                return iDAOImpedimentos.ConsultarImpedimentoCodigo(id_impedimento);
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
                return iDAOImpedimentos.ConsultarAllImpedimentoFiltros(id_impedimento, id_sprint, descricao);
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
                return iDAOImpedimentos.ConsultarAllImpedimentos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}