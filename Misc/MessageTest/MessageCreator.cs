using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    internal abstract class MessageCreator
    {
        public List<Message> CreatedMessages { get; set; } = new List<Message>();
        public Dictionary<SubType, int> SubTypes { get; set; } = new Dictionary<SubType, int>();

        //Factory methos
        public abstract Message Create(string text, SubType subType);

        public MessageCreator()
        {
            foreach (var item in Enum.GetValues(typeof(SubType)))
            {               
                SubTypes.Add((SubType)item, 0);
            }
        }
    }
}
