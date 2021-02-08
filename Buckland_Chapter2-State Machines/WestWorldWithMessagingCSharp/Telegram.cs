using System;
using System.Collections.Generic;

namespace WestWorldWithMessaging
{
    public static class TelegramConstants
    {
        public static readonly TimeSpan SmallestDelay = TimeSpan.FromMilliseconds(250);
    }

    public record Telegram()
    {
        public EntityName Sender { get; init; }
        public EntityName Receiver { get; init; }
        public MessageType Message { get; init; }
        public object ExtraInfo { get; init; }
        public DateTime DispatchTime { get; init; }
    }

    public class TelegramComparer : IComparer<Telegram>
    {
        public int Compare(Telegram x, Telegram y)
        {
            return Equals(x, y)
                ? 0
                : x.DispatchTime > y.DispatchTime
                ? 1
                : -1;
        }

        private static bool Equals(Telegram x, Telegram y)
        {
            return
                x.DispatchTime - y.DispatchTime < TelegramConstants.SmallestDelay &&
                x.Sender == y.Sender &&
                x.Receiver == y.Receiver &&
                x.Message == y.Message;
        }
    }
}

