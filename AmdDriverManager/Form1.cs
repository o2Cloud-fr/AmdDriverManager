using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AmdDriverManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowStartupMessage();
            LoadAmdDriverInfo();
            ProcessArguments(Environment.GetCommandLineArgs());

            this.FormBorderStyle = FormBorderStyle.FixedDialog;  // Empêche le redimensionnement
            this.MaximizeBox = false;  // Désactive le bouton de maximisation
            this.MinimizeBox = false;  // Désactive le bouton de minimisation (optionnel)
        }

        private void ShowStartupMessage()
        {
            // Vérifie si l'application est en mode sans échec
            if (!IsSafeMode())
            {
                MessageBox.Show(
                    "AmdDriverManager a détecté que vous n'êtes PAS en mode sans échec...\n" +
                    "Pour un nettoyage sans erreur, il est recommandé de redémarrer en mode sans échec.",
                    "Attention",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private bool IsSafeMode()
        {
            // Vérifie si l'application est en mode sans échec en vérifiant une clé du registre.
            string bootMode = Environment.GetEnvironmentVariable("SAFEBOOT");

            // Si "SAFEBOOT" est défini dans l'environnement, nous sommes en mode sans échec.
            return !string.IsNullOrEmpty(bootMode);
        }

        private void LoadAmdDriverInfo()
        {
            try
            {
                string finalVersion = "";

                // Tentative 1: WMI
                var amdDriverVersions = GetAmdDriverVersions();
                if (amdDriverVersions.Count > 0)
                {
                    foreach (var version in amdDriverVersions)
                    {
                        lstDriverVersions.Items.Add(version);
                        if (string.IsNullOrEmpty(finalVersion))
                        {
                            finalVersion = version;
                        }
                    }
                }
                else
                {
                    lstDriverVersions.Items.Add("No AMD drivers found via WMI.");
                }

                // Tentative 2: AMD command line tool (par exemple, `clinfo` ou autre)
                try
                {
                    string amdSmiOutput = ExecuteAmdSmiCommand();
                    if (!string.IsNullOrEmpty(amdSmiOutput))
                    {
                        if (string.IsNullOrEmpty(finalVersion))
                        {
                            finalVersion = $"Version (AMDSMI): {amdSmiOutput}";
                        }
                    }
                }
                catch
                {
                    // Continue si la commande AMD échoue
                }

                // Tentative 3: Registre
                try
                {
                    string registryDriverVersion = GetAmdDriverVersionFromRegistry();
                    if (!string.IsNullOrEmpty(registryDriverVersion))
                    {
                        if (string.IsNullOrEmpty(finalVersion))
                        {
                            finalVersion = $"Version (Registry): {registryDriverVersion}";
                        }
                    }
                }
                catch
                {
                    // Continue si la lecture du registre échoue
                }

                // Extraire et afficher uniquement les 6 derniers chiffres de la version
                if (!string.IsNullOrEmpty(finalVersion))
                {
                    string versionToDisplay = finalVersion.Length >= 6 ? finalVersion.Substring(finalVersion.Length - 6) : finalVersion;
                    lblDriverVersion.Text = $"AMD Driver {versionToDisplay}";
                }
                else
                {
                    lblDriverVersion.Text = "Aucune version de pilote AMD trouvée.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading AMD driver info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> GetAmdDriverVersions()
        {
            var driverVersions = new List<string>();
            string query = "SELECT DriverVersion, DeviceName FROM Win32_PnPSignedDriver WHERE DeviceName LIKE '%AMD Radeon%'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject obj in searcher.Get())
            {
                string version = obj["DriverVersion"]?.ToString();
                string deviceName = obj["DeviceName"]?.ToString();

                if (!string.IsNullOrEmpty(version) && !string.IsNullOrEmpty(deviceName))
                {
                    driverVersions.Add($"Device: {deviceName}, Version: {version}");
                }
            }

            return driverVersions;
        }

        private string ExecuteAmdSmiCommand()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c amd-smi --query-gpu=driver_version --format=csv,noheader",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (process.ExitCode == 0 && !string.IsNullOrWhiteSpace(output))
                    {
                        return output.Trim();
                    }
                    else
                    {
                        throw new Exception($"amd-smi error: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to execute amd-smi: {ex.Message}");
            }
        }

        private string GetAmdDriverVersionFromRegistry()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\AMD\Driver"))
                {
                    if (key != null)
                    {
                        object driverVersion = key.GetValue("DriverVersion");
                        if (driverVersion != null)
                        {
                            return driverVersion.ToString();
                        }
                    }
                    throw new Exception("Driver version not found in the registry.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get AMD driver version from registry: {ex.Message}");
            }
        }

        private void DisplayDriverVersion()
        {
            try
            {
                string driverVersion = GetAmdDriverVersionFromRegistry();
                lblDriverVersion.Text = $"AMD Driver Version: {driverVersion}";
            }
            catch (Exception ex)
            {
                lblDriverVersion.Text = $"Error: {ex.Message}";
            }
        }

        // Méthode pour analyser les arguments de ligne de commande
        private void ProcessArguments(string[] args)
        {
            // Vérifier si le tableau args contient suffisamment d'éléments avant d'accéder à args[1]
            if (args.Length > 1)
            {
                if (args[1].ToLower() == "/uninstallrestart")
                {
                    ExecuteUninstallRestart();
                }
                else if (args[1].ToLower() == "/uninstallnorestart")
                {
                    ExecuteUninstallNoRestart();
                }
                else if (args[1].ToLower() == "/uninstallshutdown")
                {
                    ExecuteUninstallShutdown();
                }
            }
            else
            {
                // Si les arguments sont insuffisants, afficher un message d'erreur ou prendre une autre action.
                //MessageBox.Show("Arguments insuffisants. Veuillez fournir l'argument approprié.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteUninstallNoRestart()
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to uninstall the AMD driver without restarting?",
                    "Confirm Uninstall",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    Process uninstallProcess = Process.Start("cmd.exe", "/c pnputil /delete-driver oem*.inf /uninstall /force");
                    uninstallProcess.WaitForExit();
                    MessageBox.Show("Uninstall command executed. No restart will be performed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during uninstallation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteUninstallShutdown()
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to uninstall the AMD driver and shut down the computer?",
                    "Confirm Uninstall and Shutdown",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    Process uninstallProcess = Process.Start("cmd.exe", "/c pnputil /delete-driver oem*.inf /uninstall /force");
                    uninstallProcess.WaitForExit();
                    MessageBox.Show("Uninstall command executed. Your computer will shut down now.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start("shutdown", "/s /f /t 0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during uninstallation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ExecuteUninstallRestart()
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to uninstall the AMD driver and restart?",
                    "Confirm Uninstall",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    Process uninstallProcess = Process.Start("cmd.exe", "/c pnputil /delete-driver oem*.inf /uninstall /force");
                    uninstallProcess.WaitForExit();
                    MessageBox.Show("Uninstall command executed. Your computer will restart now.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start("shutdown", "/r /f /t 0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during uninstallation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Ouvre l'URL dans le navigateur par défaut
            System.Diagnostics.Process.Start("https://www.amd.com/fr/support/download/drivers.html");
        }
    }
}
