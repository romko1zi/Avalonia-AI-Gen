using Microsoft.Data.Sqlite;
using myapp.Views;
using System;

namespace myapp.Services
{
    public class DatabaseService
    {
        private const string ConnectionString = "Data Source=students.db";

        public DatabaseService()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS students (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    identifikator TEXT NOT NULL,
                    nazwisko TEXT NOT NULL,
                    imie TEXT NOT NULL,
                    data_urodzenia TEXT NOT NULL,
                    kierunek TEXT NOT NULL,
                    semestr INTEGER NOT NULL
                );
            ";
            command.ExecuteNonQuery();
        }

        public void SaveStudent(StudentData student)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SqliteCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO students (identifikator, nazwisko, imie, data_urodzenia, kierunek, semestr) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
            cmd.Parameters.AddWithValue("@p1", student.Identifikator ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@p2", student.Nazwisko ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@p3", student.Imie1 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@p4", student.DataUrodzenia?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@p5", student.Kierunek ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@p6", student.Semestr);
            cmd.ExecuteNonQuery();
        }
    }
}
