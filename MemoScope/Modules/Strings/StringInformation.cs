using BrightIdeasSoftware;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MemoScope.Modules.Strings
{
    public class StringInformation 
    {
        public List<ulong> Addresses { get; }

        public StringInformation(string value, List<ulong> addresses)
        {
            Value = value;
            Addresses = addresses;
        }

        [OLVColumn(Width = 200, AspectToStringFormat = "{0:###,###,###,##0}", TextAlign = HorizontalAlignment.Right)]
        public int Count => Addresses.Count;

        [OLVColumn(Width =500)]
        public string Value { get; }
    }
}