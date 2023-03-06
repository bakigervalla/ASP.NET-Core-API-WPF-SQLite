using Solid.UI.API;
using Solid.UI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Solid.UI.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private readonly IPackageService _packageService;
        public ShellViewModel(IPackageService packageService)
        {
            _packageService = packageService;
        }

        protected override async void OnViewLoaded(object view)
        {
            var result = await _packageService.GetAllPackagesAsync();
            if (result.StatusCode == 200)
            {
                Packages = await result.GetJsonAsync<IList<Package>>();
            }
        }

        private IList<Package> _package;
        public IList<Package> Packages { get => _package; set { _package = value; NotifyOfPropertyChange(nameof(_package)); } }

        public async void SavePackages()
        {
            foreach (var package in Packages)
                await _packageService.SavePackage(package);
        }

        public void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
