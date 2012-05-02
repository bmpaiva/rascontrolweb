using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
  public class Usuario
  {//declarar os atributos
      private int codigo;
      private string nome;
      private string telefone;
      private string celular;
      private string email;
      private string observacao;
      private string cpf;
      private string rg;
      private string login;
      private string senha;

      //declarar um contrustor vazio
      public Usuario()
      {
      }

      //declara get´s & set´s
      public int Codigo
      {
          get { return this.codigo; }
          set { this.codigo = value; }
      }

      public string Nome
      {
          get { return this.nome; }
          set { this.nome = value; }
      }

      public string Telefone
      {
          get { return this.telefone; }
          set { this.telefone = value; }
      }

      public string Celular
      {
          get { return this.celular; }
          set { this.celular = value; }
      }

      public string Email
      {
          get { return this.email; }
          set { this.email = value; }
      }

      public string Observacao
      {
          get { return this.observacao; }
          set { this.observacao = value; }
      }

      public string Cpf
      {
          get { return this.cpf; }
          set { this.cpf = value; }
      }

      public string Rg
      {
          get { return this.rg; }
          set { this.rg = value; }
      }

      public string Login
      {
          get { return this.login; }
          set { this.login = value; }
      }

      public string Senha
      {
          get { return this.senha; }
          set { this.senha = value; }
      }
  }
}