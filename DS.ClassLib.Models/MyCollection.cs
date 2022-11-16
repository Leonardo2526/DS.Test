using System.Collections.ObjectModel;

namespace DS.ClassLib.Models
{
    public class MyCollection : ObservableCollection<int>
    {
        public void Add(int Id)
        {
            this.Add(Id);
        }
    }
}
