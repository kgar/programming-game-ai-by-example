using System;
using SharedLibraries;

namespace WestWorldWithMessaging
{
    internal static class MessageDispatcher
    {
        private static readonly PriorityQueue<Telegram> messageQueue = new PriorityQueue<Telegram>();

        internal static void DispatchDelayedMessages()
        {
            // TODO: DISPATCH . THEM . MESSAGES
        }

        internal static void Discharge(BaseGameEntity receiver, Telegram message)
        {
            // TODO: Implement me
        }
    }
}