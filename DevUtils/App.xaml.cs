using CommunityToolkit.Mvvm.DependencyInjection;

using DevUtils.Activation;
using DevUtils.Contracts.Services;
using DevUtils.Core;
using DevUtils.Core.Contracts;
using DevUtils.Core.Contracts.Services;
using DevUtils.Core.Services;
using DevUtils.Helpers;
using DevUtils.Services;
using DevUtils.ViewModels;
using DevUtils.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System.IO;
using Windows.Storage;

// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace DevUtils
{
    public partial class App : Application
    {
        public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };

        public App()
        {
            InitializeComponent();
            UnhandledException += App_UnhandledException;
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/windows/winui/api/microsoft.ui.xaml.unhandledexceptioneventargs
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            var activationService = Ioc.Default.GetService<IActivationService>();
            var context = Ioc.Default.GetRequiredService<DevUtilContext>();
            context.Database.EnsureCreated();
            await activationService.ActivateAsync(args);
        }

        private System.IServiceProvider ConfigureServices()
        {
            // TODO WTS: Register your services, viewmodels and pages here
            var services = new ServiceCollection();

            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "DevUtils.db");
            services.AddDbContext<DevUtilContext>(builder =>
            {
                builder.UseSqlite($"Filename={path}");

            }, ServiceLifetime.Singleton);
            // Other Activation Handlers

            // Services
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddTransient<IWebViewService, WebViewService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            services.AddSingleton<ISampleDataService, SampleDataService>();
            services.AddSingleton<IDatabaseService, DatabaseService>();

            services.AddSingleton<IMultiEnvSearchService, MultiEnvSearchService>();

            // Views and ViewModels
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainPage>();
            services.AddTransient<MultiEnvSearchViewModel>();
            services.AddTransient<MultiEnvSearchPage>();
            services.AddTransient<WebViewViewModel>();
            services.AddTransient<WebViewPage>();
            services.AddTransient<ListDetailsViewModel>();
            services.AddTransient<ListDetailsPage>();
            services.AddTransient<ContentGridViewModel>();
            services.AddTransient<ContentGridPage>();
            services.AddTransient<ContentGridDetailViewModel>();
            services.AddTransient<ContentGridDetailPage>();
            services.AddTransient<DataGridViewModel>();
            services.AddTransient<DataGridPage>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<DatabasesViewModel>();
            services.AddTransient<DatabasesPage>();
            return services.BuildServiceProvider();
        }
    }
}
