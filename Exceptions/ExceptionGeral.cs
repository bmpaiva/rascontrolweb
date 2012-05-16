using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exceptions
{
    public class ExceptionGeral : Exception
    {
        private string mensagem;

        public ExceptionGeral(String mensagemException)
        {
            mensagem = mensagemException;

        }

        public override string Message
        {
            get
            {
                return this.mensagem;
            }
        }

    }
}