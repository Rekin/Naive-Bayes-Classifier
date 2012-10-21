Naive-Bayes-Classifier
======================

Simple implementation of Naive Bayes Classifier in C# (.NET 4.0).

How to use? 

1. Make new instance of Classifier object.
2. Get some training data and convert it to list of InformationModel.
3. Train classifier (use Teach method).
4. And finally use Classify method. As a result you will receive a Dictionary<string,double> (propability of belonging classified object to each category).


Usage example:

using System;
using NaiveBayesClassifier.DataProvider;
using NaiveBayesClassifier.Implementation;
using System.Collections.Generic;

namespace nbc
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IDataProvider dataProvider = new MockDataProvider();
			
			Classifier<string> classifier = new Classifier<string>();
			
			var sampleData = dataProvider.GetTrainingData() as List<InformationModel<string>>;
			
			classifier.Teach(sampleData);
			IDictionary<string,double> dict = classifier.Classify(new List<string>(){"Red","SUV","Domestic"});
			
			foreach (var item in dict) {
				Console.WriteLine ("{0} ====> {1}",item.Key,item.Value);
			}
		}
	}
}
