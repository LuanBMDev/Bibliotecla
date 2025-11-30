using Bibliotecla.banco;
using Bibliotecla.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotecla.geral;

namespace Bibliotecla.DAO
{
    internal class LeitorFuncioDAO : DAO<LeitorFuncio>
    {
        private MySqlConnection conexao;

        public bool Inserir(LeitorFuncio entity)
        {
            int linhas_afetadas = 0;

            if (entity.Cargo.ToLower() == "bibliotecario" ||
                     entity.Cargo.ToLower() == "gerente" ||
                     entity.Cargo.ToLower() == "diretora")
            {
                string sql = "INSERT INTO LeitorFuncio (CPF, Telefone, Email, Nome, Cargo, Usuario, Senha, CEP, Rua, NumRes, Bairro, Cidade, isDevedor) " +
                             "VALUES (@CPF, @Telefone, @Email, @Nome, @Cargo, @Usuario, @Senha, @CEP, @Rua, @NumRes, @Bairro, @Cidade, @isDevedor)";

                conexao = Conexao.Conectar();

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                    cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                    cmd.Parameters.AddWithValue("@Cargo", entity.Cargo);
                    cmd.Parameters.AddWithValue("@Usuario", entity.Usuario);
                    cmd.Parameters.AddWithValue("@Senha", entity.Senha);
                    cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                    cmd.Parameters.AddWithValue("@Rua", entity.Rua);
                    cmd.Parameters.AddWithValue("@NumRes", entity.NumRes);
                    cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                    cmd.Parameters.AddWithValue("@isDevedor", entity.IsDevedor);

                    linhas_afetadas = cmd.ExecuteNonQuery();
                }

                Conexao.Desconectar(conexao);
            }
            else if (entity.Cargo.ToLower() == "leitor")
            {
                string sql = "INSERT INTO LeitorFuncio (CPF, Telefone, Email, Nome, Cargo, CEP, Rua, NumRes, Bairro, Cidade, IsDevedor) " +
                             "VALUES (@CPF, @Telefone, @Email, @Nome, @Cargo, @CEP, @Rua, @NumRes, @Bairro, @Cidade, @IsDevedor)";

                conexao = Conexao.Conectar();

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                    cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                    cmd.Parameters.AddWithValue("@Cargo", entity.Cargo);
                    cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                    cmd.Parameters.AddWithValue("@Rua", entity.Rua);
                    cmd.Parameters.AddWithValue("@NumRes", entity.NumRes);
                    cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                    cmd.Parameters.AddWithValue("@IsDevedor", entity.IsDevedor);

                    linhas_afetadas = cmd.ExecuteNonQuery();
                }

                Conexao.Desconectar(conexao);
            }
            else
            {
                throw new ArgumentException("Cargo inválido!");
            }

            bool ok = linhas_afetadas >= 1;
            if (ok)
            {
                try { CriacaoDJson.AtualizarTodosJson(); } catch { }
            }

            return linhas_afetadas >= 1;
        }

        public bool Alterar(LeitorFuncio entity)
        {
            int linhas_afetadas = 0;

            if (entity.Cargo.ToLower() == "bibliotecario" ||
                     entity.Cargo.ToLower() == "gerente" ||
                     entity.Cargo.ToLower() == "diretora")
            {
                string sql = "UPDATE LeitorFuncio SET " +
                             "CPF = @CPF, " +
                             "Telefone = @Telefone, " +
                             "Email = @Email, " +
                             "Nome = @Nome, " +
                             "Cargo = @Cargo, " +
                             "Usuario = @Usuario, " +
                             "Senha = @Senha, " +
                             "CEP = @CEP, " +
                             "Rua = @Rua, " +
                             "NumRes = @NumRes, " +
                             "Bairro = @Bairro, " +
                             "Cidade = @Cidade " +
                             "WHERE CodPessoa = @CodPessoa";

                conexao = Conexao.Conectar();

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                    cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                    cmd.Parameters.AddWithValue("@Cargo", entity.Cargo);
                    cmd.Parameters.AddWithValue("@Usuario", entity.Usuario);
                    cmd.Parameters.AddWithValue("@Senha", entity.Senha);
                    cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                    cmd.Parameters.AddWithValue("@Rua", entity.Rua);
                    cmd.Parameters.AddWithValue("@NumRes", entity.NumRes);
                    cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                    cmd.Parameters.AddWithValue("@CodPessoa", entity.CodPessoa);

                    linhas_afetadas = cmd.ExecuteNonQuery();
                }
                Conexao.Desconectar(conexao);
            }
            else if (entity.Cargo.ToLower() == "leitor")
            {
                string sql = "UPDATE LeitorFuncio SET " +
                             "CPF = @CPF, " +
                             "Telefone = @Telefone, " +
                             "Email = @Email, " +
                             "Nome = @Nome, " +
                             "Cargo = @Cargo, " +
                             "CEP = @CEP, " +
                             "Rua = @Rua, " +
                             "NumRes = @NumRes, " +
                             "Bairro = @Bairro, " +
                             "Cidade = @Cidade, " +
                             "IsDevedor = @IsDevedor " +
                             "WHERE CodPessoa = @CodPessoa";

                conexao = Conexao.Conectar();

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@CPF", entity.CPF);
                    cmd.Parameters.AddWithValue("@Telefone", entity.Telefone);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                    cmd.Parameters.AddWithValue("@CEP", entity.CEP);
                    cmd.Parameters.AddWithValue("@Rua", entity.Rua);
                    cmd.Parameters.AddWithValue("@NumRes", entity.NumRes);
                    cmd.Parameters.AddWithValue("@Bairro", entity.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                    cmd.Parameters.AddWithValue("@IsDevedor", entity.IsDevedor);
                    cmd.Parameters.AddWithValue("@CodPessoa", entity.CodPessoa);

                    linhas_afetadas = cmd.ExecuteNonQuery();
                }
                Conexao.Desconectar(conexao);
            }
            else
            {
                throw new ArgumentException("Alteração inválida para o cargo informado!");
            }

            bool ok = linhas_afetadas >= 1;
            if (ok)
            {
                try { CriacaoDJson.AtualizarTodosJson(); } catch { }
            }

            return linhas_afetadas >= 1;
        }

        public bool Remover(LeitorFuncio entity)
        {
            string sql = "DELETE FROM LeitorFuncio WHERE CodPessoa = @CodPessoa";

            int linhas_afetadas = 0;

            conexao = Conexao.Conectar();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodPessoa", entity.CodPessoa);

                linhas_afetadas = cmd.ExecuteNonQuery();
            }

            Conexao.Desconectar(conexao);

            bool ok = linhas_afetadas >= 1;
            if (ok)
            {
                try { CriacaoDJson.AtualizarTodosJson(); } catch { }
            }

            return linhas_afetadas >= 1;
        }

        public LeitorFuncio BuscarID(LeitorFuncio entity)
        {
            string sql = "SELECT * FROM LeitorFuncio WHERE CodPessoa = @CodPessoa";
            LeitorFuncio leitorFuncio = null;
            conexao = Conexao.Conectar();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodPessoa", entity.CodPessoa);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        leitorFuncio = new LeitorFuncio
                        {
                            CodPessoa = reader.GetInt32("CodPessoa"),
                            CPF = reader.GetString("CPF"),
                            Telefone = reader.GetString("Telefone"),
                            Email = reader.GetString("Email"),
                            Nome = reader.GetString("Nome"),
                            Cargo = reader.GetString("Cargo"),
                            Usuario = reader.IsDBNull(reader.GetOrdinal("Usuario")) ? null : reader.GetString("Usuario"),
                            Senha = reader.IsDBNull(reader.GetOrdinal("Senha")) ? null : reader.GetString("Senha"),
                            CEP = reader.GetString("CEP"),
                            Rua = reader.GetString("Rua"),
                            NumRes = reader.GetString("NumRes"),
                            Bairro = reader.GetString("Bairro"),
                            Cidade = reader.GetString("Cidade"),
                            IsDevedor = reader.IsDBNull(reader.GetOrdinal("IsDevedor")) ? 0 : reader.GetInt32("IsDevedor")
                        };
                    }
                }
            }

            Conexao.Desconectar(conexao);

            return leitorFuncio;
        }

        public List<LeitorFuncio> Listar(string critério)
        {
            string sql = "SELECT * FROM LeitorFuncio";
            if (!string.IsNullOrEmpty(critério))
            {
                sql += " WHERE " + critério;
            }

            List<LeitorFuncio> lista = new List<LeitorFuncio>();

            conexao = Conexao.Conectar();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LeitorFuncio leitorFuncio = new LeitorFuncio
                        {
                            CodPessoa = reader.GetInt32("CodPessoa"),
                            CPF = reader.GetString("CPF"),
                            Telefone = reader.GetString("Telefone"),
                            Email = reader.GetString("Email"),
                            Nome = reader.GetString("Nome"),
                            Cargo = reader.GetString("Cargo"),
                            Usuario = reader.IsDBNull(reader.GetOrdinal("Usuario")) ? null : reader.GetString("Usuario"),
                            Senha = reader.IsDBNull(reader.GetOrdinal("Senha")) ? null : reader.GetString("Senha"),
                            CEP = reader.GetString("CEP"),
                            Rua = reader.GetString("Rua"),
                            NumRes = reader.GetString("NumRes"),
                            Bairro = reader.GetString("Bairro"),
                            Cidade = reader.GetString("Cidade"),
                            IsDevedor = reader.IsDBNull(reader.GetOrdinal("IsDevedor")) ? 0 : reader.GetInt32("IsDevedor")
                        };
                        lista.Add(leitorFuncio);
                    }
                }

                Conexao.Desconectar(conexao);
            }

            return lista;
        }

        public List<LeitorFuncio> ListarFuncionario(string critério)
        {
            string sql = "SELECT codpessoa, cpf, telefone, email, nome, cargo, usuario, senha, cep, rua, numRes, cidade, bairro, isDevedor FROM LeitorFuncio";
            if (!string.IsNullOrEmpty(critério))
            {
                sql += " WHERE " + critério;
            }

            List<LeitorFuncio> lista = new List<LeitorFuncio>();

            conexao = Conexao.Conectar();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LeitorFuncio leitorFuncio = new LeitorFuncio
                        {
                            CodPessoa = reader.GetInt32("CodPessoa"),
                            CPF = reader.GetString("CPF"),
                            Telefone = reader.GetString("Telefone"),
                            Email = reader.GetString("Email"),
                            Nome = reader.GetString("Nome"),
                            Cargo = reader.GetString("Cargo"),
                            Usuario = reader.IsDBNull(reader.GetOrdinal("Usuario")) ? null : reader.GetString("Usuario"),
                            Senha = reader.IsDBNull(reader.GetOrdinal("Senha")) ? null : reader.GetString("Senha"),
                            CEP = reader.GetString("CEP"),
                            Rua = reader.GetString("Rua"),
                            NumRes = reader.GetString("NumRes"),
                            Bairro = reader.GetString("Bairro"),
                            Cidade = reader.GetString("Cidade"),
                            IsDevedor = reader.IsDBNull(reader.GetOrdinal("IsDevedor")) ? 0 : reader.GetInt32("IsDevedor")
                        };
                        lista.Add(leitorFuncio);
                    }
                }

                Conexao.Desconectar(conexao);
            }

            return lista;
        }
    }
}
