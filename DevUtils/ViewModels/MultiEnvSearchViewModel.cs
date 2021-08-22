using CommunityToolkit.Mvvm.ComponentModel;
using DevUtils.Contracts.Services;
using DevUtils.Contracts.ViewModels;
using DevUtils.Core.Models;
using DevUtils.Models;
using DevUtils.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DevUtils.ViewModels
{
    public class MultiEnvSearchViewModel : ObservableRecipient, INavigationAware
    {
        private readonly INavigationService navigationService;
        private readonly MultiEnvSearchService multiEnvSearchService;
        private readonly IEnumerable<ProjectDetails> projectDetails;

        public MultiEnvSearchViewModel(INavigationService navigationService, MultiEnvSearchService multiEnvSearchService, IWebViewService webViewService)
        {
            WebViewService = webViewService;
            this.navigationService = navigationService;
            this.multiEnvSearchService = multiEnvSearchService;
            projectDetails = multiEnvSearchService.GetProjectDetails();

            Projects.Add("Select Project");
            foreach( var project in projectDetails.GroupBy(p => new { p.ProjectName, p.DataBaseType }).Select(p => $"{p.Key.ProjectName} - {p.Key.DataBaseType}").Distinct())
            {
                Projects.Add(project);

            }
        }
        public IWebViewService WebViewService { get; }

        public ObservableCollection<string> Projects { get; private set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Env { get; private set; } = new ObservableCollection<string>();
        public void OnNavigatedFrom()
        {
            WebViewService.UnregisterEvents();
           // WebViewService.NavigationCompleted -= OnNavigationCompleted;
        }

        public void OnNavigatedTo(object parameter)
        {
            html = new Uri("https://www.google.com/");
        }

        public List<string> UpdateEnvDetailsByProjectCode(string projectCode)
        {
            var projectName =projectCode.Split("-")[0].Trim();
            var dbType = projectCode.Split("-")[1].Trim();

            return projectDetails.Where(p => p.ProjectName == projectName && p.DataBaseType == dbType).Select(p => p.EnvironmentName).ToList();
        }

        public Uri html { get; set; } 
        

    }
}
