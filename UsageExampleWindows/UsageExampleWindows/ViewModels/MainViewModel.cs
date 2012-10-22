using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using NaiveBayesClassifier.DataProvider;
using NaiveBayesClassifier.Implementation;
using UsageExampleWindows.Models;
using UsageExampleWindows.Properties;

namespace UsageExampleWindows.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly Classifier<string> _classifer;
        private readonly ResultModel _result;

        public ComboBoxData Data { get; set; }
        public ICommand ClassifyObjectCmd { get; set; }
        public ObjectViewModel ObjViewModel { get; set; }


        public string Result
        {
            get
            {
                return _result.Result;
            }
            set
            {
                _result.Result = value;
                OnPropertyChanged(() => Result);
            }
        }


        public MainViewModel()
        {
            _classifer = new Classifier<string>();
            _result = new ResultModel();
            Data = new ComboBoxData();
            ObjViewModel = new ObjectViewModel();
            ClassifyObjectCmd = new RelayCommand<object>(x => Classify());


            InitClassificator();
        }

        public void InitClassificator()
        {
            //Uczenie klasyfikatora za pomocą przykładowych danych dostępnych wraz z biblioteką
            //Od tego właściwie zależy jak będzie wyglądał widok itd.
            var teachData = (new MockDataProvider()).GetTrainingData() as List<InformationModel<string>>;

            _classifer.Teach(teachData);
        }

        private void Classify()
        {
            if (!IsStringCorrect(ObjViewModel.CarType, ObjViewModel.Color, ObjViewModel.Origin))
            {
                MessageBox.Show(Resources.ErrorMessage);

            }
            else
            {
                if (_classifer != null)
                {
                    var results = _classifer.Classify(new List<string>() { ObjViewModel.CarType, ObjViewModel.Color, ObjViewModel.Origin });
                    var bestResult = results.OrderByDescending(x=>x.Value).FirstOrDefault();

                    var strBuilder = new StringBuilder();
                    strBuilder.AppendLine(Resources.CategoryQuestion);
                    strBuilder.AppendLine(string.Format(Resources.ResultForma, bestResult.Key, bestResult.Value));

                    Result = strBuilder.ToString();

                }
            }

        }

        private bool IsStringCorrect(params string[] args)
        {
            return args.All(str => !string.IsNullOrEmpty(str));
        }
    }
}
