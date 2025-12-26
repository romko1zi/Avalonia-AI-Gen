
using Microsoft.Data.Sqlite;
using myapp.Views;
using System;
using System.Collections.Generic;

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
                    Identifikator TEXT,
                    DataPrzyjecia TEXT,
                    NumerKs TEXT,
                    Kierunek TEXT,
                    Semestr INTEGER,
                    DataRozpoczecia TEXT,
                    RokRozpoczecia INTEGER,
                    Pesel TEXT,
                    Nazwisko TEXT,
                    NazwiskoRodowe TEXT,
                    Imie1 TEXT,
                    Imie2 TEXT,
                    Plec TEXT,
                    DataUrodzenia TEXT,
                    MiejsceUrodzenia TEXT,
                    KrajUrodzenia TEXT,
                    Obywatelstwo TEXT,
                    Wojewodztwo TEXT,
                    Miasto TEXT,
                    Ulica TEXT,
                    NumerDomu TEXT,
                    NumerLokalu TEXT,
                    KodPocztowy TEXT,
                    ImieOjca TEXT,
                    ImieMatki TEXT,
                    Telefon TEXT,
                    TelegramViber TEXT,
                    Email TEXT,
                    OsobaKontaktowa TEXT,
                    TelefonOsobyKontaktowej TEXT,
                    Paszport TEXT,
                    SeriaNumer TEXT,
                    WydanyPrzez TEXT,
                    StatusUKR INTEGER,
                    JestWDzienniku INTEGER,
                    PrzyczynaOpuszczenia TEXT,
                    DataOpuszczenia TEXT,
                    NumerDecyzji TEXT
                );
            ";
            command.ExecuteNonQuery();
        }

        public List<StudentData> GetAllStudents()
        {
            var students = new List<StudentData>();
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM students";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new StudentData
                {
                    Id = reader.GetInt32(0),
                    Identifikator = reader.IsDBNull(1) ? null : reader.GetString(1),
                    DataPrzyjecia = reader.IsDBNull(2) ? null : (DateTime?)DateTime.Parse(reader.GetString(2)),
                    NumerKs = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Kierunek = reader.IsDBNull(4) ? null : reader.GetString(4),
                    Semestr = reader.GetInt32(5),
                    DataRozpoczecia = reader.IsDBNull(6) ? null : (DateTime?)DateTime.Parse(reader.GetString(6)),
                    RokRozpoczecia = reader.GetInt32(7),
                    Pesel = reader.IsDBNull(8) ? null : reader.GetString(8),
                    Nazwisko = reader.IsDBNull(9) ? null : reader.GetString(9),
                    NazwiskoRodowe = reader.IsDBNull(10) ? null : reader.GetString(10),
                    Imie1 = reader.IsDBNull(11) ? null : reader.GetString(11),
                    Imie2 = reader.IsDBNull(12) ? null : reader.GetString(12),
                    Plec = reader.IsDBNull(13) ? null : reader.GetString(13),
                    DataUrodzenia = reader.IsDBNull(14) ? null : (DateTime?)DateTime.Parse(reader.GetString(14)),
                    MiejsceUrodzenia = reader.IsDBNull(15) ? null : reader.GetString(15),
                    KrajUrodzenia = reader.IsDBNull(16) ? null : reader.GetString(16),
                    Obywatelstwo = reader.IsDBNull(17) ? null : reader.GetString(17),
                    Wojewodztwo = reader.IsDBNull(18) ? null : reader.GetString(18),
                    Miasto = reader.IsDBNull(19) ? null : reader.GetString(19),
                    Ulica = reader.IsDBNull(20) ? null : reader.GetString(20),
                    NumerDomu = reader.IsDBNull(21) ? null : reader.GetString(21),
                    NumerLokalu = reader.IsDBNull(22) ? null : reader.GetString(22),
                    KodPocztowy = reader.IsDBNull(23) ? null : reader.GetString(23),
                    ImieOjca = reader.IsDBNull(24) ? null : reader.GetString(24),
                    ImieMatki = reader.IsDBNull(25) ? null : reader.GetString(25),
                    Telefon = reader.IsDBNull(26) ? null : reader.GetString(26),
                    TelegramViber = reader.IsDBNull(27) ? null : reader.GetString(27),
                    Email = reader.IsDBNull(28) ? null : reader.GetString(28),
                    OsobaKontaktowa = reader.IsDBNull(29) ? null : reader.GetString(29),
                    TelefonOsobyKontaktowej = reader.IsDBNull(30) ? null : reader.GetString(30),
                    Paszport = reader.IsDBNull(31) ? null : reader.GetString(31),
                    SeriaNumer = reader.IsDBNull(32) ? null : reader.GetString(32),
                    WydanyPrzez = reader.IsDBNull(33) ? null : reader.GetString(33),
                    StatusUKR = reader.GetInt32(34) == 1,
                    JestWDzienniku = reader.GetInt32(35) == 1,
                    PrzyczynaOpuszczenia = reader.IsDBNull(36) ? null : reader.GetString(36),
                    DataOpuszczenia = reader.IsDBNull(37) ? null : (DateTime?)DateTime.Parse(reader.GetString(37)),
                    NumerDecyzji = reader.IsDBNull(38) ? null : reader.GetString(38)
                });
            }
            return students;
        }

        public void SaveStudent(StudentData student)
        {
            if (student.Id == 0)
            {
                InsertStudent(student);
            }
            else
            {
                UpdateStudent(student);
            }
        }

        private void InsertStudent(StudentData student)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SqliteCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO students (
                Identifikator, DataPrzyjecia, NumerKs, Kierunek, Semestr, DataRozpoczecia, RokRozpoczecia,
                Pesel, Nazwisko, NazwiskoRodowe, Imie1, Imie2, Plec, DataUrodzenia, MiejsceUrodzenia, KrajUrodzenia, Obywatelstwo,
                Wojewodztwo, Miasto, Ulica, NumerDomu, NumerLokalu, KodPocztowy,
                ImieOjca, ImieMatki, Telefon, TelegramViber, Email, OsobaKontaktowa, TelefonOsobyKontaktowej,
                Paszport, SeriaNumer, WydanyPrzez, StatusUKR, JestWDzienniku, PrzyczynaOpuszczenia, DataOpuszczenia, NumerDecyzji
            ) VALUES (
                @Identifikator, @DataPrzyjecia, @NumerKs, @Kierunek, @Semestr, @DataRozpoczecia, @RokRozpoczecia,
                @Pesel, @Nazwisko, @NazwiskoRodowe, @Imie1, @Imie2, @Plec, @DataUrodzenia, @MiejsceUrodzenia, @KrajUrodzenia, @Obywatelstwo,
                @Wojewodztwo, @Miasto, @Ulica, @NumerDomu, @NumerLokalu, @KodPocztowy,
                @ImieOjca, @ImieMatki, @Telefon, @TelegramViber, @Email, @OsobaKontaktowa, @TelefonOsobyKontaktowej,
                @Paszport, @SeriaNumer, @WydanyPrzez, @StatusUKR, @JestWDzienniku, @PrzyczynaOpuszczenia, @DataOpuszczenia, @NumerDecyzji
            )";

            AddParameters(cmd, student);
            cmd.ExecuteNonQuery();
        }

        public void UpdateStudent(StudentData student)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SqliteCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE students SET
                Identifikator = @Identifikator, DataPrzyjecia = @DataPrzyjecia, NumerKs = @NumerKs, Kierunek = @Kierunek, Semestr = @Semestr, DataRozpoczecia = @DataRozpoczecia, RokRozpoczecia = @RokRozpoczecia,
                Pesel = @Pesel, Nazwisko = @Nazwisko, NazwiskoRodowe = @NazwiskoRodowe, Imie1 = @Imie1, Imie2 = @Imie2, Plec = @Plec, DataUrodzenia = @DataUrodzenia, MiejsceUrodzenia = @MiejsceUrodzenia, KrajUrodzenia = @KrajUrodzenia, Obywatelstwo = @Obywatelstwo,
                Wojewodztwo = @Wojewodztwo, Miasto = @Miasto, Ulica = @Ulica, NumerDomu = @NumerDomu, NumerLokalu = @NumerLokalu, KodPocztowy = @KodPocztowy,
                ImieOjca = @ImieOjca, ImieMatki = @ImieMatki, Telefon = @Telefon, TelegramViber = @TelegramViber, Email = @Email, OsobaKontaktowa = @OsobaKontaktowa, TelefonOsobyKontaktowej = @TelefonOsobyKontaktowej,
                Paszport = @Paszport, SeriaNumer = @SeriaNumer, WydanyPrzez = @WydanyPrzez, StatusUKR = @StatusUKR, JestWDzienniku = @JestWDzienniku, PrzyczynaOpuszczenia = @PrzyczynaOpuszczenia, DataOpuszczenia = @DataOpuszczenia, NumerDecyzji = @NumerDecyzji
            WHERE id = @id";

            AddParameters(cmd, student);
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.ExecuteNonQuery();
        }

        public void DeleteStudent(int id)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SqliteCommand();
            cmd.Connection = connection;
            cmd.CommandText = "DELETE FROM students WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private void AddParameters(SqliteCommand cmd, StudentData student)
        {
            cmd.Parameters.AddWithValue("@Identifikator", student.Identifikator ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@DataPrzyjecia", student.DataPrzyjecia?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@NumerKs", student.NumerKs ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Kierunek", student.Kierunek ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Semestr", student.Semestr);
            cmd.Parameters.AddWithValue("@DataRozpoczecia", student.DataRozpoczecia?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@RokRozpoczecia", student.RokRozpoczecia);
            cmd.Parameters.AddWithValue("@Pesel", student.Pesel ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Nazwisko", student.Nazwisko ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@NazwiskoRodowe", student.NazwiskoRodowe ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Imie1", student.Imie1 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Imie2", student.Imie2 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Plec", student.Plec ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@DataUrodzenia", student.DataUrodzenia?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@MiejsceUrodzenia", student.MiejsceUrodzenia ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@KrajUrodzenia", student.KrajUrodzenia ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Obywatelstwo", student.Obywatelstwo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Wojewodztwo", student.Wojewodztwo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Miasto", student.Miasto ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Ulica", student.Ulica ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@NumerDomu", student.NumerDomu ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@NumerLokalu", student.NumerLokalu ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@KodPocztowy", student.KodPocztowy?.Replace("-", "") ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ImieOjca", student.ImieOjca ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ImieMatki", student.ImieMatki ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Telefon", student.Telefon?.Replace("-", "") ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@TelegramViber", student.TelegramViber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", student.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@OsobaKontaktowa", student.OsobaKontaktowa ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@TelefonOsobyKontaktowej", student.TelefonOsobyKontaktowej ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Paszport", student.Paszport ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@SeriaNumer", student.SeriaNumer ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@WydanyPrzez", student.WydanyPrzez ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@StatusUKR", student.StatusUKR ? 1 : 0);
            cmd.Parameters.AddWithValue("@JestWDzienniku", student.JestWDzienniku ? 1 : 0);
            cmd.Parameters.AddWithValue("@PrzyczynaOpuszczenia", student.PrzyczynaOpuszczenia ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@DataOpuszczenia", student.DataOpuszczenia?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@NumerDecyzji", student.NumerDecyzji ?? (object)DBNull.Value);
        }
    }
}
