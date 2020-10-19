using AppBandoADO;
using AppBancoDominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDLL
{
    public class UsuarioDAO
    {
        private Banco db;
        public void Insert(Usuario usuario)
        {
            string strInserir = string.Format("insert into tbUsuario(NomeUsu, Cargo, DataNasc)" +
                                "values('{0}', '{1}', '{2}');",usuario.NomeUsu, usuario.Cargo, usuario.DataNasc.ToString("yyyy-MM-dd"));
            using (db = new Banco())
            {
                db.ExecutaComando(strInserir);
            }
        }

        public void Atualizar(Usuario usuario)
        {
            var strquery = "";
            strquery += "update tbUsuario set ";
            strquery += string.Format(" NomeUsu = '{0}', ",usuario.NomeUsu);
            strquery += string.Format(" Cargo = '{0}', ", usuario.Cargo);
            strquery += string.Format(" DataNasc = '{0}' ",usuario.DataNasc.ToString("yyyy-MM-dd"));
            strquery += string.Format(" where IdUsu = {0};", usuario.IdUsu);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Excluir (int Id)
        {
            var strquery = "";
            strquery += "delete from tbUsuario ";
            strquery += string.Format(" where IdUsu = {0};", Id);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Salvar (Usuario usuario)
        {
            if (usuario.IdUsu > 0)
            {
                Atualizar(usuario);
            }
            else
            {
                Insert(usuario);
            }
        }

        public List<Usuario> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbUsuario; ";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeUsuario(retorno);
        }

        private List<Usuario> ListaDeUsuario(MySqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();
            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    IdUsu = int.Parse(retorno["IdUsu"].ToString()),
                    NomeUsu = retorno["NomeUsu"].ToString(),
                    Cargo = retorno["Cargo"].ToString(),
                    DataNasc = DateTime.Parse(retorno["DataNasc"].ToString()),
                };
                usuarios.Add(TempUsuario);
            }


            return usuarios;
        }
    }
}
