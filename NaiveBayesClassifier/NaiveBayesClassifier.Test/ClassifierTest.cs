using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaiveBayesClassifier.Implementation;

namespace NaiveBayesClassifier.Test
{
    [TestClass]
    public class ClassifierTest
    {

        #region TeachData
        List<InformationModel<string>> _list = new List<InformationModel<string>>()
                {
                        new InformationModel<string>()
                        {
                            Lable = "Spam",
                            Features = new List<string>(){"ass","viagra","penis","sex","money","drugs","ipad3", "prize"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "Spam",
                            Features = new List<string>(){"ass","viagra","penis","beer","money","alcohol","ipad3"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "Spam",
                            Features = new List<string>(){"viagra","penis","sex","bigger","drugs"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "Mail",
                            Features = new List<string>(){"hi","Dear","prize","game","car","girlfriend"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "Mail",
                            Features = new List<string>(){"hi","Dear","prize","game","car","boyfriend"}
                        },
                        new InformationModel<string>()
                        {
                            Lable = "Mail",
                            Features = new List<string>(){"hi","Baby","prize","money","car","sex"}
                        }
                };
        #endregion

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
        public void ShouldBeSpam()
        {
            var classifier = new Classifier<string>();
            classifier.Teach(_list);

            var actual = "Spam";
            var expected =
                classifier.Classify(new List<string>() {"sex", "penis", "viagra", "sex"}).OrderByDescending(x => x.Value)
                    .FirstOrDefault();
        }

    }
}
