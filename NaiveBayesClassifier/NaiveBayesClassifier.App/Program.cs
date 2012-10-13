using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaiveBayesClassifier.DataProvider;
using NaiveBayesClassifier.Implementation;

namespace NaiveBayesClassifier.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //USAGE EXAMPLE
            Classifier<string> classifier = new Classifier<string>();
            IDataProvider dataProvider = new MockDataProvider();

            var trainingData = dataProvider.GetTrainingData() as List<InformationModel<string>> ;


            classifier.Teach(trainingData);
            var result = classifier.Classify(new List<string>() {"Red", "SUV", "Domestic"});


            foreach (var x in result)
            {
                Console.WriteLine("{0} => {1}", x.Key, x.Value);
            }

            Console.ReadKey();
        }
    }
}
