using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Keys> keyList;
        public Form1()
        {
            InitializeComponent();
            keyList = new List<Keys>();
            keyList.Add(Keys.Space);
            keyList.Add(Keys.W);
            keyList.Add(Keys.S);
            keyList.Add(Keys.A);
            keyList.Add(Keys.D);
            button2.Enabled = false;
        }
        bool IsStart = false;


        private async void Button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            //var hwnd = FindWindow("Notepad", null);
            var hwnd = MemoryTools.FindWindow("GxWindowClass", null);
            if (hwnd == IntPtr.Zero)
                return;
            //var child = FindWindowEx(hwnd, IntPtr.Zero, "Edit", "");
            //SetForegroundWindow(hwnd);
            await Task.Delay(1500);
            await Task.Factory.StartNew(async () =>
            {
                while (!IsStart)
                {
                    var currentKey = keyList[new Random(Guid.NewGuid().GetHashCode()).Next(0, keyList.Count)];
                    //await KeyBoardPress(currentKey);
                    await BackKeyPress(hwnd, currentKey);
                    await Task.Delay(Convert.ToInt32(textBox1.Text) * 1000);
                }
                IsStart = false;
            });

        }

        public async Task BackKeyPress(IntPtr hwnd, Keys key)
        {
            var s = (int)key;
            MemoryTools.SendMessage(hwnd, MemoryTools.WM_KEYDOWN, new IntPtr(s), new IntPtr(s));
            await Task.Delay(300);
            MemoryTools.SendMessage(hwnd, MemoryTools.WM_KEYUP, new IntPtr(s), new IntPtr(s));
            await Task.Delay(300);
        }
        public async Task KeyBoardPress(Keys key)
        {
            //按下
            MemoryTools.keybd_event((byte)key, (byte)key, 0, 0);
            await Task.Delay(300);
            //释放
            MemoryTools.keybd_event((byte)key, (byte)key, 2, 0);
            await Task.Delay(300);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
            IsStart = true;
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            var hwnd = MemoryTools.FindWindow("GxWindowClass", null);
            if (hwnd == IntPtr.Zero)
                return;
            int x, y;
            x = 963;
            y = 987;
            MemoryTools.SendMessage(hwnd, MemoryTools.WM_LBUTTONDOWN, 0, y * 65536 + x);
            await Task.Delay(300);
            MemoryTools.SendMessage(hwnd, MemoryTools.WM_LBUTTONUP, 0, y * 65536 + x);
        }
    }
}
