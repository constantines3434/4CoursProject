using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnigmaProject.ViewModel;

namespace EnigmaProject.Model
{
    public class RotorsModel
    {
        #region Fields and Properties
        public List<RotorVM> _list = new List<RotorVM>();

        //исправить
        public RotorVM _keyboard = HistoricData.Keyboard;

        public RotorVM ReflectorData { get; private set; }

        //исправить
        public RotorsModel()
        {
            this.ReflectorData = HistoricData.Reflectors.ReflectorB;//HistoricData.Reflectors.ReflectorB;
        }
        #endregion
    }
}
