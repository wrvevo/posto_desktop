using Microsoft.Data.SqlClient;
using Polly;
using posto_desktop.Domain;
using posto_desktop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace posto_desktop.Infrastructure.Repository
{
    public class ConsumoRepository
    {
        public void Save(Consumo consumo)
        {
            using var conn = DbConnectionFactory.Create();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO Consumos
                (Id, BombaId, Litros, DataConsumo, Sincronizado)
                VALUES
                (@Id, @BombaId, @Litros, @Data, @Sync)", conn);

            cmd.Parameters.AddWithValue("@Id", consumo.Uuid);
            cmd.Parameters.AddWithValue("@BombaId", consumo.BombaUuid);
            cmd.Parameters.AddWithValue("@Litros", consumo.Litros);
            cmd.Parameters.AddWithValue("@Data", consumo.DataConsumo);
            cmd.Parameters.AddWithValue("@Sync", consumo.Sincronizado);

            cmd.ExecuteNonQuery();
        }

        public List<Consumo> GetPendentesSync()
        {
            var lista = new List<Consumo>();

            using var conn = DbConnectionFactory.Create();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT Id, BombaId, Litros, DataConsumo
                FROM Consumos
                WHERE Sincronizado = 0", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Consumo
                {
                    Uuid            = reader.GetGuid(0),
                    BombaUuid       = reader.GetGuid(1),
                    Litros          = reader.GetDecimal(2),
                    DataConsumo     = reader.GetDateTime(3),
                    Sincronizado    = false
                });
            }

            return lista;
        }

        public void MarcarComoSincronizado(Guid id)
        {
            using var conn = DbConnectionFactory.Create();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE Consumos
                SET Sincronizado = 1
                WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}



