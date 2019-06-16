using BrightIdeasSoftware;
using System.Collections.Generic;
using WinFwk.UITools;

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

        [IntColumn(Width = 200)]
        public int Count => Addresses.Count;

        [OLVColumn(Width =500)]
        public string Value { get; }

        [IntColumn(Width = 300, AspectToStringFormat = "{0:###,###,###,##0}")]
        public int Bytes => Value.Length * Count;


        [IntColumn(Width = 300, AspectToStringFormat = "{0:###,###,###,##0}")]
        public int Length => Value.Length;
    }
}