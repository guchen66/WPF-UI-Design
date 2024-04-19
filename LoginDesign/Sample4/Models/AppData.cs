using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample4.Models
{
    public class AppData : BindableBase
    {
        public static readonly AppData Instance = new Lazy<AppData>(() => new AppData()).Value;
        public AppData()
        {
            Init();
            //  LoadState();
        }

        public ObservableCollection<SaveDetailData> SaveDetailDatas { get; set; }
       
        public void Init()
        {
            SaveDetailDatas = new ObservableCollection<SaveDetailData>()
            {
                 new SaveDetailData(){ Id=1, IsSelected=false ,TextContent="记住密码"},
                
            };
        }
    }
}
