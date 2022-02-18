using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MouseHolder
{
    /// <summary>
    /// handles the HotKey
    /// </summary>
    public sealed  class KeyboardHook : IDisposable {
        //DllImports to handle the register and unregister
        #region DLL
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion

        private class Window : NativeWindow, IDisposable {
            private static int WM_HOTKEY = 0x0312;

            public Window() {
                this.CreateHandle(new CreateParams());
            }

            protected override void WndProc(ref Message m) {
                base.WndProc(ref m);

                if (m.Msg == WM_HOTKEY) {
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                    if (KeyPressed != null)
                        KeyPressed(this, new KeyPressedEventArgs(modifier, key));
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            public void Dispose() {
                this.DestroyHandle();
            }
        }

        private Window _window = new Window();
        private int _currentId = 1;

        public KeyboardHook() {
            _window.KeyPressed += delegate(object sender, KeyPressedEventArgs args) {
                if (KeyPressed != null)
                    KeyPressed(this, args);
            };
        }
        
        //Unregister the current HotKey and register the new one
        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            UnregisterHotKey(_window.Handle, _currentId);

            if (!RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hot key.");
        }

        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose() {
            UnregisterHotKey(_window.Handle, _currentId);
            _window.Dispose();
        }

        #endregion
    }

    //the EventArgs just the Modifier and the key
    public class KeyPressedEventArgs : EventArgs {
        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key) {
            Modifier = modifier;
            Key = key;
        }

        public ModifierKeys Modifier { get; }

        public Keys Key { get; }
    }

    [Flags]
    public enum ModifierKeys : uint {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
}