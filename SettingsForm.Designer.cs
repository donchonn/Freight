namespace Freight
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            // 메인 컨테이너
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();

            // 명령어 설정 패널
            this.panelCommands = new System.Windows.Forms.Panel();
            this.dataGridViewCommands = new System.Windows.Forms.DataGridView();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelInput = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();

            // 일반 설정 패널
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.grpAppearance = new System.Windows.Forms.GroupBox();
            this.btnResetColors = new System.Windows.Forms.Button();
            this.panelTextColorPreview = new System.Windows.Forms.Panel();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.lblTextColor = new System.Windows.Forms.Label();
            this.panelBgColorPreview = new System.Windows.Forms.Panel();
            this.btnBgColor = new System.Windows.Forms.Button();
            this.lblBgColor = new System.Windows.Forms.Label();
            this.grpFont = new System.Windows.Forms.GroupBox();
            this.btnSelectFont = new System.Windows.Forms.Button();
            this.lblFontPreview = new System.Windows.Forms.Label();
            this.grpUtility = new System.Windows.Forms.GroupBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnApplySettings = new System.Windows.Forms.Button();

            // 제스처 설정 패널
            this.panelGesture = new System.Windows.Forms.Panel();
            this.grpGestureBasic = new System.Windows.Forms.GroupBox();
            this.chkGestureEnabled = new System.Windows.Forms.CheckBox();
            this.lblPenWidth = new System.Windows.Forms.Label();
            this.numPenWidth = new System.Windows.Forms.NumericUpDown();
            this.btnGestureColor = new System.Windows.Forms.Button();
            this.panelGestureColorPreview = new System.Windows.Forms.Panel();
            this.lblGestureColor = new System.Windows.Forms.Label();
            this.grpGestureActions = new System.Windows.Forms.GroupBox();
            this.lblUp = new System.Windows.Forms.Label();
            this.cmbUpAction = new System.Windows.Forms.ComboBox();
            this.lblDown = new System.Windows.Forms.Label();
            this.cmbDownAction = new System.Windows.Forms.ComboBox();
            this.lblLeft = new System.Windows.Forms.Label();
            this.cmbLeftAction = new System.Windows.Forms.ComboBox();
            this.lblRight = new System.Windows.Forms.Label();
            this.cmbRightAction = new System.Windows.Forms.ComboBox();
            this.grpGestureLShape = new System.Windows.Forms.GroupBox();
            this.lblDownRight = new System.Windows.Forms.Label();
            this.cmbDownRightAction = new System.Windows.Forms.ComboBox();
            this.lblDownLeft = new System.Windows.Forms.Label();
            this.cmbDownLeftAction = new System.Windows.Forms.ComboBox();
            this.lblUpRight = new System.Windows.Forms.Label();
            this.cmbUpRightAction = new System.Windows.Forms.ComboBox();
            this.lblUpLeft = new System.Windows.Forms.Label();
            this.cmbUpLeftAction = new System.Windows.Forms.ComboBox();
            this.grpGestureDiagonal = new System.Windows.Forms.GroupBox();
            this.lblDiagDownRight = new System.Windows.Forms.Label();
            this.cmbDiagDownRightAction = new System.Windows.Forms.ComboBox();
            this.lblDiagDownLeft = new System.Windows.Forms.Label();
            this.cmbDiagDownLeftAction = new System.Windows.Forms.ComboBox();
            this.lblDiagUpRight = new System.Windows.Forms.Label();
            this.cmbDiagUpRightAction = new System.Windows.Forms.ComboBox();
            this.lblDiagUpLeft = new System.Windows.Forms.Label();
            this.cmbDiagUpLeftAction = new System.Windows.Forms.ComboBox();
            this.btnApplyGesture = new System.Windows.Forms.Button();

            // 탭 네비게이션
            this.panelTabNav = new System.Windows.Forms.Panel();
            this.btnTabCommands = new System.Windows.Forms.Button();
            this.btnTabGeneral = new System.Windows.Forms.Button();
            this.btnTabGesture = new System.Windows.Forms.Button();

            // 헤더
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();

            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommands)).BeginInit();
            this.panelInput.SuspendLayout();
            this.panelGeneral.SuspendLayout();
            this.grpAppearance.SuspendLayout();
            this.grpFont.SuspendLayout();
            this.grpUtility.SuspendLayout();
            this.panelGesture.SuspendLayout();
            this.grpGestureBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPenWidth)).BeginInit();
            this.grpGestureActions.SuspendLayout();
            this.grpGestureLShape.SuspendLayout();
            this.grpGestureDiagonal.SuspendLayout();
            this.panelTabNav.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // ========================================
            // 색상 정의 (다크 테마)
            // ========================================
            System.Drawing.Color bgDark = System.Drawing.Color.FromArgb(32, 32, 32);
            System.Drawing.Color bgPanel = System.Drawing.Color.FromArgb(42, 42, 42);
            System.Drawing.Color bgInput = System.Drawing.Color.FromArgb(50, 50, 50);
            System.Drawing.Color textPrimary = System.Drawing.Color.FromArgb(230, 230, 230);
            System.Drawing.Color textSecondary = System.Drawing.Color.FromArgb(160, 160, 160);
            System.Drawing.Color accentBlue = System.Drawing.Color.FromArgb(0, 120, 212);
            System.Drawing.Color accentHover = System.Drawing.Color.FromArgb(30, 144, 255);
            System.Drawing.Color btnNormal = System.Drawing.Color.FromArgb(55, 55, 55);
            System.Drawing.Color btnHover = System.Drawing.Color.FromArgb(70, 70, 70);
            System.Drawing.Color btnGreen = System.Drawing.Color.FromArgb(40, 167, 69);
            System.Drawing.Color btnRed = System.Drawing.Color.FromArgb(200, 60, 60);
            System.Drawing.Color borderColor = System.Drawing.Color.FromArgb(70, 70, 70);

            // ========================================
            // panelMain
            // ========================================
            this.panelMain.BackColor = bgDark;
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelTabNav);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1100, 750);
            this.panelMain.TabIndex = 0;

            // ========================================
            // panelHeader
            // ========================================
            this.panelHeader.BackColor = bgPanel;
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 36);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = textPrimary;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(37, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "설정";

            // btnClose
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(180, 0, 0);
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 17, 35);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnClose.ForeColor = textPrimary;
            this.btnClose.Location = new System.Drawing.Point(1062, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ========================================
            // panelTabNav
            // ========================================
            this.panelTabNav.BackColor = bgPanel;
            this.panelTabNav.Controls.Add(this.btnTabCommands);
            this.panelTabNav.Controls.Add(this.btnTabGeneral);
            this.panelTabNav.Controls.Add(this.btnTabGesture);
            this.panelTabNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTabNav.Location = new System.Drawing.Point(0, 36);
            this.panelTabNav.Name = "panelTabNav";
            this.panelTabNav.Size = new System.Drawing.Size(1100, 36);
            this.panelTabNav.TabIndex = 1;

            // btnTabCommands
            this.btnTabCommands.BackColor = accentBlue;
            this.btnTabCommands.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabCommands.FlatAppearance.BorderSize = 0;
            this.btnTabCommands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabCommands.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnTabCommands.ForeColor = System.Drawing.Color.White;
            this.btnTabCommands.Location = new System.Drawing.Point(12, 4);
            this.btnTabCommands.Name = "btnTabCommands";
            this.btnTabCommands.Size = new System.Drawing.Size(70, 28);
            this.btnTabCommands.TabIndex = 0;
            this.btnTabCommands.Text = "명령";
            this.btnTabCommands.UseVisualStyleBackColor = false;
            this.btnTabCommands.Click += new System.EventHandler(this.btnTabCommands_Click);

            // btnTabGeneral
            this.btnTabGeneral.BackColor = btnNormal;
            this.btnTabGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabGeneral.FlatAppearance.BorderSize = 0;
            this.btnTabGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabGeneral.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnTabGeneral.ForeColor = textSecondary;
            this.btnTabGeneral.Location = new System.Drawing.Point(92, 4);
            this.btnTabGeneral.Name = "btnTabGeneral";
            this.btnTabGeneral.Size = new System.Drawing.Size(70, 28);
            this.btnTabGeneral.TabIndex = 1;
            this.btnTabGeneral.Text = "일반";
            this.btnTabGeneral.UseVisualStyleBackColor = false;
            this.btnTabGeneral.Click += new System.EventHandler(this.btnTabGeneral_Click);

            // btnTabGesture
            this.btnTabGesture.BackColor = btnNormal;
            this.btnTabGesture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabGesture.FlatAppearance.BorderSize = 0;
            this.btnTabGesture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabGesture.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnTabGesture.ForeColor = textSecondary;
            this.btnTabGesture.Location = new System.Drawing.Point(172, 4);
            this.btnTabGesture.Name = "btnTabGesture";
            this.btnTabGesture.Size = new System.Drawing.Size(70, 28);
            this.btnTabGesture.TabIndex = 2;
            this.btnTabGesture.Text = "제스처";
            this.btnTabGesture.UseVisualStyleBackColor = false;
            this.btnTabGesture.Click += new System.EventHandler(this.btnTabGesture_Click);

            // ========================================
            // panelContent
            // ========================================
            this.panelContent.BackColor = bgDark;
            this.panelContent.Controls.Add(this.panelCommands);
            this.panelContent.Controls.Add(this.panelGeneral);
            this.panelContent.Controls.Add(this.panelGesture);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 72);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(12);
            this.panelContent.Size = new System.Drawing.Size(1100, 678);
            this.panelContent.TabIndex = 2;

            // ========================================
            // panelCommands - 명령어 설정
            // ========================================
            this.panelCommands.BackColor = bgDark;
            this.panelCommands.Controls.Add(this.dataGridViewCommands);
            this.panelCommands.Controls.Add(this.panelInput);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommands.Location = new System.Drawing.Point(12, 12);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(1076, 654);
            this.panelCommands.TabIndex = 0;

            // dataGridViewCommands
            this.dataGridViewCommands.AllowUserToAddRows = false;
            this.dataGridViewCommands.AllowUserToDeleteRows = false;
            this.dataGridViewCommands.AllowUserToResizeRows = false;
            this.dataGridViewCommands.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCommands.BackgroundColor = bgInput;
            this.dataGridViewCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCommands.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewCommands.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = accentBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = accentBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.dataGridViewCommands.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCommands.ColumnHeadersHeight = 32;
            this.dataGridViewCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCommands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colEnabled, this.colName, this.colDescription, this.colPath, this.colType});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = bgInput;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            dataGridViewCellStyle2.ForeColor = textPrimary;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle2.SelectionForeColor = accentHover;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.dataGridViewCommands.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCommands.EnableHeadersVisualStyles = false;
            this.dataGridViewCommands.GridColor = borderColor;
            this.dataGridViewCommands.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCommands.MultiSelect = false;
            this.dataGridViewCommands.Name = "dataGridViewCommands";
            this.dataGridViewCommands.RowHeadersVisible = false;
            this.dataGridViewCommands.RowTemplate.Height = 28;
            this.dataGridViewCommands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCommands.Size = new System.Drawing.Size(1076, 494);
            this.dataGridViewCommands.TabIndex = 0;
            this.dataGridViewCommands.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCommands_CellValueChanged);
            this.dataGridViewCommands.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewCommands_CurrentCellDirtyStateChanged);
            this.dataGridViewCommands.SelectionChanged += new System.EventHandler(this.dataGridViewCommands_SelectionChanged);

            // colEnabled
            this.colEnabled.FillWeight = 40F;
            this.colEnabled.HeaderText = "활성";
            this.colEnabled.Name = "colEnabled";

            // colName
            this.colName.FillWeight = 80F;
            this.colName.HeaderText = "명령어";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;

            // colDescription
            this.colDescription.FillWeight = 120F;
            this.colDescription.HeaderText = "설명";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;

            // colPath
            this.colPath.FillWeight = 200F;
            this.colPath.HeaderText = "경로";
            this.colPath.Name = "colPath";
            this.colPath.ReadOnly = true;

            // colType
            this.colType.FillWeight = 60F;
            this.colType.HeaderText = "타입";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;

            // panelInput
            this.panelInput.BackColor = bgPanel;
            this.panelInput.Controls.Add(this.btnBrowse);
            this.panelInput.Controls.Add(this.btnClear);
            this.panelInput.Controls.Add(this.btnDelete);
            this.panelInput.Controls.Add(this.btnEdit);
            this.panelInput.Controls.Add(this.btnAdd);
            this.panelInput.Controls.Add(this.txtPath);
            this.panelInput.Controls.Add(this.txtDescription);
            this.panelInput.Controls.Add(this.txtName);
            this.panelInput.Controls.Add(this.label3);
            this.panelInput.Controls.Add(this.label2);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInput.Location = new System.Drawing.Point(0, 494);
            this.panelInput.Name = "panelInput";
            this.panelInput.Padding = new System.Windows.Forms.Padding(12);
            this.panelInput.Size = new System.Drawing.Size(1076, 160);
            this.panelInput.TabIndex = 1;

            // label1 - 이름
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label1.ForeColor = textSecondary;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "이름";

            // txtName
            this.txtName.BackColor = bgInput;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtName.ForeColor = textPrimary;
            this.txtName.Location = new System.Drawing.Point(60, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 1;

            // label2 - 설명
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label2.ForeColor = textSecondary;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "설명";

            // txtDescription
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = bgInput;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtDescription.ForeColor = textPrimary;
            this.txtDescription.Location = new System.Drawing.Point(60, 50);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(1000, 23);
            this.txtDescription.TabIndex = 3;

            // label3 - 경로
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label3.ForeColor = textSecondary;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "경로";

            // txtPath
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.BackColor = bgInput;
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtPath.ForeColor = textPrimary;
            this.txtPath.Location = new System.Drawing.Point(60, 85);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(940, 23);
            this.txtPath.TabIndex = 5;

            // btnBrowse
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.BackColor = btnNormal;
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnBrowse.ForeColor = textPrimary;
            this.btnBrowse.Location = new System.Drawing.Point(1010, 83);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(50, 27);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            // btnClear
            this.btnClear.BackColor = btnNormal;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnClear.ForeColor = textPrimary;
            this.btnClear.Location = new System.Drawing.Point(12, 120);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 28);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "초기화";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // btnAdd
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = btnGreen;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(820, 120);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 28);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = accentBlue;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(900, 120);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 28);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "수정";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = btnRed;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(980, 120);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 28);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ========================================
            // panelGeneral - 일반 설정
            // ========================================
            this.panelGeneral.BackColor = bgDark;
            this.panelGeneral.Controls.Add(this.grpFont);
            this.panelGeneral.Controls.Add(this.grpAppearance);
            this.panelGeneral.Controls.Add(this.grpUtility);
            this.panelGeneral.Controls.Add(this.btnApplySettings);
            this.panelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGeneral.Location = new System.Drawing.Point(12, 12);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(1076, 654);
            this.panelGeneral.TabIndex = 1;
            this.panelGeneral.Visible = false;

            // grpFont
            this.grpFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFont.Controls.Add(this.btnSelectFont);
            this.grpFont.Controls.Add(this.lblFontPreview);
            this.grpFont.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.grpFont.ForeColor = textSecondary;
            this.grpFont.Location = new System.Drawing.Point(0, 0);
            this.grpFont.Name = "grpFont";
            this.grpFont.Size = new System.Drawing.Size(1076, 80);
            this.grpFont.TabIndex = 0;
            this.grpFont.TabStop = false;
            this.grpFont.Text = "폰트 설정";

            // btnSelectFont
            this.btnSelectFont.BackColor = accentBlue;
            this.btnSelectFont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectFont.FlatAppearance.BorderSize = 0;
            this.btnSelectFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFont.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnSelectFont.ForeColor = System.Drawing.Color.White;
            this.btnSelectFont.Location = new System.Drawing.Point(15, 32);
            this.btnSelectFont.Name = "btnSelectFont";
            this.btnSelectFont.Size = new System.Drawing.Size(100, 28);
            this.btnSelectFont.TabIndex = 0;
            this.btnSelectFont.Text = "폰트 선택";
            this.btnSelectFont.UseVisualStyleBackColor = false;
            this.btnSelectFont.Click += new System.EventHandler(this.btnSelectFont_Click);

            // lblFontPreview
            this.lblFontPreview.AutoSize = true;
            this.lblFontPreview.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lblFontPreview.ForeColor = textPrimary;
            this.lblFontPreview.Location = new System.Drawing.Point(130, 35);
            this.lblFontPreview.Name = "lblFontPreview";
            this.lblFontPreview.Size = new System.Drawing.Size(160, 21);
            this.lblFontPreview.TabIndex = 1;
            this.lblFontPreview.Text = "NanumGothicOTF, 20pt";

            // grpAppearance
            this.grpAppearance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAppearance.Controls.Add(this.lblBgColor);
            this.grpAppearance.Controls.Add(this.btnBgColor);
            this.grpAppearance.Controls.Add(this.panelBgColorPreview);
            this.grpAppearance.Controls.Add(this.lblTextColor);
            this.grpAppearance.Controls.Add(this.btnTextColor);
            this.grpAppearance.Controls.Add(this.panelTextColorPreview);
            this.grpAppearance.Controls.Add(this.btnResetColors);
            this.grpAppearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.grpAppearance.ForeColor = textSecondary;
            this.grpAppearance.Location = new System.Drawing.Point(0, 100);
            this.grpAppearance.Name = "grpAppearance";
            this.grpAppearance.Size = new System.Drawing.Size(1076, 120);
            this.grpAppearance.TabIndex = 1;
            this.grpAppearance.TabStop = false;
            this.grpAppearance.Text = "색상 설정";

            // lblBgColor
            this.lblBgColor.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblBgColor.ForeColor = textSecondary;
            this.lblBgColor.Location = new System.Drawing.Point(15, 35);
            this.lblBgColor.Name = "lblBgColor";
            this.lblBgColor.Size = new System.Drawing.Size(70, 20);
            this.lblBgColor.TabIndex = 0;
            this.lblBgColor.Text = "배경 색상";

            // btnBgColor
            this.btnBgColor.BackColor = btnNormal;
            this.btnBgColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBgColor.FlatAppearance.BorderSize = 0;
            this.btnBgColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBgColor.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnBgColor.ForeColor = textPrimary;
            this.btnBgColor.Location = new System.Drawing.Point(90, 32);
            this.btnBgColor.Name = "btnBgColor";
            this.btnBgColor.Size = new System.Drawing.Size(70, 26);
            this.btnBgColor.TabIndex = 1;
            this.btnBgColor.Text = "선택";
            this.btnBgColor.UseVisualStyleBackColor = false;
            this.btnBgColor.Click += new System.EventHandler(this.btnBgColor_Click);

            // panelBgColorPreview
            this.panelBgColorPreview.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.panelBgColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBgColorPreview.Location = new System.Drawing.Point(170, 32);
            this.panelBgColorPreview.Name = "panelBgColorPreview";
            this.panelBgColorPreview.Size = new System.Drawing.Size(32, 26);
            this.panelBgColorPreview.TabIndex = 2;

            // lblTextColor
            this.lblTextColor.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblTextColor.ForeColor = textSecondary;
            this.lblTextColor.Location = new System.Drawing.Point(15, 75);
            this.lblTextColor.Name = "lblTextColor";
            this.lblTextColor.Size = new System.Drawing.Size(70, 20);
            this.lblTextColor.TabIndex = 3;
            this.lblTextColor.Text = "텍스트";

            // btnTextColor
            this.btnTextColor.BackColor = btnNormal;
            this.btnTextColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTextColor.FlatAppearance.BorderSize = 0;
            this.btnTextColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTextColor.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnTextColor.ForeColor = textPrimary;
            this.btnTextColor.Location = new System.Drawing.Point(90, 72);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(70, 26);
            this.btnTextColor.TabIndex = 4;
            this.btnTextColor.Text = "선택";
            this.btnTextColor.UseVisualStyleBackColor = false;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);

            // panelTextColorPreview
            this.panelTextColorPreview.BackColor = System.Drawing.Color.White;
            this.panelTextColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTextColorPreview.Location = new System.Drawing.Point(170, 72);
            this.panelTextColorPreview.Name = "panelTextColorPreview";
            this.panelTextColorPreview.Size = new System.Drawing.Size(32, 26);
            this.panelTextColorPreview.TabIndex = 5;

            // btnResetColors
            this.btnResetColors.BackColor = btnNormal;
            this.btnResetColors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetColors.FlatAppearance.BorderSize = 0;
            this.btnResetColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetColors.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnResetColors.ForeColor = textPrimary;
            this.btnResetColors.Location = new System.Drawing.Point(230, 52);
            this.btnResetColors.Name = "btnResetColors";
            this.btnResetColors.Size = new System.Drawing.Size(70, 26);
            this.btnResetColors.TabIndex = 6;
            this.btnResetColors.Text = "초기화";
            this.btnResetColors.UseVisualStyleBackColor = false;
            this.btnResetColors.Click += new System.EventHandler(this.btnResetColors_Click);

            // grpUtility
            this.grpUtility.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUtility.Controls.Add(this.btnOpenFolder);
            this.grpUtility.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.grpUtility.ForeColor = textSecondary;
            this.grpUtility.Location = new System.Drawing.Point(0, 240);
            this.grpUtility.Name = "grpUtility";
            this.grpUtility.Size = new System.Drawing.Size(1076, 80);
            this.grpUtility.TabIndex = 2;
            this.grpUtility.TabStop = false;
            this.grpUtility.Text = "유틸리티";

            // btnOpenFolder
            this.btnOpenFolder.BackColor = btnNormal;
            this.btnOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFolder.FlatAppearance.BorderSize = 0;
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFolder.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnOpenFolder.ForeColor = textPrimary;
            this.btnOpenFolder.Location = new System.Drawing.Point(15, 32);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(100, 28);
            this.btnOpenFolder.TabIndex = 0;
            this.btnOpenFolder.Text = "폴더 열기";
            this.btnOpenFolder.UseVisualStyleBackColor = false;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);

            // btnApplySettings
            this.btnApplySettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplySettings.BackColor = accentBlue;
            this.btnApplySettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplySettings.FlatAppearance.BorderSize = 0;
            this.btnApplySettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplySettings.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnApplySettings.ForeColor = System.Drawing.Color.White;
            this.btnApplySettings.Location = new System.Drawing.Point(966, 610);
            this.btnApplySettings.Name = "btnApplySettings";
            this.btnApplySettings.Size = new System.Drawing.Size(100, 36);
            this.btnApplySettings.TabIndex = 3;
            this.btnApplySettings.Text = "저장";
            this.btnApplySettings.UseVisualStyleBackColor = false;
            this.btnApplySettings.Click += new System.EventHandler(this.btnApplySettings_Click);

            // ========================================
            // panelGesture - 제스처 설정
            // ========================================
            this.panelGesture.BackColor = bgDark;
            this.panelGesture.Controls.Add(this.grpGestureBasic);
            this.panelGesture.Controls.Add(this.grpGestureActions);
            this.panelGesture.Controls.Add(this.grpGestureLShape);
            this.panelGesture.Controls.Add(this.grpGestureDiagonal);
            this.panelGesture.Controls.Add(this.btnApplyGesture);
            this.panelGesture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGesture.Location = new System.Drawing.Point(12, 12);
            this.panelGesture.Name = "panelGesture";
            this.panelGesture.Size = new System.Drawing.Size(1076, 654);
            this.panelGesture.TabIndex = 2;
            this.panelGesture.Visible = false;

            // grpGestureBasic
            this.grpGestureBasic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGestureBasic.Controls.Add(this.chkGestureEnabled);
            this.grpGestureBasic.Controls.Add(this.lblGestureColor);
            this.grpGestureBasic.Controls.Add(this.btnGestureColor);
            this.grpGestureBasic.Controls.Add(this.panelGestureColorPreview);
            this.grpGestureBasic.Controls.Add(this.lblPenWidth);
            this.grpGestureBasic.Controls.Add(this.numPenWidth);
            this.grpGestureBasic.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.grpGestureBasic.ForeColor = textSecondary;
            this.grpGestureBasic.Location = new System.Drawing.Point(0, 0);
            this.grpGestureBasic.Name = "grpGestureBasic";
            this.grpGestureBasic.Size = new System.Drawing.Size(1076, 80);
            this.grpGestureBasic.TabIndex = 0;
            this.grpGestureBasic.TabStop = false;
            this.grpGestureBasic.Text = "기본 설정";

            // chkGestureEnabled
            this.chkGestureEnabled.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.chkGestureEnabled.ForeColor = textPrimary;
            this.chkGestureEnabled.Location = new System.Drawing.Point(15, 35);
            this.chkGestureEnabled.Name = "chkGestureEnabled";
            this.chkGestureEnabled.Size = new System.Drawing.Size(130, 22);
            this.chkGestureEnabled.TabIndex = 0;
            this.chkGestureEnabled.Text = "제스처 활성화";
            this.chkGestureEnabled.Checked = true;
            this.chkGestureEnabled.UseVisualStyleBackColor = true;

            // lblGestureColor
            this.lblGestureColor.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblGestureColor.ForeColor = textSecondary;
            this.lblGestureColor.Location = new System.Drawing.Point(170, 37);
            this.lblGestureColor.Name = "lblGestureColor";
            this.lblGestureColor.Size = new System.Drawing.Size(50, 20);
            this.lblGestureColor.TabIndex = 1;
            this.lblGestureColor.Text = "색상";

            // btnGestureColor
            this.btnGestureColor.BackColor = btnNormal;
            this.btnGestureColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestureColor.FlatAppearance.BorderSize = 0;
            this.btnGestureColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestureColor.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnGestureColor.ForeColor = textPrimary;
            this.btnGestureColor.Location = new System.Drawing.Point(225, 33);
            this.btnGestureColor.Name = "btnGestureColor";
            this.btnGestureColor.Size = new System.Drawing.Size(60, 26);
            this.btnGestureColor.TabIndex = 2;
            this.btnGestureColor.Text = "선택";
            this.btnGestureColor.UseVisualStyleBackColor = false;
            this.btnGestureColor.Click += new System.EventHandler(this.btnGestureColor_Click);

            // panelGestureColorPreview
            this.panelGestureColorPreview.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.panelGestureColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGestureColorPreview.Location = new System.Drawing.Point(295, 33);
            this.panelGestureColorPreview.Name = "panelGestureColorPreview";
            this.panelGestureColorPreview.Size = new System.Drawing.Size(32, 26);
            this.panelGestureColorPreview.TabIndex = 3;

            // lblPenWidth
            this.lblPenWidth.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblPenWidth.ForeColor = textSecondary;
            this.lblPenWidth.Location = new System.Drawing.Point(360, 37);
            this.lblPenWidth.Name = "lblPenWidth";
            this.lblPenWidth.Size = new System.Drawing.Size(50, 20);
            this.lblPenWidth.TabIndex = 4;
            this.lblPenWidth.Text = "두께";

            // numPenWidth
            this.numPenWidth.BackColor = bgInput;
            this.numPenWidth.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.numPenWidth.ForeColor = textPrimary;
            this.numPenWidth.Location = new System.Drawing.Point(415, 34);
            this.numPenWidth.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numPenWidth.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numPenWidth.Name = "numPenWidth";
            this.numPenWidth.Size = new System.Drawing.Size(70, 23);
            this.numPenWidth.TabIndex = 5;
            this.numPenWidth.Value = new decimal(new int[] { 56, 0, 0, 0 });

            // grpGestureActions
            this.grpGestureActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGestureActions.Controls.Add(this.lblUp);
            this.grpGestureActions.Controls.Add(this.cmbUpAction);
            this.grpGestureActions.Controls.Add(this.lblDown);
            this.grpGestureActions.Controls.Add(this.cmbDownAction);
            this.grpGestureActions.Controls.Add(this.lblLeft);
            this.grpGestureActions.Controls.Add(this.cmbLeftAction);
            this.grpGestureActions.Controls.Add(this.lblRight);
            this.grpGestureActions.Controls.Add(this.cmbRightAction);
            this.grpGestureActions.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.grpGestureActions.ForeColor = textSecondary;
            this.grpGestureActions.Location = new System.Drawing.Point(0, 100);
            this.grpGestureActions.Name = "grpGestureActions";
            this.grpGestureActions.Size = new System.Drawing.Size(1076, 120);
            this.grpGestureActions.TabIndex = 1;
            this.grpGestureActions.TabStop = false;
            this.grpGestureActions.Text = "단일 방향 제스처";

            // lblUp
            this.lblUp.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblUp.ForeColor = textSecondary;
            this.lblUp.Location = new System.Drawing.Point(15, 35);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(60, 20);
            this.lblUp.TabIndex = 0;
            this.lblUp.Text = "위 (↑)";

            // cmbUpAction
            this.cmbUpAction.BackColor = bgInput;
            this.cmbUpAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUpAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbUpAction.ForeColor = textPrimary;
            this.cmbUpAction.FormattingEnabled = true;
            this.cmbUpAction.Location = new System.Drawing.Point(80, 32);
            this.cmbUpAction.Name = "cmbUpAction";
            this.cmbUpAction.Size = new System.Drawing.Size(180, 23);
            this.cmbUpAction.TabIndex = 1;

            // lblDown
            this.lblDown.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblDown.ForeColor = textSecondary;
            this.lblDown.Location = new System.Drawing.Point(300, 35);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(70, 20);
            this.lblDown.TabIndex = 2;
            this.lblDown.Text = "아래 (↓)";

            // cmbDownAction
            this.cmbDownAction.BackColor = bgInput;
            this.cmbDownAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDownAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDownAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbDownAction.ForeColor = textPrimary;
            this.cmbDownAction.FormattingEnabled = true;
            this.cmbDownAction.Location = new System.Drawing.Point(375, 32);
            this.cmbDownAction.Name = "cmbDownAction";
            this.cmbDownAction.Size = new System.Drawing.Size(180, 23);
            this.cmbDownAction.TabIndex = 3;

            // lblLeft
            this.lblLeft.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblLeft.ForeColor = textSecondary;
            this.lblLeft.Location = new System.Drawing.Point(15, 80);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(60, 20);
            this.lblLeft.TabIndex = 4;
            this.lblLeft.Text = "왼쪽 (←)";

            // cmbLeftAction
            this.cmbLeftAction.BackColor = bgInput;
            this.cmbLeftAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeftAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLeftAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbLeftAction.ForeColor = textPrimary;
            this.cmbLeftAction.FormattingEnabled = true;
            this.cmbLeftAction.Location = new System.Drawing.Point(80, 77);
            this.cmbLeftAction.Name = "cmbLeftAction";
            this.cmbLeftAction.Size = new System.Drawing.Size(180, 23);
            this.cmbLeftAction.TabIndex = 5;

            // lblRight
            this.lblRight.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblRight.ForeColor = textSecondary;
            this.lblRight.Location = new System.Drawing.Point(300, 80);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(70, 20);
            this.lblRight.TabIndex = 6;
            this.lblRight.Text = "오른쪽 (→)";

            // cmbRightAction
            this.cmbRightAction.BackColor = bgInput;
            this.cmbRightAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRightAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRightAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbRightAction.ForeColor = textPrimary;
            this.cmbRightAction.FormattingEnabled = true;
            this.cmbRightAction.Location = new System.Drawing.Point(375, 77);
            this.cmbRightAction.Name = "cmbRightAction";
            this.cmbRightAction.Size = new System.Drawing.Size(180, 23);
            this.cmbRightAction.TabIndex = 7;

            // grpGestureLShape
            this.grpGestureLShape.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGestureLShape.Controls.Add(this.lblDownRight);
            this.grpGestureLShape.Controls.Add(this.cmbDownRightAction);
            this.grpGestureLShape.Controls.Add(this.lblDownLeft);
            this.grpGestureLShape.Controls.Add(this.cmbDownLeftAction);
            this.grpGestureLShape.Controls.Add(this.lblUpRight);
            this.grpGestureLShape.Controls.Add(this.cmbUpRightAction);
            this.grpGestureLShape.Controls.Add(this.lblUpLeft);
            this.grpGestureLShape.Controls.Add(this.cmbUpLeftAction);
            this.grpGestureLShape.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.grpGestureLShape.ForeColor = textSecondary;
            this.grpGestureLShape.Location = new System.Drawing.Point(0, 240);
            this.grpGestureLShape.Name = "grpGestureLShape";
            this.grpGestureLShape.Size = new System.Drawing.Size(1076, 120);
            this.grpGestureLShape.TabIndex = 2;
            this.grpGestureLShape.TabStop = false;
            this.grpGestureLShape.Text = "L자형 제스처";

            // lblDownRight
            this.lblDownRight.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblDownRight.ForeColor = textSecondary;
            this.lblDownRight.Location = new System.Drawing.Point(15, 35);
            this.lblDownRight.Name = "lblDownRight";
            this.lblDownRight.Size = new System.Drawing.Size(60, 20);
            this.lblDownRight.TabIndex = 0;
            this.lblDownRight.Text = "↓→ (ㄴ)";

            // cmbDownRightAction
            this.cmbDownRightAction.BackColor = bgInput;
            this.cmbDownRightAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDownRightAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDownRightAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbDownRightAction.ForeColor = textPrimary;
            this.cmbDownRightAction.FormattingEnabled = true;
            this.cmbDownRightAction.Location = new System.Drawing.Point(80, 32);
            this.cmbDownRightAction.Name = "cmbDownRightAction";
            this.cmbDownRightAction.Size = new System.Drawing.Size(180, 23);
            this.cmbDownRightAction.TabIndex = 1;

            // lblDownLeft
            this.lblDownLeft.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblDownLeft.ForeColor = textSecondary;
            this.lblDownLeft.Location = new System.Drawing.Point(300, 35);
            this.lblDownLeft.Name = "lblDownLeft";
            this.lblDownLeft.Size = new System.Drawing.Size(70, 20);
            this.lblDownLeft.TabIndex = 2;
            this.lblDownLeft.Text = "↓←";

            // cmbDownLeftAction
            this.cmbDownLeftAction.BackColor = bgInput;
            this.cmbDownLeftAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDownLeftAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDownLeftAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbDownLeftAction.ForeColor = textPrimary;
            this.cmbDownLeftAction.FormattingEnabled = true;
            this.cmbDownLeftAction.Location = new System.Drawing.Point(375, 32);
            this.cmbDownLeftAction.Name = "cmbDownLeftAction";
            this.cmbDownLeftAction.Size = new System.Drawing.Size(180, 23);
            this.cmbDownLeftAction.TabIndex = 3;

            // lblUpRight
            this.lblUpRight.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblUpRight.ForeColor = textSecondary;
            this.lblUpRight.Location = new System.Drawing.Point(15, 80);
            this.lblUpRight.Name = "lblUpRight";
            this.lblUpRight.Size = new System.Drawing.Size(60, 20);
            this.lblUpRight.TabIndex = 4;
            this.lblUpRight.Text = "↑→ (ㄱ)";

            // cmbUpRightAction
            this.cmbUpRightAction.BackColor = bgInput;
            this.cmbUpRightAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpRightAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUpRightAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbUpRightAction.ForeColor = textPrimary;
            this.cmbUpRightAction.FormattingEnabled = true;
            this.cmbUpRightAction.Location = new System.Drawing.Point(80, 77);
            this.cmbUpRightAction.Name = "cmbUpRightAction";
            this.cmbUpRightAction.Size = new System.Drawing.Size(180, 23);
            this.cmbUpRightAction.TabIndex = 5;

            // lblUpLeft
            this.lblUpLeft.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblUpLeft.ForeColor = textSecondary;
            this.lblUpLeft.Location = new System.Drawing.Point(300, 80);
            this.lblUpLeft.Name = "lblUpLeft";
            this.lblUpLeft.Size = new System.Drawing.Size(70, 20);
            this.lblUpLeft.TabIndex = 6;
            this.lblUpLeft.Text = "↑←";

            // cmbUpLeftAction
            this.cmbUpLeftAction.BackColor = bgInput;
            this.cmbUpLeftAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpLeftAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUpLeftAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbUpLeftAction.ForeColor = textPrimary;
            this.cmbUpLeftAction.FormattingEnabled = true;
            this.cmbUpLeftAction.Location = new System.Drawing.Point(375, 77);
            this.cmbUpLeftAction.Name = "cmbUpLeftAction";
            this.cmbUpLeftAction.Size = new System.Drawing.Size(180, 23);
            this.cmbUpLeftAction.TabIndex = 7;

            // grpGestureDiagonal
            this.grpGestureDiagonal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGestureDiagonal.Controls.Add(this.lblDiagDownRight);
            this.grpGestureDiagonal.Controls.Add(this.cmbDiagDownRightAction);
            this.grpGestureDiagonal.Controls.Add(this.lblDiagDownLeft);
            this.grpGestureDiagonal.Controls.Add(this.cmbDiagDownLeftAction);
            this.grpGestureDiagonal.Controls.Add(this.lblDiagUpRight);
            this.grpGestureDiagonal.Controls.Add(this.cmbDiagUpRightAction);
            this.grpGestureDiagonal.Controls.Add(this.lblDiagUpLeft);
            this.grpGestureDiagonal.Controls.Add(this.cmbDiagUpLeftAction);
            this.grpGestureDiagonal.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.grpGestureDiagonal.ForeColor = textSecondary;
            this.grpGestureDiagonal.Location = new System.Drawing.Point(0, 380);
            this.grpGestureDiagonal.Name = "grpGestureDiagonal";
            this.grpGestureDiagonal.Size = new System.Drawing.Size(1076, 120);
            this.grpGestureDiagonal.TabIndex = 4;
            this.grpGestureDiagonal.TabStop = false;
            this.grpGestureDiagonal.Text = "대각선 제스처";

            // lblDiagDownRight
            this.lblDiagDownRight.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblDiagDownRight.ForeColor = textSecondary;
            this.lblDiagDownRight.Location = new System.Drawing.Point(15, 35);
            this.lblDiagDownRight.Name = "lblDiagDownRight";
            this.lblDiagDownRight.Size = new System.Drawing.Size(60, 20);
            this.lblDiagDownRight.TabIndex = 0;
            this.lblDiagDownRight.Text = "↘";

            // cmbDiagDownRightAction
            this.cmbDiagDownRightAction.BackColor = bgInput;
            this.cmbDiagDownRightAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiagDownRightAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDiagDownRightAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbDiagDownRightAction.ForeColor = textPrimary;
            this.cmbDiagDownRightAction.FormattingEnabled = true;
            this.cmbDiagDownRightAction.Location = new System.Drawing.Point(80, 32);
            this.cmbDiagDownRightAction.Name = "cmbDiagDownRightAction";
            this.cmbDiagDownRightAction.Size = new System.Drawing.Size(180, 23);
            this.cmbDiagDownRightAction.TabIndex = 1;

            // lblDiagDownLeft
            this.lblDiagDownLeft.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblDiagDownLeft.ForeColor = textSecondary;
            this.lblDiagDownLeft.Location = new System.Drawing.Point(300, 35);
            this.lblDiagDownLeft.Name = "lblDiagDownLeft";
            this.lblDiagDownLeft.Size = new System.Drawing.Size(70, 20);
            this.lblDiagDownLeft.TabIndex = 2;
            this.lblDiagDownLeft.Text = "↙";

            // cmbDiagDownLeftAction
            this.cmbDiagDownLeftAction.BackColor = bgInput;
            this.cmbDiagDownLeftAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiagDownLeftAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDiagDownLeftAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbDiagDownLeftAction.ForeColor = textPrimary;
            this.cmbDiagDownLeftAction.FormattingEnabled = true;
            this.cmbDiagDownLeftAction.Location = new System.Drawing.Point(375, 32);
            this.cmbDiagDownLeftAction.Name = "cmbDiagDownLeftAction";
            this.cmbDiagDownLeftAction.Size = new System.Drawing.Size(180, 23);
            this.cmbDiagDownLeftAction.TabIndex = 3;

            // lblDiagUpRight
            this.lblDiagUpRight.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblDiagUpRight.ForeColor = textSecondary;
            this.lblDiagUpRight.Location = new System.Drawing.Point(15, 80);
            this.lblDiagUpRight.Name = "lblDiagUpRight";
            this.lblDiagUpRight.Size = new System.Drawing.Size(60, 20);
            this.lblDiagUpRight.TabIndex = 4;
            this.lblDiagUpRight.Text = "↗";

            // cmbDiagUpRightAction
            this.cmbDiagUpRightAction.BackColor = bgInput;
            this.cmbDiagUpRightAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiagUpRightAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDiagUpRightAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbDiagUpRightAction.ForeColor = textPrimary;
            this.cmbDiagUpRightAction.FormattingEnabled = true;
            this.cmbDiagUpRightAction.Location = new System.Drawing.Point(80, 77);
            this.cmbDiagUpRightAction.Name = "cmbDiagUpRightAction";
            this.cmbDiagUpRightAction.Size = new System.Drawing.Size(180, 23);
            this.cmbDiagUpRightAction.TabIndex = 5;

            // lblDiagUpLeft
            this.lblDiagUpLeft.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lblDiagUpLeft.ForeColor = textSecondary;
            this.lblDiagUpLeft.Location = new System.Drawing.Point(300, 80);
            this.lblDiagUpLeft.Name = "lblDiagUpLeft";
            this.lblDiagUpLeft.Size = new System.Drawing.Size(70, 20);
            this.lblDiagUpLeft.TabIndex = 6;
            this.lblDiagUpLeft.Text = "↖";

            // cmbDiagUpLeftAction
            this.cmbDiagUpLeftAction.BackColor = bgInput;
            this.cmbDiagUpLeftAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiagUpLeftAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDiagUpLeftAction.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbDiagUpLeftAction.ForeColor = textPrimary;
            this.cmbDiagUpLeftAction.FormattingEnabled = true;
            this.cmbDiagUpLeftAction.Location = new System.Drawing.Point(375, 77);
            this.cmbDiagUpLeftAction.Name = "cmbDiagUpLeftAction";
            this.cmbDiagUpLeftAction.Size = new System.Drawing.Size(180, 23);
            this.cmbDiagUpLeftAction.TabIndex = 7;

            // btnApplyGesture
            this.btnApplyGesture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyGesture.BackColor = accentBlue;
            this.btnApplyGesture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyGesture.FlatAppearance.BorderSize = 0;
            this.btnApplyGesture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyGesture.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnApplyGesture.ForeColor = System.Drawing.Color.White;
            this.btnApplyGesture.Location = new System.Drawing.Point(966, 610);
            this.btnApplyGesture.Name = "btnApplyGesture";
            this.btnApplyGesture.Size = new System.Drawing.Size(100, 36);
            this.btnApplyGesture.TabIndex = 3;
            this.btnApplyGesture.Text = "저장";
            this.btnApplyGesture.UseVisualStyleBackColor = false;
            this.btnApplyGesture.Click += new System.EventHandler(this.btnApplyGesture_Click);

            // ========================================
            // SettingsForm
            // ========================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = bgDark;
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "설정";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelCommands.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommands)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelGeneral.ResumeLayout(false);
            this.grpFont.ResumeLayout(false);
            this.grpFont.PerformLayout();
            this.grpAppearance.ResumeLayout(false);
            this.grpUtility.ResumeLayout(false);
            this.panelGesture.ResumeLayout(false);
            this.grpGestureBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPenWidth)).EndInit();
            this.grpGestureActions.ResumeLayout(false);
            this.grpGestureLShape.ResumeLayout(false);
            this.grpGestureDiagonal.ResumeLayout(false);
            this.panelTabNav.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        // 메인 컨테이너
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;

        // 탭 네비게이션
        private System.Windows.Forms.Panel panelTabNav;
        private System.Windows.Forms.Button btnTabCommands;
        private System.Windows.Forms.Button btnTabGeneral;
        private System.Windows.Forms.Button btnTabGesture;

        // 콘텐츠 영역
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Panel panelGeneral;
        private System.Windows.Forms.Panel panelGesture;

        // 명령어 설정
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView dataGridViewCommands;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;

        // 일반 설정
        private System.Windows.Forms.GroupBox grpFont;
        private System.Windows.Forms.Button btnSelectFont;
        private System.Windows.Forms.Label lblFontPreview;
        private System.Windows.Forms.GroupBox grpAppearance;
        private System.Windows.Forms.Label lblBgColor;
        private System.Windows.Forms.Button btnBgColor;
        private System.Windows.Forms.Panel panelBgColorPreview;
        private System.Windows.Forms.Label lblTextColor;
        private System.Windows.Forms.Button btnTextColor;
        private System.Windows.Forms.Panel panelTextColorPreview;
        private System.Windows.Forms.Button btnResetColors;
        private System.Windows.Forms.GroupBox grpUtility;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnApplySettings;

        // 제스처 설정
        private System.Windows.Forms.GroupBox grpGestureBasic;
        private System.Windows.Forms.CheckBox chkGestureEnabled;
        private System.Windows.Forms.Label lblGestureColor;
        private System.Windows.Forms.Button btnGestureColor;
        private System.Windows.Forms.Panel panelGestureColorPreview;
        private System.Windows.Forms.Label lblPenWidth;
        private System.Windows.Forms.NumericUpDown numPenWidth;
        private System.Windows.Forms.GroupBox grpGestureActions;
        private System.Windows.Forms.Label lblUp;
        private System.Windows.Forms.ComboBox cmbUpAction;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.ComboBox cmbDownAction;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.ComboBox cmbLeftAction;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.ComboBox cmbRightAction;
        private System.Windows.Forms.GroupBox grpGestureLShape;
        private System.Windows.Forms.Label lblDownRight;
        private System.Windows.Forms.ComboBox cmbDownRightAction;
        private System.Windows.Forms.Label lblDownLeft;
        private System.Windows.Forms.ComboBox cmbDownLeftAction;
        private System.Windows.Forms.Label lblUpRight;
        private System.Windows.Forms.ComboBox cmbUpRightAction;
        private System.Windows.Forms.Label lblUpLeft;
        private System.Windows.Forms.ComboBox cmbUpLeftAction;
        private System.Windows.Forms.GroupBox grpGestureDiagonal;
        private System.Windows.Forms.Label lblDiagDownRight;
        private System.Windows.Forms.ComboBox cmbDiagDownRightAction;
        private System.Windows.Forms.Label lblDiagDownLeft;
        private System.Windows.Forms.ComboBox cmbDiagDownLeftAction;
        private System.Windows.Forms.Label lblDiagUpRight;
        private System.Windows.Forms.ComboBox cmbDiagUpRightAction;
        private System.Windows.Forms.Label lblDiagUpLeft;
        private System.Windows.Forms.ComboBox cmbDiagUpLeftAction;
        private System.Windows.Forms.Button btnApplyGesture;
    }
}
