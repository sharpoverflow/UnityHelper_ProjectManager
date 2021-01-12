using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    //https://stackoverflow.com/questions/19095199/get-list-of-selected-files-from-windows-desktop
    public class ShellItems
    {
        [StructLayoutAttribute(LayoutKind.Sequential)]
        private struct LVITEM
        {
            public uint mask;
            public int iItem;
            public int iSubItem;
            public uint state;
            public uint stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
        }

        const int LVM_FIRST = 0x1000;
        const int LVM_GETSELECTEDCOUNT = 4146;
        const int LVM_GETNEXTITEM = LVM_FIRST + 12;
        const int LVNI_SELECTED = 2;
        const int LVM_GETITEMCOUNT = LVM_FIRST + 4;
        const int LVM_GETITEM = LVM_FIRST + 75;
        const int LVIF_TEXT = 0x0001;

        [DllImport("user32.dll" , EntryPoint = "GetShellWindow")]
        public static extern System.IntPtr GetShellWindow();

        [DllImport("user32.dll" , SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle , IntPtr childAfter , string className , string windowTitle);

        [DllImport("user32.dll" , EntryPoint = "SendMessage" , CharSet = CharSet.Auto)]
        public static extern int SendMessagePtr(IntPtr hWnd , int wMsg , IntPtr wParam , IntPtr lParam);

        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd , UInt32 Msg , Int32 wParam , Int32 lParam);


        public int SelectedItemCount
        {
            get
            {
                return SendMessage(ShellListViewHandle , LVM_GETSELECTEDCOUNT , IntPtr.Zero.ToInt32() , IntPtr.Zero.ToInt32());
            }
        }
        public int Count
        {
            get
            {
                return SendMessage(ShellListViewHandle , LVM_GETITEMCOUNT , IntPtr.Zero.ToInt32() , IntPtr.Zero.ToInt32());
            }
        }

        //https://stackoverflow.com/questions/4857602/get-listview-items-from-other-windows
        //index:桌面图标的index
        //subIndex:项的子属性,0代表名称,2代表类型(例:文件夹,文件,jpg文件)
        public string GetItemText(int index , int subIndex = 0)
        {
            //取得桌面listViewPtr
            var listViewPtr = ShellListViewHandle;

            // get the ID of the process who owns the list view
            uint processId = 0;
            WinAPI_Shell.GetWindowThreadProcessId(listViewPtr , ref processId);

            // open the process
            var processHandle = WinAPI_Shell.OpenProcess(
                WinAPI_Shell.ProcessAccessFlags.VirtualMemoryOperation
                | WinAPI_Shell.ProcessAccessFlags.VirtualMemoryRead
                | WinAPI_Shell.ProcessAccessFlags.VirtualMemoryWrite ,
                false ,
                processId);

            // allocate buffer for a string to store the text of the list view item we wanted
            var textBufferPtr = WinAPI_Shell.VirtualAllocEx(
                processHandle ,
                IntPtr.Zero ,
                WinAPI_Shell.MAX_LVMSTRING ,
                WinAPI_Shell.AllocationType.Commit ,
                WinAPI_Shell.MemoryProtection.ReadWrite);

            var itemId = index; // the item (row) index
            var subItemId = subIndex; // the subitem (column) index

            // this is the LVITEM we need to inject
            var lvItem = new WinAPI_Shell.LVITEM
            {
                mask = (uint)WinAPI_Shell.ListViewItemFilters.LVIF_TEXT ,
                cchTextMax = (int)WinAPI_Shell.MAX_LVMSTRING ,
                pszText = textBufferPtr ,
                iItem = itemId ,
                iSubItem = subItemId
            };

            // allocate memory for the LVITEM structure in the remote process
            var lvItemSize = Marshal.SizeOf(lvItem);
            var lvItemBufferPtr = WinAPI_Shell.VirtualAllocEx(
                processHandle ,
                IntPtr.Zero ,
                (uint)lvItemSize ,
                WinAPI_Shell.AllocationType.Commit ,
                WinAPI_Shell.MemoryProtection.ReadWrite);

            // to inject the LVITEM structure, we have to use the WriteProcessMemory API, which does a pointer-to-pointer copy. So we need to turn the managed LVITEM structure to an unmanaged LVITEM pointer
            // first allocate a piece of unmanaged memory ...
            var lvItemLocalPtr = Marshal.AllocHGlobal(lvItemSize);

            // ... then copy the managed object into the unmanaged memory
            Marshal.StructureToPtr(lvItem , lvItemLocalPtr , false);

            // and write into remote process's memory
            WinAPI_Shell.WriteProcessMemory(
                processHandle ,
                lvItemBufferPtr ,
                lvItemLocalPtr ,
                (uint)lvItemSize ,
                out var _);

            // tell the list view to fill in the text we desired
            WinAPI_Shell.SendMessage(listViewPtr , (int)WinAPI_Shell.ListViewMessages.LVM_GETITEMTEXT , itemId , lvItemBufferPtr);

            // read the text. we allocate a managed byte array to store the retrieved text instead of AllocHGlobal-ing a piece of unmanaged memory, because CLR knows how to marshal between a pointer and a byte array
            var localTextBuffer = new byte[WinAPI_Shell.MAX_LVMSTRING];
            WinAPI_Shell.ReadProcessMemory(
                processHandle ,
                textBufferPtr ,
                localTextBuffer ,
                (int)WinAPI_Shell.MAX_LVMSTRING ,
                out var _);

            // convert the byte array to a string. assume the remote process uses Unicode
            var text = Encoding.Unicode.GetString(localTextBuffer);
            // the trailing zeros are not cleared automatically
            text = text.Substring(0 , text.IndexOf('\0'));

            // finally free all the memory we allocated, and close the process handle we opened
            WinAPI_Shell.VirtualFreeEx(processHandle , textBufferPtr , 0 , WinAPI_Shell.AllocationType.Release);
            WinAPI_Shell.VirtualFreeEx(processHandle , lvItemBufferPtr , 0 , WinAPI_Shell.AllocationType.Release);
            Marshal.FreeHGlobal(lvItemLocalPtr);

            WinAPI_Shell.CloseHandle(processHandle);

            return text;
        }

        private IntPtr ShellListViewHandle
        {
            get
            {
                IntPtr _ProgMan = GetShellWindow();
                IntPtr _SHELLDLL_DefViewParent = _ProgMan;
                IntPtr _SHELLDLL_DefView = FindWindowEx(_ProgMan , IntPtr.Zero , "SHELLDLL_DefView" , null);
                IntPtr _SysListView32 = FindWindowEx(_SHELLDLL_DefView , IntPtr.Zero , "SysListView32" , "FolderView");
                return _SysListView32;
            }
        }

        public int GetSelectedItemIndex(int iPos = -1)
        {
            return SendMessage(ShellListViewHandle , LVM_GETNEXTITEM , iPos , LVNI_SELECTED);
        }
    }

    public static class WinAPI_Shell
    {

        public enum ListViewMessages
        {
            LVM_GETITEMTEXT = 0x104B
        }

        public enum ListViewItemFilters : uint
        {
            LVIF_TEXT = 0x0001,
        }

        public const uint MAX_LVMSTRING = 255;

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct LVITEM
        {
            public uint mask;
            public int iItem;
            public int iSubItem;
            public uint state;
            public uint stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd , int Msg , int wParam , IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd , ref uint lpdwProcessId);


        [Flags]
        public enum ProcessAccessFlags : uint
        {
            VirtualMemoryOperation = 0x0008,
            VirtualMemoryRead = 0x0010,
            VirtualMemoryWrite = 0x0020,
        }

        [DllImport("kernel32.dll" , SetLastError = true , ExactSpelling = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess , IntPtr lpAddress , uint dwSize , AllocationType flAllocationType , MemoryProtection flProtect);

        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Release = 0x8000,
        }

        [Flags]
        public enum MemoryProtection
        {
            ReadWrite = 0x0004,
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess , bool bInheritHandle , uint processId);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hHandle);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess , IntPtr lpBaseAddress , IntPtr lpBuffer , uint nSize , out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess , IntPtr lpBaseAddress , [Out] byte[] buffer , int dwSize , out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool VirtualFreeEx(IntPtr hProcess , IntPtr lpAddress , int dwSize , AllocationType dwFreeType);
    }
}

