
using Avalonia.Controls;
using Avalonia.Interactivity;
using myapp.Services;
using System;

namespace myapp.Views
{
    public partial class MainWindow : Window
    {
        private readonly DatabaseService _databaseService;

        public MainWindow()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private void SaveButton_Click(object? sender, RoutedEventArgs e)
        {
            var student = new StudentData
            {
                // Учеба
                Identifikator = this.FindControl<TextBox>("IdentifikatorBox")?.Text,
                DataPrzyjecia = this.FindControl<CalendarDatePicker>("DataPrzyjeciaPicker")?.SelectedDate?.Date,
                NumerKs = this.FindControl<TextBox>("NumerKsBox")?.Text,
                Kierunek = this.FindControl<TextBox>("KierunekBox")?.Text,
                Semestr = int.TryParse(this.FindControl<TextBox>("SemestrBox")?.Text, out var semestr) ? semestr : 0,
                DataRozpoczecia = this.FindControl<CalendarDatePicker>("DataRozpoczeciaPicker")?.SelectedDate?.Date,
                RokRozpoczecia = int.TryParse(this.FindControl<TextBox>("RokRozpoczeciaBox")?.Text, out var rok) ? rok : 0,

                // Личные
                Pesel = this.FindControl<TextBox>("PeselBox")?.Text,
                Nazwisko = this.FindControl<TextBox>("NazwiskoBox")?.Text,
                NazwiskoRodowe = this.FindControl<TextBox>("NazwiskoRodoweBox")?.Text,
                Imie1 = this.FindControl<TextBox>("Imie1Box")?.Text,
                Imie2 = this.FindControl<TextBox>("Imie2Box")?.Text,
                Plec = this.FindControl<TextBox>("PlecBox")?.Text,
                DataUrodzenia = this.FindControl<CalendarDatePicker>("DataUrodzeniaPicker")?.SelectedDate?.Date,
                MiejsceUrodzenia = this.FindControl<TextBox>("MiejsceUrodzeniaBox")?.Text,
                KrajUrodzenia = this.FindControl<TextBox>("KrajUrodzeniaBox")?.Text,
                Obywatelstwo = this.FindControl<TextBox>("ObywatelstwoBox")?.Text,

                // Адрес
                Wojewodztwo = this.FindControl<TextBox>("WojewodztwoBox")?.Text,
                Miasto = this.FindControl<TextBox>("MiastoBox")?.Text,
                Ulica = this.FindControl<TextBox>("UlicaBox")?.Text,
                NumerDomu = this.FindControl<TextBox>("NumerDomuBox")?.Text,
                NumerLokalu = this.FindControl<TextBox>("NumerLokaluBox")?.Text,
                KodPocztowy = this.FindControl<TextBox>("KodPocztowyBox")?.Text,

                // Семья и Контакты
                ImieOjca = this.FindControl<TextBox>("ImieOjcaBox")?.Text,
                ImieMatki = this.FindControl<TextBox>("ImieMatkiBox")?.Text,
                Telefon = this.FindControl<TextBox>("TelefonBox")?.Text,
                TelegramViber = this.FindControl<TextBox>("TelegramViberBox")?.Text,
                Email = this.FindControl<TextBox>("EmailBox")?.Text,
                OsobaKontaktowa = this.FindControl<TextBox>("OsobaKontaktowaBox")?.Text,
                TelefonOsobyKontaktowej = this.FindControl<TextBox>("TelefonOsobyKontaktowejBox")?.Text,

                // Документы и Статус
                Paszport = this.FindControl<TextBox>("PaszportBox")?.Text,
                SeriaNumer = this.FindControl<TextBox>("SeriaNumerBox")?.Text,
                WydanyPrzez = this.FindControl<TextBox>("WydanyPrzezBox")?.Text,
                StatusUKR = this.FindControl<CheckBox>("StatusUKRCheckBox")?.IsChecked ?? false,
                JestWDzienniku = this.FindControl<CheckBox>("JestWDziennikuCheckBox")?.IsChecked ?? false,
                PrzyczynaOpuszczenia = this.FindControl<TextBox>("PrzyczynaOpuszczeniaBox")?.Text,
                DataOpuszczenia = this.FindControl<CalendarDatePicker>("DataOpuszczeniaPicker")?.SelectedDate?.Date,
                NumerDecyzji = this.FindControl<TextBox>("NumerDecyzjiBox")?.Text
            };

            try
            {
                _databaseService.SaveStudent(student);
                this.Title = "Сохранено в Базу Данных!";
            }
            catch (Exception ex)
            {
                this.Title = $"Ошибка: {ex.Message}";
            }
        }
    }
}
