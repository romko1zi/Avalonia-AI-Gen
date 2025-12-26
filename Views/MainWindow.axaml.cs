
using Avalonia.Controls;
using Avalonia.Interactivity;
using myapp.Services;
using System.Linq;

namespace myapp.Views
{
    public partial class MainWindow : Window
    {
        private readonly DatabaseService _databaseService;
        private DataGrid _studentsGrid;

        public MainWindow()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            _studentsGrid = this.FindControl<DataGrid>("StudentsGrid");
            LoadStudents();
        }

        private void LoadStudents()
        {
            _studentsGrid.ItemsSource = _databaseService.GetAllStudents();
        }

        private async void AddStudent_Click(object? sender, RoutedEventArgs e)
        {
            var editor = new StudentEditorWindow();
            await editor.ShowDialog(this);
            LoadStudents();
        }

        private async void EditStudent_Click(object? sender, RoutedEventArgs e)
        {
            if (_studentsGrid.SelectedItem is StudentData selectedStudent)
            {
                var editor = new StudentEditorWindow(selectedStudent);
                await editor.ShowDialog(this);
                LoadStudents();
            }
        }

        private void DeleteStudent_Click(object? sender, RoutedEventArgs e)
        {
            if (_studentsGrid.SelectedItem is StudentData selectedStudent)
            {
                _databaseService.DeleteStudent(selectedStudent.Id);
                LoadStudents();
            }
        }
    }
}
