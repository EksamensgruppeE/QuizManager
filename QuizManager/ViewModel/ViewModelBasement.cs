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
        private static ModelDate _selectedDate;

       



        #endregion

        //properties som skal bruges til at oprette nye grupper fra GUI
        #region ModelGroupProps
        //By Mosbæk

        public string TeamName { get; set; }

        public string PhoneNumber { get; set; }

        public int Participants { get; set; }

        public int TableNr { get; set; }

        public int NumberOfPayments { get; set; }

        public int NumberOfAttendingParticipants { get; set; }




        //end Mosbæk
        #endregion

        #region Properties
        //properties som bruges til at oprette nye datoer med
        private int Year { get; set; }
        private int Month { get; set; }
        private int Day { get; set; }
        public string EventType { get; set; }

        public int TotalSeats { get; set; }

        //SelectedDate property som kan bruges til at få fat i properties hos en valgt ModelDate
        public ModelDate SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
                CheckTotalParticipants();
            }
        }


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





        #endregion

 
        #region Constructor



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


        //metode der løber listen af grupper igennem opdaterer TotalParticipants med participants fra hver gruppe.
        public void CheckTotalParticipants()
        {
            SelectedDate.TotalParticipants = 0;
            for (int i = 0; i < SelectedDate.Groups.Count; i++)
            {
                SelectedDate.TotalParticipants += SelectedDate.Groups[i].Participants;
            }
        }
        //metode til at tilføje nye Datoer
        public void AddDate()
        {
            ModelEventsBasementSingleton.Instance.AddDate(new ModelDate(new DateTime(Year, Month, Day), EventType, TotalSeats));
        }
        
        //metode til at fjerne en dato fra listen
        public void RemoveDate()
        {
            ModelEventsBasementSingleton.Instance.RemoveDate(SelectedDate.Date);
        }

        #region Gruppe Metoder

        //tilføje nye grupper via GUI'en, samt opdatere TotalParticipants
        public void AddGroup()
        {
            SelectedDate.AddGroup(new ModelGroup(TeamName, PhoneNumber, Participants, TableNr));
            SelectedDate.TotalParticipants += Participants;

        }


        //fjernelse af grupper via GUI'en
        public void RemoveGroup()
        {
            SelectedDate.RemoveGroup(SelectedGroup.TeamName);
            CheckTotalParticipants();
        }

        //tilføjelse af 1 deltager
        public void AddOneParticipant()
        {
            SelectedGroup.Participants++;
        }

        //fjernelse af 1 deltager
        public void RemoveOneParticipant()
        {
            if (SelectedGroup.Participants > 0) SelectedGroup.Participants--;
        }

        //tilføjelse af 1 betaling
        public void AddOnePayment()
        {
            if (SelectedGroup.NumberOfPayments < SelectedGroup.Participants) SelectedGroup.NumberOfPayments++;
            if (SelectedGroup.NumberOfPayments >= SelectedGroup.Participants) SelectedGroup.AllPaidMessage = "Alle Betalt";
        }

        //fjernelse af 1 betaling
        public void RemoveOnePayment()
        {
            if (SelectedGroup.NumberOfPayments > 0) SelectedGroup.NumberOfPayments--;
            if (SelectedGroup.NumberOfPayments < SelectedGroup.Participants) SelectedGroup.AllPaidMessage = "";
        }

        //tilføjelse af 1 tilstedeværende deltager (vedkommende er dukket op)
        public void AddOneAttending()
        {
            if (SelectedGroup.NumberOfAttendingParticipants < SelectedGroup.Participants) SelectedGroup.NumberOfAttendingParticipants++;
            if (SelectedGroup.NumberOfAttendingParticipants >= SelectedGroup.Participants) SelectedGroup.AllAttendingMessage = "Alle fremmødt";
        }

        //fjernelse af 1 tilstedeværende deltager (vedkommende er taget hjem eller har aflyst
        public void RemoveOneAttending()
        {
            if (SelectedGroup.NumberOfAttendingParticipants > 0) SelectedGroup.NumberOfAttendingParticipants--;
            if (SelectedGroup.NumberOfAttendingParticipants < SelectedGroup.Participants) SelectedGroup.AllAttendingMessage = "";
        }

        #endregion




        #endregion



    }
}
