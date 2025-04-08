using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Enabler
{
    public partial class Main : Form
    {
        bool ControllEnabled = false;
        bool Targeting = false;
        bool visibleHwnd = true;
        bool SetText = false;
        bool GetText = false;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnableWindow(IntPtr hWnd, bool enable);

        [DllImport("user32.dll")]
        private static extern IntPtr ShowWindow(IntPtr hwnd, ShowWindowCommands nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowEnabled(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(int xPoint, int yPoint);

        [DllImport("user32.dll")]
        static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, POINT Point);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, [Out] StringBuilder lpClassName, int nMaxCount);

        // Deklarasi fungsi SendMessage dari user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        // Konstanta pesan untuk mengubah tampilan tombol menjadi abu-abu
        const uint BM_SETSTATE = 0xF4;
        const uint WM_SETTEXT = 0x000C;
        const uint WM_GETTEXT = 0x000D;
        const uint WM_GETTEXTLENGTH = 0x000E;

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public enum ShowWindowCommands : uint
        {
            /// <summary>
            ///        Hides the window and activates another window.
            /// </summary>
            SW_HIDE = 0,

            /// <summary>
            ///        Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
            /// </summary>
            SW_SHOWNORMAL = 1,

            /// <summary>
            ///        Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
            /// </summary>
            SW_NORMAL = 1,

            /// <summary>
            ///        Activates the window and displays it as a minimized window.
            /// </summary>
            SW_SHOWMINIMIZED = 2,

            /// <summary>
            ///        Activates the window and displays it as a maximized window.
            /// </summary>
            SW_SHOWMAXIMIZED = 3,

            /// <summary>
            ///        Maximizes the specified window.
            /// </summary>
            SW_MAXIMIZE = 3,

            /// <summary>
            ///        Displays a window in its most recent size and position. This value is similar to <see cref="ShowWindowCommands.SW_SHOWNORMAL"/>, except the window is not activated.
            /// </summary>
            SW_SHOWNOACTIVATE = 4,

            /// <summary>
            ///        Activates the window and displays it in its current size and position.
            /// </summary>
            SW_SHOW = 5,

            /// <summary>
            ///        Minimizes the specified window and activates the next top-level window in the z-order.
            /// </summary>
            SW_MINIMIZE = 6,

            /// <summary>
            ///        Displays the window as a minimized window. This value is similar to <see cref="ShowWindowCommands.SW_SHOWMINIMIZED"/>, except the window is not activated.
            /// </summary>
            SW_SHOWMINNOACTIVE = 7,

            /// <summary>
            ///        Displays the window in its current size and position. This value is similar to <see cref="ShowWindowCommands.SW_SHOW"/>, except the window is not activated.
            /// </summary>
            SW_SHOWNA = 8,

            /// <summary>
            ///        Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
            /// </summary>
            SW_RESTORE = 9,

            /// <summary>
            ///        Items 10, 11 and 11 existed in the VB definition but not the c# definition - so I am assuming this was a mistake and have added them here.
            ///         Please forgive me if this is wrong!  I don't think it should have any negative impact.
            ///         According to what I have read elsewhere: The SW_SHOWDEFAULT makes sure the window is restored prior to showing, then activating.
            ///         And the 11's try to coerce a window to minimized or maximized.
            /// </summary>
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11

        }

        IntPtr HWndHandle;

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ControllEnabled)
            {
                cmdEnable.Text = "Enable";
                EnableWindow(HWndHandle, false);
                SendMessage(HWndHandle, BM_SETSTATE, (IntPtr)0, IntPtr.Zero);
                ControllEnabled = false;
            }
            else
            {
                cmdEnable.Text = "Disable";
                EnableWindow(HWndHandle, true);
                SendMessage(HWndHandle, BM_SETSTATE, (IntPtr)1, IntPtr.Zero);
                ControllEnabled = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Bitmap cursorBitmap = new Bitmap(32, 32);

            // Draw cross lines on the bitmap
            using (Graphics g = Graphics.FromImage(cursorBitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen pen = new Pen(Color.Black, 1); // Adjust thickness as needed

                // Calculate the center of the PictureBox
                int centerX = imgTarget.Width / 2;
                int centerY = imgTarget.Height / 2;

                // Draw cross lines at the center
                g.DrawLine(pen, centerX - 10, centerY, centerX + 10, centerY);
                g.DrawLine(pen, centerX, centerY - 10, centerX, centerY + 10);
            }

            imgTarget.Image = cursorBitmap;
        }

        private void imgTarget_MouseDown(object sender, MouseEventArgs e)
        {
            Targeting = true;
            imgTarget.Image = null;
            this.Cursor = Cursors.Cross;
        }

        private void imgTarget_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Targeting) return;

            GetCursorPos(out POINT cursorPosition);

            IntPtr tempHwnd = WindowFromPoint(cursorPosition.x, cursorPosition.y);
            GetWindowPoint(tempHwnd, out int WindowX, out int WindowY);

            POINT WindowPos;
            WindowPos.x = WindowX;
            WindowPos.y = WindowY;

            IntPtr child = ChildWindowFromPoint(tempHwnd, WindowPos);

            StringBuilder className = new StringBuilder(256);
            if (child != IntPtr.Zero)
            {
                GetClassName(child, className, className.Capacity);
                lblHWnd.Text = child.ToString();
                HWndHandle = child;
                ControllEnabled = false;
                cmdEnable.Text = "Enable";
            }
            else
            {
                GetClassName(tempHwnd, className, className.Capacity);
                lblHWnd.Text = tempHwnd.ToString();
                HWndHandle = tempHwnd;
                ControllEnabled = true;
                cmdEnable.Text = "Disable";
            }

            lblClassName.Text = className.ToString().TrimEnd('\0');
            PopulateTreeViewWithChildWindows(HWndHandle, hwndTree);
        }

        private void imgTarget_MouseUp(object sender, MouseEventArgs e)
        {
            // Create a bitmap for the custom cursor
            Bitmap cursorBitmap = new Bitmap(32, 32);

            // Draw cross lines on the bitmap
            using (Graphics g = Graphics.FromImage(cursorBitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen pen = new Pen(Color.Black, 1); // Adjust thickness as needed

                // Calculate the center of the PictureBox
                int centerX = imgTarget.Width / 2;
                int centerY = imgTarget.Height / 2;

                // Draw cross lines at the center
                g.DrawLine(pen, centerX - 10, centerY, centerX + 10, centerY);
                g.DrawLine(pen, centerX, centerY - 10, centerX, centerY + 10);
            }

            Targeting = false;
            imgTarget.Image = cursorBitmap;
            this.Cursor = Cursors.Default;
        }

        public static bool GetWindowPoint(IntPtr hWnd, out int x, out int y)
        {
            int topLevelParent;
            x = 0; y = 0;

            // Get current cursor position
            if (!GetCursorPos(out POINT cursorPosition))
                return false;

            // Get top level parent
            topLevelParent = (int)GetTopLevelParent(hWnd);

            // Get window rectangle
            if (GetWindowRect((IntPtr)topLevelParent, out RECT r))
            {
                // Calculate coordinates relative to the window
                y = cursorPosition.y - r.top - 20; // You can adjust this if there is an offset effect
                x = cursorPosition.x - r.left;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static IntPtr GetTopLevelParent(IntPtr hWndNum)
        {
            IntPtr tmpHwnd = hWndNum; // Holds a temp Hwnd

            // Make sure the input hWnd refers to a window
            if (IsWindow(tmpHwnd))
            {
                IntPtr parentHwnd = GetParent(tmpHwnd);
            }

            // Supposed to be parent hwnd
            return hWndNum;
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            if (visibleHwnd == true)
            {
                ShowWindow(HWndHandle, ShowWindowCommands.SW_HIDE);
            }
            else
            {
                ShowWindow(HWndHandle, ShowWindowCommands.SW_SHOW);
            }
            visibleHwnd = !visibleHwnd;
        }

        private void cmdSetText_Click(object sender, EventArgs e)
        {
            if(SetText == true)
            {
                cmdSetText.Text = "Set Text (OFF)";
                timerSetText.Enabled = false;
            }
            else
            {
                cmdSetText.Text = "Set Text (ON)";
                timerSetText.Enabled = true;
            }
            SetText = !SetText;
        }

        private void timerText_Tick(object sender, EventArgs e)
        {
            // Allocate memory for the string
            IntPtr lParam = Marshal.StringToHGlobalAuto(txtSetText.Text);
            try
            {
                SendMessage(HWndHandle, WM_SETTEXT, IntPtr.Zero, lParam);
            }
            catch
            {
                return;
            }
            finally
            {
                // Free the allocated memory
                Marshal.FreeHGlobal(lParam);
            }
        }

        private void cmdGetText_Click(object sender, EventArgs e)
        {
            if (GetText == true)
            {
                cmdGetText.Text = "Get Text (OFF)";
                timerGetText.Enabled = false;
            }
            else
            {
                cmdGetText.Text = "Get Text (ON)";
                timerGetText.Enabled = true;
            }
            GetText = !GetText;
        }

        private void timerGetText_Tick(object sender, EventArgs e)
        {
            try
            {
                // Get the length of the text in the target window
                IntPtr txtSize = SendMessage(HWndHandle, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);

                // Allocate buffer to receive the text
                int bufferSize = txtSize.ToInt32() + 1;
                IntPtr buffer = Marshal.AllocHGlobal(bufferSize * sizeof(char));

                try
                {
                    // Send the message to get the text
                    SendMessage(HWndHandle, WM_GETTEXT, (IntPtr)bufferSize, buffer);

                    // Retrieve the text from the buffer
                    txtSetText.Text = Marshal.PtrToStringAuto(buffer);
                }
                finally
                {
                    // Free the allocated buffer
                    Marshal.FreeHGlobal(buffer);
                }
            }
            catch
            {
                // Handle exceptions if necessary
                return;
            }
        }


        // Delegate untuk EnumChildWindows
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        // Mendapatkan list dari child windows dari sebuah parent window
        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        // Mendapatkan text dari sebuah window
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int nMaxCount);

        // Mendapatkan panjang dari text dari sebuah window
        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, ref RECT lpPoints, int cPoints);

        // Struktur untuk menampung informasi window
        private struct WindowInfo
        {
            public IntPtr Handle;
            public string Title;
            public RECT Rect;
        }

        // Mendapatkan daftar dari child windows dan menampilkan di TreeView
        public static void PopulateTreeViewWithChildWindows(IntPtr parentHandle, TreeView treeView)
        {
            treeView.Nodes.Clear(); // Clear nodes before adding new ones

            List<WindowInfo> childWindows = new List<WindowInfo>();

            // Enumerate all child windows, including hidden and disabled ones
            EnumChildWindows(parentHandle, (hWnd, lParam) =>
            {
                int length = GetWindowTextLength(hWnd);
                StringBuilder sb = new StringBuilder(length + 1);
                GetWindowText(hWnd, sb, sb.Capacity);
                string title = sb.ToString();
                RECT rect;
                GetWindowRect(hWnd, out rect);

                // Convert coordinates from desktop to parent window coordinates
                MapWindowPoints(IntPtr.Zero, parentHandle, ref rect, 2);

                childWindows.Add(new WindowInfo { Handle = hWnd, Title = title, Rect = rect });
                return true; // Continue enumeration
            }, IntPtr.Zero);

            // Add child windows to the TreeView
            foreach (var windowInfo in childWindows)
            {
                TreeNode node = new TreeNode(windowInfo.Title);
                node.Tag = windowInfo.Handle; // Store handle in Tag

                // Add size and position information to the text of the node
                string nodeText = $"{windowInfo.Title} - Left: {windowInfo.Rect.left}, Top: {windowInfo.Rect.top}, Width: {windowInfo.Rect.right - windowInfo.Rect.left}, Height: {windowInfo.Rect.bottom - windowInfo.Rect.top}";
                node.Text = nodeText;

                treeView.Nodes.Add(node);
            }
        }

    }
}
