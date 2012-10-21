using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsageExampleWindows.Models;

namespace UsageExampleWindows.ViewModels
{
    public class ObjectViewModel : BaseViewModel
    {

        private readonly ClassificationObjModel _obj;

        public ObjectViewModel()
        {
            _obj = new ClassificationObjModel();
        }

        public string Color
        {
            get
            {
                return _obj.Color;
            }
            set
            {
                _obj.Color = value;
                OnPropertyChanged(() => Color);
            }
        }

        public string CarType
        {
            get
            {
                return _obj.CarType;
            }
            set
            {
                _obj.CarType = value;
                OnPropertyChanged(() => CarType);
            }
        }

        public string Origin
        {
            get
            {
                return _obj.Origin;
            }
            set
            {
                _obj.Origin = value;
                OnPropertyChanged(() => Origin);
            }
        }
    }
}
