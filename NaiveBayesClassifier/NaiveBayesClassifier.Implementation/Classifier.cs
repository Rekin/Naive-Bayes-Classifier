/*
 *  @Author: Adam Wyrembelski
 *  @Data: 12.10.2012.
 *  @Project: NaiveBayesClassifier 
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace NaiveBayesClassifier.Implementation
{
    public class Classifier<TFeature>
    {
        private readonly Dictionary<string, double> _categoryProbability;
        private readonly Dictionary<string, List<TFeature>> _featuresOfCategory;
        private List<InformationModel<TFeature>> _rawTrainingData;


        public Classifier()
        {
            _categoryProbability = new Dictionary<string, double>();
            _featuresOfCategory = new Dictionary<string, List<TFeature>>();
            _rawTrainingData = new List<InformationModel<TFeature>>();
        }

        public Dictionary<string,double> Classify(List<TFeature> objectFeatures)
        {
            if (objectFeatures == null)
                throw new ArgumentNullException();

            if (_featuresOfCategory.Count <= 0)
                throw new ArgumentException("Classifier has not been trained. First use Teach method.");


            foreach (var item in _featuresOfCategory)
            {
                _categoryProbability.Add(item.Key,CalculateProbability(item.Key,objectFeatures));
            }

            return _categoryProbability;
        }

        public void Teach(List<InformationModel<TFeature>> objList)
        {
            if (objList == null)
                throw new ArgumentNullException();

            _rawTrainingData = objList;

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
        /// Calculate probability for current lable.
        /// </summary>
        /// <param name="label">Label</param>
        /// <param name="features">Features of object</param>
        /// <returns></returns>
        private double CalculateProbability(string label, IEnumerable<TFeature> features)
        {
            if(string.IsNullOrEmpty(label))
                throw new ArgumentException("Empty lable");

            if(features==null)
                throw new ArgumentNullException();


            //P(d) = ilosc_wystapien_danej_kategorii/ilosc_wszystkich_pozycji_na_liscie_treningowej
            //P(v1|d) = ilosc_wystepowania_cechy_v1/ilosc_wystepowania_danej_kategorii_w_danych_treningowych

            var currentLableSetCount = _rawTrainingData.Count(x => x.Lable==label);
            double labelProbability = currentLableSetCount/ Convert.ToDouble(_rawTrainingData.Count);

            var objFeaturesProb = new List<double>();

            foreach (var feature in features)
            {
                //takes all features occurency from Dictionary which contain feature from training data.
                var featureOccurency = _featuresOfCategory[label].FindAll(p => p.Equals(feature)).Count;
                //calculate a posteriori probability and add it to collection
                var featurePosterioriProb = featureOccurency / Convert.ToDouble(currentLableSetCount);
                //objFeaturesProp.Add(!featurePosterioriProb.Equals(0) ? featurePosterioriProb : 1);
                if(!featurePosterioriProb.Equals(0)) objFeaturesProb.Add(featurePosterioriProb);
            }

            double result = objFeaturesProb.Aggregate(1.0, (current, item) => current*item) * labelProbability;

            return result;
        }


    }
}
