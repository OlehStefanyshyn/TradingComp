using DTO;
using BL
using TradingCompWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using Unity;
using Unity.Resolution;
using System.Collections.ObjectModel;

namespace TradingCompWPF.View
{
    public class SListView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private StockManager _manager;
        private ObservableCollection<StockItemsDTO> _sList;
        public ObservableCollection<StockItemsDTO> SList
        {
            get { return _sList; }
            set
            {
                _sList = value;
                OnPropertyChanged(nameof(SList));
            }
        }

        public SListView(StockManager manager)
        {
            _manager = manager;
            Update();
        }

        public void Update()
        {
            var lists= _manager.GetAll();
        }
    }
}
