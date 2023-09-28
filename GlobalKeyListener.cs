using System.Diagnostics;
using System.Runtime.InteropServices;

public class GlobalKeyListener
{
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;

    private IntPtr hookId = IntPtr.Zero;
    private List<char> keysList = new List<char>();
    private TextBox textBox;

    public GlobalKeyListener(TextBox textBox)
    {
        this.textBox = textBox;     
    }

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    private IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            char pressedKey = (char)vkCode;

            keysList.Add(pressedKey);
            textBox.Text += pressedKey + ", ";
        }

        return CallNextHookEx(hookId, nCode, wParam, lParam);
    }

    internal void Unhook()
    {
        UnhookWindowsHookEx(hookId);
        ClearSettings();
    }

    internal void Hook()
    {
        ClearSettings();
        hookId = SetHook(HookCallback);
    }

    internal string UsedCharacters()
    {
        return String.Join("", keysList);
    }

    internal void ClearSettings()
    {
        keysList.Clear();
        textBox.Text = "";
    }
}
