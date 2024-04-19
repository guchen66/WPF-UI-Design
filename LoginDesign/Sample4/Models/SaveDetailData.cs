using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample4.Models
{
    public class SaveDetailData : BindableBase
    {
        public string Type => "SaveDetailData";//如果使用面向接口，通过Type判断

        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty<int>(ref id, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty<bool>(ref _isSelected, value); }
        }

        private string _textContent;
        public string TextContent
        {
            get { return _textContent; }
            set { SetProperty<string>(ref _textContent, value); }
        }

        //public ObservableCollection<SaveDetailData> CommonSaveInfos { get; set; }
    }
}
