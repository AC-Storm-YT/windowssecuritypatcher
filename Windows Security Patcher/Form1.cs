using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Security_Patcher
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool IsProcessorFeaturePresent(uint ProcessorFeature);

        private void SetControlsEnabled(bool enabled)
        {
            btnKSHSP.Enabled = enabled;
            btnDisableKSHSP.Enabled = enabled;
            btnHVCI.Enabled = enabled;
            btnDisableHVCI.Enabled = enabled;
            btnCheckDrivers.Enabled = enabled;
            btnCloseConsole.Enabled = enabled;
        }

        public Form1()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            if (!Windows_Security_Patcher.Properties.Settings.Default.HasAcceptedAgreement)
            {
                ShowAgreement();
            }

            this.MaximizeBox = false;
            this.Sizable = false;
            pnlConsole.Visible = false;
        }

        private void ShowAgreement()
        {
            string agreementText = "SECURITY PATCHER: DEPLOYMENT PROTOCOLS\n\n" +
                                   "1. APPLICATION INTENT: This utility is designed to repair and patch bugged security scenarios that are otherwise inaccessible.\n" +
                                   "2. KERNEL MODIFICATION: Execution involves direct low-level overrides of Kernel-mode Security Scenarios within the system configuration.\n" +
                                   "3. UI BYPASS: User acknowledges that this patcher bypasses standard Windows UI restrictions to resolve 'greyed out' or restricted states.\n" +
                                   "4. HARDWARE VALIDATION: While the tool performs a hardware compatibility check, manual bypass of warnings is at the user's discretion.\n" +
                                   "5. SYSTEM SCENARIOS: Targeted modifications focus on Kernel-mode Hardware-enforced Stack Protection and Memory Integrity structures.\n" +
                                   "6. INSTABILITY RISK: Modification of kernel-level parameters carries a risk of system instability if hardware does not fully support the patch.\n" +
                                   "7. BOOT INTEGRITY: The developer is not liable for failures to initialize the OS boot-loader, potential system boot loops or any other damages.\n" +
                                   "8. THIRD-PARTY STATUS: User acknowledges this is an unofficial tool and not a product endorsed by Microsoft Corporation.\n" +
                                   "9. ELEVATED ACCESS: Direct system-level access requires administrative privileges to modify restricted security scenario data.\n" +
                                   "10. DEPLOYMENT FINALIZATION: A full system restart is required to synchronize with the newly applied configuration.\n\n" +
                                   "Do you understand and authorize the execution of these security patches?";


            DialogResult result = MaterialMessageBox.Show(this, agreementText, "Authorization Protocol", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.HasAcceptedAgreement = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private string GetCPUModel()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor"))
                {
                    foreach (var item in searcher.Get())
                        return item["Name"].ToString().Trim();
                }
            }
            catch { return "Unknown CPU"; }
            return "Unknown CPU";
        }

        private bool IsAMDKSHSPSupported()
        {
            string cpu = GetCPUModel().ToUpper();

            // --- ZEN 5 (Granite Ridge / Strix Point / Turin) ---
            string[] zen5 = {
        "9950X", "9950X3D", "9900X", "9900X3D", "9800X3D", "9850X3D", "9700X", "9600X",
        "AI 9 HX 375", "AI 9 HX 370", "AI 9 365", "AI 7 PRO 360", "AI 5 340", "AI 5 330",
        "AI MAX+ 395", "AI MAX 390", "AI MAX 385",
        "9965", "9845", "9745", "9654", "9554", "9454", "9354", "9254" // EPYC 9005 (Turin)
    };

            // --- ZEN 4 (Raphael / Phoenix / Dragon Range / Storm Peak / Genoa) ---
            string[] zen4 = {
        "7950X", "7950X3D", "7900X", "7900X3D", "7900", "7800X3D", "7700X", "7700", "7600X3D", "7600X", "7600", "7500X3D", "7500F", "7400F", "7400",
        "8700G", "8600G", "8500G", "8500GE", "8300G", "8700F", "8400F",
        "7945HX", "7845HX", "7745HX", "7645HX", "7940HS", "7840HS", "7740HS", "7640HS", "7840U", "7640U", "7540U", "7440U",
        "8945HS", "8845HS", "8645HS", "8840HS", "8640HS", "8840U", "8640U", "8540U", "8440U",
        "7995WX", "7985WX", "7975WX", "7960X", "7965WX", "7970X", "7980X", "7955WX", "7945WX", // Threadripper 7000 / Storm Peak
        "Z1 EXTREME", "Z1", // Handhelds
        "9754", "9654", "9554", "9454", "9354", "9254", "9154" // EPYC 9004 (Genoa/Bergamo)
    };

            // --- ZEN 3 & ZEN 3+ (Vermeer / Cezanne / Milan / Rembrandt / Barcelo) ---
            string[] zen3 = {
        "5950X", "5900XT", "5900X", "5900", "5800X3D", "5800XT", "5800X", "5800", "5700X3D", "5700X", "5700", "5600X3D", "5600XT", "5600X", "5600", "5600GT", "5600T", "5600G", "5600GE", "5500X3D", "5500GT", "5500", "5100",
        "5980HX", "5980HS", "5900HX", "5900HS", "5825U", "5800H", "5800HS", "5800U", "5625U", "5600H", "5600HS", "5600U", "5425U", "5400U",
        "6980HX", "6980HS", "6900HX", "6900HS", "6850U", "6800H", "6800HS", "6800U", "6650U", "6600H", "6600HS", "6600U",
        "7735HS", "7735HX", "7535HS", "7535HX", "7335HS", "7235HS", "7730U", "7530U", "7330U",
        "100E", "130E", "150E", "170E",
        "5995WX", "5975WX", "5965WX", "5955WX", "5945WX",
        "7773X", "7763", "7713", "7663", "7643", "7543", "7513", "7453", "7443", "7413", "7343", "7313", "7203"
    };

            // PRO & Embedded Variants (Using the same core logic)
            string[] enterprise = {
        "PRO 9950", "PRO 9900", "PRO 9700", "PRO 9600",
        "PRO 8845", "PRO 8840", "PRO 7945", "PRO 7845", "PRO 7840", "PRO 7645", "PRO 7640", "PRO 7545", "PRO 7540",
        "PRO 5995", "PRO 5975", "PRO 5965", "PRO 5955", "PRO 5945",
        "PRO 5950", "PRO 5850", "PRO 5750", "PRO 5650", "PRO 5645",
        "V3C48", "V3C18", "V3C16", "V3C14", "V3B14", "V3B06"
    };

            // --- The Master Check ---
            foreach (var m in zen5) if (cpu.Contains(m)) return true;
            foreach (var m in zen4) if (cpu.Contains(m)) return true;
            foreach (var m in zen3) if (cpu.Contains(m)) return true;
            foreach (var m in enterprise) if (cpu.Contains(m)) return true;

            return false;
        }

        private bool IsIntelKSHSPSupported()
        {
            string cpu = GetCPUModel().ToUpper();
            if (!cpu.Contains("INTEL")) return false;

            // --- CORE ULTRA / CORE SERIES 1 & 2 (Meteor, Arrow, Lunar Lake) ---
            string[] coreUltra = {
        "ULTRA 9", "ULTRA 7", "ULTRA 5", "ULTRA 3",
        "288V", "268V", "258V", "256V", "238V", "236V", "228V", "226V", // Lunar Lake SKUs
        "270H", "250H", "250U", "165H", "155H", "135H", "125H", "165U", "155U" // Meteor/Arrow SKUs
    };

            // --- CORE i SERIES (11th to 14th Gen) ---
            // Using "-1" ensures we only catch 11, 12, 13, 14, and 15 series.
            string[] coreGenerations = { "-11", "-12", "-13", "-14", "-15" };

            // --- XEON SCALABLE & WORKSTATION (Ice Lake-SP, Sapphire Rapids, Emerald Rapids, Granite Rapids) ---
            string[] xeonScalable = { 
        // Platinum/Gold/Silver/Bronze (3rd Gen+)
        " 83", " 84", " 85", " 63", " 64", " 65", " 53", " 54", " 55", " 43", " 44", " 45", " 34",
        // Xeon W (2400/3400/3500/2500)
        "W9-3", "W7-3", "W5-3", "W3-3", "W9-2", "W7-2", "W5-2", "W3-2",
        // Xeon 6 (6900/6700 series)
        "6980P", "6979P", "6972P", "6780E", "6766E", "6756E", "6746E", "6731E"
    };

            // --- ATOM, PENTIUM & CELERON (Jasper Lake, Elkhart Lake, Alder Lake-N) ---
            // These specific E-core architectures support CET.
            string[] modernSmallCores = {
        "N6000", "N6005", "N5100", "N5105", "N4500", "N4505", // Jasper Lake
        "J6412", "J6413", "N6210", "N6211", // Elkhart Lake
        "N100", "N200", "N300", "N305", "N95", "N97", "G7400", "G6900" // Alder Lake-N
    };

            // --- MASTER CHECK ---
            foreach (var m in coreUltra) if (cpu.Contains(m)) return true;

            foreach (var gen in coreGenerations)
            {
                if (cpu.Contains(gen)) return true;
            }

            foreach (var x in xeonScalable)
            {
                if (cpu.Contains(x)) return true;
            }

            foreach (var b in modernSmallCores)
            {
                if (cpu.Contains(b)) return true;
            }

            return false;
        }

        public bool IsHardwareWhitelisted()
        {
            return IsAMDKSHSPSupported() || IsIntelKSHSPSupported();
        }

        private int GetCurrentState(string regPath)
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regPath))
                {
                    if (key != null)
                    {
                        object val = key.GetValue("Enabled");
                        return (val != null) ? Convert.ToInt32(val) : -1;
                    }
                }
            }
            catch { }
            return -1;
        }

        private void LogToConsole(string text)
        {
            if (txtConsole.InvokeRequired)
            {
                txtConsole.Invoke(new Action(() => LogToConsole(text)));
                return;
            }
            txtConsole.AppendText($"[{DateTime.Now:HH:mm:ss}] {text}{Environment.NewLine}");
        }

        private async void RunDriverAudit()
        {
            txtConsole.Clear();
            pnlConsole.Visible = true;
            pnlConsole.BringToFront();
            SetControlsEnabled(false);

            try
            {
                LogToConsole("--- INITIATING SECURITY AUDIT ---");

                LogToConsole("Auditing for HVCI & KSHSP compatibility...");

                string disclaimer = "\n\nNote: This scan may yield false positives, and some hidden " +
                        "drivers might not appear.";

                List<string> conflicts = await DeepScanDriverStoreAsync();

                if (conflicts.Count > 0)
                {
                    LogToConsole($"--- AUDIT COMPLETE: {conflicts.Count} CONFLICTS FOUND ---");
                    foreach (var driver in conflicts)
                    {
                        LogToConsole($"[!] FLAG: {driver}");
                    }

                    string list = string.Join("\n", conflicts);
                    MaterialMessageBox.Show(this,
                        $"Security Audit Results:\n\n{list}{disclaimer}",
                        "Incompatible Drivers Found");
                }
                else
                {
                    LogToConsole("--- AUDIT COMPLETE: SYSTEM VERIFIED ---");
                    MaterialMessageBox.Show(this, "No incompatible drivers were detected for HVCI or KSHSP.", "Audit Clear");
                }
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private async Task<List<string>> DeepScanDriverStoreAsync()
        {
            return await Task.Run(() =>
            {
                List<string> flaggedDrivers = new List<string>();
                try
                {
                    string script = @"
                $drivers = Get-WindowsDriver -Online -All | Where-Object { $_.Inbox -eq $false }
                
                # List of known 'problematic' driver keywords
                $keywords = @('*wdcsam*', '*vbox*', '*ssud*', '*lgcore*', '*ene*', '*gio*', '*ngmsvs*')

                foreach ($d in $drivers) {
                    $found = $false;
                    foreach ($k in $keywords) {
                        if ($d.OriginalFileName -like $k) {
                            $found = $true;
                            break;
                        }
                    }
                    
                    if ($found) {
                        $d.PublishedName + ' (' + (Split-Path $d.OriginalFileName -Leaf) + ')'
                    }
                }
            ";

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-NoProfile -WindowStyle Hidden -Command \"{script}\"",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    };

                    using (Process process = Process.Start(psi))
                    {
                        while (!process.StandardOutput.EndOfStream)
                        {
                            string line = process.StandardOutput.ReadLine();
                            if (!string.IsNullOrWhiteSpace(line)) flaggedDrivers.Add(line);
                        }
                        process.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() => LogToConsole("Deep Scan Error: " + ex.Message)));
                }
                return flaggedDrivers;
            });
        }

        private void btnCheckDrivers_Click(object sender, EventArgs e)
        {
            RunDriverAudit();
        }

        private async void btnAction_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();

            string tag = ((MaterialButton)sender).Tag.ToString();
            bool isEnabling = tag.EndsWith("_ON");
            string feature = tag.Split('_')[0];

            string regPath = (feature == "KSHSP")
                ? @"SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\KernelShadowStacks"
                : @"SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity";

            string policyPath = @"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard";

            pnlConsole.Visible = true;
            pnlConsole.BringToFront();

            LogToConsole($"--- Starting Action: {feature} ---");

            int currentState = GetCurrentState(regPath);
            string stateString = (currentState == 1) ? "ENABLED" : (currentState == 0) ? "DISABLED" : "NOT FOUND/NOT SET";
            LogToConsole($"Current System State: {stateString}");

            if ((isEnabling && currentState == 1) || (!isEnabling && currentState == 0))
            {
                LogToConsole($"ABORT: {feature} is already in the requested state.");
                return;
            }

            if (feature == "KSHSP" && isEnabling)
            {
                LogToConsole("Checking Prerequisites: VBS & HVCI...");

                int hvciState = GetCurrentState(@"SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity");

                if (hvciState != 1)
                {
                    LogToConsole("FAILURE: Memory Integrity (HVCI) must be enabled before KSHSP.");
                    MaterialMessageBox.Show(this, "Please enable Memory Integrity and restart your system before enabling Kernel Stack Protection.", "Prerequisite Missing");
                    return;
                }

                LogToConsole("Performing Hardware Compatibility Check...");
                bool supported = IsHardwareWhitelisted();

                if (!supported)
                {
                    string cpuModel = GetCPUModel();
                    LogToConsole($"WARNING: Hardware/VBS capability check failed on {cpuModel}.");

                    string warn1 = $"CPU Detected: {cpuModel}\n{feature}: System reports incompatible.\n\n" +
                                   "This may be due to incompatible drivers, BIOS settings (SVM/NX), or VBS status.\n" +
                                   "Forcing this may result in a Boot Loop or BSOD.\n\n" +
                                   "Proceed with Force Patch?";

                    if (MaterialMessageBox.Show(this, warn1, "Security Override", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        LogToConsole("User cancelled action after hardware warning.");
                        return;
                    }
                }
                else
                {
                    LogToConsole("Hardware and VBS prerequisites verified.");
                }
            }

            string actionVerb = isEnabling ? "Enable" : "Disable";
            if (MaterialMessageBox.Show(this, $"{actionVerb} {feature}?", "Confirm Action", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LogToConsole($"Applying Policy and Scenario overrides...");
                try
                {
                    await Task.Run(() => {
                        using (RegistryKey key = Registry.LocalMachine.CreateSubKey(regPath))
                        {
                            key.SetValue("Enabled", isEnabling ? 1 : 0, RegistryValueKind.DWord);
                        }
                        if (feature == "KSHSP")
                        {
                            using (RegistryKey policyKey = Registry.LocalMachine.CreateSubKey(policyPath))
                            {
                                policyKey.SetValue("HvcicpKernelModeHardwareEnforcedStackProtection", isEnabling ? 1 : 0, RegistryValueKind.DWord);
                            }
                        }
                    });

                    LogToConsole($"SUCCESS: {feature} {actionVerb}d successfully.");
                    LogToConsole("RESTART REQUIRED to synchronize kernel stacks.");
                }
                catch (Exception ex)
                {
                    LogToConsole($"EXECUTION ERROR: {ex.Message}");
                }
            }
            else
            {
                LogToConsole("Action cancelled by user.");
            }
        }

        private void btnCloseConsole_Click(object sender, EventArgs e)
        {
            pnlConsole.Visible = false;
            txtConsole.Clear();
        }
    }
}