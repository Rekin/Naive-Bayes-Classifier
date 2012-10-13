using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace NaiveBayesClassifier.Implementation
{
    public class Classifier<TFeature>
    {
        private readonly Dictionary<string, double> _categoryPropability;
        private readonly Dictionary<string, List<TFeature>> _featuresOfCategory;
        private List<InformationModel<TFeature>> _rawData;


        public Classifier()
        {
            _categoryPropability = new Dictionary<string, double>();
            _featuresOfCategory = new Dictionary<string, List<TFeature>>();
            _rawData = new List<InformationModel<TFeature>>();
        }

        public Dictionary<string,double> Classify(List<TFeature> objectFeatures)
        {
            if (objectFeatures == null)
                throw new ArgumentNullException();

            if (_featuresOfCategory.Count <= 0)
                throw new ArgumentException("Classifier has not been trained. First use Teach method from Classifier class.");


            foreach (var item in _featuresOfCategory)
            {
                _categoryPropability.Add(item.Key,CalculatePropabilityForLabel(item.Key,objectFeatures));
            }

            return _categoryPropability;
        }

        public void Teach(List<InformationModel<TFeature>> objList)
        {
            if (objList == null)
                throw new ArgumentNullException();

            _rawData = objList;

            foreach (var model in objList)
            {
                if (!_featuresOfCategory.ContainsKey(model.Lable))
                {
                    _featuresOfCategory.Add(model.Lable, model.Features);
                }
                else
                {
                    _featuresOfCategory[model.Lable].AddRange(model.Features);
                }
            }

        }

        /// <summary>
        /// Calculate propability for current lable.
        /// </summary>
        /// <param name="label">Label</param>
        /// <param name="features">Features of object</param>
        /// <returns></returns>
        private double CalculatePropabilityForLabel(string label, List<TFeature> features)
        {
            if(string.IsNullOrEmpty(label))
                throw new ArgumentException("Empty lable");

            if(features==null)
                throw new ArgumentNullException();


            //P(d) = ilosc_wystapien_danej_kategorii/ilosc_wszystkich_pozycji_na_liscie_treningowej
            //P(v1|d) = ilosc_wystepowania_cechy_v1/ilosc_wystepowania_danej_kategorii_w_danych_treningowych

            var currentLableSet = _rawData.Where(x=>x.Lable==label).ToList();
            double labelPropability = currentLableSet.Count() / Convert.ToDouble(_rawData.Count);

            var objFeaturesProp = new List<double>();

            foreach (var feature in features)
            {
                //takes all features occurency from Dictionary which contain all features from training data.
                var featureOccurency = _featuresOfCategory[label].FindAll(p => p.Equals(feature)).Count;

                //calculate a posteriori propability and add it to collection
                var featurePosterioriProp = featureOccurency / Convert.ToDouble(currentLableSet.Count);
                //objFeaturesProp.Add(!featurePosterioriProp.Equals(0) ? featurePosterioriProp : 1);
                if(!featurePosterioriProp.Equals(0)) objFeaturesProp.Add(featurePosterioriProp);
            }

            double result = objFeaturesProp.Aggregate(1.0, (current, item) => current*item);

            return result*labelPropability;
        }


    }
}
