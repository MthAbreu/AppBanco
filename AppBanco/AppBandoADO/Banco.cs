using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace AppBandoADO
{
    public class Banco : IDisposable
    {
        private readonly MySqlConnection conexao;
        public Banco()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }

        public MySqlDataReader RetornaComando(string strQuery)
        {
            var vComando = new MySqlCommand(strQuery, conexao);
            return vComando.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }
    }
}
