
using Avalonia.Controls;
using Avalonia.Interactivity;
using myapp.Services;
using System;

namespace myapp.Views
{
    public partial class StudentEditorWindow : Window
    {
        private readonly DatabaseService _databaseService;
        private readonly StudentData? _student;

        public StudentEditorWindow(StudentData? student = null)
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            _student = student;

            if (_student != null)
            {
                // Edukacja
                this.FindControl<TextBox>("IdentifikatorBox").Text = _student.Identifikator;
                this.FindControl<CalendarDatePicker>("DataPrzyjeciaPicker").SelectedDate = _student.DataPrzyjecia;
                this.FindControl<TextBox>("NumerKsBox").Text = _student.NumerKs;
                this.FindControl<TextBox>("KierunekBox").Text = _student.Kierunek;
                this.FindControl<TextBox>("SemestrBox").Text = _student.Semestr.ToString();
                this.FindControl<CalendarDatePicker>("DataRozpoczeciaPicker").SelectedDate = _student.DataRozpoczecia;
                this.FindControl<TextBox>("RokRozpoczeciaBox").Text = _student.RokRozpoczecia.ToString();

                // Dane osobowe
                this.FindControl<TextBox>("PeselBox").Text = _student.Pesel;
                this.FindControl<TextBox>("NazwiskoBox").Text = _student.Nazwisko;
                this.FindControl<TextBox>("NazwiskoRodoweBox").Text = _student.NazwiskoRodowe;
                this.FindControl<TextBox>("Imie1Box").Text = _student.Imie1;
                this.FindControl<TextBox>("Imie2Box").Text = _student.Imie2;
                this.FindControl<TextBox>("PlecBox").Text = _student.Plec;
                this.FindControl<CalendarDatePicker>("DataUrodzeniaPicker").SelectedDate = _student.DataUrodzenia;
                this.FindControl<TextBox>("MiejsceUrodzeniaBox").Text = _student.MiejsceUrodzenia;
                this.FindControl<TextBox>("KrajUrodzeniaBox").Text = _student.KrajUrodzenia;
                this.FindControl<TextBox>("ObywatelstwoBox").Text = _student.Obywatelstwo;

                // Adres
                this.FindControl<TextBox>("WojewodztwoBox").Text = _student.Wojewodztwo;
                this.FindControl<TextBox>("MiastoBox").Text = _student.Miasto;
                this.FindControl<TextBox>("UlicaBox").Text = _student.Ulica;
                this.FindControl<TextBox>("NumerDomuBox").Text = _student.NumerDomu;
                this.FindControl<TextBox>("NumerLokaluBox").Text = _student.NumerLokalu;
                this.FindControl<MaskedTextBox>("KodPocztowyBox").Text = _student.KodPocztowy;

                // Rodzina i kontakt
                this.FindControl<TextBox>("ImieOjcaBox").Text = _student.ImieOjca;
                this.FindControl<TextBox>("ImieMatkiBox").Text = _student.ImieMatki;
                this.FindControl<MaskedTextBox>("TelefonBox").Text = _student.Telefon;
                this.FindControl<TextBox>("TelegramViberBox").Text = _student.TelegramViber;
                this.FindControl<TextBox>("EmailBox").Text = _student.Email;
                this.FindControl<TextBox>("OsobaKontaktowaBox").Text = _student.OsobaKontaktowa;
                this.FindControl<TextBox>("TelefonOsobyKontaktowejBox").Text = _student.TelefonOsobyKontaktowej;

                // Dokumenty i status
                this.FindControl<TextBox>("PaszportBox").Text = _student.Paszport;
                this.FindControl<TextBox>("SeriaNumerBox").Text = _student.SeriaNumer;
                this.FindControl<TextBox>("WydanyPrzezBox").Text = _student.WydanyPrzez;
                this.FindControl<CheckBox>("StatusUKRCheckBox").IsChecked = _student.StatusUKR;
                this.FindControl<CheckBox>("JestWDziennikuCheckBox").IsChecked = _student.JestWDzienniku;
                this.FindControl<TextBox>("PrzyczynaOpuszczeniaBox").Text = _student.PrzyczynaOpuszczenia;
                this.FindControl<CalendarDatePicker>("DataOpuszczeniaPicker").SelectedDate = _student.DataOpuszczenia;
                this.FindControl<TextBox>("NumerDecyzjiBox").Text = _student.NumerDecyzji;
            }
        }

        private void SaveButton_Click(object? sender, RoutedEventArgs e)
        {
            var student = _student ?? new StudentData();

            // Edukacja
            student.Identifikator = this.FindControl<TextBox>("IdentifikatorBox")?.Text;
            student.DataPrzyjecia = this.FindControl<CalendarDatePicker>("DataPrzyjeciaPicker")?.SelectedDate?.Date;
            student.NumerKs = this.FindControl<TextBox>("NumerKsBox")?.Text;
            student.Kierunek = this.FindControl<TextBox>("KierunekBox")?.Text;
            student.Semestr = int.TryParse(this.FindControl<TextBox>("SemestrBox")?.Text, out var semestr) ? semestr : 0;
            student.DataRozpoczecia = this.FindControl<CalendarDatePicker>("DataRozpoczeciaPicker")?.SelectedDate?.Date;
            student.RokRozpoczecia = int.TryParse(this.FindControl<TextBox>("RokRozpoczeciaBox")?.Text, out var rok) ? rok : 0;

            // Dane osobowe
            student.Pesel = this.FindControl<TextBox>("PeselBox")?.Text;
            student.Nazwisko = this.FindControl<TextBox>("NazwiskoBox")?.Text;
            student.NazwiskoRodowe = this.FindControl<TextBox>("NazwiskoRodoweBox")?.Text;
            student.Imie1 = this.FindControl<TextBox>("Imie1Box")?.Text;
            student.Imie2 = this.FindControl<TextBox>("Imie2Box")?.Text;
            student.Plec = this.FindControl<TextBox>("PlecBox")?.Text;
            student.DataUrodzenia = this.FindControl<CalendarDatePicker>("DataUrodzeniaPicker")?.SelectedDate?.Date;
            student.MiejsceUrodzenia = this.FindControl<TextBox>("MiejsceUrodzeniaBox")?.Text;
            student.KrajUrodzenia = this.FindControl<TextBox>("KrajUrodzeniaBox")?.Text;
            student.Obywatelstwo = this.FindControl<TextBox>("ObywatelstwoBox")?.Text;

            // Adres
            student.Wojewodztwo = this.FindControl<TextBox>("WojewodztwoBox")?.Text;
            student.Miasto = this.FindControl<TextBox>("MiastoBox")?.Text;
            student.Ulica = this.FindControl<TextBox>("UlicaBox")?.Text;
            student.NumerDomu = this.FindControl<TextBox>("NumerDomuBox")?.Text;
            student.NumerLokalu = this.FindControl<TextBox>("NumerLokaluBox")?.Text;
            student.KodPocztowy = this.FindControl<MaskedTextBox>("KodPocztowyBox")?.Text;

            // Rodzina i kontakt
            student.ImieOjca = this.FindControl<TextBox>("ImieOjcaBox")?.Text;
            student.ImieMatki = this.FindControl<TextBox>("ImieMatkiBox")?.Text;
            student.Telefon = this.FindControl<MaskedTextBox>("TelefonBox")?.Text;
            student.TelegramViber = this.FindControl<TextBox>("TelegramViberBox")?.Text;
            student.Email = this.FindControl<TextBox>("EmailBox")?.Text;
            student.OsobaKontaktowa = this.FindControl<TextBox>("OsobaKontaktowaBox")?.Text;
            student.TelefonOsobyKontaktowej = this.FindControl<TextBox>("TelefonOsobyKontaktowejBox")?.Text;

            // Dokumenty i status
            student.Paszport = this.FindControl<TextBox>("PaszportBox")?.Text;
            student.SeriaNumer = this.FindControl<TextBox>("SeriaNumerBox")?.Text;
            student.WydanyPrzez = this.FindControl<TextBox>("WydanyPrzezBox")?.Text;
            student.StatusUKR = this.FindControl<CheckBox>("StatusUKRCheckBox")?.IsChecked ?? false;
            student.JestWDzienniku = this.FindControl<CheckBox>("JestWDziennikuCheckBox")?.IsChecked ?? false;
            student.PrzyczynaOpuszczenia = this.FindControl<TextBox>("PrzyczynaOpuszczeniaBox")?.Text;
            student.DataOpuszczenia = this.FindControl<CalendarDatePicker>("DataOpuszczeniaPicker")?.SelectedDate?.Date;
            student.NumerDecyzji = this.FindControl<TextBox>("NumerDecyzjiBox")?.Text;

            try
            {
                _databaseService.SaveStudent(student);
                Close();
            }
            catch (Exception ex)
            {
                // Tutaj można obsłużyć błąd, np. wyświetlić komunikat
            }
        }
    }
}
