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
        public ModelDate ModelDates;
        //Collection til at store på alle modeldates. Bootleg Database
        public ObservableCollection<ModelDate> Dates { get; set; }

        public ModelDateCollection()
        {
            
        }

    }
}
