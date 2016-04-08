using MemoScope.Core;
using MemoScope.Core.Data;
using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace MemoScope.Modules.Referers
{
    public static class ReferersAnalysis
    {
        public static bool HasReferers(MessageBus msgBus, ClrDump clrDump, IEnumerable<ulong> addresses)
        {
            foreach(ulong address in addresses) { 
                if (clrDump.HasReferers(address))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<ReferersInformation> AnalyzeReferers(MessageBus msgBus, ClrDump clrDump, HashSet<ulong> addresses)
        {
            var referers = new List<ReferersInformation>();
            var dico = new Dictionary<ClrType, Dictionary<string, ReferersInformation>>();
            CancellationTokenSource token = new CancellationTokenSource();
            msgBus.BeginTask("Analyzing referers...", token);
            Application.DoEvents(); // todo: avoid this call to Application.DoEvents()
            int count = addresses.Count;
            int i = 0;
            foreach(var address in addresses)
            {
                i++;
                if( token.IsCancellationRequested)
                {
                    msgBus.EndTask("Referers analyze: cancelled.");
                    return referers;
                }
                if ( i % 1024 == 0)
                {
                    msgBus.Status($"Analyzing referers: {(double)i/count:p2}, {i:###,###,###,##0} / {count:###,###,###,##0}...");
                    Application.DoEvents();// todo: avoid this call to Application.DoEvents()
                }
                foreach( var refererAddress in clrDump.EnumerateReferers(address))
                {
                    var type = clrDump.GetObjectType(refererAddress);
                    string field;
                    if (type.IsArray)
                    {
                        field = "[ * ]";
                    }
                    else
                    {
                        field = clrDump.GetFieldNameReference(address, refererAddress);
                    }
                    Dictionary<string, ReferersInformation> toto;
                    if( ! dico.TryGetValue(type, out toto))
                    {
                        toto = new Dictionary<string, ReferersInformation>();
                        dico[type] = toto;
                    }

                    ReferersInformation referersInformation;
                    if ( ! toto.TryGetValue(field, out referersInformation))
                    {
                        referersInformation = new ReferersInformation(clrDump, type, field, msgBus);
                        toto[field] = referersInformation;
                    }

                    referersInformation.References.Add(address);
                    referersInformation.Instances.Add(refererAddress);
                }
            }

            foreach(var kvpType in dico)
            {
                var type = kvpType.Key;
                foreach(var kvpField in kvpType.Value)
                {
                    var refInfo = kvpField.Value;
                    referers.Add(refInfo);
                    refInfo.Init();
                }
            }
            msgBus.EndTask("Referers analyzed.");
            Application.DoEvents();// todo: avoid this call to Application.DoEvents()
            return referers;
        }
    }
}
