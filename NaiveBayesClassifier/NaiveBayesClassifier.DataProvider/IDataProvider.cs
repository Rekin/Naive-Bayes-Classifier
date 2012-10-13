using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveBayesClassifier.DataProvider
{
    public interface IDataProvider
    {
        object GetTrainingData();
        void SaveTrainingData(object modelInfos);
    }
}
