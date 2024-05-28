// ViewModels/MainWindowViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.Linq;
using FixedAssetsManagement2.Models;
using FixedAssetsManagement2.Data;
using ReactiveUI;

using System.Reactive;

namespace FixedAssetsManagement2.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private ObservableCollection<Asset> _assets;
        public ObservableCollection<Asset> Assets
        {
            get => _assets;
            set => this.RaiseAndSetIfChanged(ref _assets, value);
        }

        private string _newAssetId;
        public string NewAssetId
        {
            get => _newAssetId;
            set => this.RaiseAndSetIfChanged(ref _newAssetId, value);
        }

        private string _newAssetName;
        public string NewAssetName
        {
            get => _newAssetName;
            set => this.RaiseAndSetIfChanged(ref _newAssetName, value);
        }

        private decimal _newOriginalCost;
        public decimal NewOriginalCost
        {
            get => _newOriginalCost;
            set => this.RaiseAndSetIfChanged(ref _newOriginalCost, value);
        }

        private DateTime _newAcquisitionDate;
        public DateTime NewAcquisitionDate
        {
            get => _newAcquisitionDate;
            set => this.RaiseAndSetIfChanged(ref _newAcquisitionDate, value);
        }

        public ReactiveCommand<Unit, Unit> AddAssetCommand { get; }

        public MainWindowViewModel()
        {
            LoadAssets();
            AddAssetCommand = ReactiveCommand.Create(AddAsset);
        }

        private void LoadAssets()
        {
            using (var context = new FixedAssetsDbContext())
            {
                var assets = context.Assets.ToList();
                Assets = new ObservableCollection<Asset>(assets);
            }
        }

        private void AddAsset()
        {
            var newAsset = new Asset
            {
                AssetId = NewAssetId,
                AssetName = NewAssetName,
                OriginalCost = NewOriginalCost,
                AcquisitionDate = NewAcquisitionDate
            };

            using (var context = new FixedAssetsDbContext())
            {
                context.Assets.Add(newAsset);
                context.SaveChanges();
                LoadAssets(); // Refresh the list to include the new asset
            }

            // Clear input fields
            NewAssetId = string.Empty;
            NewAssetName = string.Empty;
            NewOriginalCost = 0;
            NewAcquisitionDate = DateTime.Now;
        }
    }
}
