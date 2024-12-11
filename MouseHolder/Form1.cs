using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using Shell32;
using File = System.IO.File;
using Folder = Shell32.Folder;

namespace MouseHolder
{
    public partial class Form1 : Form
    {
        //DllImport to control the mouse
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);
        
        readonly KeyboardHook _hook = new KeyboardHook();
        //bool to check if the user is hooking a HotKey
        public bool Hooking = false;
        //set default mouse button to hold
        private uint _mouseButton = (uint)mouseButtons.LeftMouse;
        
        public Form1()
        {
            InitializeComponent();
            checkAndSetLinkToExe();
            
            //set default HotKey
            _hook.KeyPressed += hook_KeyPressed;
            _hook.RegisterHotKey(MouseHolder.ModifierKeys.Control, Keys.H);
        }
        
        // add application to start menu 
        private void checkAndSetLinkToExe()
        {
            try
            {
                string currentFilePath   = Assembly.GetEntryAssembly().Location;
                string appdata           = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string startMenuFilePath = appdata + @"\Microsoft\Windows\Start Menu\Programs\MouseHolder.lnk";

                if (File.Exists(startMenuFilePath))
                {
                    if (GetShortcutTargetFile(startMenuFilePath) == currentFilePath)
                    {
                        return;
                    }

                    File.Delete(startMenuFilePath);
                }

                WshShell     shell    = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(startMenuFilePath);

                shortcut.TargetPath = Assembly.GetEntryAssembly().Location;
                shortcut.Save();
            }
            catch (Exception e)
            {
                MessageBox.Show("Adding link to application failed","Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        
        // check if link is set to current executed application
        private static string GetShortcutTargetFile(string shortcutFilename)
        {
            string pathOnly     = Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = Path.GetFileName(shortcutFilename);

            Shell      shell      = new Shell();
            Folder     folder     = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                ShellLinkObject link = (ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }

            return string.Empty;
        }
        
        //Used to change the HotKey
        private void hotKeyChange_Click(object sender, EventArgs e)
        {
            GetHotkey getHotkey = new GetHotkey(this);
            getHotkey.Show();
        }
        
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if(Hooking) return;
            mouse_event(_mouseButton, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, (UIntPtr)0);
        }

        #region Hotkey
        
        //used to change the HotKey and the HotKey text
        public void Form1RegisterHotKey(List<Keys> keysList)
        {
            Keys tmpKeys = Keys.None;
            ModifierKeys tmpModifiers = MouseHolder.ModifierKeys.None;

            hotKeyLabel.Text = String.Join(" + ", keysList);
            //adding all keys together (more then two normal keys are not possible need to be fixed)
            foreach (var key in keysList)
            {
                if (isModifierKey(key.ToString()))
                {
                    tmpModifiers |= getModifierKeyByKeyCode(key.ToString());
                }
                else
                {
                    tmpKeys |= key;
                }
            }
            
            _hook.RegisterHotKey(tmpModifiers, tmpKeys);
        }

        private bool isModifierKey(string keyCode)
        {
            switch (keyCode)
            {
                case "ControlKey":
                case "Menu":
                case "ShiftKey":
                case "LWin":
                case "RWin":
                    return true;
                default:
                    return false;
            }
        }

        private ModifierKeys getModifierKeyByKeyCode(string keyCode)
        {
            switch (keyCode)
            {
                case "ControlKey":
                    return MouseHolder.ModifierKeys.Control;
                case "Menu":
                    return MouseHolder.ModifierKeys.Alt;
                case "ShiftKey":
                    return MouseHolder.ModifierKeys.Shift;
                case "LWin":
                case"RWin":
                    return MouseHolder.ModifierKeys.Win;
                default:
                    return MouseHolder.ModifierKeys.None;
            }
        }
        
        #endregion

        #region CheckBoxen

        private void lmButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lmButton.Checked)
            {
                _mouseButton |= (uint)mouseButtons.LeftMouse;
            }
            else
            {
                _mouseButton -= (uint)mouseButtons.LeftMouse;
            }
        }

        private void mmButton_CheckedChanged(object sender, EventArgs e)
        {
            if (mmButton.Checked)
            {
                _mouseButton |= (uint)mouseButtons.MiddleMouse;
            }
            else
            {
                _mouseButton -= (uint)mouseButtons.MiddleMouse;
            }
        }

        private void rmButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rmButton.Checked)
            {
                _mouseButton |= (uint)mouseButtons.RightMouse;
            }
            else
            {
                _mouseButton -= (uint)mouseButtons.RightMouse;
            }
        }
        
        #endregion
    }
    
    public enum mouseButtons : uint
    {
        LeftMouse = 0x02,
        MiddleMouse = 0x20,
        RightMouse = 0x08
    }
}