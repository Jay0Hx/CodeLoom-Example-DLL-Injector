using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CodeLoom___Example_DLL_Injector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                processList.Items.Add(process.ProcessName);
            }
        }

        private void injectButton_Click_1(object sender, EventArgs e)
        {
            string processName = processList.SelectedItem.ToString();
            string dllpath = dllPathTEST.Text;

            //Check to make sure that the soft cunt has selected a process && DLL...
            if (string.IsNullOrEmpty(processName) || string.IsNullOrEmpty(dllpath))
            {
                MessageBox.Show("silly cunt");
                return;
            }

            //Double check that the process that they have selected is real and not some dud shit.
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                MessageBox.Show("silly cunt 2");
                return;
            }

            foreach (Process process in processes)
            {
                IntPtr hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, process.Id);
                if (hProcess == IntPtr.Zero)
                {
                    MessageBox.Show("Silly cunt for the third time.");
                    return;
                }
            }

            foreach (Process process in processes)
            {
                IntPtr hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, process.Id);
                if (hProcess == IntPtr.Zero)
                {
                    MessageBox.Show("cant open the cunting process.");
                    return;
                }

                IntPtr pDllPath = IntPtr.Zero;
                IntPtr hThread = IntPtr.Zero;
                try
                {
                    // Allocate memory in the target process for the DLL path
                    pDllPath = Marshal.StringToHGlobalAnsi(dllpath);
                    IntPtr pLoadLibrary = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                    // Constants for error codes (you can define these or use their actual values)
                    const int ERROR_ACCESS_DENIED = 5;
                    const int ERROR_FILE_NOT_FOUND = 2;

                    // Create a remote thread in the target process to load the DLL
                    hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, pLoadLibrary, pDllPath, 0, IntPtr.Zero);
                    if (hThread == IntPtr.Zero)
                    {
                        int errorCode = Marshal.GetLastWin32Error();
                        string errorMessage = $"Failed to create remote thread to load DLL. Error code: {errorCode}";

                        switch (errorCode)
                        {
                            case ERROR_ACCESS_DENIED:
                                errorMessage += "Permissions are too low you sillt cunt";
                                break;
                            case ERROR_FILE_NOT_FOUND:
                                errorMessage += " Process has fucked off.";
                                break;

                            default:
                                errorMessage += "Not a fucking scoobys mate";
                                break;
                        }

                        MessageBox.Show(errorMessage);
                        return;
                    }


                    // Wait for the remote thread to finish
                    WaitForSingleObject(hThread, 0xFFFFFFFF);
                }
                finally
                {
                    // Cleanup
                    CloseHandle(hThread);
                    Marshal.FreeHGlobal(pDllPath);
                    CloseHandle(hProcess);
                }

                MessageBox.Show("Shes fuckin in boys.");
            }
        }

        //Import shit
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess,
           IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter,
           uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll")]
        static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int CloseHandle(IntPtr hObject);

        const uint PROCESS_ALL_ACCESS = 0x1F0FFF;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
