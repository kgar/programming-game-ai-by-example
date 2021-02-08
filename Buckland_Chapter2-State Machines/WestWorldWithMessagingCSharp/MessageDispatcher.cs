using System;
using System.Collections.Generic;
using System.Linq;
using SharedLibraries;

namespace WestWorldWithMessaging
{
    public static class MessageDispatcher
    {
        private static readonly SortedSet<Telegram> MessageQueue = new(new TelegramComparer());

        public static void DispatchDelayedMessages()
        {
            var now = DateTime.Now;

            while (MessageQueue.Count > 0 && MessageQueue.Min.DispatchTime <= now)
            {
                var telegram = MessageQueue.First();
                Console.WriteLine($"Queued telegram ready for dispatch: Sent to {EntityFunctions.GetNameOfEntity(telegram.Receiver)}. Message is {telegram.Message}");
                var receiverEntity = EntityManager.GetEntityFromName(telegram.Receiver);
                Discharge(receiverEntity, telegram);
                MessageQueue.Remove(telegram);
            }
        }

        public static void DispatchMessage(TimeSpan delay, EntityName sender, EntityName receiver, MessageType message, object extraInfo = null)
        {
            var receiverEntity = EntityManager.GetEntityFromName(receiver);

            if (receiverEntity == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Warning! No receiver with ID of {receiver} found");
                Console.ResetColor();
            }

            var telegram = new Telegram
            {
                Sender = sender,
                Receiver = receiver,
                Message = message,
                ExtraInfo = extraInfo,
                DispatchTime = DateTime.Now.Add(delay)
            };

            if (delay <= TimeSpan.Zero)
            {
                Console.WriteLine($"Instant telegram dispatched at time {DateTime.Now} by {EntityFunctions.GetNameOfEntity(sender)} for {EntityFunctions.GetNameOfEntity(receiver)}. Message is {message}");
                Discharge(receiverEntity, telegram);
                return;
            }

            Console.WriteLine($"Delayed telegram from {EntityFunctions.GetNameOfEntity(telegram.Sender)} recorded at time {DateTime.Now} for {EntityFunctions.GetNameOfEntity(telegram.Receiver)}. Message is {telegram.Message}");
            MessageQueue.Add(telegram);
        }

        public static void Discharge(BaseGameEntity receiver, Telegram telegram)
        {
            if (!receiver.HandleMessage(telegram))
            {
                System.Console.WriteLine("Message not handled.");
            }
        }
    }
}