using System;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm.HotKey
{
    public class GlobalHotKeyEventArgs : EventArgs
    {
        //public string Name { get { return HotKey.Name; } }
        //public Keys Key { get { return HotKey.Key; } set { HotKey.Key = value; } }
        //public Modifiers Modifier { get { return HotKey.Modifier; } set { HotKey.Modifier = value; } }
        //public string FullInfo() { return HotKey.FullInfo(); }
        //public object Tag { get { return HotKey.Tag; } set { HotKey.Tag = value; } }
        //public int Id { get { return HotKey.Id; } }
        //public bool Enabled { get { return HotKey.Enabled; } set { HotKey.Enabled = value; } }

        public GlobalHotKeyEventArgs(GlobalHotKey hotKey)
        {
            HotKey = hotKey;
        }

        public GlobalHotKey HotKey { get; private set; }
    }

    public class LocalHotKeyEventArgs : EventArgs
    {
        public LocalHotKeyEventArgs(LocalHotKey hotKey)
        {
            HotKey = hotKey;
        }

        public LocalHotKey HotKey { get; private set; }
    }

    public class PreChordHotKeyEventArgs : EventArgs
    {
        private readonly LocalHotKey HotKey;

        public PreChordHotKeyEventArgs(LocalHotKey hotkey)
        {
            HotKey = hotkey;
        }

        ///// <summary>The name of the chord that raised this event.
        ///// </summary>
        //public string Name { get { return HotKey.Name; } }
        /// <summary>
        ///     The base key of the chord that raised this event.
        /// </summary>
        public Keys BaseKey
        {
            get { return HotKey.Key; }
        }

        /// <summary>
        ///     The base modifier of the chord that raised this event.
        /// </summary>
        public Modifiers BaseModifier
        {
            get { return HotKey.Modifier; }
        }

        /// <summary>
        ///     Gets or sets if the chord event should be handled.
        /// </summary>
        public bool HandleChord { get; set; }

        /// <summary>
        ///     Displays information about
        /// </summary>
        public override string ToString()
        {
            return Info();
        }

        /// <summary>
        ///     Displays the Modifier and key in extended format.
        /// </summary>
        /// <returns>The key and modifier in string.</returns>
        public string Info()
        {
            string info = "";
            foreach (Modifiers mod in new HotKeyShared.ParseModifier((int) BaseModifier))
            {
                info += mod + " + ";
            }

            info += BaseKey.ToString();
            return info;
        }
    }

    public class ChordHotKeyEventArgs : EventArgs
    {
        public ChordHotKeyEventArgs(ChordHotKey hotkey)
        {
            HotKey = hotkey;
        }

        /// <summary>
        ///     The HotKey that raised this event.
        /// </summary>
        public ChordHotKey HotKey { get; private set; }
    }

    public class HotKeyIsSetEventArgs : EventArgs
    {
        public HotKeyIsSetEventArgs(Keys key, Modifiers modifier)
        {
            UserKey = key;
            UserModifier = modifier;
        }

        public Keys UserKey { get; private set; }
        public Modifiers UserModifier { get; private set; }
        public bool Cancel { get; set; }

        public string Shortcut
        {
            get { return HotKeyShared.CombineShortcut(UserModifier, UserKey); }
        }
    }

    public class HotKeyEventArgs : EventArgs
    {
        public HotKeyEventArgs(Keys key, Modifiers modifier, RaiseLocalEvent KeyPressevent)
        {
            Key = key;
            Modifier = modifier;
            KeyPressEvent = KeyPressevent;
        }

        public Keys Key { get; private set; }
        public Modifiers Modifier { get; private set; }
        public RaiseLocalEvent KeyPressEvent { get; private set; }
    }

    public class KeyboardHookEventArgs : EventArgs
    {
        public enum modifiers
        {
            /// <summary>
            ///     Specifies that no modifier key is pressed.
            /// </summary>
            None,

            /// <summary>
            ///     Specifies that only the Shift key is pressed.
            /// </summary>
            Shift,

            /// <summary>
            ///     Specifies that only the Control key is pressed.
            /// </summary>
            Control,

            /// <summary>
            ///     Specifies that only the Alt key is pressed.
            /// </summary>
            Alt,

            /// <summary>
            ///     Specifies that the Shift and Control key are pressed.
            /// </summary>
            ShiftControl,

            /// <summary>
            ///     Specifies that the Shift and Alt key are pressed.
            /// </summary>
            ShiftAlt,

            /// <summary>
            ///     Specifies that the Control and Alt key are pressed.
            /// </summary>
            ControlAlt,

            /// <summary>
            ///     Specifies that the Shift, Control and Alt key are pressed.
            /// </summary>
            ShiftControlAlt
        }

        private bool handled;
        private KeyboardHookStruct lParam;

        public KeyboardHookEventArgs(KeyboardHookStruct lparam)
        {
            LParam = lparam;
        }

        private KeyboardHookStruct LParam
        {
            get { return lParam; }
            set
            {
                lParam = value;
                uint nonVirtual = Win32.MapVirtualKey((uint) VirtualKeyCode, 2);
                Char = Convert.ToChar(nonVirtual);
            }
        }

        /// <summary>
        ///     The ASCII code of the key pressed.
        /// </summary>
        public int VirtualKeyCode
        {
            get { return LParam.VirtualKeyCode; }
        }

        /// <summary>
        ///     The Key pressed.
        /// </summary>
        public Keys Key
        {
            get { return (Keys) VirtualKeyCode; }
        }

        public char Char { get; private set; }

        public string KeyString
        {
            get
            {
                if (Char == '\0')
                {
                    return Key == Keys.Return ? "[Enter]" : string.Format("[{0}]", Key);
                }
                if (Char == '\r')
                {
                    Char = '\0';
                    return "[Enter]";
                }
                if (Char == '\b')
                {
                    Char = '\0';
                    return "[Backspace]";
                }
                return Char.ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        ///     Specifies if this key should be processed  by other windows.
        /// </summary>
        public bool Handled
        {
            get { return handled; }
            set
            {
                //Because a key cannot be handled when it is already up, we'll ignore this.
                if (KeyboardEventName != KeyboardEventNames.KeyUp)
                    handled = value;
            }
        }

        /// <summary>
        ///     The event that raised this 'event' Whether KeyUp or KeyDown.
        /// </summary>
        public KeyboardEventNames KeyboardEventName { get; internal set; }

        /// <summary>
        ///     Gets the modifier that is pressed when this event was raised.
        /// </summary>
        public modifiers Modifier
        {
            get
            {
                var KeyBoard = new Keyboard();
                if (KeyBoard.AltKeyDown && KeyBoard.CtrlKeyDown && KeyBoard.ShiftKeyDown)
                    return modifiers.ShiftControlAlt;
                if (KeyBoard.AltKeyDown && KeyBoard.CtrlKeyDown && !KeyBoard.ShiftKeyDown)
                    return modifiers.ControlAlt;
                if (KeyBoard.AltKeyDown && !KeyBoard.CtrlKeyDown && KeyBoard.ShiftKeyDown)
                    return modifiers.ShiftAlt;
                if (!KeyBoard.AltKeyDown && KeyBoard.CtrlKeyDown && KeyBoard.ShiftKeyDown)
                    return modifiers.ShiftControl;
                if (!KeyBoard.AltKeyDown && !KeyBoard.CtrlKeyDown && KeyBoard.ShiftKeyDown)
                    return modifiers.Shift;
                if (KeyBoard.AltKeyDown && !KeyBoard.CtrlKeyDown && !KeyBoard.ShiftKeyDown)
                    return modifiers.Alt;
                if (!KeyBoard.AltKeyDown && KeyBoard.CtrlKeyDown && !KeyBoard.ShiftKeyDown)
                    return modifiers.Control;
                return modifiers.None;
            }
        }

        public int Time
        {
            get { return lParam.Time; }
        }
    }
}