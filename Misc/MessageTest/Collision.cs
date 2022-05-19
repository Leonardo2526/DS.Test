using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.MessageTest
{
    public class ClsnInfo
    {
        public int ClsnNumber;
        public int MECCurve1Id;
        public int MECCurve2Id;
        public bool IsResolved;

        public ClsnInfo(int collisionNumber, int mECCurve1Id, int mECCurve2Id)
        {
            ClsnNumber = collisionNumber;
            MECCurve1Id = mECCurve1Id;
            MECCurve2Id = mECCurve2Id;
        }
    }
}
