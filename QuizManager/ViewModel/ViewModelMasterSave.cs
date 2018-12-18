using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using QuizManager.Annotations;
using QuizManager.Model;

namespace QuizManager.ViewModel
{
    class ViewModelMasterSave : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public static void SaveAll()
        {
            PersistencyService.SaveBasementLogsAsJsonAsync(ModelEventsBasementSingleton.Instance.BasementDates);
        }


    }

}