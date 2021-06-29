﻿using System;
using System.Collections.Generic;
using GerenciadorAgenda.Dominios.Dominio;
using GerenciadorAgenda.Controlarodes.Conectar;
using System.Data.SqlClient;
using System.Linq;
using GerenciadorAgenda.Controlarodes.Controladores.ControladoresContatos;

namespace GerenciadorAgenda.Controlarodes.Controladores.ControladoresContatos
{
    public class ControladorContatos : Controlador<Contatos>
    {
        private Conexao conexao;
        private SqlContatos sqlContatos;

        public ControladorContatos()
        {
            this.conexao = new Conexao();
            this.sqlContatos = new SqlContatos();
        }

        public override bool InserirRegistro(Contatos contatos)
        {
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlContatos.SqlInsersao, conexao);

                comando.Parameters.AddWithValue("nome", contatos.Nome);
                comando.Parameters.AddWithValue("email", contatos.Email);
                comando.Parameters.AddWithValue("telefone", contatos.Telefone);
                comando.Parameters.AddWithValue("empresa", contatos.Empresa);
                comando.Parameters.AddWithValue("cargo", contatos.Cargo);

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao;
        }

        public override bool EditarRegistro(Contatos contatos)
        {
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlContatos.SqlEdicao, conexao);

                comando.Parameters.AddWithValue("nome", contatos.Nome);
                comando.Parameters.AddWithValue("email", contatos.Email);
                comando.Parameters.AddWithValue("telefone", contatos.Telefone);
                comando.Parameters.AddWithValue("empresa", contatos.Empresa);
                comando.Parameters.AddWithValue("cargo", contatos.Cargo);

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao;
        }

        public override bool ExcluirRegistro(int idExcluir)
        {
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlContatos.SqlExclusao, conexao);

                comando.Parameters.AddWithValue("id", idExcluir);

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao;
        }

        public override Contatos SelecionarRegistroPorId(int idPesquisa)
        {
            Contatos contato = null;
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlContatos.SqlVisualizacaoPorId, conexao);

                comando.Parameters.AddWithValue("id", idPesquisa);

                SqlDataReader leitorContatos = comando.ExecuteReader();

                int id = Convert.ToInt32(leitorContatos["id"]);
                string nome = Convert.ToString(leitorContatos["nome"]);
                string email = Convert.ToString(leitorContatos["email"]);
                string telefone = Convert.ToString(leitorContatos["telefone"]);
                string empresa = Convert.ToString(leitorContatos["empresa"]);
                string cargo = Convert.ToString(leitorContatos["cargo"]);

                contato = new Contatos(nome, email, telefone, empresa, cargo);
                contato.Id = id;

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao ? contato : null;
        }

        public override List<Contatos> SelecionarTodosRegistros()
        {
            List<Contatos> listaContatos = new List<Contatos>();
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlContatos.SqlVisualizacaoTodos, conexao);

                SqlDataReader leitorContatos = comando.ExecuteReader();

                while (leitorContatos.Read())
                {
                    int id = Convert.ToInt32(leitorContatos["id"]);
                    string nome = Convert.ToString(leitorContatos["nome"]);
                    string email = Convert.ToString(leitorContatos["email"]);
                    string telefone = Convert.ToString(leitorContatos["telefone"]);
                    string empresa = Convert.ToString(leitorContatos["empresa"]);
                    string cargo = Convert.ToString(leitorContatos["cargo"]);

                    Contatos contato = new Contatos(nome, email, telefone, empresa, cargo);
                    contato.Id = id;

                    listaContatos.Add(contato);
                }

            });
            return (List<Contatos>)listaContatos;
        }

    }
}
