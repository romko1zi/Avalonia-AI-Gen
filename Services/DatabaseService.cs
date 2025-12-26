
using myapp.Views;
using Npgsql;
using System;

namespace myapp.Services
{
    public class DatabaseService
    {
        private const string ConnectionString = "Host=localhost;Username=postgres;Password=твои_пароль;Database=postgres";

        public void SaveStudent(StudentData student)
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            connection.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO students (identifikator, nazwisko, imie, data_urodzenia, kierunek, semestr) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
            cmd.Parameters.AddWithValue("p1", student.Identifikator ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p2", student.Nazwisko ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p3", student.Imie1 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p4", student.DataUrodzenia ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p5", student.Kierunek ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("p6", student.Semestr);
            cmd.ExecuteNonQuery();
        }
    }
}
