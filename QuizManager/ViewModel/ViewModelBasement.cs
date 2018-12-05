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
        
        private ObservableCollection<ModelDate> _dates;
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
        
        //SelectedDate property som kan bruges til at få fat i properties hos en valgt ModelDate
        public ModelDate SelectedDate { get; set; }
        

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


        // To get access to Dates collection in view, this is saved in BasementDates through the singleton
        public ObservableCollection<ModelDate> Dates
        {
            get { return _dates; }
            set
            {
                _dates = value;
                OnPropertyChanged();
            }
        }

        //observable collection af ModelGroups


        #endregion


        #region Empty Constructor

        public ViewModelBasement()
        {
            _dates = ModelEventsBasementSingleton.Instance.BasementDates;
            


        }
        #endregion

        #region Methods

        //add and remove by Rasmus

        public void AddSeat()
        {
            //skal ha fat i TotalSeats i ModelDate og pluse med 1. findes gennem SelectedItem af ModelDates
            SelectedDate.TotalSeats++;
            
        }

        public void SubtractSeat()
        {
            //skal ha fat i TotalSeats i ModelDate og minuse med 1. findes gennem selectedItem af ModelDates
            SelectedDate.TotalSeats--;
        }

        //tilføje nye grupper via GUI'en
        public void AddGroup()
        {
            SelectedDate.AddGroup(new ModelGroup(TeamName, PhoneNumber, Participants, TableNr));
        }

        
        #endregion


    }
}
