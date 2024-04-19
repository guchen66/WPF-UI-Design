using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample4.Settings
{
    [Serializable]
    public class StateSetting
    {
        public int Id { get; set; }
        public bool IsSelected { get; set; }
        public SettingType Type { get; set; } // 修改为枚举类型
    }

    public enum SettingType
    {
        StartupInfo,
        SaveDetailData,
        LyricsSetInfo,

        //添加其他TabItem类型
    }
}
