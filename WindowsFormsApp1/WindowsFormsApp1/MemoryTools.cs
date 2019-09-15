using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class MemoryTools
    {
        /// <summary>
        /// 键盘按下（目标窗体也许并不接受）
        /// </summary>
        public static int WM_KEYDOWN = 0x0100;
        /// <summary>
        /// 键盘松开
        /// </summary>
        public static int WM_KEYUP = 0x0101;
        /// <summary>
        /// 移动鼠标时发生，同WM_MOUSEFIRST
        /// </summary>
        public static int WM_MOUSEMOVE = 0x200;
        /// <summary>
        /// 按下鼠标左键
        /// </summary>
        public static int WM_LBUTTONDOWN = 0x201;
        /// <summary>
        /// 释放鼠标左键
        /// </summary>
        public static int WM_LBUTTONUP = 0x202;
        /// <summary>
        /// 双击鼠标左键
        /// </summary>
        public static int WM_LBUTTONDBLCLK = 0x203;
        /// <summary>
        /// 按下鼠标右键
        /// </summary>
        public static int WM_RBUTTONDOWN = 0x204;
        /// <summary>
        /// 释放鼠标右键
        /// </summary>
        public static int WM_RBUTTONUP = 0x205;
        /// <summary>
        /// 双击鼠标右键
        /// </summary>
        public static int WM_RBUTTONDBLCLK = 0x206;
        /// <summary>
        /// 按下鼠标中键
        /// </summary>
        public static int WM_MBUTTONDOWN = 0x207;
        /// <summary>
        /// 双击鼠标中键
        /// </summary>
        public static int WM_MBUTTONDBLCLK = 0x209;
        /// <summary>
        /// 释放鼠标中键
        /// </summary>
        public static int WM_MBUTTONUP = 0x208;
        /// <summary>
        /// 发送字符
        /// </summary>
        public static int WM_CHAR = 0x102;
        /// <summary>
        /// 发送文本
        /// </summary>
        public static int WM_SETTEXT = 0x0C;
        /// <summary>
        /// 获取文本
        /// </summary>
        public static int WM_GETTEXT = 0x0D;
        /// <summary>
        /// 获取形状
        /// </summary>
        public static int EM_GETRECT = 0xB2;
        /// <summary>
        /// 获取文本行数
        /// </summary>
        public static int EM_GETLINECOUNT = 0xBA;
        /// <summary>
        /// 获得文本是否被修改过
        /// </summary>
        public static int EM_GETMODIFY = 0xB8;
        /// <summary>
        /// 获得光标在文本第几行
        /// </summary>
        public static int EM_LINEFROMCHAR = 0xC9;
        /// <summary>
        /// 获得多行文本编辑控件的滚动框的当前位置（像素值）
        /// </summary>
        public static int EM_GETTHUMB = 0xBE;
        /// <summary>
        /// 滚动到文本指定行列
        /// </summary>
        public static int EM_LINESCROLL = 0xB6;
        /// <summary>
        /// 获得文本光标处之前的字符数,包括回车换行 
        /// </summary>
        public static int EM_LINEINDEX = 0xBB;
        /// <summary>
        /// 限制文本长度
        /// </summary>
        public static int EM_LIMITTEXT = 0xC5;
        /// <summary>
        /// 撤销操作，可撤销很多次
        /// </summary>
        public static int EM_UNDO = 0xC7;
        /// <summary>
        /// 设定只读
        /// </summary>
        public static int EM_SETREADONLY = 0xCF;
        /// <summary>
        /// 控件获得焦点
        /// </summary>
        public static int WM_SETFOCUS = 0x07;
        /// <summary>
        /// 控件失去焦点
        /// </summary>
        public static int WM_KILLFOCUS = 0x08;
        /// <summary>
        /// 滚动
        /// </summary>
        public static int EM_SCROLL = 0xB5;
        /// <summary>
        /// 选取指定范围字符串（要先获得焦点）
        /// </summary>
        public static int EM_SETSEL = 0xB1;
        #region 句柄操作
        /// <summary>
        /// 打开进程
        /// </summary>
        /// <param name="iAccess"></param>
        /// <param name="Handle"></param>
        /// <param name="ProcessID"></param>
        /// <returns></returns>
        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess
        (
            int iAccess,
            bool Handle,
            int ProcessID
        );
        /// <summary>
        /// 关闭句柄
        /// </summary>
        /// <param name="hObject"></param>
        [DllImport("kernel32.dll", EntryPoint = "CloseHandle")]
        private static extern void CloseHandle
        (
            IntPtr hObject
        );
        /// <summary>
        /// 查找窗口
        /// </summary>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口的标题</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 查找子窗口 子按钮 子菜单
        /// </summary>
        /// <param name="hwndParent">父窗口句柄</param>
        /// <param name="hwndChildAfter"></param>
        /// <param name="lpszClass"></param>
        /// <param name="lpszWindow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        /// <summary>
        /// 激活窗口
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern int SetForegroundWindow(IntPtr hwnd);
        #endregion


        #region 按键操作
        /// <summary>
        /// 驱动级按键
        /// </summary>
        /// <param name="bVk">虚拟按键</param>
        /// <param name="bScan">物理按键</param>
        /// <param name="dwFlags">0 按下 2 释放</param>
        /// <param name="dwExtraInfo">默认0</param>
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        /// <summary>
        /// 后台发送按键
        /// </summary>
        /// <param name="hWnd">句柄</param>
        /// <param name="Msg">指定附加的消息特定信息。</param>
        /// <param name="wParam">指定附加的消息特定信息。</param>
        /// <param name="lParam">返回值指定消息处理的结果，依赖于所发送的消息。</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, StringBuilder lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        //public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, ref Rectangle lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern IntPtr SendMessage(IntPtr hwnd, uint wMsg, uint wParam, uint lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, bool wParam, int lParam);
        #endregion

        #region 内存操作
        /// <summary>
        /// 读内存
        /// </summary>
        /// <param name="lpProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nSize"></param>
        /// <param name="BytesRead"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory
       (
           IntPtr lpProcess,
           IntPtr lpBaseAddress,
           IntPtr lpBuffer,
           int nSize,
           IntPtr BytesRead
       );

        /// <summary>
        /// 写内存
        /// </summary>
        /// <param name="lpProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nSize"></param>
        /// <param name="BytesWrite"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory
        (
            IntPtr lpProcess,
            IntPtr lpBaseAddress,
            int[] lpBuffer,
            int nSize,
            IntPtr BytesWrite

        );
        /// <summary>
        /// 写内存
        /// </summary>
        /// <param name="lpProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nSize"></param>
        /// <param name="BytesWrite"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessByteMemory
        (
            IntPtr lpProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            IntPtr BytesWrite

        );
        /// <summary>
        /// 写内存
        /// </summary>
        /// <param name="lpProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nSize"></param>
        /// <param name="BytesWrite"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessbyteMemory
       (
           IntPtr lpProcess,
           IntPtr lpBaseAddress,
           byte[] lpBuffer,
           int nSize,
           IntPtr BytesWrite

       );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool VirtualProtectEx
        (
            //修改内存的句柄
            IntPtr hProcess,
            //要修改的起始地址
            IntPtr lpAddress,
            //页区域大小
            int dwSize,
            //访问方式
            int flNewProtect,
            //用于保护改变前的保护属性
            ref IntPtr lpflOldProtect
        );

        //GetModuleHandle是获取一个应用程序或动态链接库的模块句柄  
        [DllImport("kernel32.dll", CharSet = CharSet.Auto,
                CallingConvention = CallingConvention.StdCall)]
        public static extern int GetModuleHandle(string lpModuleName);
        #endregion

        //根据进程名获取PID
        public static int GetPidByProcessName(string processName)
        {
            Process[] ArrayProcess = Process.GetProcessesByName(processName);
            foreach (Process pro in ArrayProcess)
            {
                return pro.Id;
            }
            return 0;
        }
        //读取内存的值
        public static int ReadMemoryValue(int baseAddress, string ProcessName)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, GetPidByProcessName(ProcessName));
                ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero);
                CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }
        #region 写内存方式

        //写内存整数型
        public static void WriteMemoryValue(int baseAddress, string ProcessName, int value)
        {
            //打开进程获得句柄
            IntPtr hProcess = OpenProcess(0x1F0FFF, false, GetPidByProcessName(ProcessName));
            bool flag;
            flag = WriteProcessMemory(hProcess, (IntPtr)baseAddress, new int[] { value }, value, IntPtr.Zero);
            CloseHandle(hProcess);
        }
        //写内存字节型
        public static void WriteMemoryValue(int baseAddress, string ProcessName, byte[] value)
        {
            //打开进程获得句柄
            IntPtr hProcess = OpenProcess(0x1F0FFF, false, GetPidByProcessName(ProcessName));

            bool flag;
            //bool flag2;
            IntPtr adds = (IntPtr)0x33;
            //flag2 = VirtualProtectEx(hProcess, (IntPtr)baseAddress, 4, 0x40, ref adds);
            flag = WriteProcessByteMemory(hProcess, (IntPtr)baseAddress, value, value.Length, IntPtr.Zero);

            string temp = ((IntPtr)baseAddress).ToString("x");
            CloseHandle(hProcess);
        }

        #endregion
    }
}
