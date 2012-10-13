using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveBayesClassifier.Implementation
{
    public class InformationModel<TFeature>
    {
        public string Lable { get; set; }
        public List<TFeature> Features { get; set; }
    }
}
