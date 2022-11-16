using System.Collections.ObjectModel;

namespace DS.RVT.ExtCmd.FW4._8.MVVM1
{
    public class NamesCollection : ObservableCollection<MyObject>
    {
        public void Add(string name)
        {
            this.Add(new MyObject { Name = name });
        }
    }
}
