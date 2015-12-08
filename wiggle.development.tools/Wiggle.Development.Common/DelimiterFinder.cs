using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiggle.Development.Common
{
    public class DelimiterFinder
    {
        public IEnumerable<string> GetDelimiters(string text)
        {
            if (text == null)
            {
                return new List<string>();
            }

            var delimetedText = text.Split(new string[] { @"##" }, StringSplitOptions.None);

            bool isInDelimiter = false;
            var result = new List<string>();
            foreach (var fragment in delimetedText)
            {
                if (isInDelimiter)
                {
                    if (!result.Contains(fragment))
                    {
                        result.Add(fragment);
                    }
                }

                isInDelimiter = !isInDelimiter;
            }

            return result;
        } 
    }
}
