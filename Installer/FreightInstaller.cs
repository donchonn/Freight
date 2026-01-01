using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Reflection;

namespace FreightInstaller
{
    public class InstallerForm : Form
    {
        private static readonly string AppName = "Freight 3.0";
        private static readonly string ExeName = "Freight 3.0.exe";

        // Embedded resource names
        private static readonly Dictionary<string, string> EmbeddedFiles = new Dictionary<string, string>
        {
            { "Freight3.exe", "Freight 3.0.exe" },
            { "Freight3.exe.config", "Freight 3.0.exe.config" },
            { "Newtonsoft.Json.dll", "Newtonsoft.Json.dll" },
            { "config.json", "config.json" }
        };
        // AppData\Local\Freight에 모든 파일 설치 (관리자 권한 불필요)
        private static readonly string DefaultInstallPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Freight"
        );
        private static readonly string StartupRegistryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        // 사용자별 언인스톨 레지스트리 (HKCU)
        private static readonly string UninstallRegistryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Freight";

        private Panel headerPanel;
        private Label titleLabel;
        private Label subtitleLabel;
        private TextBox pathTextBox;
        private Button browseButton;
        private Button installButton;
        private Button updateButton;
        private Button uninstallButton;
        private Button cancelButton;
        private ProgressBar progressBar;
        private Label statusLabel;
        private CheckBox startupCheckBox;
        private bool isAlreadyInstalled = false;

        public InstallerForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form settings
            this.Text = "Freight 3.0 Setup";
            this.Size = new Size(500, 380);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.Font = new Font("Segoe UI", 9F);

            // Header Panel
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(30, 30, 30)
            };

            titleLabel = new Label
            {
                Text = "Freight 3.0",
                Font = new Font("Segoe UI Light", 24F),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 15)
            };

            subtitleLabel = new Label
            {
                Text = "Command Launcher & Automation Tool",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(150, 150, 150),
                AutoSize = true,
                Location = new Point(22, 52)
            };

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(subtitleLabel);

            // Installation path label
            var pathLabel = new Label
            {
                Text = "Installation Path:",
                ForeColor = Color.White,
                Location = new Point(20, 100),
                AutoSize = true
            };

            // Path TextBox
            pathTextBox = new TextBox
            {
                Text = DefaultInstallPath,
                Location = new Point(20, 125),
                Size = new Size(360, 25),
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Browse Button
            browseButton = new Button
            {
                Text = "Browse...",
                Location = new Point(390, 124),
                Size = new Size(80, 27),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            browseButton.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            browseButton.Click += BrowseButton_Click;

            // Startup CheckBox
            startupCheckBox = new CheckBox
            {
                Text = "Start Freight when Windows starts",
                ForeColor = Color.White,
                Location = new Point(20, 165),
                AutoSize = true,
                Checked = true
            };

            // Progress Bar
            progressBar = new ProgressBar
            {
                Location = new Point(20, 210),
                Size = new Size(450, 23),
                Style = ProgressBarStyle.Continuous,
                Visible = false
            };

            // Status Label
            statusLabel = new Label
            {
                Text = "",
                ForeColor = Color.FromArgb(100, 200, 100),
                Location = new Point(20, 240),
                Size = new Size(450, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Install Button
            installButton = new Button
            {
                Text = "Install",
                Location = new Point(20, 280),
                Size = new Size(100, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI Semibold", 10F)
            };
            installButton.FlatAppearance.BorderSize = 0;
            installButton.Click += InstallButton_Click;

            // Update Button
            updateButton = new Button
            {
                Text = "Update",
                Location = new Point(130, 280),
                Size = new Size(100, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(60, 150, 60),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI Semibold", 10F),
                Enabled = false
            };
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.Click += UpdateButton_Click;

            // Uninstall Button
            uninstallButton = new Button
            {
                Text = "Uninstall",
                Location = new Point(240, 280),
                Size = new Size(100, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(180, 60, 60),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI Semibold", 10F)
            };
            uninstallButton.FlatAppearance.BorderSize = 0;
            uninstallButton.Click += UninstallButton_Click;

            // Cancel Button
            cancelButton = new Button
            {
                Text = "Cancel",
                Location = new Point(350, 280),
                Size = new Size(100, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(70, 70, 70),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10F)
            };
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.Click += (s, e) => this.Close();

            // Add controls
            this.Controls.Add(headerPanel);
            this.Controls.Add(pathLabel);
            this.Controls.Add(pathTextBox);
            this.Controls.Add(browseButton);
            this.Controls.Add(startupCheckBox);
            this.Controls.Add(progressBar);
            this.Controls.Add(statusLabel);
            this.Controls.Add(installButton);
            this.Controls.Add(updateButton);
            this.Controls.Add(uninstallButton);
            this.Controls.Add(cancelButton);

            this.ResumeLayout(false);

            // Check if already installed
            CheckInstallationStatus();
        }

        private void CheckInstallationStatus()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(UninstallRegistryKey))
            {
                if (key != null)
                {
                    string installedPath = key.GetValue("InstallLocation")?.ToString();
                    if (!string.IsNullOrEmpty(installedPath))
                    {
                        pathTextBox.Text = installedPath;
                        statusLabel.Text = "Freight 3.0 is currently installed";
                        statusLabel.ForeColor = Color.FromArgb(100, 180, 255);
                        isAlreadyInstalled = true;
                        updateButton.Enabled = true;
                    }
                }
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select Installation Folder";
                dialog.SelectedPath = pathTextBox.Text;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pathTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        private async void InstallButton_Click(object sender, EventArgs e)
        {
            SetButtonsEnabled(false);
            progressBar.Visible = true;
            progressBar.Value = 0;

            try
            {
                await Task.Run(() => PerformInstallation());

                progressBar.Value = 100;
                statusLabel.Text = "Installation completed successfully!";
                statusLabel.ForeColor = Color.FromArgb(100, 200, 100);

                var result = MessageBox.Show(
                    "Freight 3.0 has been installed successfully!\n\nWould you like to start Freight now?",
                    "Installation Complete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes)
                {
                    string exePath = Path.Combine(pathTextBox.Text, ExeName);
                    if (File.Exists(exePath))
                    {
                        Process.Start(exePath);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Installation failed!";
                statusLabel.ForeColor = Color.FromArgb(255, 100, 100);
                MessageBox.Show($"Installation failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetButtonsEnabled(true);
            }
        }

        private void PerformInstallation()
        {
            string installPath = pathTextBox.Text;

            // Create directory
            UpdateStatus("Creating installation directory...", 10);
            if (!Directory.Exists(installPath))
            {
                Directory.CreateDirectory(installPath);
            }

            // Extract embedded files
            UpdateStatus("Extracting files...", 20);
            int fileProgress = 20;
            int progressPerFile = 40 / EmbeddedFiles.Count;

            foreach (var kvp in EmbeddedFiles)
            {
                string destPath = Path.Combine(installPath, kvp.Value);
                ExtractEmbeddedResource(kvp.Key, destPath);
                fileProgress += progressPerFile;
                UpdateProgress(fileProgress);
            }

            // Copy installer for uninstallation
            UpdateStatus("Setting up uninstaller...", 65);
            string installerSource = Process.GetCurrentProcess().MainModule.FileName;
            string installerDest = Path.Combine(installPath, "FreightInstaller.exe");
            if (File.Exists(installerSource) && installerSource != installerDest)
            {
                File.Copy(installerSource, installerDest, true);
            }

            // Register startup if checked
            if (startupCheckBox.Checked)
            {
                UpdateStatus("Registering Windows startup...", 75);
                string exePath = Path.Combine(installPath, ExeName);
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupRegistryKey, true))
                {
                    key.SetValue(AppName, $"\"{exePath}\"");
                }
            }

            // Create uninstall registry entry (HKCU - 관리자 권한 불필요)
            UpdateStatus("Creating uninstall entry...", 80);
            string exeFullPath = Path.Combine(installPath, ExeName);
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(UninstallRegistryKey))
            {
                key.SetValue("DisplayName", AppName);
                key.SetValue("DisplayVersion", "3.0.0.0");
                key.SetValue("Publisher", "Freight");
                key.SetValue("InstallLocation", installPath);
                key.SetValue("UninstallString", $"\"{installerDest}\"");
                key.SetValue("DisplayIcon", exeFullPath);
                key.SetValue("NoModify", 1, RegistryValueKind.DWord);
                key.SetValue("NoRepair", 1, RegistryValueKind.DWord);
            }

            // Create Start Menu shortcut (사용자 전용)
            UpdateStatus("Creating shortcuts...", 88);
            CreateShortcut(exeFullPath, installPath);

            // Create copy.txt (for Ctrl+Shift+S hotkey)
            UpdateStatus("Creating copy.txt...", 95);
            string copyTxtPath = Path.Combine(installPath, "copy.txt");
            if (!File.Exists(copyTxtPath))
            {
                File.WriteAllText(copyTxtPath, "");
            }

            UpdateStatus("Installation complete!", 100);
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!isAlreadyInstalled)
            {
                MessageBox.Show(
                    "Freight 3.0 is not installed. Please install first.",
                    "Not Installed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Ask about config.json preservation
            var configResult = MessageBox.Show(
                "설정 파일(config.json)을 유지하시겠습니까?\n\n" +
                "예: 기존 명령어 설정을 유지합니다.\n" +
                "아니오: 설정을 초기화합니다.",
                "설정 파일 유지 여부",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (configResult == DialogResult.Cancel)
                return;

            bool keepConfig = (configResult == DialogResult.Yes);

            SetButtonsEnabled(false);
            progressBar.Visible = true;
            progressBar.Value = 0;

            try
            {
                await Task.Run(() => PerformUpdate(keepConfig));

                progressBar.Value = 100;
                statusLabel.Text = "Update completed successfully!";
                statusLabel.ForeColor = Color.FromArgb(100, 200, 100);

                var result = MessageBox.Show(
                    "Freight 3.0 has been updated successfully!\n\nWould you like to start Freight now?",
                    "Update Complete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes)
                {
                    string exePath = Path.Combine(pathTextBox.Text, ExeName);
                    if (File.Exists(exePath))
                    {
                        Process.Start(exePath);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Update failed!";
                statusLabel.ForeColor = Color.FromArgb(255, 100, 100);
                MessageBox.Show($"Update failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetButtonsEnabled(true);
            }
        }

        private void PerformUpdate(bool keepConfig)
        {
            string installPath = pathTextBox.Text;
            string configBackupPath = Path.Combine(Path.GetTempPath(), "freight_config_backup.json");

            // Kill running process
            UpdateStatus("Closing Freight...", 5);
            foreach (var process in Process.GetProcessesByName("Freight 3.0"))
            {
                try
                {
                    process.Kill();
                    process.WaitForExit(3000);
                }
                catch { }
            }

            // Backup config.json if user wants to keep it
            string configPath = Path.Combine(installPath, "config.json");
            if (keepConfig && File.Exists(configPath))
            {
                UpdateStatus("Backing up settings...", 15);
                File.Copy(configPath, configBackupPath, true);
            }

            // Extract program files from embedded resources
            UpdateStatus("Updating files...", 30);
            int fileProgress = 30;
            int progressPerFile = 50 / EmbeddedFiles.Count;

            foreach (var kvp in EmbeddedFiles)
            {
                // config.json은 백업 여부에 따라 처리
                if (kvp.Key == "config.json" && keepConfig)
                    continue;

                string destPath = Path.Combine(installPath, kvp.Value);
                ExtractEmbeddedResource(kvp.Key, destPath);
                fileProgress += progressPerFile;
                UpdateProgress(fileProgress);
            }

            // Restore config if backed up
            if (keepConfig && File.Exists(configBackupPath))
            {
                UpdateStatus("Restoring settings...", 75);
                File.Copy(configBackupPath, configPath, true);
                File.Delete(configBackupPath);
            }

            // Update installer
            UpdateStatus("Updating installer...", 85);
            string installerSource = Process.GetCurrentProcess().MainModule.FileName;
            string installerDest = Path.Combine(installPath, "FreightInstaller.exe");
            if (File.Exists(installerSource) && installerSource != installerDest)
            {
                File.Copy(installerSource, installerDest, true);
            }

            // Update registry version (HKCU)
            UpdateStatus("Updating registry...", 90);
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(UninstallRegistryKey, true))
            {
                if (key != null)
                {
                    key.SetValue("DisplayVersion", "3.0.0.0");
                }
            }

            // Create copy.txt if not exists
            UpdateStatus("Checking copy.txt...", 95);
            string copyTxtPath = Path.Combine(installPath, "copy.txt");
            if (!File.Exists(copyTxtPath))
            {
                File.WriteAllText(copyTxtPath, "");
            }

            UpdateStatus("Update complete!", 100);
        }

        private async void UninstallButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to uninstall Freight 3.0?\n\nThis will remove all program files and settings.",
                "Confirm Uninstall",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            SetButtonsEnabled(false);
            progressBar.Visible = true;
            progressBar.Value = 0;

            try
            {
                await Task.Run(() => PerformUninstallation());

                progressBar.Value = 100;
                statusLabel.Text = "Uninstallation completed!";
                statusLabel.ForeColor = Color.FromArgb(100, 200, 100);

                MessageBox.Show(
                    "Freight 3.0 has been uninstalled successfully!",
                    "Uninstall Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Uninstallation failed!";
                statusLabel.ForeColor = Color.FromArgb(255, 100, 100);
                MessageBox.Show($"Uninstallation failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetButtonsEnabled(true);
            }
        }

        private void PerformUninstallation()
        {
            // Kill running process
            UpdateStatus("Closing Freight...", 10);
            foreach (var process in Process.GetProcessesByName("Freight 3.0"))
            {
                try
                {
                    process.Kill();
                    process.WaitForExit(3000);
                }
                catch { }
            }

            // Get install path (HKCU)
            string installPath = pathTextBox.Text;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(UninstallRegistryKey))
            {
                if (key != null)
                {
                    installPath = key.GetValue("InstallLocation")?.ToString() ?? installPath;
                }
            }

            // Remove startup entry
            UpdateStatus("Removing startup entry...", 25);
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupRegistryKey, true))
            {
                if (key?.GetValue(AppName) != null)
                {
                    key.DeleteValue(AppName);
                }
            }

            // Remove uninstall registry (HKCU)
            UpdateStatus("Removing registry entries...", 40);
            try
            {
                Registry.CurrentUser.DeleteSubKey(UninstallRegistryKey, false);
            }
            catch { }

            // Remove Start Menu shortcut (사용자 전용)
            UpdateStatus("Removing shortcuts...", 55);
            string shortcutPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.StartMenu),
                "Programs",
                "Freight 3.0.lnk"
            );
            if (File.Exists(shortcutPath))
            {
                File.Delete(shortcutPath);
            }

            // Remove Desktop shortcut (사용자 전용)
            string desktopShortcut = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                "Freight 3.0.lnk"
            );
            if (File.Exists(desktopShortcut))
            {
                File.Delete(desktopShortcut);
            }

            // Delete files
            UpdateStatus("Removing program files...", 70);
            if (Directory.Exists(installPath))
            {
                string[] filesToDelete = new string[]
                {
                    "Freight 3.0.exe",
                    "Freight 3.0.exe.config",
                    "Newtonsoft.Json.dll",
                    "config.json",
                    "copy.txt"
                };

                foreach (string file in filesToDelete)
                {
                    string filePath = Path.Combine(installPath, file);
                    if (File.Exists(filePath))
                    {
                        try { File.Delete(filePath); } catch { }
                    }
                }

                // Schedule cleanup
                string installerPath = Path.Combine(installPath, "FreightInstaller.exe");
                string batchPath = Path.Combine(Path.GetTempPath(), "freight_cleanup.bat");

                File.WriteAllText(batchPath,
                    $"@echo off\r\n" +
                    $"ping 127.0.0.1 -n 3 > nul\r\n" +
                    $"del \"{installerPath}\" 2>nul\r\n" +
                    $"rmdir \"{installPath}\" 2>nul\r\n" +
                    $"del \"%~f0\"\r\n");

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = batchPath,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                };
                Process.Start(psi);
            }

            UpdateStatus("Uninstallation complete!", 100);
        }

        private void UpdateStatus(string message, int progress)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    statusLabel.Text = message;
                    progressBar.Value = progress;
                });
            }
            else
            {
                statusLabel.Text = message;
                progressBar.Value = progress;
            }
            System.Threading.Thread.Sleep(200);
        }

        private void UpdateProgress(int progress)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { progressBar.Value = progress; });
            }
            else
            {
                progressBar.Value = progress;
            }
        }

        private void SetButtonsEnabled(bool enabled)
        {
            installButton.Enabled = enabled;
            updateButton.Enabled = enabled && isAlreadyInstalled;
            uninstallButton.Enabled = enabled;
            browseButton.Enabled = enabled;
            pathTextBox.Enabled = enabled;
            startupCheckBox.Enabled = enabled;
        }

        private bool IsAdministrator()
        {
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        private void ExtractEmbeddedResource(string resourceName, string destPath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new FileNotFoundException($"Embedded resource not found: {resourceName}");

                using (FileStream fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
            }
        }

        private void ExtractAllFiles(string installPath, bool skipConfig = false)
        {
            foreach (var kvp in EmbeddedFiles)
            {
                if (skipConfig && kvp.Key == "config.json")
                    continue;

                string destPath = Path.Combine(installPath, kvp.Value);
                ExtractEmbeddedResource(kvp.Key, destPath);
            }
        }

        private void CreateShortcut(string targetPath, string installPath)
        {
            try
            {
                // Start Menu shortcut (사용자 전용 - 관리자 권한 불필요)
                string startMenuPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.StartMenu),
                    "Programs",
                    "Freight 3.0.lnk"
                );

                // Desktop shortcut (사용자 전용)
                string desktopPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                    "Freight 3.0.lnk"
                );

                string psScript = $@"
$WshShell = New-Object -ComObject WScript.Shell

# Start Menu shortcut
$Shortcut = $WshShell.CreateShortcut('{startMenuPath.Replace("'", "''")}')
$Shortcut.TargetPath = '{targetPath.Replace("'", "''")}'
$Shortcut.WorkingDirectory = '{installPath.Replace("'", "''")}'
$Shortcut.Description = 'Freight 3.0 - Command Launcher'
$Shortcut.Save()

# Desktop shortcut
$Shortcut2 = $WshShell.CreateShortcut('{desktopPath.Replace("'", "''")}')
$Shortcut2.TargetPath = '{targetPath.Replace("'", "''")}'
$Shortcut2.WorkingDirectory = '{installPath.Replace("'", "''")}'
$Shortcut2.Description = 'Freight 3.0 - Command Launcher'
$Shortcut2.Save()
";
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{psScript.Replace("\"", "\\\"")}\"",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                Process p = Process.Start(psi);
                p.WaitForExit();
            }
            catch { }
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InstallerForm());
        }
    }
}
