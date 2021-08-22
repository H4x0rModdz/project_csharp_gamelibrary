using BibliotecaGames.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.DAL
{
    public class JogoDao
    {
        public List<Jogo> ObterTodosOsJogos()
        {
            try
            {
                Conexao.Conectar();

                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM jogos";

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                var jogos = new List<Jogo>();

                while (reader.Read())
                {
                    var jogo = new Jogo();

                    jogo.Id = Convert.ToInt32(reader["id"]);
                    jogo.Img = reader["imagem"].ToString();
                    jogo.DataCompra = reader["data_compra"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["data_compra"]);
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.ValorPago = reader["valor_pago"] == DBNull.Value ? (double?) null : Convert.ToDouble(reader["valor_pago"]);

                    jogos.Add(jogo);
                }

                return jogos;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public Jogo ObterJogoPeloId(int id)
        {
            try
            {
                Conexao.Conectar();

                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM jogos where id = @id";
                command.Parameters.AddWithValue("@id", id);

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                Jogo jogo = null;

                while (reader.Read())
                {
                    jogo = new Jogo();

                    jogo.Id = Convert.ToInt32(reader["id"]);
                    jogo.Img = reader["imagem"].ToString();
                    jogo.DataCompra = reader["data_compra"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["data_compra"]);
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.ValorPago = reader["valor_pago"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["valor_pago"]);
                    jogo.IdEditor = Convert.ToInt32(reader["id_editor"]);
                    jogo.IdGenero = Convert.ToInt32(reader["id_genero"]);
                }
                return jogo;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    
        public int AlterarJogo(Jogo jogo)
        {
            try
            {
                Conexao.Conectar();

                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"UPDATE [dbo].[jogos]
                                           SET [imagem] = @IMAGEM
                                              ,[data_compra] = @DATA_COMPRA
                                              ,[titulo] = @TITULO
                                              ,[valor_pago] = @VALOR_PAGO
                                              ,[id_editor] = @ID_EDITOR
                                              ,[id_genero] = @ID_GENERO
                                         WHERE Id = @ID"; // o @ deixa quebrar linha

                command.Parameters.AddWithValue("@IMAGEM", jogo.Img);
                command.Parameters.AddWithValue("@DATA_COMPRA", jogo.DataCompra);
                command.Parameters.AddWithValue("@TITULO", jogo.Titulo);
                command.Parameters.AddWithValue("@VALOR_PAGO", jogo.ValorPago);
                command.Parameters.AddWithValue("@ID_EDITOR", jogo.IdEditor);
                command.Parameters.AddWithValue("@ID_GENERO", jogo.IdGenero);
                command.Parameters.AddWithValue("@ID", jogo.Id);




                Conexao.Conectar();

                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
        public int InserirJogo(Jogo jogo)
        {
            try
            {
                Conexao.Conectar();

                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"INSERT INTO [dbo].[jogos]
                                           ([imagem]
                                           ,[data_compra]
                                           ,[titulo]
                                           ,[valor_pago]
                                           ,[id_editor]
                                           ,[id_genero])
                                            VALUES
                                           (@IMAGEM
                                           ,@DATA_COMPRA
                                           ,@TITULO
                                           ,@VALOR_PAGO
                                           ,@ID_EDITOR
                                           ,@ID_GENERO)"; // o @ deixa quebrar linha

                command.Parameters.AddWithValue("@IMAGEM", jogo.Img);
                command.Parameters.AddWithValue("@DATA_COMPRA", jogo.DataCompra);
                command.Parameters.AddWithValue("@TITULO", jogo.Titulo);
                command.Parameters.AddWithValue("@VALOR_PAGO", jogo.ValorPago);
                command.Parameters.AddWithValue("@ID_EDITOR", jogo.IdEditor);
                command.Parameters.AddWithValue("@ID_GENERO", jogo.IdGenero);




                Conexao.Conectar();

                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
