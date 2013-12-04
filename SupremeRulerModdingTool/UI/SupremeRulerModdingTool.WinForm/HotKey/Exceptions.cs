using System;
using System.Runtime.Serialization;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm.HotKey
{

    #region **Exceptions

    [Serializable]
    public class HotKeyAlreadyRegisteredException : Exception
    {
        public HotKeyAlreadyRegisteredException(string message, GlobalHotKey hotKey) : base(message)
        {
            HotKey = hotKey;
        }

        public HotKeyAlreadyRegisteredException(string message, GlobalHotKey hotKey, Exception inner)
            : base(message, inner)
        {
            HotKey = hotKey;
        }

        public HotKeyAlreadyRegisteredException(string message, LocalHotKey hotKey) : base(message)
        {
            LocalKey = hotKey;
        }

        public HotKeyAlreadyRegisteredException(string message, LocalHotKey hotKey, Exception inner)
            : base(message, inner)
        {
            LocalKey = hotKey;
        }

        public HotKeyAlreadyRegisteredException(string message, ChordHotKey hotKey) : base(message)
        {
            ChordKey = hotKey;
        }

        public HotKeyAlreadyRegisteredException(string message, ChordHotKey hotKey, Exception inner)
            : base(message, inner)
        {
            ChordKey = hotKey;
        }

        protected HotKeyAlreadyRegisteredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public GlobalHotKey HotKey { get; private set; }
        public LocalHotKey LocalKey { get; private set; }
        public ChordHotKey ChordKey { get; private set; }
    }

    [Serializable]
    public class HotKeyUnregistrationFailedException : Exception
    {
        public HotKeyUnregistrationFailedException(string message, GlobalHotKey hotKey) : base(message)
        {
            HotKey = hotKey;
        }

        public HotKeyUnregistrationFailedException(string message, GlobalHotKey hotKey, Exception inner)
            : base(message, inner)
        {
            HotKey = hotKey;
        }

        protected HotKeyUnregistrationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public GlobalHotKey HotKey { get; private set; }
    }

    [Serializable]
    public class HotKeyRegistrationFailedException : Exception
    {
        public HotKeyRegistrationFailedException(string message, GlobalHotKey hotKey) : base(message)
        {
            HotKey = hotKey;
        }

        public HotKeyRegistrationFailedException(string message, GlobalHotKey hotKey, Exception inner)
            : base(message, inner)
        {
            HotKey = hotKey;
        }

        protected HotKeyRegistrationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public GlobalHotKey HotKey { get; private set; }
    }

    [Serializable]
    public class HotKeyInvalidNameException : Exception
    {
        public HotKeyInvalidNameException(string message) : base(message)
        {
        }

        public HotKeyInvalidNameException(string message, Exception inner) : base(message, inner)
        {
        }

        protected HotKeyInvalidNameException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    #endregion
}