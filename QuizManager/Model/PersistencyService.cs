using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;


namespace QuizManager.Model
{
    class PersistencyService
    {

        private static string JsonFileName = "BasementLog.json";


        //Save
        public static async void SaveBasementLogsAsJsonAsync(ObservableCollection<ModelDate> log)
        {
            string logsJsonString = JsonConvert.SerializeObject(log);
            SerializeNotesFileAsync(logsJsonString, JsonFileName);
        }


        //Load
        public static async Task<List<ModelDate>> LoadNotesFromJsonAsync()
        {
            string notesJsonString = await DeserializeNotesFileAsync(JsonFileName);
            if (notesJsonString != null)
                return (List<ModelDate>)JsonConvert.DeserializeObject(notesJsonString, typeof(List<ModelDate>));
            return null;
        }



        private static async void SerializeNotesFileAsync(string logsJsonString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, logsJsonString);
        }


        private static async Task<string> DeserializeNotesFileAsync(string fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {
                //MessageDialogHelper.Show("Loading for the first time? - Try Add and Save some Notes before trying to Save for the first time", "File not Found");
                return null;
            }
        }


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
