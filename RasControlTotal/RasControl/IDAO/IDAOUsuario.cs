using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassesBasicas;

namespace IDAO
{
    //A classe IDAO de qualquer classe basica deve ser to tipo "INTERFACE" para ....
    public interface IDAOUsuario
    {
        //Todos os metodos devem ser declarados aqui para facilitar a busca deles dentro do projeto
        List<Usuario> ConsultarAllUsuario();
        Usuario ConsultarUsuarioCodigo(int codigo);
        List<Usuario> ConsultarAllUsuarioFiltros(int codigo, string cpf);
        void CadastrarUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int id);

       
    }
}