using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/// <summary>
/// Handles everything related to protecting the process from being terminated...
/// </summary>
public class ProcessProtector
{
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseHandle(IntPtr hObject);

    [DllImport("ntdll.dll")]
    private static extern int NtSetInformationProcess(IntPtr processHandle, int processInformationClass, ref int processInformation, int processInformationLength);

    private const int ProcessBreakOnTermination = 29;
    private const int BreakOnTerminationFlag = 1;
    private const int ClearBreakOnTerminationFlag = 0;

    /// <summary>
    /// Protects the current process from termination...
    /// </summary>
    public static void ProtectProcess()
    {
        SetBreakOnTermination(BreakOnTerminationFlag);
    }

    /// <summary>
    /// Removes the protection from the current process, allowing it to be terminated...
    /// </summary>
    public static void UnprotectProcess()
    {
        SetBreakOnTermination(ClearBreakOnTerminationFlag);
    }

    /// <summary>
    /// Sets or clears the BreakOnTermination flag for the current process...
    /// </summary>
    /// <param name="flag">The flag value to set (1 to protect, 0 to unprotect)...</param>
    private static void SetBreakOnTermination(int flag)
    {
        int isCritical = flag;
        int processInfoClass = ProcessBreakOnTermination;

        // Enter Debug Mode to acquire necessary privileges...
        Process.EnterDebugMode();

        // Get the current process handle...
        IntPtr hProcess = Process.GetCurrentProcess().Handle;

        // Set the process information...
        int result = NtSetInformationProcess(hProcess, processInfoClass, ref isCritical, sizeof(int));

        if(result != 0)
        {
            throw new InvalidOperationException($"Failed to set process information. Error code: {result}");
        }
    }
}
