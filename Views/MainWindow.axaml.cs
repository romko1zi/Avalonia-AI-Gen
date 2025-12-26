
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace myapp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SaveButton_Click(object? sender, RoutedEventArgs e)
        {
            var student = new StudentData
            {
                Identifikator = this.FindControl<TextBox>("IdentifikatorBox")?.Text,
                DataPrzyjecia = this.FindControl<DatePicker>("DataPrzyjeciaPicker")?.SelectedDate?.DateTime,
                NumerKs = this.FindControl<TextBox>("NumerKsBox")?.Text,
                Kierunek = this.FindControl<TextBox>("KierunekBox")?.Text,
                Semestr = int.TryParse(this.FindControl<TextBox>("SemestrBox")?.Text, out var semestr) ? semestr : 0,
                DataRozpoczecia = this.FindControl<DatePicker>("DataRozpoczeciaPicker")?.SelectedDate?.DateTime,
                RokRozpoczecia = int.TryParse(this.FindControl<TextBox>("RokRozpoczeciaBox")?.Text, out var rok) ? rok : 0,

                Pesel = this.FindControl<TextBox>("PeselBox")?.Text,
                Nazwisko = this.FindControl<TextBox>("NazwiskoBox")?.Text,
                NazwiskoRodowe = this.FindControl<TextBox>("NazwiskoRodoweBox")?.Text,
                Imie1 = this.FindControl<TextBox>("Imie1Box")?.Text,
                Imie2 = this.FindControl<TextBox>("Imie2Box")?.Text,
                Plec = this.FindControl<TextBox>("PlecBox")?.Text,
                DataUrodzenia = this.FindControl<DatePicker>("DataUrodzeniaPicker")?.SelectedDate?.DateTime,
                MiejsceUrodzenia = this.FindControl<TextBox>("MiejsceUrodzeniaBox")?.Text,
                KrajUrodzenia = this.FindControl<TextBox>("KrajUrodzeniaBox")?.Text,
                Obywatelstwo = this.FindControl<TextBox>("ObywatelstwoBox")?.Text,

                Ulica = this.FindControl<TextBox>("UlicaBox")?.Text,
                NumerDomu = this.FindControl<TextBox>("NumerDomuBox")?.Text,
                NumerLokalu = this.FindControl<TextBox>("NumerLokaluBox")?.Text,
                Miasto = this.FindControl<TextBox>("MiastoBox")?.Text,
                KodPocztowy = this.FindControl<TextBox>("KodPocztowyBox")?.Text,
                Poczta = this.FindControl<TextBox>("PocztaBox")?.Text,
                Gmina = this.FindControl<TextBox>("GminaBox")?.Text,
                Powiat = this.FindControl<TextBox>("PowiatBox")?.Text,
                Wojewodztwo = this.FindControl<TextBox>("WojewodztwoBox")?.Text,

                KodPocztowyPL = this.FindControl<TextBox>("KodPocztowyPLBox")?.Text,
                MiastoPL = this.FindControl<TextBox>("MiastoPLBox")?.Text,
                UlicaPL = this.FindControl<TextBox>("UlicaPLBox")?.Text,
                NumerDomuPL = this.FindControl<TextBox>("NumerDomuPLBox")?.Text,

                ImieOjca = this.FindControl<TextBox>("ImieOjcaBox")?.Text,
                ImieMatki = this.FindControl<TextBox>("ImieMatkiBox")?.Text,
                Telefon = this.FindControl<TextBox>("TelefonBox")?.Text,
                TelegramViber = this.FindControl<TextBox>("TelegramViberBox")?.Text,
                Email = this.FindControl<TextBox>("EmailBox")?.Text,
                OsobaKontaktowa = this.FindControl<TextBox>("OsobaKontaktowaBox")?.Text,
                TelefonOsobyKontaktowej = this.FindControl<TextBox>("TelefonOsobyKontaktowejBox")?.Text,

                Paszport = this.FindControl<TextBox>("PaszportBox")?.Text,
                SeriaNumer = this.FindControl<TextBox>("SeriaNumerBox")?.Text,
                WydanyPrzez = this.FindControl<TextBox>("WydanyPrzezBox")?.Text,
                StatusUKR = this.FindControl<CheckBox>("StatusUKRCheckBox")?.IsChecked ?? false,
                JestWDzienniku = this.FindControl<CheckBox>("JestWDziennikuCheckBox")?.IsChecked ?? false,
                PrzyczynaOpuszczenia = this.FindControl<TextBox>("PrzyczynaOpuszczeniaBox")?.Text,
                DataOpuszczenia = this.FindControl<DatePicker>("DataOpuszczeniaPicker")?.SelectedDate?.DateTime,
                NumerDecyzji = this.FindControl<TextBox>("NumerDecyzjiBox")?.Text
            };

            var csvLine = new StringBuilder();
            csvLine.Append($"{student.Identifikator};{student.DataPrzyjecia:yyyy-MM-dd};{student.NumerKs};{student.Kierunek};{student.Semestr};{student.DataRozpoczecia:yyyy-MM-dd};{student.RokRozpoczecia};");
            csvLine.Append($"{student.Pesel};{student.Nazwisko};{student.NazwiskoRodowe};{student.Imie1};{student.Imie2};{student.Plec};{student.DataUrodzenia:yyyy-MM-dd};{student.MiejsceUrodzenia};{student.KrajUrodzenia};{student.Obywatelstwo};");
            csvLine.Append($"{student.Ulica};{student.NumerDomu};{student.NumerLokalu};{student.Miasto};{student.KodPocztowy};{student.Poczta};{student.Gmina};{student.Powiat};{student.Wojewodztwo};");
            csvLine.Append($"{student.KodPocztowyPL};{student.MiastoPL};{student.UlicaPL};{student.NumerDomuPL};");
            csvLine.Append($"{student.ImieOjca};{student.ImieMatki};{student.Telefon};{student.TelegramViber};{student.Email};{student.OsobaKontaktowa};{student.TelefonOsobyKontaktowej};");
            csvLine.Append($"{student.Paszport};{student.SeriaNumer};{student.WydanyPrzez};{student.StatusUKR};{student.JestWDzienniku};{student.PrzyczynaOpuszczenia};{student.DataOpuszczenia:yyyy-MM-dd};{student.NumerDecyzji}\n");

            var saveFileDialog = new SaveFileDialog()
            {
                Title = "Сохранить как...",
                DefaultExtension = "csv",
                InitialFileName = "students.csv",
                Filters = { new FileDialogFilter() { Name = "CSV Files", Extensions = { "csv" } } }
            };

            string? result = await saveFileDialog.ShowAsync(this);

            if (result != null)
            {
                await File.AppendAllTextAsync(result, csvLine.ToString());
                this.Title = "Сохранено!";
            }
            else
            {
                this.Title = "Сохранение отменено.";
            }
        }
    }
}
