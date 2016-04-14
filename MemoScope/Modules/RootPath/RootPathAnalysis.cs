using MemoScope.Core;
using MemoScope.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using System;

namespace MemoScope.Modules.RootPath
{
    public static class RootPathAnalysis
    {
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
            var roots = new HashSet<ulong>(clrDump.ClrRoots.Select(clrRoot => clrRoot.Object));
            var visitedInstances = new HashSet<ulong>();
            List<ulong> bestPath = null;
            var currentPath = new List<ulong>();
            currentPath.Add(address);
            visitedInstances.Add(address);
            bool result = FindShortestPath(currentPath, ref bestPath, roots, visitedInstances, clrDump);

            List<RootPathInformation> path = new List<RootPathInformation>();
            ulong prevAddress = address;
            if (bestPath != null)
            {
                foreach (var refAddress in bestPath)
                {
                    var refClrDumpObject = new ClrDumpObject(clrDump, clrDump.GetObjectType(refAddress), refAddress);
                    var fieldName = clrDump.GetFieldNameReference(prevAddress, refAddress);
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

        private static bool FindShortestPath(List<ulong> currentPath, ref List<ulong> bestPath, HashSet<ulong> roots, HashSet<ulong> visitedInstances, IClrDump clrDump)
        {
            if( bestPath != null && currentPath.Count >= bestPath.Count)
            {
                return false;
            }
            foreach(var refAddress in clrDump.EnumerateReferers(currentPath[currentPath.Count-1]))
            {
                if(visitedInstances.Contains(refAddress))
                {
                    continue;
                }
                visitedInstances.Add(refAddress);
                currentPath.Add(refAddress);
                if ( roots.Contains(refAddress))
                {
                    bestPath = new List<ulong>(currentPath);
                    return true;
                }

                bool res = FindShortestPath(currentPath, ref bestPath, roots, visitedInstances, clrDump);
                if( res)
                {
                    bestPath = new List<ulong>(currentPath);
                    return true;
                }
                else
                {
                    currentPath.RemoveAt(currentPath.Count - 1);
                }

            }

            return false;
        }
    }
}
