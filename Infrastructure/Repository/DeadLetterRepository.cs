using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posto_desktop.Infrastructure.Repository
{
    public class DeadLetterRepository
    {
        public void Save(Guid consumoId, string erro)
        {
            using var conn = DbConnectionFactory.Create();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO DeadLetter
                (Id, ConsumoId, Erro, DataErro)
                VALUES
                (NEWID(), @ConsumoId, @Erro, GETDATE())", conn);

            cmd.Parameters.AddWithValue("@ConsumoId", consumoId);
            cmd.Parameters.AddWithValue("@Erro", erro);

            cmd.ExecuteNonQuery();
        }
    }
}
