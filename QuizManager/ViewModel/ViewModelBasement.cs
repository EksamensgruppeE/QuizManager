using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using QuizManager.Annotations;
using QuizManager.Model;

namespace QuizManager.ViewModel
{
    class ViewModelBasement : INotifyPropertyChanged
    {
       

        #region INotifyPropertyChanged
        // By Mosbæk
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        
        #region Instancefields
        
        //disse 2 felter tilhører tilsvarende properties i Properties Tabben
        private ObservableCollection<ModelGroup> _groups;
        private ModelGroup _selectedGroup;

        #endregion

        //properties som skal bruges til at oprette nye grupper fra GUI
        #region ModelGroupProps
        //By Mosbæk

        public string TeamName { get; set; }

        public string PhoneNumber { get; set; }

        public int Participants { get; set; }

        public int TableNr { get; set; }

        public int NumberOfPayments { get; set; }

        public string AllPayed { get; set; }

        public int NumberOfAttendingParticipants { get; set; }

        //end Mosbæk
        #endregion

        //property der har med Dato at gøre
        public string Date { get; set; }

        
        #region Properties
        
        //SelectedItem property som kan bruges til at få fat i properties hos en valgt ModelDate
        public ModelDate SelectedItem { get; set; }

        // observable collection i property form med ModelDateCollection 
        public ObservableCollection<ModelDateCollection> DateCollection { get; set; }
        

        //property der har med SelectedGroup at gøre, som kan vælges fra GridView i ViewBasement
        public ModelGroup SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                OnPropertyChanged();
            }
        }

        //observable collection af ModelGroups
        public ObservableCollection<ModelGroup> BasementGroups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        #endregion

       
        #region Empty Constructor

        public ViewModelBasement()
        {
            //her skabes ny DateCollection og der tilføjes en ModelDateCollection til den. 
           DateCollection = new ObservableCollection<ModelDateCollection>();
           DateCollection.Add(new ModelDateCollection());

            //som ovenstående, bortset fra at her så oprettes en instans af en collection af groups
            //samt der kaldes en metode som tilføjer 3 test groups.
            //nederst sættes propertien AllPaid til true, hos objektet på plads [0] i group collectionen
            _groups = new ObservableCollection<ModelGroup>();
            AddTest();
            _groups[0].AllPaid = true;

        }
        #endregion

        #region Methods

        //add and remove by Rasmus

        public void AddSeat()
        {
            //skal ha fat i TotalSeats i ModelDate og pluse med 1. findes gennem SelectedItem af ModelDates
            SelectedItem.TotalSeats++;
            
        }

        public void SubtractSeat()
        {
            //skal ha fat i TotalSeats i ModelDate og minuse med 1. findes gennem selectedItem af ModelDates
            SelectedItem.TotalSeats--;
        }

        
        #endregion

        //metode der skaber 3 testgrupper, med yderst opfindsomme navne
        public void AddTest()
        {
            _groups.Add(new ModelGroup("Russerne", "10203040", 7, 1));
            _groups.Add(new ModelGroup("StupidTeamName", "20304050", 3, 1));
            _groups.Add(new ModelGroup("Gede Hviskerne", "30405060", 12, 3));
        }

        //skal måske bruges senere. spørg Laura. DON'T DELETE
        #region Udkommenteret Kode
        
        //public void MakeGroupList(string date)
        //{
        //    if (_groups.Count < ModelEventsBasementSingleton.Instance.BasementModelDateCollection.GetDate(date).Groups
        //            .Count)
        //    {
        //        for (int i = 0;
        //            i < ModelEventsBasementSingleton.Instance.BasementModelDateCollection.GetDate(date).Groups
        //                .Count;
        //            i++)
        //        {
        //            Groups.Add(
        //                ModelEventsBasementSingleton.Instance.BasementModelDateCollection.GetDate(date).Groups[i]);
        //        }
        //    }
        //}

        #endregion

    }
}
