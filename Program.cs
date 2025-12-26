using Avalonia;

namespace myapp;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        // Это заглушка, чтобы проект собирался.
        // Реальный запуск будет у тебя в Rider.
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
}