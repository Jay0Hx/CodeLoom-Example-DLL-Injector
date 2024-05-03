using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// Code is super messy, i will clean it up at some point when i have time.
// I only made this to test a DLL that im working on for Assetto Corsa so it looks awful.
// Dont use it for games like COD etc, you'll get banned.

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

            if (string.IsNullOrEmpty(processName) || string.IsNullOrEmpty(dllpath))
            {
                MessageBox.Show("No information at all?");
                return;
            }

            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                MessageBox.Show("Process name empty...");
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
                    pDllPath = Marshal.StringToHGlobalAnsi(dllpath);
                    IntPtr pLoadLibrary = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                    const int ERROR_ACCESS_DENIED = 5;
                    const int ERROR_FILE_NOT_FOUND = 2;

                    hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, pLoadLibrary, pDllPath, 0, IntPtr.Zero);
                    if (hThread == IntPtr.Zero)
                    {
                        int errorCode = Marshal.GetLastWin32Error();
                        string errorMessage = $"Failed to create remote thread to load DLL. Error code: {errorCode}";

                        switch (errorCode)
                        {
                            case ERROR_ACCESS_DENIED:
                                errorMessage += "This application required eleveated permissions.";
                                break;
                            case ERROR_FILE_NOT_FOUND:
                                errorMessage += "That taget process can no longer be found.";
                                break;

                            default:
                                errorMessage += "Unknown error occured.";
                                break;
                        }

                        MessageBox.Show(errorMessage);
                        return;
                    }

                    WaitForSingleObject(hThread, 0xFFFFFFFF);
                }
                finally
                {
                    CloseHandle(hThread);
                    Marshal.FreeHGlobal(pDllPath);
                    CloseHandle(hProcess);
                }

                MessageBox.Show("Shes fuckin in boys.");
            }
        }

        //Import everything that we need at the bottom here.
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

        //I'll do something with this later and remove it...
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dllSelector_Click(object sender, EventArgs e)
        {
            // Create a new instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to only show DLL files
            openFileDialog.Filter = "DLL Files (*.dll)|*.dll";

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string selectedFilePath = openFileDialog.FileName;

                // Update the text of dllPathTEST with the selected file path
                dllPathTEST.Text = selectedFilePath;
            }
        }
    }
}
