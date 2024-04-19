using Newtonsoft.Json;
using Sample4.Models;
using Sample4.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sample4.Helper
{
    public static class StateHelper
    {
        public static void SaveState(ObservableCollection<SaveDetailData> items)
        {
            // 创建设置settings对象
            var settingsList = new List<StateSetting>();

            // 遍历所有StartupInfo
            foreach (var item in items)
            {
                // 创建MusicSettings对象并添加到settingsList
                var settings = new StateSetting() { Id = item.Id, IsSelected = item.IsSelected, Type = SettingType.StartupInfo };
                settingsList.Add(settings);
            }

            // 序列化保存
            string serializedSettings = JsonConvert.SerializeObject(settingsList);
            File.WriteAllText("settings.json", serializedSettings);
        }




        public static void ApplySavedState()
        {
            if (File.Exists("settings.json"))
            {
                string serializedSettings = File.ReadAllText("settings.json");
                var settingsList = JsonConvert.DeserializeObject<List<StateSetting>>(serializedSettings);

                foreach (var settings in settingsList)
                {
                    if (settings.Type == SettingType.StartupInfo)
                    {
                        var startupInfo = AppData.Instance.SaveDetailDatas.FirstOrDefault(s => s.Id == settings.Id);
                        if (startupInfo != null)
                        {
                            startupInfo.IsSelected = settings.IsSelected;
                        }
                    }

                }
            }
        }

    }
    /* public static class StateHelper
     {
         private const string FileName = "state.json";

         public static void SaveState(bool isChecked)
         {
             using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
             {
                 using (var stream = new IsolatedStorageFileStream(FileName, FileMode.Create, isolatedStorage))
                 {
                     using (var writer = new StreamWriter(stream))
                     {
                         writer.WriteLine(isChecked.ToString());
                     }
                 }
             }
         }

         public static bool LoadState()
         {
             using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
             {
                 if (isolatedStorage.FileExists(FileName))
                 {
                     using (var stream = new IsolatedStorageFileStream(FileName, FileMode.Open, isolatedStorage))
                     {
                         using (var reader = new StreamReader(stream))
                         {
                             var line = reader.ReadLine();
                             if (bool.TryParse(line, out bool isChecked))
                                 return isChecked;
                         }
                     }
                 }
             }

             return false;
         }

         public static void ApplySavedState(CheckBox checkBox)
         {
             checkBox.IsChecked = LoadState();
         }

         public static void ApplySavedState()
         {
             if (File.Exists("settings.json"))
             {
                 string serializedSettings = File.ReadAllText("settings.json");
                 var settingsList = JsonConvert.DeserializeObject<List<SaveDetailData>>(serializedSettings);

                 foreach (var settings in settingsList)
                 {
                     var startupInfo = new SaveDetailData();//.FirstOrDefault(s => s.Id == settings.Id);
                     if (startupInfo != null)
                     {
                         startupInfo.IsSelected = settings.IsSelected;
                     }

                 }
             }
         }
     }*/
}
