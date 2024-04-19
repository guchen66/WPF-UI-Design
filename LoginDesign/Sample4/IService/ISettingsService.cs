using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample4.IService
{
    public interface ISettingsService
    {
        /// <summary>
        /// 保存页面的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stateInfos"></param>
        void SaveDataStateInfos<T>(ObservableCollection<T> stateInfos);

        /// <summary>
        /// 获取具体的页面的id
        /// </summary>
        /// <param name="stateIffo"></param>
        /// <returns></returns>
        int GetId(object stateIffo);
        // ObservableCollection<T> LoadState<T>();
    }
}
