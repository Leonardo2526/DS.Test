using System.Collections.ObjectModel;

namespace DS.ClassLib.Models
{
    public class ClassModel
    {
        //public static ObservableCollection<int> Collection { get; set; } = new ObservableCollection<int>();
        public MyCollection MyCollection { get; set; } = new MyCollection();

        public void AddItem()
        {
            MyCollection.Add(1);
        }

        //public static void AddItems()
        //{
        //    Collection.Add(3);
        //    Collection.Add(5);
        //    Collection.Add(7);
        //}
    }
}