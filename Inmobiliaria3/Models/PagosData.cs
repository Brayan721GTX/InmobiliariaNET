using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria3.Models
{
    public class PagosData
    {
        public List<Pagos> obtenerPagos(int idAlquiler)
        {
            //SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=inmobiliaria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM pagos WHERE id_alquiler = "+idAlquiler;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            List<Pagos> pagos = new List<Pagos>();

            while (reader.Read())
            {
                System.Diagnostics.Debug.WriteLine("HOLAAAAAAAA");
                AlquilerData alquilerData = new AlquilerData();
                Alquiler alquiler = alquilerData.obtenerAlquiler(idAlquiler);


                Pagos p = new Pagos {
                    Id = reader.GetInt32(0),
                    NroPago = Convert.ToInt32(reader["nro_pago"]),
                    Fecha = Convert.ToDateTime(reader["fecha"]),
                    Importe = Convert.ToInt32(reader["importe"]),
                    Alquiler = alquiler,
                };

                pagos.Add(p);
            }

            conn.Close();
            return pagos;
        }

        public int crear(Pagos pago)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "INSERT INTO pagos (nro_pago, fecha, importe, id_alquiler) VALUES (@nro_pago, @fecha, @importe, @id_alquiler)";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@nro_pago", pago.NroPago);
            command.Parameters.AddWithValue("@fecha", pago.Fecha);
            command.Parameters.AddWithValue("@importe", pago.Importe);
            command.Parameters.AddWithValue("@id_alquiler", pago.Alquiler.Id);

            conn.Open();

            int id = Convert.ToInt32(command.ExecuteScalar());

            conn.Close();

            return id;
        }

        public int obtenerNumerosDePagos(int idAlquiler) {
            return obtenerPagos(idAlquiler).Count;
        }

        public Inquilino eliminar(int id)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "DELETE FROM pagos WHERE id = " + id;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            conn.Close();

            return null;
        }
    }
}
