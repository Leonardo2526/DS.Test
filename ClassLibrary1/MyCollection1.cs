using System.Collections.ObjectModel;

namespace ClassLibrary1
{
    public class MyCollection1 : ObservableCollection<ObjectModel1>
    {
        public void AddItem(string name)
        {
            this.Add(new ObjectModel1 { Name = name });
        }
    }
}
