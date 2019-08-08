using System;
using MediatR;

namespace NerdStore.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime TimesTemp { get; private set; }

        public Event()
        {
            TimesTemp = DateTime.Now;
        }
    }
}