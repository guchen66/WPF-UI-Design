using Newtonsoft.Json;
using Sample4.Models;
using Sample4.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample4.IService
{
    public class SettingsService : ISettingsService
    {
        private const string StateFileName = "settings.json";
        private List<StateSetting> _settingsList; // 移除静态变量
        private Dictionary<Type, SettingType> _typeMap;
        public SettingsService()
        {
            _settingsList = LoadSavedState(); // 加载保存的状态
            _typeMap = new Dictionary<Type, SettingType>()
            {
                {typeof(SaveDetailData), SettingType.StartupInfo},
             //   {typeof(DownLoadInfo), SettingType.DownLoadInfo},
              //  {typeof(LyricsSetInfo),SettingType.LyricsSetInfo},
                //添加其他TabItem类型与设置映射
            };
        }

        public void SaveDataStateInfos<T>(ObservableCollection<T> stateInfos)
        {
            foreach (var stateInfo in stateInfos)
            {
                if (_typeMap.TryGetValue(stateInfo.GetType(), out SettingType settingType))
                {
                    var settings = _settingsList.FirstOrDefault(s => s.Id == GetId(stateInfo) && s.Type == settingType);
                    if (settings != null)
                    {
                        settings.IsSelected = GetIsSelected(stateInfo);
                    }
                    else
                    {
                        settings = new StateSetting() { Id = GetId(stateInfo), IsSelected = GetIsSelected(stateInfo), Type = settingType };
                        _settingsList.Add(settings);
                    }
                }
            }

            string serializedSettings = JsonConvert.SerializeObject(_settingsList);
            File.WriteAllText(StateFileName, serializedSettings);
        }




        public int GetId(object stateInfo)
        {
            if (stateInfo is StateSetting stateInfo1)
            {
                return stateInfo1.Id;
            }
            /*else if (stateInfo is DownLoadInfo stateInfo2)
            {
                return stateInfo2.Id;
            }
            else if (stateInfo is LyricsSetInfo stateInfo3)
            {
                return stateInfo3.Id;
            }*/
            // 处理其他情况，可以返回默认值或抛出异常

            return 0; // 或者根据具体逻辑返回适当的默认值
        }

        private bool GetIsSelected(object stateInfo)
        {

            if (stateInfo is SaveDetailData stateInfo1)
            {
                // 根据 SomeStateInfo1 类型获取相应的 IsSelected 值
                return stateInfo1.IsSelected;
            }
           /* else if (stateInfo is DownLoadInfo stateInfo2)
            {
                // 根据 SomeStateInfo2 类型获取相应的 IsSelected 值
                return stateInfo2.IsSelected;
            }
            else if (stateInfo is LyricsSetInfo stateInfo3)
            {
                // 根据 SomeStateInfo2 类型获取相应的 IsSelected 值
                return stateInfo3.IsSelected;
            }*/
            // 处理其他情况，可以返回默认值或抛出异常

            return false; // 或者根据具体逻辑返回适当的默认值
        }

        private List<StateSetting> LoadSavedState()
        {
            if (File.Exists(StateFileName))
            {
                string serializedSettings = File.ReadAllText(StateFileName);
                return JsonConvert.DeserializeObject<List<StateSetting>>(serializedSettings);
            }

            return new List<StateSetting>();
        }
    }
}
