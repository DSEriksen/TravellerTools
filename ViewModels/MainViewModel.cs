using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CurrencyConversion.Models;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;

namespace CurrencyConversion.ViewModels
{
    internal class MainViewModel : ObservableObject
    {

        #region properties
        private List<KeyValuePair<char, short>> _starportClasses;
        public List<KeyValuePair<char, short>> StarportClasses 
        { 
            get => _starportClasses; 
            set => SetProperty(ref _starportClasses, value); 
        }

        private KeyValuePair<char, short> _selectedStarport;
        public KeyValuePair<char, short> SelectedStarport
        { 
            get => _selectedStarport; 
            set => SetProperty(ref _selectedStarport, value); 
        }

        private List<KeyValuePair<string, short>> _populationClasses;
        public List<KeyValuePair<string, short>> PopulationClasses
        {
            get => _populationClasses;
            set => SetProperty(ref _populationClasses, value);
        }

        private KeyValuePair<string, short> _selectedPopulation;
        public KeyValuePair<string, short> SelectedPopulation
        {
            get => _selectedPopulation;
            set => SetProperty(ref _selectedPopulation, value);
        }

        private List<KeyValuePair<string, short>> _techLevelClasses;
        public List<KeyValuePair<string, short>> TechLevelClasses
        {
            get => _techLevelClasses;
            set => SetProperty(ref _techLevelClasses, value);
        }

        private KeyValuePair<string,short> _selectedTechLevel;
        public KeyValuePair<string,short> SelectedTechLevel
        {
            get => _selectedTechLevel;
            set => SetProperty(ref _selectedTechLevel, value);
        }

        private List<KeyValuePair<string, short>> _securityZoneClasses;
        public List<KeyValuePair<string, short>> SecurityZoneClasses
        {
            get => _securityZoneClasses;
            set => SetProperty(ref _securityZoneClasses, value);
        }

        private KeyValuePair<string, short> _selectedSecurityZone;
        public KeyValuePair<string, short> SelectedSecurityZone
        {
            get => _selectedSecurityZone;
            set => SetProperty(ref _selectedSecurityZone, value);
        }

        private ObservableCollection<Lot> _incidentalCargoLines;
        public ObservableCollection<Lot> IncidentalCargoLines
        {
            get => _incidentalCargoLines;
            set => SetProperty(ref _incidentalCargoLines, value);
        }

        private ObservableCollection<Lot> _minorCargoLines;
        public ObservableCollection<Lot> MinorCargoLines
        {
            get => _minorCargoLines;
            set => SetProperty(ref _minorCargoLines, value);
        }

        private ObservableCollection<Lot> _majorCargoLines;
        public ObservableCollection<Lot> MajorCargoLines
        {
            get => _majorCargoLines;
            set => SetProperty(ref _majorCargoLines, value);
        }

        private int _parsecDistance;
        public int ParsecDistance
        {
            get => _parsecDistance;
            set => SetProperty(ref _parsecDistance, value);
        }
        #endregion

        #region Commands

        public ICommand GenerateManifestCommand { get; set; }

        #endregion

        public MainViewModel()
        {
            StarportClasses = Modifiers.StarportClasses;
            SelectedStarport = StarportClasses.First();

            PopulationClasses = Modifiers.PopulationClasses;
            SelectedPopulation = PopulationClasses.First();

            TechLevelClasses = Modifiers.TechLevelClasses;
            SelectedTechLevel = TechLevelClasses.First();

            SecurityZoneClasses = Modifiers.SecurityZoneClasses;
            SelectedSecurityZone = SecurityZoneClasses.First();

            ParsecDistance = 1;

            GenerateManifestCommand = new RelayCommand(GenerateManifest);
        }

        private void GenerateManifest()
        {
            // Roll 3 times for incidental, minor, and major each


            //Calculate the totals of modifiers first
            int starportModifier = SelectedStarport.Value;
            int populationModifier = SelectedPopulation.Value;
            int techlevelModifier = SelectedTechLevel.Value;
            int securityZoneModifier = SelectedSecurityZone.Value;
            int parsecDistanceModifier = ParsecDistance <= 1 ? 0 : ParsecDistance;

            int totalModifier =
                starportModifier +
                populationModifier +
                techlevelModifier +
                securityZoneModifier +
                parsecDistanceModifier;

            IncidentalCargoLines = new ObservableCollection<Lot>();
            CreateLots(IncidentalCargoLines, CargoType.Incidental, totalModifier + 2);

            MinorCargoLines = new ObservableCollection<Lot>();
            CreateLots(MinorCargoLines, CargoType.Minor, totalModifier);

            MajorCargoLines = new ObservableCollection<Lot>();
            CreateLots(MajorCargoLines, CargoType.Major, totalModifier - 4);
            
        }

        private void CreateLots(ObservableCollection<Lot> lots, CargoType cargoType, int modifier)
        {
            var dice = new Random();
            var roll = dice.Next(1, 6) + dice.Next(1, 6);
            var modifiedRoll = Math.Clamp(roll + modifier, 1, 20);
            var lotsCount = Tables.FreightTraffic()[modifiedRoll];
            int tonnesMultiplier = cargoType switch
            {
                CargoType.Incidental => 1,
                CargoType.Minor => 5,
                CargoType.Major => 10,
                _ => throw new ArgumentOutOfRangeException(nameof(cargoType))
            };

            for (int i =  0; i < lotsCount; i++)
            {
                var tonnesRoll = dice.Next(1, 6) * tonnesMultiplier;
                var payout = Tables.Passage()[ParsecDistance] * tonnesMultiplier;
                var lot = new Lot()
                {
                    Tonnes = tonnesRoll,
                    Payout = payout,
                    DisplayText = $"[{i+1}] {tonnesRoll} tonnes | {payout} credits"
                };
                lots.Add(lot);
            }
        }
    }

}
