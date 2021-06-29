using GerenciadorAgenda.Controlarodes.Conectar;
using System;
using System.Collections.Generic;
using System.Linq;
using GerenciadorAgenda.Dominios.Dominio;
using System.Data.SqlClient;

namespace GerenciadorAgenda.Controlarodes.Controladores.ControladoresCompromisso
{
    public class ControladorCompromisso : Controlador<Compromisso>
    {
        private Conexao conexao;
        private SqlCompromisso sqlCompromisso;

        public ControladorCompromisso()
        {
            this.conexao = new Conexao();
            this.sqlCompromisso = new SqlCompromisso();
        }

        public override bool InserirRegistro(Compromisso compromisso)
        {
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlCompromisso.SqlInsersao, conexao);

                comando.Parameters.AddWithValue("assunto", compromisso.Assunto);
                comando.Parameters.AddWithValue("local", compromisso.Local);
                comando.Parameters.AddWithValue("data", compromisso.Data);
                comando.Parameters.AddWithValue("horaInicio", compromisso.HoraInicio);
                comando.Parameters.AddWithValue("horaTermino", compromisso.HoraTermino);
                comando.Parameters.AddWithValue("idContatos", compromisso.IdContatos);

                int n = Convert.ToInt32(comando.ExecuteScalar());

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao;
        }

        public override bool EditarRegistro(Compromisso compromisso)
        {
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlCompromisso.SqlEdicao, conexao);

                comando.Parameters.AddWithValue("assunto", compromisso.Assunto);
                comando.Parameters.AddWithValue("local", compromisso.Local);
                comando.Parameters.AddWithValue("data", compromisso.Data);
                comando.Parameters.AddWithValue("horaInicio", compromisso.HoraInicio);
                comando.Parameters.AddWithValue("horaTermino", compromisso.HoraTermino);
                comando.Parameters.AddWithValue("idContatos", compromisso.IdContatos);

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
                SqlCommand comando = new SqlCommand(sqlCompromisso.SqlExclusao, conexao);

                comando.Parameters.AddWithValue("id", idExcluir);

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao;
        }

        public override Compromisso SelecionarRegistroPorId(int idPesquisa)
        {
            Compromisso compromisso = null;
            bool sucessoNaOperacao = false;
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlCompromisso.SqlVisualizacaoPorId, conexao);

                comando.Parameters.AddWithValue("id", idPesquisa);

                SqlDataReader leitorCompromissos = comando.ExecuteReader();

                int id = Convert.ToInt32(leitorCompromissos["id"]);
                string assunto = Convert.ToString(leitorCompromissos["assunto"]);
                string local = Convert.ToString(leitorCompromissos["local"]);
                DateTime data = Convert.ToDateTime(leitorCompromissos["data"]);
                string horaInicio = Convert.ToDateTime(leitorCompromissos["horaInicio"]).ToString("HH:mm");
                string horaTermino = Convert.ToDateTime(leitorCompromissos["horaTermino"]).ToString("HH:mm");
                int idContatos = Convert.ToInt32(leitorCompromissos["idContatos"]);

                compromisso = new Compromisso(assunto, local, data, horaInicio, horaTermino, idContatos);
                compromisso.Id = id;

                int n = comando.ExecuteNonQuery();

                sucessoNaOperacao = (n != 0);

            });
            return sucessoNaOperacao ? compromisso : null;
        }

        public override List<Compromisso> SelecionarTodosRegistros()
        {
            List<Compromisso> listaCompromisso = new List<Compromisso>();
            conexao.AbrirConexão(conexao =>
            {
                SqlCommand comando = new SqlCommand(sqlCompromisso.SqlVisualizacaoTodos, conexao);

                SqlDataReader leitorCompromissos = comando.ExecuteReader();

                while (leitorCompromissos.Read())
                {
                    int id = Convert.ToInt32(leitorCompromissos["id"]);
                    string assunto = Convert.ToString(leitorCompromissos["assunto"]);
                    string local = Convert.ToString(leitorCompromissos["local"]);
                    DateTime data = Convert.ToDateTime(leitorCompromissos["data"]);
                    String horaInicio = Convert.ToString(leitorCompromissos["horaInicio"]);
                    String horaTermino = Convert.ToString(leitorCompromissos["horaTermino"]);
                    
                    int idContatos = 0;
                    if (leitorCompromissos["idContatos"] != DBNull.Value)
                        idContatos = Convert.ToInt32(leitorCompromissos["idContatos"]);

                    Compromisso compromisso = new Compromisso(assunto, local, data, horaInicio, horaTermino, idContatos);
                    compromisso.Id = id;

                    listaCompromisso.Add(compromisso);
                }

            });
            return (List<Compromisso>)listaCompromisso;
        }

    }
}
