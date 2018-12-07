using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using QuizManager.Annotations;

namespace QuizManager.Model
{
    class ModelDate : INotifyPropertyChanged
    {

        #region Instance Fields
        
        

        private ObservableCollection<ModelGroup> _groups;

        private int _totalSeats;
        private int _totalParticipants;
        private double _totalRevenue;
        private double _revenue20To24;
        private double _revenue24ToClose;
        private double _totalRevenueQuiz;
        private double _totalRevenueQuizParticipants;
        private double _revenueQuizOffers;


        #endregion


        #region Properties

        //Undersøges for relevant datatype
        public string Date { get; set; }

        public string EventType { get; set; }

        //Collection af grupper
        public ObservableCollection<ModelGroup> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                OnPropertyChanged();
            }
        }

        //Deltagere i alt
        public int TotalParticipants
        {
            get => _totalParticipants;
            set
            {_totalParticipants = value; OnPropertyChanged(); }
        }

        //antal stole i alt.
        public int TotalSeats
        {
            get => _totalSeats;
            set
            {_totalSeats = value; OnPropertyChanged(); }
        }

        //betaling i alt.
        public int TotalPayments { get; set; }


        #region Statistik

        //Dagens Omsætning
        public double TotalRevenue
        {
            get => _totalRevenue;
            set { _totalRevenue = value; OnPropertyChanged();}
        }

        //Omsætningen i tidsrummet 20-24
        public double Revenue20To24
        {
            get => _revenue20To24;
            set { _revenue20To24 = value; OnPropertyChanged();}
        }

        //Omsætningen i tidsrummet 24-lukketid
        public double Revenue24ToClose
        {
            get => _revenue24ToClose;
            set { _revenue24ToClose = value; OnPropertyChanged() ;}
        }

        //Totale omsætning af deltagelsesgebyr og salg til deltagere
        public double TotalRevenueQuiz
        {
            get => _totalRevenueQuiz;
            set { _totalRevenueQuiz = value; OnPropertyChanged(); }
        }

        //Totale omsætning af quizdeltagelsesgebyr
        public double TotalRevenueQuizParticipants
        {
            get => _totalRevenueQuizParticipants;
            set { _totalRevenueQuizParticipants = value; OnPropertyChanged(); }
        }

        //Totale omsætning af varer solgt med rabat til quiz deltagere
        public double RevenueQuizOffers
        {
            get => _revenueQuizOffers;
            set { _revenueQuizOffers = value; OnPropertyChanged(); }
        }

        #endregion


        #endregion
        

        #region Constructor

        //denne constructor initialisere properties med det input den nu får, 
        //samt opretter en observable collection af ModelGroups.

        //skal måske erstattes af nedenstående constructor

        public ModelDate(string date, string eventType, int totalParticipants, int totalSeats, int totalPayments, double totalRevenue, double revenue20To24, double revenue24ToClose, double totalRevenueQuiz, double totalRevenueQuizParticipants, double revenueQuizOffers)

        {
            Date = date;
            EventType = eventType;
            Groups = new ObservableCollection<ModelGroup>();
            TotalParticipants = totalParticipants;
            TotalSeats = totalSeats;
            TotalPayments = totalPayments;
            TotalRevenue = totalRevenue;
            Revenue20To24 = revenue20To24;
            Revenue24ToClose = revenue24ToClose;
            TotalRevenueQuiz = totalRevenueQuiz;
            TotalRevenueQuizParticipants = totalRevenueQuizParticipants;
            RevenueQuizOffers = revenueQuizOffers;
        }

        
        //Er det ikke bedre at have en lidt mere simpel constructor, som nedenstående? - Laura
        public ModelDate(string date, string eventType, int totalSeats)
        {
            Date = date;
            EventType = eventType;
            Groups = new ObservableCollection<ModelGroup>();
            TotalSeats = totalSeats;
        }

        #endregion


        #region Methods

        //metode der gennemløber Groups Collectionen for det specificerede teamName.
        public ModelGroup GetGroup(string teamName)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (teamName == Groups[i].TeamName)
                {
                    return Groups[i];
                }
            }

            return null;
        }

        public void AddGroup(ModelGroup group)
        {
           Groups.Add(group);
        }

        public void RemoveGroup(string name)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (Groups[i].TeamName == name) Groups.RemoveAt(i);
            }
        }

        


        #endregion


        #region INotifyPropertyChanged
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
