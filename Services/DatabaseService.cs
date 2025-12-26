
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
            command.CommandText = "DROP TABLE IF EXISTS students;";
            command.ExecuteNonQuery();

            command.CommandText = @"
                CREATE TABLE students (
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

        public void SaveStudent(StudentData student)
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
            
            cmd.ExecuteNonQuery();
        }
    }
}
