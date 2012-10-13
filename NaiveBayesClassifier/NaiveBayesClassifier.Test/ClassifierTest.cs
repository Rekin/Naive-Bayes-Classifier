/*
 *  @Author: Adam Wyrembelski
 *  @Data: 12.10.2012.
 *  @Project: NaiveBayesClassifier 
 */

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaiveBayesClassifier.DataProvider;
using NaiveBayesClassifier.Implementation;

namespace NaiveBayesClassifier.Test
{
    [TestClass]
    public class ClassifierTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentNullExceptionClassify()
        {
            var classifier = new Classifier<string>();
            classifier.Classify(null);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentNullExceptionTeach()
        {
            var classifier = new Classifier<string>();
            classifier.Teach(null);
        }


        [TestMethod]
        public void ShouldBeNoLable()
        {
            IDataProvider dataProvider = new MockDataProvider();
            var trainingDataSet = dataProvider.GetTrainingData() as List<InformationModel<string>>;

            var classifier = new Classifier<string>();
            classifier.Teach(trainingDataSet);

            var actual = "No";
            var expected =
                classifier.Classify(new List<string>() {"Red","Sports","Imported"}).OrderByDescending(x => x.Value)
                    .FirstOrDefault();
        }

    }
}
