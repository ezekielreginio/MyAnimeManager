using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public class AccessTypeEventArgs
    {
        public enum AccessType
        {
            Read, 
            Add,
            Delete,
            Update
        }

        private AccessType _accessType;
    }
}
