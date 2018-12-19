using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
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
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
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
                if (SelectedDate != null)
                {
                    CheckTotalParticipants();
                }
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
            try
            {
                ModelEventsBasementSingleton.Instance.AddDate(new ModelDate(new DateTime(Year, Month, Day), EventType, TotalSeats));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageDialogHelper.Show("Er dato indtastet korrekt? Format dd, mm, åååå","Ugyldig Dato");
            }
        }
        
        //metode til at fjerne en dato fra listen 
        public void RemoveDate()
        {
            if (SelectedDate != null) ModelEventsBasementSingleton.Instance.RemoveDate(SelectedDate.Date);
        }

        #endregion

        #region Gruppe Metoder

        //tilføje nye grupper via GUI'en, samt opdatere TotalParticipants
        public void AddGroup()
        {

            if (SelectedDate != null)
            {
                SelectedDate.AddGroup(new ModelGroup(TeamName, PhoneNumber, Participants, TableNr));
                SelectedDate.TotalParticipants += Participants;
                SelectedDate.TotalSeats -= Participants;
            }



        }


        //fjernelse af grupper via GUI'en
        public void RemoveGroup()
        {

            if (SelectedGroup != null)
            {
                SelectedDate.TotalSeats += SelectedGroup.Participants;
                SelectedDate.RemoveGroup(SelectedGroup.TeamName);
                CheckTotalParticipants();
            }


        }

        //tilføjelse af 1 deltager
        public void AddOneParticipant()
        {

            if (SelectedGroup != null)
            {
                SelectedGroup.Participants++;
                CheckTotalParticipants();
                SetAllPaidMessage(SelectedGroup);
                SetAllAttendingMessage(SelectedGroup);
                SubtractSeat();
            }



        }

        //Fjernelse af 1 deltager
        public void RemoveOneParticipant()
        {

            if (SelectedGroup != null)
            {
                if (SelectedGroup.Participants > 0) SelectedGroup.Participants--;
                CheckTotalParticipants();
                SetAllAttendingMessage(SelectedGroup);
                SetAllPaidMessage(SelectedGroup);
                if (SelectedGroup.NumberOfPayments == SelectedGroup.Participants) SetAllPaidMessage(SelectedGroup);
                AddSeat();
            }


        }

        //Tilføjelse af 1 betaling
        public void AddOnePayment()
        {
            if (SelectedGroup != null)
            {
                if (SelectedGroup.NumberOfPayments < SelectedGroup.Participants) SelectedGroup.NumberOfPayments++;
                SetAllPaidMessage(SelectedGroup);
            }

        }

        //fjernelse af 1 betaling
        public void RemoveOnePayment()
        {
            if (SelectedGroup != null)
            {
                if (SelectedGroup.NumberOfPayments > 0) SelectedGroup.NumberOfPayments--;
                SetAllPaidMessage(SelectedGroup);
            }

        }

        //tilføjelse af 1 tilstedeværende deltager (vedkommende er dukket op)
        public void AddOneAttending()
        {
            if (SelectedGroup != null)
            {
                if (SelectedGroup.NumberOfAttendingParticipants < SelectedGroup.Participants) SelectedGroup.NumberOfAttendingParticipants++;
                SetAllAttendingMessage(SelectedGroup);
            }

        }

        //fjernelse af 1 tilstedeværende deltager (vedkommende er taget hjem eller har aflyst
        public void RemoveOneAttending()
        {
            if (SelectedGroup != null)
            {
                if (SelectedGroup.NumberOfAttendingParticipants > 0) SelectedGroup.NumberOfAttendingParticipants--;
                SetAllAttendingMessage(SelectedGroup);
            }

        }

        #region Private methods

        private void SetAllPaidMessage(ModelGroup group)
        {
            if (group.NumberOfPayments == group.Participants) group.AllPaidMessage = "Alle betalt";
            if (group.NumberOfPayments < group.Participants) group.AllPaidMessage = "";
        }

        private void SetAllAttendingMessage(ModelGroup group)
        {
            if (group.NumberOfAttendingParticipants == group.Participants) group.AllAttendingMessage = "Alle mødt";
            if (group.NumberOfAttendingParticipants < group.Participants) group.AllAttendingMessage = "";
        }

        #endregion

        #endregion

        private class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }
    }
}
