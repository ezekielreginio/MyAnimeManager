using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public class EventHelpers
    {
        public static void RaiseEvent(Object objectRaisingEvent, EventHandler<AccessTypeEventArgs> eventHandlerRaised, AccessTypeEventArgs accessTypeEventArgs)
        {
            if (objectRaisingEvent != null) //Check if any subscribed to this event
                eventHandlerRaised(objectRaisingEvent, accessTypeEventArgs); //Notify all subscribers
        }

        public static void RaiseEvent(Object objectRaisingEvent, EventHandler eventHandlerRaised, EventArgs eventArgs)
        {
            if (eventHandlerRaised != null) //Check if any subscribed to this event
                eventHandlerRaised(objectRaisingEvent, eventArgs); //Notify all subscribers
        }

        public static void RaiseEvent(Object objectRaisingEvent, EventHandler eventHandlerRaised, _WMPOCXEvents_CurrentItemChangeEvent eventArgs)
        {
            if (eventHandlerRaised != null) //Check if any subscribed to this event
                eventHandlerRaised(objectRaisingEvent, null); //Notify all subscribers
        }

    }
}
