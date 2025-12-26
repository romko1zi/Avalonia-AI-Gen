
using System;

namespace myapp.Views
{
    public class StudentData
    {
        // Учеба
        public string? Identifikator { get; set; }
        public DateTime? DataPrzyjecia { get; set; }
        public string? NumerKs { get; set; }
        public string? Kierunek { get; set; }
        public int Semestr { get; set; }
        public DateTime? DataRozpoczecia { get; set; }
        public int RokRozpoczecia { get; set; }

        // Личные
        public string? Pesel { get; set; }
        public string? Nazwisko { get; set; }
        public string? NazwiskoRodowe { get; set; }
        public string? Imie1 { get; set; }
        public string? Imie2 { get; set; }
        public string? Plec { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string? MiejsceUrodzenia { get; set; }
        public string? KrajUrodzenia { get; set; }
        public string? Obywatelstwo { get; set; }

        // Адрес
        public string? Ulica { get; set; }
        public string? NumerDomu { get; set; }
        public string? NumerLokalu { get; set; }
        public string? Miasto { get; set; }
        public string? KodPocztowy { get; set; }
        public string? Poczta { get; set; }
        public string? Gmina { get; set; }
        public string? Powiat { get; set; }
        public string? Wojewodztwo { get; set; }

        // Адрес PL (доп)
        public string? KodPocztowyPL { get; set; }
        public string? MiastoPL { get; set; }
        public string? UlicaPL { get; set; }
        public string? NumerDomuPL { get; set; }

        // Семья и Контакты
        public string? ImieOjca { get; set; }
        public string? ImieMatki { get; set; }
        public string? Telefon { get; set; }
        public string? TelegramViber { get; set; }
        public string? Email { get; set; }
        public string? OsobaKontaktowa { get; set; }
        public string? TelefonOsobyKontaktowej { get; set; }

        // Документы и Статус
        public string? Paszport { get; set; }
        public string? SeriaNumer { get; set; }
        public string? WydanyPrzez { get; set; }
        public bool StatusUKR { get; set; }
        public bool JestWDzienniku { get; set; }
        public string? PrzyczynaOpuszczenia { get; set; }
        public DateTime? DataOpuszczenia { get; set; }
        public string? NumerDecyzji { get; set; }
    }
}
