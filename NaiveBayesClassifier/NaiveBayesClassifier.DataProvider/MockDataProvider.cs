using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaiveBayesClassifier.Implementation;

namespace NaiveBayesClassifier.DataProvider
{
    public class MockDataProvider : IDataProvider
    {
        public object GetTrainingData()
        {
            var data = new List<InformationModel<string>>()
                {
                        new InformationModel<string>()
                        {
                            Lable = "Yes",
                            Features = new List<string>(){"Red","Sports","Domestic"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "Yes",
                            Features = new List<string>(){"Red","Sports","Domestic"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "Yes",
                            Features = new List<string>(){"Yellow","Sports","Imported"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "Yes",
                            Features = new List<string>(){"Yellow","SUV","Imported"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "Yes",
                            Features = new List<string>(){"Red","Sports","Imported"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "No",
                            Features = new List<string>(){"Red","Sports","Domestic"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "No",
                            Features = new List<string>(){"Yellow","Sports","Domestic"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "No",
                            Features = new List<string>(){"Yellow","SUV","Imported"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "No",
                            Features = new List<string>(){"Yellow","SUV","Domestic"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "No",
                            Features = new List<string>(){"Red","SUV","Imported"}
                        }
                };


            return data;
        }

        public void SaveTrainingData(object modelInfos)
        {
            if(modelInfos==null)
                throw new ArgumentNullException();

            throw new NotImplementedException();
        }
    }
}
