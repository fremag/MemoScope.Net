using MemoScope.Core;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace MemoScope.Modules.RootPath
{
    public static class RootPathAnalysis
    {
        static Logger logger = LogManager.GetLogger(typeof(RootPathAnalysis).FullName);

        public static List<RootPathInformation> AnalyzeRootPath(MessageBus msgBus, ClrDumpObject clrDumpObject)
        {
            ClrDump clrDump = clrDumpObject.ClrDump;
            ulong address = clrDumpObject.Address;
            CancellationTokenSource token = new CancellationTokenSource();
            msgBus.BeginTask("Analysing Root Path...", token);
            if( token.IsCancellationRequested)
            {
                msgBus.EndTask("Root Path analysis: cancelled.");
                return null;
            }

            msgBus.Status("Analysing Root Path: collecting root instances...");
            var roots = new HashSet<ulong>(clrDump.EnumerateClrRoots.Select(clrRoot => clrRoot.Object));
            if (logger.IsDebugEnabled)
            {
                logger.Debug("Roots: " + Str(roots));
            }
            List<ulong> bestPath = null;
            var currentPath = new List<ulong>();
            currentPath.Add(address);
            bool result = FindShortestPath(currentPath, ref bestPath, clrDump);

            List<RootPathInformation> path = new List<RootPathInformation>();
            ulong prevAddress = address;
            if (bestPath != null)
            {
                foreach (var refAddress in bestPath)
                {
                    var refClrDumpObject = new ClrDumpObject(clrDump, clrDump.GetObjectType(refAddress), refAddress);
                    var fieldName = refAddress == address ? " - " : clrDump.GetFieldNameReference(prevAddress, refAddress);
                    fieldName = TypeHelpers.RealName(fieldName);
                    path.Add(new RootPathInformation(refClrDumpObject, fieldName));
                    prevAddress = refAddress;
                }
                msgBus.EndTask("Root Path found.");
            }
            else
            {
                msgBus.EndTask("Root Path NOT found.");
            }
            return path;
        }

        public static bool FindShortestPath(List<ulong> currentPath, ref List<ulong> bestPath, IClrDump clrDump)
        {
            if(logger.IsDebugEnabled) logger.Debug("FindShortestPath: currentPath: " + Str(currentPath)+", best: "+Str(bestPath));
            if( bestPath != null && currentPath.Count >= bestPath.Count)
            {
                return false;
            }
            bool res = false;
            foreach (var refAddress in clrDump.EnumerateReferers(currentPath[currentPath.Count-1]))
            {
                if(currentPath.Contains(refAddress))
                {
                    continue;
                }
                if (logger.IsDebugEnabled) logger.Debug($"Visiting: {refAddress:X}");
                currentPath.Add(refAddress);
                if (! clrDump.HasReferers(refAddress))
                {
                    bestPath = new List<ulong>(currentPath);
                    if (logger.IsDebugEnabled) logger.Debug("Root found !, best path: "+Str(bestPath));
                    currentPath.RemoveAt(currentPath.Count - 1);
                    return true;
                }

                res |= FindShortestPath(currentPath, ref bestPath, clrDump);
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            return res;
        }

        private static string Str(IEnumerable<ulong> ulongEnum)
        {
            if ( ulongEnum == null || ! ulongEnum.Any()) 
            {
                return "[]";
            }
            var s = "[";
            int n = 0;
            foreach(var u in ulongEnum)
            {
                s += u.ToString("X") + ", ";
                if( ++n % 128 == 0)
                {
                    s += "..., ";
                    break;
                }
            }
            return s.Substring(0, s.Length-2)+"]";
        }
    }
}
