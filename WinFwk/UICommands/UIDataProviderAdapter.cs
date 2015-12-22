using System;

namespace WinFwk.UICommands
{

    public class UIDataProviderAdapter<T> : UIDataProvider<T>
    {
        private Func<T> dataProvider;

        public UIDataProviderAdapter(Func<T> dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public T Data
        {
            get
            {
                return dataProvider();
            }
        }
    }
}
