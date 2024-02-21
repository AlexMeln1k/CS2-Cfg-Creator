using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Counter_StrikeCfgCreator
{
    public partial class frmMain : Form
    {
        private string AppDataFolderPath;
        private string ConfigFilePath;
        private bool isWaitingForKey = false;
        private bool isProcessing = false;
        private bool isOptimizationChecked = false;
        //string consoleAppPath = @"C:\Development\Counter-StrikeCfgCreator\ReBindCfg\bin\Debug\RebindCfg.exe";
        //string startCfg = @"C:\Development\Counter-StrikeCfgCreator\UnbindAllCfg\bin\Debug\UnbindAllCfg.exe";
        //string tweak1 = @"C:\Development\Counter-StrikeCfgCreator\Tweak1\bin\Debug\Tweak1.exe";
        //string tweak2 = @"C:\Development\Counter-StrikeCfgCreator\Tweak2\bin\Debug\Tweak2.exe";
        //string tweak3 = @"C:\Development\Counter-StrikeCfgCreator\Tweak3\bin\Debug\Tweak3.exe";
        //string tweak4 = @"C:\Development\Counter-StrikeCfgCreator\Tweak4\bin\Debug\Tweak4.exe";
        //string tweak5 = @"C:\Development\Counter-StrikeCfgCreator\Tweak5\bin\Debug\Tweak5.exe";

        string consoleAppPath = Description.GetPath(0);
        string startCfg = Description.GetPath(1);
        string tweak1 = Description.GetPath(2);
        string tweak2 = Description.GetPath(3);
        string tweak3 = Description.GetPath(4);
        string tweak4 = Description.GetPath(5);
        string tweak5 = Description.GetPath(6);

        public frmMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            txtDirectory.TabStop = false;
            txtEnterKeyJumpThrow.TabStop = false;

            AppDataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Yami", "CfgCreator");
            ConfigFilePath = Path.Combine(AppDataFolderPath, "config.json");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FormPrepare();

            if (!File.Exists(consoleAppPath) ||
                !File.Exists(startCfg) ||
                !File.Exists(tweak1) ||
                !File.Exists(tweak2) ||
                !File.Exists(tweak3) ||
                !File.Exists(tweak4) ||
                !File.Exists(tweak5))
            {
                MessageBox.Show("Failed to start the program. Important components required for the operation of this utility are missing. Please download the application and try again.", "Failed to launch the program.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (!File.Exists(ConfigFilePath))
            {
                MessageBox.Show(Description.FirstStart(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SaveConfig();
            }

            txtDirectory.Text = FindConfigPath();
        }

        public string FindConfigPath()
        {
            chk1.Checked = false;
            chk2.Checked = false;
            chk3.Checked = false;

            string steamPath = @"C:\Program Files (x86)\Steam"; // Путь к Steam, предполагая, что это ваша базовая директория

            // Проверяем, существует ли Steam по указанному пути
            if (!Directory.Exists(steamPath))
            {
                return string.Empty; // Если Steam не установлен, возвращаем пустоту
            }

            // Ищем папку userdata внутри папки Steam
            string userDataPath = Path.Combine(steamPath, "userdata");

            // Получаем список папок внутри папки userdata
            DirectoryInfo userDataDirInfo = new DirectoryInfo(userDataPath);
            DirectoryInfo[] userDirectories = userDataDirInfo.GetDirectories();

            // Выбираем папку, которая была модифицирована позже всех остальных
            DirectoryInfo latestModifiedUserDir = userDirectories.OrderByDescending(dir => dir.LastWriteTime).FirstOrDefault();

            if (latestModifiedUserDir == null)
            {
                return string.Empty; // Если не найдено пользователей, возвращаем пустоту
            }

            // Формируем путь к папке cfg внутри выбранной папки пользователя
            string cfgPath = Path.Combine(latestModifiedUserDir.FullName, "730", "local", "cfg");

            // Проверяем наличие необходимых файлов в папке cfg
            if (Directory.Exists(cfgPath))
            {
                chk1.Checked = File.Exists(Path.Combine(cfgPath, "cs2_machine_convars.vcfg"));
                chk2.Checked = File.Exists(Path.Combine(cfgPath, "cs2_user_convars_0_slot0.vcfg"));
                chk3.Checked = File.Exists(Path.Combine(cfgPath, "cs2_user_keys_0_slot0.vcfg"));

                // Если все файлы присутствуют, возвращаем путь к cfg
                if (chk1.Checked && chk2.Checked && chk3.Checked)
                    return cfgPath;
            }

            return string.Empty; // Если файлы отсутствуют, возвращаем пустоту
        }

        private void FormPrepare()
        {
            btnSetKeyForJumpThrow.Visible = false;
            txtEnterKeyJumpThrow.Visible = false;
            chk1.Enabled = false;
            chk2.Enabled = false;
            chk3.Enabled = false;
            label1.Text = chk1.Text;
            label2.Text = chk2.Text;
            label3.Text = chk3.Text;
            chk1.Text = chk2.Text = chk3.Text = "";
        }

        private void SaveConfig()
        {
            try
            {
                Directory.CreateDirectory(AppDataFolderPath);

                var config = new { FirstRun = false };
                string json = JsonConvert.SerializeObject(config);
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the configuration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangeDirectory_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = dialog.SelectedPath;
                    txtDirectory.Text = folderPath;

                    // Check the path and set the checkboxes
                    CheckConfigFilesAndSetCheckBoxes(folderPath);
                }
            }
        }

        private void CheckConfigFilesAndSetCheckBoxes(string folderPath)
        {
            bool chk1Checked = false;
            bool chk2Checked = false;
            bool chk3Checked = false;

            // Check the existence of required files in the specified directory
            if (Directory.Exists(folderPath))
            {
                chk1Checked = File.Exists(Path.Combine(folderPath, "cs2_machine_convars.vcfg"));
                chk2Checked = File.Exists(Path.Combine(folderPath, "cs2_user_convars_0_slot0.vcfg"));
                chk3Checked = File.Exists(Path.Combine(folderPath, "cs2_user_keys_0_slot0.vcfg"));

                // If all files are present, set the checkboxes and display the path
                if (chk1Checked && chk2Checked && chk3Checked)
                {
                    chk1.Checked = true;
                    chk2.Checked = true;
                    chk3.Checked = true;
                    txtDirectory.Text = folderPath;
                    return;
                }
            }

            // If any of the files are missing, show an error message
            MessageBox.Show("Files were not found in the specified directory. Please double-check the directory and the presence of files with your settings.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

            // If there's an error, reset the checkboxes and clear the TextBox
            chk1.Checked = false;
            chk2.Checked = false;
            chk3.Checked = false;
            txtDirectory.Text = string.Empty;
        }

        private void chkJumpThrow_CheckedChanged(object sender, EventArgs e)
        {
            txtEnterKeyJumpThrow.Text = String.Empty;
            if (chkJumpThrow.Checked == true)
            {
                btnSetKeyForJumpThrow.Visible = true;
                txtEnterKeyJumpThrow.Visible = true;
            }
            else
            {
                btnSetKeyForJumpThrow.Visible = false;
                txtEnterKeyJumpThrow.Visible = false;
            }
        }

        private void btnSetKeyForJumpThrow_Click(object sender, EventArgs e)
        {
            if (!isWaitingForKey)
            {
                btnSetKeyForJumpThrow.Text = "Waiting...";
                IsAllControlsEnabled(false);
                chkJumpThrow.Enabled = false;
                isWaitingForKey = true;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isWaitingForKey)
            {
                if (IsSystemKey(keyData))
                    return base.ProcessCmdKey(ref msg,keyData); // Allow system keys to be processed normally

                txtEnterKeyJumpThrow.Text = keybinds.ConvertToKey(keyData.ToString());
                btnSetKeyForJumpThrow.Text = "Set Key";
                IsAllControlsEnabled(true);
                chkJumpThrow.Enabled = true;
                isWaitingForKey = false;
                return true; // Prevent further processing of the key event
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool IsSystemKey(Keys keyData)
        {
            // Проверяем, является ли клавиша системной
            return keyData == Keys.Escape ||
                   keyData == Keys.LWin ||
                   keyData == Keys.RWin ||
                   keyData == Keys.Menu ||
                   keyData == Keys.Home ||
                   keyData == Keys.End ||
                   keyData == Keys.PrintScreen ||
                   keyData == Keys.Scroll ||
                   keyData == Keys.Pause ||
                   keyData == Keys.VolumeMute ||
                   keyData == Keys.VolumeDown ||
                   keyData == Keys.NumLock ||
                   keyData == Keys.Return ||
                   keyData == Keys.VolumeUp;
        }

        private void btnJumpThrowHint_Click(object sender, EventArgs e)
        {
            ShowHint(0);
        }

        private void btnNewBobHint_Click(object sender, EventArgs e)
        {
            ShowHint(1);
        }

        private void btnOptimizeHint_Click(object sender, EventArgs e)
        {
            ShowHint(2);
        }

        private void btnShaderScopeHint_Click(object sender, EventArgs e)
        {
            ShowHint(3);
        }

        private void ShowHint(int id)
        {
            switch (id)
            {
                case 0:
                    MessageBox.Show(Description.JumpThrow(), "JumpThrow", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 1:
                    MessageBox.Show(Description.Bob(), "Use New Bob", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 2:
                    MessageBox.Show(Description.Optimize(), "CS2 Optimization", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 3:
                    MessageBox.Show(Description.HelloInConsole(), "Hello In Console", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 4:
                    MessageBox.Show(Description.GunfireTraces(), "Disable gunfire traces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                default:
                    MessageBox.Show("Whoops, I cannot find the description for this command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void IsAllControlsEnabled(bool isEnabled)
        {
            btnChangeDirectory.Enabled = isEnabled;
            txtDirectory.Enabled = isEnabled;
            btnSetKeyForJumpThrow.Enabled = isEnabled;
            txtEnterKeyJumpThrow.Enabled = isEnabled;
            chkJumpThrow.Enabled = isEnabled;
            chkBob.Enabled = isEnabled;
            chkOptimization.Enabled = isEnabled;
            chkSayHello.Enabled = isEnabled;
            btnJumpThrowHint.Enabled = isEnabled;
            btnNewBobHint.Enabled = isEnabled;
            btnOptimizeHint.Enabled = isEnabled;
            btnShaderScopeHint.Enabled = isEnabled;
            btnCreateConfig.Enabled = isEnabled;
            ChkDisGunfireTraces.Enabled = isEnabled;
            btnDisTracesHint.Enabled = isEnabled;
        }

        private void btnCreateConfig_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                return;
            }

            isProcessing = true;
            IsAllControlsEnabled(false);

            string directoryPath = txtDirectory.Text.Trim();

            string[] fileNames = { "cs2_machine_convars.vcfg", "cs2_user_convars_0_slot0.vcfg", "cs2_user_keys_0_slot0.vcfg" };
            string outputFileName = "merged_config.cfg";
            string tempFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Yami", "CfgCreator", outputFileName);

            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                foreach (string fileName in fileNames)
                {
                    string filePath = Path.Combine(directoryPath, fileName);

                    if (File.Exists(filePath))
                    {
                        writer.WriteLine($"//{fileName}");

                        string fileContent = File.ReadAllText(filePath);
                        if (!string.IsNullOrWhiteSpace(fileContent))
                        {
                            // Remove brackets block from the content
                            string cleanedContent = RemoveBracketsBlock(fileContent);
                            writer.WriteLine(cleanedContent);
                        }
                        else
                        {
                            writer.WriteLine("// File is empty or contains only whitespace.");
                        }

                        writer.WriteLine();
                    }
                    else
                    {
                        writer.WriteLine($"// File not found: {fileName}");
                        writer.WriteLine();
                    }
                }
            }

            ProcessStart(consoleAppPath);
            ProcessStart(startCfg);

            OptionalImprovments();

            MessageBox.Show("Your config file is ready. Please select a location to save it to.", "CFG Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Config files (*.cfg)|*.cfg|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "autoexec.cfg";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = saveFileDialog.FileName;
                File.Copy(tempFilePath, selectedFilePath, true);
                MessageBox.Show($"Your configuration is ready and saved at: {selectedFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            File.Delete(tempFilePath);

            IsAllControlsEnabled(true);
            isProcessing = false;
        }

        private void OptionalImprovments()
        {
            if (chkJumpThrow.Checked) //Готово, работает.
                ProcessStart(tweak1);

            if (chkBob.Checked) //Готово, работает.
                ProcessStart(tweak2);

            if (chkOptimization.Checked)  //Готово, работает.
                ProcessStart(tweak3);

            if (chkSayHello.Checked) //Готово, работает.
                ProcessStart(tweak4);

            if (ChkDisGunfireTraces.Checked) //Готово, работает.
                ProcessStart(tweak5);

        }

        private void ProcessStart(string appName)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = appName;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            if (appName == tweak1)
            startInfo.Arguments = txtEnterKeyJumpThrow.Text;

            Process process = new Process();
            process.StartInfo = startInfo;

            process.OutputDataReceived += Process_OutputDataReceived; // Обработка вывода
            process.Start();
            process.BeginOutputReadLine(); // Начинаем асинхронное чтение вывода
            process.WaitForExit();
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                // Здесь вы можете обработать вывод вашего консольного приложения
                // Например, вы можете добавить его в какой-то текстовый блок на форме
                // richTextBox1.AppendText(e.Data + Environment.NewLine);
                // Или вы можете сохранить его в переменную для дальнейшего использования
                // string consoleOutput = e.Data;
            }
        }

        private bool ValidData()
        {
            if (string.IsNullOrEmpty(txtDirectory.Text))
            {
                MessageBox.Show("CFG Directory is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnChangeDirectory.Focus();
                return false;
            }
            if (chk1.Checked == false || chk2.Checked == false || chk3.Checked == false)
            {
                MessageBox.Show("Some of the files are missing. Please check the directory where your VCFG files are stored.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnChangeDirectory.Focus();
                return false;
            }
            if (chkJumpThrow.Checked && string.IsNullOrEmpty(txtEnterKeyJumpThrow.Text))
            {
                MessageBox.Show("Please select the button to use for JumpThrow.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnChangeDirectory.Focus();
                return false;
            }
            return true;
        }

        private void btnDisTracesHint_Click(object sender, EventArgs e)
        {
            ShowHint(4);
        }

        private void frmMain_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (isProcessing)
            {
                MessageBox.Show("Please wait until the current operation is completed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Отменяем закрытие формы
            }
        }

        private string RemoveBracketsBlock(string content)
        {
            // Удаляем первые четыре строки
            int index = content.IndexOf('\n');
            if (index != -1)
            {
                content = content.Substring(index + 1);
                index = content.IndexOf('\n');
                if (index != -1)
                {
                    content = content.Substring(index + 1);
                    index = content.IndexOf('\n');
                    if (index != -1)
                    {
                        content = content.Substring(index + 1);
                        index = content.IndexOf('\n');
                        if (index != -1)
                        {
                            content = content.Substring(index + 1);
                        }
                    }
                }
            }

            // Удаляем последние две строки
            index = content.LastIndexOf('\n');
            if (index != -1)
            {
                content = content.Substring(0, index);
                index = content.LastIndexOf('\n');
                if (index != -1)
                {
                    content = content.Substring(0, index);
                }
            }

            // Удаляем открывающую фигурную скобку в конце, если она есть
            content = content.TrimEnd();

            // Удаляем закрывающую фигурную скобку в конце, если она есть
            if (content.EndsWith("}"))
            {
                content = content.Substring(0, content.Length - 1);
            }

            return content;
        }

        private void chkOptimization_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOptimization.Checked && isOptimizationChecked == false)
            {
                isOptimizationChecked = true;
                MessageBox.Show(Description.CsOptimizationPreview(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}