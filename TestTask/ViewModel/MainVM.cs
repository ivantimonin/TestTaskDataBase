using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Model;

namespace TestTask.ViewModel
{
    class MainVM:BaseVM
    {
        /// <summary>
        /// Таблица которая хранит результат запроса
        /// </summary>           
        private DataTable allQueryData;
        public DataTable AllQueryData
        {
            get { return allQueryData; }
            set
            {
                allQueryData = value;
                OnPropertyChanged();
            }
        }

        public MainVM()
        {
            AllQueryData=DataBase.Select("USE TestTask EXEC AllData");
        }
    }
}
