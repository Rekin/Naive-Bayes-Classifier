using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace UsageExampleWindows.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(Expression<Func<object>> property)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(GetPropertyName(property)));
        }

        private string GetPropertyName(Expression<Func<object>> property)
        {
            var unaryExpression = property.Body as UnaryExpression;
            var memberExpression = unaryExpression == null ? (MemberExpression)property.Body : (MemberExpression)unaryExpression.Operand;
            var propertyName = memberExpression.Member.Name;
            return propertyName;
        }
    }
}
