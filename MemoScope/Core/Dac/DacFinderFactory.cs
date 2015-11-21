using System;

namespace MemoScope.Core.Dac
{
    public static class DacFinderFactory
    {
        public static AbstractDacFinder CreateDactFinder(string localCache)
        {
            if (Environment.Is64BitProcess)
            {
                return new DacFinder64(localCache);
            }
            return new DacFinder32(localCache);
        }
    }
}