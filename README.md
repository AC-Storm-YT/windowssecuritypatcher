<p align="center">
  <img src="iconwsp.png" alt="Windows Security Patcher shield" width="160">
</p>

<h1 align="center">Windows Security Patcher</h1>

<p align="center">
  A Windows 11 utility for repairing inaccessible or greyed-out Memory Integrity and Kernel-mode Hardware-enforced Stack Protection settings.
</p>

<p align="center">
  <img alt="Platform" src="https://img.shields.io/badge/platform-Windows%2011-0078D4">
  <img alt=".NET Framework" src="https://img.shields.io/badge/.NET%20Framework-4.8-512BD4">
  <img alt="Version" src="https://img.shields.io/badge/version-1.0.0-6CC04A">
</p>

> [!WARNING]
> This application changes system-wide Windows security configuration. An incorrect or unsupported configuration can cause instability, a blue screen, or a boot loop. Create a restore point or system backup first, run the driver scan, and do not force-enable a feature on unsupported hardware unless you understand the risk.

## Overview

Windows Security Patcher provides direct controls for security settings that can become unavailable through the standard Windows Security interface. It can:

- Enable or disable **Memory Integrity (HVCI)**.
- Enable or disable **Kernel-mode Hardware-enforced Stack Protection (KSHSP)**.
- Check the Windows driver store for known driver patterns that may conflict with HVCI or KSHSP.
- Perform Windows, Windows Security app, and CPU compatibility checks before applying changes.
- Display an in-app activity log for audits and configuration changes.

This is an unofficial third-party utility and is not affiliated with or endorsed by Microsoft.

## Requirements

- Windows 11 22H2 or newer (build `22621` or later).
- Windows Security app version `1000.25330.0.9000` or newer.
- .NET Framework 4.8.
- An administrator account and elevated execution.
- Compatible CPU, firmware settings, and drivers for the feature being enabled.
- A restart after changing either security feature.

The built-in KSHSP hardware check recognizes supported families including AMD Zen 3 through Zen 5 and modern Intel Core, Core Ultra, Xeon, Atom, Pentium, and Celeron models. The check is a safeguard, not a guarantee of compatibility.

## Usage

1. Create a Windows restore point or another known-good backup.
2. Right-click `Windows Security Patcher.exe` and select **Run as administrator**.
3. Read and accept the authorization notice.
4. Select **Scan System for Driver Conflicts** and review any flagged drivers.
5. Choose the action you need:
   - **Enable Memory Integrity**
   - **Disable Memory Integrity**
   - **Enable Kernel Stack Protection**
   - **Disable Kernel Stack Protection**
6. Confirm the requested action and review the in-app log.
7. Restart Windows to apply the new configuration.

### Recommended enablement order

KSHSP depends on Memory Integrity. When enabling both features:

1. Enable Memory Integrity.
2. Restart Windows.
3. Reopen the patcher as administrator.
4. Enable Kernel Stack Protection.
5. Restart Windows again.

## What the app changes

The patcher sets `Enabled` DWORD values under these system registry paths:

```text
HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity
HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\KernelShadowStacks
```

For KSHSP, it also updates the following policy value:

```text
HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DeviceGuard
  HvcicpKernelModeHardwareEnforcedStackProtection
```

Enabling a feature writes `1`; disabling it writes `0`. Changes do not fully take effect until Windows restarts.

## Driver conflict scan

The audit runs `Get-WindowsDriver -Online -All`, examines non-inbox drivers, and flags filenames matching a small list of known problematic patterns. It currently looks for patterns associated with:

- Western Digital (`wdcsam`)
- VirtualBox (`vbox`)
- Samsung USB drivers (`ssud`)
- Logitech Gaming Software (`lgcore`)
- ENE components (`ene`)
- GIGABYTE utilities (`gio`)
- `ngmsvs` drivers

The scan is heuristic: it may report false positives, and it cannot guarantee that every incompatible or hidden driver will be found.

## Build from source

### Prerequisites

- Visual Studio 2022 with the **.NET desktop development** workload.
- .NET Framework 4.8 Developer Pack.
- NuGet package restore enabled.

### Visual Studio

1. Clone the repository:

   ```powershell
   git clone https://github.com/AC-Storm-YT/windowssecuritypatcher.git
   cd windowssecuritypatcher
   ```

2. Open `Windows Security Patcher.sln` in Visual Studio.
3. Restore the NuGet packages if Visual Studio does not restore them automatically.
4. Select the `Release` configuration.
5. Choose **Build > Build Solution**.

The compiled application will be written to:

```text
Windows Security Patcher\bin\Release\
```

### Developer PowerShell

From a Visual Studio Developer PowerShell prompt:

```powershell
nuget restore "Windows Security Patcher.sln"
msbuild "Windows Security Patcher.sln" /p:Configuration=Release /p:Platform="Any CPU"
```

## Dependencies

- [MaterialSkin.2](https://github.com/IgnaceMaes/MaterialSkin) — Material Design controls for Windows Forms.
- [Fody](https://github.com/Fody/Fody) — extensible build-time assembly weaving.
- [Costura.Fody](https://github.com/Fody/Costura) — embeds managed dependencies in the output assembly.

## Project layout

```text
Windows Security Patcher.sln
Windows Security Patcher/
├── Form1.cs                 # Main UI, feature controls, and driver audit
├── Program.cs               # Startup and operating-system checks
├── app.manifest             # Windows execution-level configuration
├── packages.config          # NuGet dependencies
└── Windows Security Patcher.csproj
```

## Contributing

Issues and pull requests are welcome. When reporting a compatibility problem, include your Windows build, Windows Security app version, CPU model, and the relevant in-app log output. Do not include private system or account information.

## Disclaimer

Use this software at your own risk. Security features exist to protect the operating system, and disabling or overriding them can reduce protection. The authors and contributors are not responsible for data loss, system instability, boot failure, reduced security, or other damage resulting from use of this project.
