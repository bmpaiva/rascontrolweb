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


    }
}