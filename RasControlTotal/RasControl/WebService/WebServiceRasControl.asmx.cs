using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text;
using Fachada;
using ClassesBasicas;

namespace WebService
{
    /// <summary>
    /// Summary description for WebServiceRasControl
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceRasControl : System.Web.Services.WebService
    {

        #region Graficos

        [WebMethod]
        public XmlDocument XmlBurnDown(int idProjeto, int idSprint)
        {
            XmlDocument xmlDocumento = new XmlDocument();
            StringBuilder xmlString = new StringBuilder();

             int quantidadeDiasSprint = Fachada.Fachada.Instancia.SelectQtdDiasSprint(1, 1);
             double quantidadeHorasPlanejadaSprint = Fachada.Fachada.Instancia.SelectQtdHorasPlanejadaSprint(1, 1);
             double quantidadeHorasPorDia = 1;

             if (quantidadeDiasSprint > 1 && quantidadeHorasPlanejadaSprint > 0)
             {
                 quantidadeHorasPorDia = Math.Truncate(quantidadeHorasPlanejadaSprint / (quantidadeDiasSprint - 1));
             }

             xmlString.Append("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?><?xml-stylesheet type='text/xsl' version='1.0'?>");
             xmlString.Append("<Burndown xmlns=\"http://www.w3.org/2001/XMLSchema\">");
             xmlString.Append("<Sprint>");
             xmlString.Append("<NumeroProjeto> "+ idProjeto.ToString() + " </NumeroProjeto>");
             xmlString.Append("<NumeroSprint> " + idSprint.ToString() + " </NumeroSprint>");
             xmlString.Append("<QtdDias> " + quantidadeDiasSprint.ToString() + " </QtdDias>");
             xmlString.Append("<Dias>");


             double qtdPlanejadoRestante = quantidadeHorasPlanejadaSprint;
             double valorRealizado = qtdPlanejadoRestante;
             for (int i = 1; i <= quantidadeDiasSprint; i++)
             {   
                 double qtdHorasRalizadaDia = Fachada.Fachada.Instancia.SelectTamanhoRealizadoDia(idProjeto, idSprint, i);
                 if (qtdHorasRalizadaDia > 0)
                 {
                     valorRealizado = valorRealizado - qtdHorasRalizadaDia;  
                 }
                 
                 xmlString.Append("<Dia>");
                 xmlString.Append("<Numero> " + i.ToString() + " </Numero>");
                 xmlString.Append("<Previsto> " + qtdPlanejadoRestante.ToString() + " </Previsto>");
                 xmlString.Append("<Realizado> " + valorRealizado.ToString() + " </Realizado>");
                 xmlString.Append("</Dia>");

                 qtdPlanejadoRestante = qtdPlanejadoRestante - quantidadeHorasPorDia;
             }

            xmlString.Append("</Dias>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Burndown>");

             xmlDocumento.LoadXml(xmlString.ToString());
            return xmlDocumento;

        }

        [WebMethod]
        public XmlDocument XmlDesempenhoMembrosProjeto (int idProjeto)
        {
            XmlDocument xmlDocumento = new XmlDocument();
            StringBuilder xmlString = new StringBuilder();

            xmlString.Append("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?><?xml-stylesheet type='text/xsl' version='1.0'?>");
            xmlString.Append("<Avaliacao xmlns=\"http://www.w3.org/2001/XMLSchema\">");
            xmlString.Append("<Projetos>");
            xmlString.Append("<Projeto>");
            xmlString.Append("<QtdSprints> 5 </QtdSprints>");
            xmlString.Append("<Membros>");
            xmlString.Append("<QtdMembros> 5 </QtdMembros>");
            
            xmlString.Append("<Membro>");
            xmlString.Append("<Nome> Nilson </Nome>");
            xmlString.Append("<Sprints>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 1 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 2 </Codigo>");
            xmlString.Append("<Media> 4 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 3 </Codigo>");
            xmlString.Append("<Media> 6 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 4 </Codigo>");
            xmlString.Append("<Media> 9 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 5 </Codigo>");
            xmlString.Append("<Media> 10 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Sprints>");
            xmlString.Append("</Membro>");

            xmlString.Append("<Membro>");
            xmlString.Append("<Nome> Gisele </Nome>");
            xmlString.Append("<Sprints>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 1 </Codigo>");
            xmlString.Append("<Media> 2 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 2 </Codigo>");
            xmlString.Append("<Media> 4 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 3 </Codigo>");
            xmlString.Append("<Media> 5 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 4 </Codigo>");
            xmlString.Append("<Media> 5 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 5 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Sprints>");
            xmlString.Append("</Membro>");


            xmlString.Append("<Membro>");
            xmlString.Append("<Nome> Igor </Nome>");
            xmlString.Append("<Sprints>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 1 </Codigo>");
            xmlString.Append("<Media> 5 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 2 </Codigo>");
            xmlString.Append("<Media> 4 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 3 </Codigo>");
            xmlString.Append("<Media> 3 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 4 </Codigo>");
            xmlString.Append("<Media> 2 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 5 </Codigo>");
            xmlString.Append("<Media> 1 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Sprints>");
            xmlString.Append("</Membro>");


            xmlString.Append("<Membro>");
            xmlString.Append("<Nome> Pedro </Nome>");
            xmlString.Append("<Sprints>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 1 </Codigo>");
            xmlString.Append("<Media> 1 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 2 </Codigo>");
            xmlString.Append("<Media> 2 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 3 </Codigo>");
            xmlString.Append("<Media> 3 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 4 </Codigo>");
            xmlString.Append("<Media> 4 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 5 </Codigo>");
            xmlString.Append("<Media> 5 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Sprints>");
            xmlString.Append("</Membro>");


            xmlString.Append("<Membro>");
            xmlString.Append("<Nome> Bruno </Nome>");
            xmlString.Append("<Sprints>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 1 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 2 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 3 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 4 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 5 </Codigo>");
            xmlString.Append("<Media> 7 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Sprints>");
            xmlString.Append("</Membro>");
            

            xmlString.Append("</Membros>");
            xmlString.Append("</Projeto>");
            xmlString.Append("</Projetos>");
            xmlString.Append("</Avaliacao>");

            xmlDocumento.LoadXml(xmlString.ToString());
            return xmlDocumento;


        }

        [WebMethod]
        public XmlDocument XmlBurnUp(int idProjeto, int idSprint)
        {
            XmlDocument xmlDocumento = new XmlDocument();
            StringBuilder xmlString = new StringBuilder();

            int quantidadeDiasSprint = Fachada.Fachada.Instancia.SelectQtdDiasSprint(1, 1);
            double quantidadeHorasPlanejadaSprint = Fachada.Fachada.Instancia.SelectQtdHorasPlanejadaSprint(1, 1);
            double quantidadeHorasPorDia = 1;

            if (quantidadeDiasSprint > 1 && quantidadeHorasPlanejadaSprint > 0)
            {
                quantidadeHorasPorDia = Math.Truncate(quantidadeHorasPlanejadaSprint / (quantidadeDiasSprint - 1));
            }

            xmlString.Append("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?><?xml-stylesheet type='text/xsl' version='1.0'?>");
            xmlString.Append("<Burndown xmlns=\"http://www.w3.org/2001/XMLSchema\">");
            xmlString.Append("<Sprint>");
            xmlString.Append("<NumeroProjeto> " + idProjeto.ToString() + " </NumeroProjeto>");
            xmlString.Append("<NumeroSprint> " + idSprint.ToString() + " </NumeroSprint>");
            xmlString.Append("<QtdDias> " + quantidadeDiasSprint.ToString() + " </QtdDias>");
            xmlString.Append("<Dias>");


            double qtdPlanejado = 0;//quantidadeHorasPlanejadaSprint;
            double valorRealizado = 0;//qtdPlanejadoRestante;
            for (int i = 1; i <= quantidadeDiasSprint; i++)
            {
                double qtdHorasRalizadaDia = Fachada.Fachada.Instancia.SelectTamanhoRealizadoDia(idProjeto, idSprint, i);
                if (qtdHorasRalizadaDia > 0)
                {
                    valorRealizado = valorRealizado + qtdHorasRalizadaDia;
                }

                xmlString.Append("<Dia>");
                xmlString.Append("<Numero> " + i.ToString() + " </Numero>");
                xmlString.Append("<Previsto> " + qtdPlanejado.ToString() + " </Previsto>");
                xmlString.Append("<Realizado> " + valorRealizado.ToString() + " </Realizado>");
                xmlString.Append("</Dia>");

                qtdPlanejado = qtdPlanejado + quantidadeHorasPorDia;
            }

            xmlString.Append("</Dias>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Burndown>");

            xmlDocumento.LoadXml(xmlString.ToString());
            return xmlDocumento;

        }

        #endregion

        #region Permissao

        [WebMethod]
        public void CadastrarPermissao(Permissao permissao)
        {
            try
            {
                Fachada.Fachada.Instancia.CadastrarPermissao(permissao);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void AlterarPermissao(Permissao permissao)
        {
            try
            {
                Fachada.Fachada.Instancia.AlterarPermissao(permissao);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void DeletarPermissao(int idPermissao)
        {
            try
            {
                Fachada.Fachada.Instancia.DeletarPermissao(idPermissao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Permissao ConsultarPermissaoPorId(int idPermissao)
        {
            try
            {

                return Fachada.Fachada.Instancia.ConsultarPermissaoPorId(idPermissao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Permissao> ConsultarAllPermissaoFiltros(int codigo, string descricao)
        {
            try
            {
                return Fachada.Fachada.Instancia.ConsultarAllPermissaoFiltros(codigo,descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Permissao> ConsultarAllPermissaoPerfil(int idPerfil)
        {
            try
            {
                return Fachada.Fachada.Instancia.ConsultarAllPermissaoPerfil(idPerfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
               
        

        [WebMethod]
        public List<Permissao> ListarPermissoes()
        {
            try
            {
                return Fachada.Fachada.Instancia.ListarPermissoes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void CadastrarPermissaoPerfil(int idPerfil, Permissao permissao)
        {
            try
            {
                Fachada.Fachada.Instancia.CadastrarPermissaoPerfil(idPerfil, permissao);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void DeletarPerfilPermissao(int idPerfil, int idPermissao)
        {
            try
            {
                Fachada.Fachada.Instancia.DeletarPerfilPermissao(idPerfil,idPermissao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
               

        #endregion

        #region Usuario

        [WebMethod]
        public void CadastrarUsuario(Usuario usuario)
        {
            try
            {
                Fachada.Fachada.Instancia.CadastrarUsuario(usuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void AlterarUsuario(Usuario usuario)
        {
            try
            {
                Fachada.Fachada.Instancia.AlterarUsuario(usuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void DeletarUsuario(int idUsuario)
        {
            try
            {
                Fachada.Fachada.Instancia.DeletarUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Usuario ConsultarUsuarioPorId(int idUsuario)
        {
            try
            {

                return Fachada.Fachada.Instancia.ConsultarUsuarioPorId(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Usuario> ConsultarAllUsuarioFiltros(int codigo, string cpf)
        {
            try
            {
                return Fachada.Fachada.Instancia.ConsultarAllUsuarioFiltros(codigo, cpf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Usuario> ListarUsuario()
        {
            try
            {
                return Fachada.Fachada.Instancia.ListarUsuario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Projeto

        [WebMethod]
        public void CadastrarProjeto(Projeto projeto)
        {
            try
            {
                Fachada.Fachada.Instancia.CadastrarProjeto(projeto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void AlterarProjeto(Projeto projeto)
        {
            try
            {
                Fachada.Fachada.Instancia.AlterarProjeto(projeto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void DeletarProjeto(int idProjeto)
        {
            try
            {
                Fachada.Fachada.Instancia.DeletarProjeto(idProjeto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Projeto ConsultarProjetoPorId(int idProjeto)
        {
            try
            {

                return Fachada.Fachada.Instancia.ConsultarProjetoPorId(idProjeto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Projeto> ConsultarAllProjetoFiltros(int codigo, string descricao)
        {
            try
            {
                return Fachada.Fachada.Instancia.ConsultarAllProjetoFiltros(codigo, descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Projeto> ListarProjeto()
        {
            try
            {
                return Fachada.Fachada.Instancia.ListarProjeto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region PerfilUsuario

        [WebMethod]
        public void CadastrarPerfilUsuario(PerfilUsuario perfilUsuario)
        {
            try
            {
                Fachada.Fachada.Instancia.CadastrarPerfilUsuario(perfilUsuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void AlterarPerfilUsuario(PerfilUsuario perfilUsuario)
        {
            try
            {
                Fachada.Fachada.Instancia.AlterarPerfilUsuario(perfilUsuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void DeletarPerfilUsuario(int idPerfilUsuario)
        {
            try
            {
                Fachada.Fachada.Instancia.DeletarPerfilUsuario(idPerfilUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public PerfilUsuario ConsultarPerfilUsuarioPorId(int idPerfilUsuario)
        {
            try
            {

                return Fachada.Fachada.Instancia.ConsultarPerfilUsuarioPorId(idPerfilUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<PerfilUsuario> ConsultarAllPerfilUsuarioFiltros(int codigo, string descricao)
        {
            try
            {
                return Fachada.Fachada.Instancia.ConsultarAllPerfilUsuarioFiltros(codigo, descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<PerfilUsuario> ListarPerfilUsuario()
        {
            try
            {
                return Fachada.Fachada.Instancia.ListarPerfilUsuario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Atividade

        [WebMethod]
        public void CadastrarAtividade(Atividade atividade)
        {
            try
            {
                Fachada.Fachada.Instancia.CadastrarAtividade(atividade);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void AlterarAtividade(Atividade atividade)
        {
            try
            {
                Fachada.Fachada.Instancia.AlterarAtividade(atividade);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void DeletarAtividade(int id_atividade)
        {
            try
            {
                Fachada.Fachada.Instancia.DeletarAtividade(id_atividade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Atividade ConsultarAtividadePorId(int id_atividade)
        {
            try
            {

                return Fachada.Fachada.Instancia.ConsultarAtividadePorId(id_atividade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Atividade> ConsultarAllAtividadeFiltros(int id_atividade, int id_tipo_atividade, int id_estoria_sprint, string descricao, double duracao_estimada, double duracao_realizada)
        {
            try
            {
                return Fachada.Fachada.Instancia.ConsultarAllAtividadeFiltros(id_atividade, id_tipo_atividade, id_estoria_sprint, descricao, duracao_estimada, duracao_realizada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Atividade> ListarAtividade()
        {
            try
            {
                return Fachada.Fachada.Instancia.ListarAtividade();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Impedimentos

        [WebMethod]
        public void CadastrarImpedimento(Impedimentos impedimentos)
        {
            try
            {
                Fachada.Fachada.Instancia.CadastrarImpedimento(impedimentos);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void AlterarImpedimento(Impedimentos impedimentos)
        {
            try
            {
                Fachada.Fachada.Instancia.AlterarImpedimento(impedimentos);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void DeletarImpedimento(int id_impedimento)
        {
            try
            {
                Fachada.Fachada.Instancia.DeletarImpedimento(id_impedimento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Impedimentos ConsultarImpedimentoPorId(int id_impedimento)
        {
            try
            {

                return Fachada.Fachada.Instancia.ConsultarImpedimentoPorId(id_impedimento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Impedimentos> ConsultarAllImpedimentoFiltros(int id_impedimento, int id_sprint, string descricao)
        {
            try
            {
                return Fachada.Fachada.Instancia.ConsultarAllImpedimentoFiltros(id_impedimento, id_sprint, descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Impedimentos> ListarImpedimentos()
        {
            try
            {
                return Fachada.Fachada.Instancia.ListarImpedimentos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Estoria

        [WebMethod]
        public void CadastrarEstoria(Estoria estoria)
        {
          try
          {
            Fachada.Fachada.Instancia.CadastrarEstoria(estoria);

          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        [WebMethod]
        public void AlterarEstoria(Estoria estoria)
        {
          try
          {
            Fachada.Fachada.Instancia.AlterarEstoria(estoria);

          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        [WebMethod]
        public void DeletarEstoria(int idEstoria)
        {
          try
          {
            Fachada.Fachada.Instancia.DeletarEstoria(idEstoria);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        [WebMethod]
        public Estoria ConsultarEstoriaPorId(int idEstoria)
        {
          try
          {

            return Fachada.Fachada.Instancia.ConsultarEstoriaPorId(idEstoria);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        [WebMethod]
        public List<Estoria> ConsultarAllEstoriaFiltros(int codigo, string descricao)
        {
          try
          {
            return Fachada.Fachada.Instancia.ConsultarAllEstoriaFiltros(codigo, descricao);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        [WebMethod]
        public List<Estoria> ListarEstoria()
        {
          try
          {
            return Fachada.Fachada.Instancia.ListarEstoria();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

      #endregion
      
        #region Sprint

        [WebMethod]
        public void CadastrarSprint(Sprint sprint)
        {
            try
            {
                Fachada.Fachada.Instancia.CadastrarSprint(sprint);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void AlterarSprint(Sprint sprint)
        {
            try
            {
                Fachada.Fachada.Instancia.AlterarSprint(sprint);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void DeletarSprint(int id_sprint)
        {
            try
            {
                Fachada.Fachada.Instancia.DeletarSprint(id_sprint);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Sprint ConsultarSprintPorId(int id_sprint)
        {
            try
            {

                return Fachada.Fachada.Instancia.ConsultarSprintPorId(id_sprint);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Sprint> ConsultarAllSprintFiltros(int idProjeto, string descricao)
        {
            try
            {
                return Fachada.Fachada.Instancia.ConsultarAllSprintFiltros(idProjeto, descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Sprint> ListarSprint()
        {
            try
            {
                return Fachada.Fachada.Instancia.ListarSprint();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
