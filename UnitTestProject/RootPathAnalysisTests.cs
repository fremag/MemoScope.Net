using MemoScope.Core;
using MemoScope.Modules.RootPath;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestFixture]
    public class RootPathAnalysisTests
    {
        MockClrDump clrDump;
        List<ulong> currentPath;
        List<ulong> shortestPath;

        [SetUp]
        public void SetUp()
        {
            clrDump = new MockClrDump();
            currentPath = new List<ulong>();
            shortestPath = null;
        }

        [Test]
        public void RootPathAnalysisTest_1()
        {
            clrDump.Add(1, 2, 3 );
            ulong[] shortestPath = new ulong[] { 1, 2 };
            Run(1, shortestPath );
        }

        [Test]
        public void RootPathAnalysisTest_2()
        {
            /* 
                1 
                |_ 2 
                   |_ 4
                      |_ 5
                |_ 3
            */

            clrDump.Add(1, 2, 3 );
            clrDump.Add(2, 4 );
            clrDump.Add(4, 5 );

            ulong[] shortestPath = new ulong[] { 1, 3};
            Run(1, shortestPath);
        }

        [Test]
        public void RootPathAnalysisTest_3()
        {
            /* 
                1 
                |_ 2 
                   |_ 4
                      |_ 5
                |_ 3
                    |_ 6
                |_ 7
                    |_ 8
            */

            clrDump.Add(1, 2, 3, 7);
            clrDump.Add(2, 4);
            clrDump.Add(4, 5);
            clrDump.Add(3, 6);
            clrDump.Add(4, 5);
            clrDump.Add(7, 8);

            ulong[] shortestPath = new ulong[] { 1, 7, 8 };
            Run(1, shortestPath);
        }

        [Test]
        public void RootPathAnalysisTest_4()
        {
            /* 
                1 
                |_ 7
                    |_ 8
                |_ 2 
                   |_ 4
                      |_ 5
                |_ 3
                    |_ 6
            */

            clrDump.Add(1, 2, 3, 7);
            clrDump.Add(7, 8);
            clrDump.Add(2, 4);
            clrDump.Add(4, 5);
            clrDump.Add(3, 6);
            clrDump.Add(4, 5);

            ulong[] shortestPath = new ulong[] { 1, 7, 8};
            Run(1, shortestPath);
        }

        [Test]
        public void RootPathAnalysisTest_5()
        {
            /* 
                1 
            */

            ulong[] shortestPath = null;
            Run(1, shortestPath, false);
        }

        [Test]
        public void RootPathAnalysisTest_6()
        {
            /* 
                1 
                |_ 2
                   |_ 1
                   |_ 2
                   |_ 3
            */
            clrDump.Add(1, 2);
            clrDump.Add(2, 1);
            clrDump.Add(2, 2);
            clrDump.Add(2, 3);

            ulong[] shortestPath = new ulong[] { 1, 2, 3 };
            Run(1, shortestPath);
        }

        [Test]
        public void RootPathAnalysisTest_7()
        {
            /* 
                1 
                |_ 2
                   |_ 3
                      |_ 4
                |_ 3
                   |_ 4
            */
            clrDump.Add(1, 2, 3);
            clrDump.Add(2, 3);
            clrDump.Add(3, 4);

            ulong[] shortestPath = new ulong[] { 1, 3, 4 };
            Run(1, shortestPath);
        }

        private void Run(ulong address, ulong[] expectedPath, bool result=true)
        {
            currentPath.Add(address);
            var res = RootPathAnalysis.FindShortestPath(currentPath, ref shortestPath, clrDump);
            Assert.That(res, Is.EqualTo(result));
            Assert.That(shortestPath, Is.EqualTo(expectedPath));
        }

        private HashSet<ulong> BuildRoots(ulong[] v)
        {
            var roots = new HashSet<ulong>();
            foreach(var address in v)
            {
                roots.Add(address);
            }
            return roots;
        }


#if False
        [Test]
        public void RootPathAnalysisTest_xxx()
        {
            clrDump.Add(1, new ulong[] { x, y });
            ulong[] roots = new ulong[] { x };
            ulong[] shortestPath = new ulong[] { z, t };
            Run(w, roots, shortestPath );
        }
#endif
    }

    public class MockClrDump : IClrDump
    {
        public void Add(ulong address, params ulong[] referers)
        {
            this.referers[address] = referers;
        }
        Dictionary<ulong, ulong[]> referers = new Dictionary<ulong, ulong[]>();
        public IEnumerable<ulong> EnumerateReferers(ulong address)
        {
            ulong[] refs;
            if( referers.TryGetValue(address, out refs))
            {
                return refs;
            }
            return new ulong[0];
        }

        public bool HasReferers(ulong address)
        {
            return referers.ContainsKey(address);
        }
    }
}
