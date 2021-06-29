using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using GerenciadorAgenda.Controlarodes.Conectar;
using GerenciadorAgenda.Dominios.Dominio;

namespace GerenciadorAgenda.Controlarodes.Controladores.ControladoresTarefa
{
    public class ControladorTarefa : Controlador<Tarefa>
    {
        private Conexao conexao;
        private SqlTarefa sqlTarefa;

        public ControladorTarefa()
        {
            this.conexao = new Conexao();
            this.sqlTarefa = new SqlTarefa();
        }

        public override bool InserirRegistro(Tarefa tarefa)
        {
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlTarefa.SqlInsersao, conexao);

                comando.Parameters.AddWithValue("titulo", tarefa.Titulo);
                comando.Parameters.AddWithValue("dataCriacao", tarefa.DataCriacao);
                comando.Parameters.AddWithValue("dataConclusao", tarefa.DataConclusao);
                comando.Parameters.AddWithValue("percentualConcluido", tarefa.PercentualConcluido);
                comando.Parameters.AddWithValue("prioridade", tarefa.Prioridade);

                int n = Convert.ToInt32(comando.ExecuteScalar());

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao;
        }

        public override bool EditarRegistro(Tarefa tarefa)
        {
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlTarefa.SqlEdicao, conexao);

                comando.Parameters.AddWithValue("titulo", tarefa.Titulo);
                comando.Parameters.AddWithValue("dataConclusao", tarefa.DataConclusao);
                comando.Parameters.AddWithValue("percentualConcluido", tarefa.PercentualConcluido);
                comando.Parameters.AddWithValue("prioridade", tarefa.Prioridade);

                int n = Convert.ToInt32(comando.ExecuteScalar());

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao;
        }

        public override bool ExcluirRegistro(int idExcluir)
        {
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlTarefa.SqlExclusao, conexao);

                comando.Parameters.AddWithValue("id", idExcluir);

                int n = Convert.ToInt32(comando.ExecuteScalar());

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao;
        }

        public override Tarefa SelecionarRegistroPorId(int idPesquisa)
        {
            Tarefa tarefa = null;
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlTarefa.SqlVisualizacaoPorId, conexao);

                comando.Parameters.AddWithValue("id", idPesquisa);

                SqlDataReader leitorTarefa = comando.ExecuteReader();

                int id = Convert.ToInt32(leitorTarefa["id"]);
                string titulo = Convert.ToString(leitorTarefa["titulo"]);
                DateTime dataCriacao = Convert.ToDateTime(leitorTarefa["dataCriacao"]);
                DateTime dataConclusao = Convert.ToDateTime(leitorTarefa["dataConclusao"]);
                int percentualConcluido = Convert.ToInt32(leitorTarefa["percentualConcluido"]);
                Prioridades prioridade = DefinirPrioridade(Convert.ToString(leitorTarefa["prioridade"]));

                tarefa = new Tarefa(titulo, percentualConcluido, prioridade);
                tarefa.Id = id;

                int n = Convert.ToInt32(comando.ExecuteScalar());

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao ? tarefa : null;
        }

        public override List<Tarefa> SelecionarTodosRegistros()
        {
            List<Tarefa> listaTarefa = new List<Tarefa>();
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlTarefa.SqlVisualizacaoTodos, conexao);

                SqlDataReader leitorTarefa = comando.ExecuteReader();

                while (leitorTarefa.Read())
                {
                    int id = Convert.ToInt32(leitorTarefa["id"]);
                    string titulo = Convert.ToString(leitorTarefa["titulo"]);
                    DateTime dataCriacao = Convert.ToDateTime(leitorTarefa["dataCriacao"]);
                    DateTime dataConclusao = Convert.ToDateTime(leitorTarefa["dataConclusao"]);
                    int percentualConcluido = Convert.ToInt32(leitorTarefa["percentualConcluido"]);
                    Prioridades prioridade = DefinirPrioridade(Convert.ToString(leitorTarefa["prioridade"]));

                    Tarefa tarefa = new Tarefa(titulo,  percentualConcluido, prioridade);
                    tarefa.Id = id;

                    listaTarefa.Add(tarefa);
                }

            });
            return (List<Tarefa>)listaTarefa;
        }

        public Prioridades DefinirPrioridade(string tipo)
        {
            switch (tipo)
            {
                case "Alta":
                    return Prioridades.Alta;
                case "Normal":
                    return Prioridades.Normal;
                case "Baixa":
                    return Prioridades.Baixa;
            }
            return Prioridades.Normal;
        }

    }
}
