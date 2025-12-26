
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
                Identifikator = this.FindControl<TextBox>("IdentifikatorBox")?.Text,
                Nazwisko = this.FindControl<TextBox>("NazwiskoBox")?.Text,
                Imie1 = this.FindControl<TextBox>("Imie1Box")?.Text,
                DataUrodzenia = this.FindControl<DatePicker>("DataUrodzeniaPicker")?.SelectedDate?.DateTime,
                Kierunek = this.FindControl<TextBox>("KierunekBox")?.Text,
                Semestr = int.TryParse(this.FindControl<TextBox>("SemestrBox")?.Text, out var semestr) ? semestr : 0,
                // Остальные поля остаются незаполненными, как и было запрошено
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

