using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizManager.Model
{
    class ModelDateCollection
    {
    
      
        #region Properties

        //Collection til at store på alle modeldates. Bootleg Database
        public ObservableCollection<ModelDate> Dates { get; set; }

        #endregion

        #region Constructor

       public ModelDateCollection()
        {
            Dates = new ObservableCollection<ModelDate>();
            //test collection til at teste TotalSeats. virker dog ikke med collectionen af modelgroup
            Dates.Add(new ModelDate("21 january", "Quiz Night",  52,50,5000,1235,55,54,545,4545,4549));
        }

        #endregion

        #region Methods

        public ModelDate GetDate(string date)
        {
            for (int i = 0; i < Dates.Count; i++)
            {
                if (date == Dates[i].Date)
                    return Dates[i];
            }

            return null;
        }

        public void Add(ModelDate modelDate)
        {
            Dates.Add(modelDate);
        }



        public void AddTest()
        {
            Dates.Add(new ModelDate("29/11/18", "Quiz", 38));
        }
        #endregion
    }
}
