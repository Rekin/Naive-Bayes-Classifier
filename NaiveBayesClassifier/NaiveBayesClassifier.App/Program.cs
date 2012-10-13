using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaiveBayesClassifier.Implementation;

namespace NaiveBayesClassifier.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var classifier = new Classifier<string>();

            #region TeachData
            var list = new List<InformationModel<string>>()
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
                            Features = new List<string>(){"viagra","penis","sex","bigger","drugs","car"}
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

            classifier.Teach(list);
            var result = classifier.Classify(new List<string>() { "Dear", "sex", "car", "money" });

            //Some real example
            var example = @"Viagra -20%

                            About 50% of all men over 40 years old suffer from ED. 
                            Erectile Dysfunction happens when not enough blood flows to the penis, as a result, man can't maintain erection. 
                            You can improve your erection with medicine called Generic Viagra. Generic Viagra can improve your sexual activity by prolonging erection for 4 hours. 
                            Generic Viagra helps to improve erection.".Split(' ');

            var result2 = classifier.Classify(new List<string>(example.Select(x => x.ToLower())));




            foreach (var x in result2)
            {
                Console.WriteLine("{0} => {1}", x.Key, x.Value);
            }

            Console.ReadKey();
        }
    }
}
