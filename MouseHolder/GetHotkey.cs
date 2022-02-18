using System.Collections.Generic;
using System.Windows.Forms;

namespace MouseHolder
{
    public partial class GetHotkey : Form
    {
        private readonly List<Keys> _keysList = new List<Keys>();
        private readonly Form1 _form1;

        public GetHotkey(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
            _form1.Hooking = true;
        }

        private void GetHotkey_KeyUp(object sender, KeyEventArgs e)
        {
            _form1.Form1RegisterHotKey(_keysList);
            _form1.Hooking = false;
            Close();
        }

        private void GetHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            //then the user is holding a button the program detects it multiple times
            if (_keysList.Contains(e.KeyCode)) return;

            _keysList.Add(e.KeyCode);
            
            //change the text
            if (label.Text.Equals("Press Any Keys..."))
            {
                label.Text = e.KeyCode.ToString();
            }
            else
            {
                label.Text += " + " + e.KeyCode;
            }
        }
    }
}