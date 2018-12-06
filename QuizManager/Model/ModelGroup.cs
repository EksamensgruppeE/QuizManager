using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using QuizManager.Annotations;

namespace QuizManager.Model
{
    class ModelGroup : INotifyPropertyChanged
    {
        private string _allPaidMessage;
        private int _participants;
        private int _numberOfPayments;
        private int _numberOfAttendingParticipants;


        #region Properties
        //Oplysninger omkring holdet som er tilmeldt.
        public string TeamName { get; set; }

        public string PhoneNumber { get; set; }

        public int Participants
        {
            get
            { return _participants; }
            set
            {
                _participants = value;
                OnPropertyChanged();
            }
        }

        public int TableNr { get; set; }

        public int NumberOfPayments
        {
            get { return _numberOfPayments; }
            set
            {
                _numberOfPayments = value;
                OnPropertyChanged();
                if (NumberOfPayments >= Participants) AllPaidMessage = "Alle betalt";
                if (NumberOfPayments < Participants) AllPaidMessage = "";
            }
        }

        public string AllPaidMessage
        {
            get { return _allPaidMessage; }
            set
            {
                _allPaidMessage = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor
        // By Mosbæk
        public ModelGroup(string teamName, string phoneNumber, int participants, int tableNr)
        {
            TeamName = teamName;
            PhoneNumber = phoneNumber;
            _participants = participants;
            TableNr = tableNr;
            _numberOfPayments = 0;
            AllPaidMessage = "";
        }

        #endregion

        #region Methods

        //tilføjelse af 1 deltager
        public void AddOneParticipant()
        {
            Participants++;
        }

        //fjernelse af 1 deltager
        public void RemoveOneParticipant()
        {
            if (Participants > 0) Participants--;
        }

        //tilføjelse af 1 betaling
        public void AddOnePayment()
        {
            if (NumberOfPayments<Participants) NumberOfPayments++;
            if (NumberOfPayments >= Participants) AllPaidMessage = "Alle Betalt";
        }

        //fjernelse af 1 betaling
        public void RemoveOnePayment()
        {
            if (NumberOfPayments > 0) NumberOfPayments--;
            if (NumberOfPayments < Participants) AllPaidMessage = "";
        }
        #endregion


        #region InotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
