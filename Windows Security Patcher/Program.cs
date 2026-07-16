using System;
using System.Management;
using System.Windows.Forms;

namespace Windows_Security_Patcher
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!IsSystemCompatible())
            {
                return;
            }

            Application.Run(new Form1());
        }

        static bool IsSystemCompatible()
        {
            int buildNumber = 0;
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT BuildNumber FROM Win32_OperatingSystem"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        buildNumber = Convert.ToInt32(obj["BuildNumber"]);
                    }
                }
            }
            catch { buildNumber = Environment.OSVersion.Version.Build; }

            if (buildNumber < 22621)
            {
                MessageBox.Show($"This patcher requires Windows 11 22H2 (Build 22621) or newer.\n\nDetected Build: {buildNumber}",
                                "Compatibility Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!CheckSecurityAppVersion("1000.25330.0.9000"))
            {
                MessageBox.Show("Windows Security App version 1000.25330.0.9000 or newer is required.\n\nPlease update via Microsoft Store.",
                                "Compatibility Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        static bool CheckSecurityAppVersion(string minVersion)
        {
            try
            {
                string script = "Get-AppxPackage -Name Microsoft.SecHealthUI | Select-Object -ExpandProperty Version";
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd().Trim();
                    process.WaitForExit();

                    if (Version.TryParse(output, out Version current) && Version.TryParse(minVersion, out Version required))
                    {
                        return current >= required;
                    }
                }
            }
            catch { return false; }
            return false;
        }
    }
}