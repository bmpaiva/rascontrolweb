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
     
        public Controlador()
        {
            try
            {
                iDaoPermissao = new DAOPermmisao();
                iDAOBurnDown = new DAOBurnDown();
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
    }
}