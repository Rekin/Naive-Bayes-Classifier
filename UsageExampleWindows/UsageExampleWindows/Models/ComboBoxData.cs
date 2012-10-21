using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsageExampleWindows.Models
{
    public class ComboBoxData
    {
        public List<string> Colors
        {
            get { return new List<string>() {"Red", "Yellow"}; }
        }
        public List<string> Types
        {
            get { return new List<string>() { "SUV", "Sports" }; }
        }
        public List<string> Origins
        {
            get { return new List<string>() { "Domestic", "Imported" }; }
        }
    }
}
