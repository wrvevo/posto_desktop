using Microsoft.Data.SqlClient;
using posto_desktop.Domain;
using posto_desktop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posto_desktop.Infrastructure.Repository
{
    public class BombaRepository
    {
        public void Save(Bomba bomba)
        {
            using var conn = DbConnectionFactory.Create();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO Bombas (Id, Numero, EstoqueLitros)
                VALUES (@Id, @Numero, @Estoque)", conn);

            cmd.Parameters.AddWithValue("@Id", bomba.Uuid);
            cmd.Parameters.AddWithValue("@Numero", bomba.Numero);
            cmd.Parameters.AddWithValue("@Estoque", bomba.EstoqueLitros);

            cmd.ExecuteNonQuery();
        }

        public List<Bomba> GetAll()
        {
            var lista = new List<Bomba>();

            using var conn = DbConnectionFactory.Create();
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT Id, Numero, EstoqueLitros FROM Bombas", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Bomba
                {
                    Uuid            = reader.GetGuid(0),
                    Numero          = reader.GetInt32(1),
                    EstoqueLitros   = reader.GetDecimal(2)
                });
            }

            return lista;
        }

        public void DebitarEstoque(Guid bombaId, decimal litros)
        {
            using var conn = DbConnectionFactory.Create();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE Bombas
                SET EstoqueLitros = EstoqueLitros - @Litros
                WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", bombaId);
            cmd.Parameters.AddWithValue("@Litros", litros);

            cmd.ExecuteNonQuery();
        }
    }
}
