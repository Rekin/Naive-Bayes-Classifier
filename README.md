Naive-Bayes-Classifier
======================

Simple implementation of Naive Bayes Classifier in C# (.NET 4.0).

How to use? 

1. Make new instance of Classifier object.
2. Get some training data and convert it to list of InformationModel.
3. Train classifier (use Teach method).
4. And finally use Classify method. As a result you will receive a Dictionary<string,double> (propability of belonging classified object to each category).



