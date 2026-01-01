using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Freight.Models;
using Freight.Services;

namespace Freight
{
    public partial class SettingsForm : ModernForm
    {
        private ConfigManager configManager;
        private CommandItem selectedCommand = null;

        // 일반 설정용 임시 저장 변수
        private string tempFontName;
        private float tempFontSize;
        private Color tempBgColor;
        private Color tempTextColor;

        // 설정 변경 이벤트
        public event EventHandler SettingsApplied;

        // 폼 드래그 이동용
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public SettingsForm()
        {
            InitializeComponent();
            configManager = ConfigManager.Instance;
            this.BorderRadius = 10;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadCommands();
            LoadGeneralSettings();
        }

        private void LoadGeneralSettings()
        {
            var settings = configManager.Settings;

            // 현재 설정값 로드
            tempFontName = settings.FontName;
            tempFontSize = settings.FontSize;
            tempBgColor = Color.FromArgb(settings.BackgroundColor);
            tempTextColor = Color.FromArgb(settings.TextColor);

            // UI 업데이트
            UpdateFontPreview();
            UpdateColorPreviews();
        }

        private void UpdateFontPreview()
        {
            lblFontPreview.Text = $"{tempFontName}, {tempFontSize}pt";
            try
            {
                lblFontPreview.Font = new Font(tempFontName, 14F);
            }
            catch
            {
                lblFontPreview.Font = new Font("NanumGothicOTF", 14F);
            }
        }

        private void UpdateColorPreviews()
        {
            panelBgColorPreview.BackColor = tempBgColor;
            panelTextColorPreview.BackColor = tempTextColor;
        }

        private void LoadCommands()
        {
            dataGridViewCommands.Rows.Clear();
            selectedCommand = null;

            foreach (var command in configManager.Settings.Commands)
            {
                int rowIndex = dataGridViewCommands.Rows.Add();
                DataGridViewRow row = dataGridViewCommands.Rows[rowIndex];

                row.Cells["colEnabled"].Value = command.IsEnabled;
                row.Cells["colName"].Value = command.Name;
                row.Cells["colDescription"].Value = command.Description;
                row.Cells["colPath"].Value = command.Path;
                row.Cells["colType"].Value = command.Type.ToString();
                row.Tag = command;
            }

            // 명시적으로 선택 해제
            dataGridViewCommands.ClearSelection();
            dataGridViewCommands.CurrentCell = null;

            ClearInputs();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string path = txtPath.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                ShowMessage("명령어 이름을 입력하세요.", "입력 오류", MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(path))
            {
                ShowMessage("경로를 입력하세요.", "입력 오류", MessageBoxIcon.Warning);
                txtPath.Focus();
                return;
            }

            // 중복 체크
            if (configManager.FindCommand(name) != null)
            {
                ShowMessage("이미 존재하는 명령어 이름입니다.", "입력 오류", MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            // 명령어 타입 결정
            CommandType type = DetermineCommandType(path);

            var newCommand = new CommandItem(name, description, path, type);
            configManager.AddCommand(newCommand);

            LoadCommands();
            ShowMessage("명령어가 추가되었습니다.", "성공", MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCommand == null)
            {
                ShowMessage("수정할 항목을 선택하세요.", "선택 오류", MessageBoxIcon.Warning);
                return;
            }

            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string path = txtPath.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                ShowMessage("명령어 이름을 입력하세요.", "입력 오류", MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(path))
            {
                ShowMessage("경로를 입력하세요.", "입력 오류", MessageBoxIcon.Warning);
                txtPath.Focus();
                return;
            }

            // 이름 변경 시 중복 체크 (자기 자신 제외)
            if (name != selectedCommand.Name && configManager.FindCommand(name) != null)
            {
                ShowMessage("이미 존재하는 명령어 이름입니다.", "입력 오류", MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            // 명령어 업데이트
            selectedCommand.Name = name;
            selectedCommand.Description = description;
            selectedCommand.Path = path;
            selectedCommand.Type = DetermineCommandType(path);

            configManager.SaveSettings();
            LoadCommands();
            ShowMessage("명령어가 수정되었습니다.", "성공", MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCommand == null)
            {
                ShowMessage("삭제할 항목을 선택하세요.", "선택 오류", MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"'{selectedCommand.Name}' 명령어를 삭제하시겠습니까?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                configManager.RemoveCommand(selectedCommand.Name);
                LoadCommands();
                ShowMessage("명령어가 삭제되었습니다.", "성공", MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dataGridViewCommands.ClearSelection();
            selectedCommand = null;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "모든 파일|*.*|실행 파일|*.exe|배치 파일|*.bat";
                ofd.Title = "파일 선택";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = ofd.FileName;
                }
            }
        }

        private void dataGridViewCommands_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCommands.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewCommands.SelectedRows[0];
                selectedCommand = row.Tag as CommandItem;

                if (selectedCommand != null)
                {
                    txtName.Text = selectedCommand.Name;
                    txtDescription.Text = selectedCommand.Description;
                    txtPath.Text = selectedCommand.Path;
                }
            }
            else
            {
                selectedCommand = null;
            }
        }

        private void dataGridViewCommands_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewCommands.Rows.Count)
                return;

            // 체크박스(활성화) 컬럼만 처리
            if (e.ColumnIndex == dataGridViewCommands.Columns["colEnabled"].Index)
            {
                DataGridViewRow row = dataGridViewCommands.Rows[e.RowIndex];
                CommandItem command = row.Tag as CommandItem;

                if (command != null)
                {
                    bool isEnabled = Convert.ToBoolean(row.Cells["colEnabled"].Value);
                    command.IsEnabled = isEnabled;
                    configManager.SaveSettings();
                }
            }
        }

        private void dataGridViewCommands_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // 체크박스 변경 즉시 반영
            if (dataGridViewCommands.IsCurrentCellDirty)
            {
                dataGridViewCommands.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtPath.Clear();
            txtName.Focus();
            selectedCommand = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private CommandType DetermineCommandType(string path)
        {
            if (string.IsNullOrEmpty(path))
                return CommandType.FilePath;

            if (path.StartsWith("http://") || path.StartsWith("https://"))
                return CommandType.URL;

            string lowerPath = path.ToLower();
            if (lowerPath.EndsWith(".exe") || lowerPath.EndsWith(".bat") || lowerPath.EndsWith(".cmd"))
                return CommandType.Application;

            return CommandType.FilePath;
        }

        private void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        // ===== 일반 설정 이벤트 핸들러 =====

        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                try
                {
                    fontDialog.Font = new Font(tempFontName, tempFontSize);
                }
                catch
                {
                    fontDialog.Font = new Font("NanumGothicOTF", 20F);
                }

                fontDialog.ShowColor = false;
                fontDialog.ShowEffects = false;

                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    tempFontName = fontDialog.Font.Name;
                    tempFontSize = fontDialog.Font.Size;
                    UpdateFontPreview();
                }
            }
        }

        private void btnBgColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = tempBgColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    tempBgColor = colorDialog.Color;
                    UpdateColorPreviews();
                }
            }
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = tempTextColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    tempTextColor = colorDialog.Color;
                    UpdateColorPreviews();
                }
            }
        }

        private void btnResetColors_Click(object sender, EventArgs e)
        {
            tempFontName = "NanumGothicOTF";
            tempFontSize = 20F;
            tempBgColor = Color.FromArgb(30, 30, 30);
            tempTextColor = Color.White;

            UpdateFontPreview();
            UpdateColorPreviews();

            ShowMessage("기본값으로 초기화되었습니다.\n'설정 적용' 버튼을 눌러 저장하세요.", "초기화", MessageBoxIcon.Information);
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = Application.StartupPath;
                Process.Start("explorer.exe", folderPath);
            }
            catch (Exception ex)
            {
                ShowMessage($"폴더를 열 수 없습니다: {ex.Message}", "오류", MessageBoxIcon.Error);
            }
        }

        private void btnApplySettings_Click(object sender, EventArgs e)
        {
            // 설정 저장
            var settings = configManager.Settings;
            settings.FontName = tempFontName;
            settings.FontSize = tempFontSize;
            settings.BackgroundColor = tempBgColor.ToArgb();
            settings.TextColor = tempTextColor.ToArgb();

            configManager.SaveSettings();

            // 이벤트 발생 (메인 폼에서 UI 업데이트하도록)
            SettingsApplied?.Invoke(this, EventArgs.Empty);

            ShowMessage("설정이 적용되었습니다.", "성공", MessageBoxIcon.Information);
        }

        // ===== 탭 전환 =====

        private void btnTabCommands_Click(object sender, EventArgs e)
        {
            SwitchTab(true);
        }

        private void btnTabGeneral_Click(object sender, EventArgs e)
        {
            SwitchTab(false);
        }

        private void SwitchTab(bool showCommands)
        {
            // 패널 표시/숨김
            panelCommands.Visible = showCommands;
            panelGeneral.Visible = !showCommands;

            // 탭 버튼 스타일 변경 (밝은 테마)
            if (showCommands)
            {
                btnTabCommands.BackColor = Color.FromArgb(99, 102, 241);
                btnTabCommands.ForeColor = Color.White;
                btnTabGeneral.BackColor = Color.FromArgb(220, 220, 225);
                btnTabGeneral.ForeColor = Color.FromArgb(100, 100, 110);
            }
            else
            {
                btnTabCommands.BackColor = Color.FromArgb(220, 220, 225);
                btnTabCommands.ForeColor = Color.FromArgb(100, 100, 110);
                btnTabGeneral.BackColor = Color.FromArgb(99, 102, 241);
                btnTabGeneral.ForeColor = Color.White;
            }
        }
    }
}
