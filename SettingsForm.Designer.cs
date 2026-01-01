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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            // 명령어 설정 패널
            this.panelCommands = new System.Windows.Forms.Panel();
            this.panelCommandContent = new System.Windows.Forms.Panel();
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
            this.panelGeneralContent = new System.Windows.Forms.Panel();
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
            // 탭 네비게이션
            this.panelTabNav = new System.Windows.Forms.Panel();
            this.btnTabCommands = new System.Windows.Forms.Button();
            this.btnTabGeneral = new System.Windows.Forms.Button();
            // 헤더
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitleIcon = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();

            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelCommands.SuspendLayout();
            this.panelCommandContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommands)).BeginInit();
            this.panelInput.SuspendLayout();
            this.panelGeneral.SuspendLayout();
            this.panelGeneralContent.SuspendLayout();
            this.grpAppearance.SuspendLayout();
            this.grpFont.SuspendLayout();
            this.grpUtility.SuspendLayout();
            this.panelTabNav.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            //
            // panelMain
            //
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelTabNav);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(2);
            this.panelMain.Size = new System.Drawing.Size(900, 600);
            this.panelMain.TabIndex = 0;
            //
            // panelTabNav - 커스텀 탭 네비게이션
            //
            this.panelTabNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.panelTabNav.Controls.Add(this.btnTabCommands);
            this.panelTabNav.Controls.Add(this.btnTabGeneral);
            this.panelTabNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTabNav.Location = new System.Drawing.Point(2, 62);
            this.panelTabNav.Name = "panelTabNav";
            this.panelTabNav.Size = new System.Drawing.Size(896, 50);
            this.panelTabNav.TabIndex = 1;
            //
            // btnTabCommands
            //
            this.btnTabCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnTabCommands.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabCommands.FlatAppearance.BorderSize = 0;
            this.btnTabCommands.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnTabCommands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabCommands.Font = new System.Drawing.Font("NanumGothicOTF", 11F, System.Drawing.FontStyle.Bold);
            this.btnTabCommands.ForeColor = System.Drawing.Color.White;
            this.btnTabCommands.Location = new System.Drawing.Point(15, 8);
            this.btnTabCommands.Name = "btnTabCommands";
            this.btnTabCommands.Size = new System.Drawing.Size(140, 34);
            this.btnTabCommands.TabIndex = 0;
            this.btnTabCommands.Text = "명령어 설정";
            this.btnTabCommands.UseVisualStyleBackColor = false;
            this.btnTabCommands.Click += new System.EventHandler(this.btnTabCommands_Click);
            //
            // btnTabGeneral
            //
            this.btnTabGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.btnTabGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabGeneral.FlatAppearance.BorderSize = 0;
            this.btnTabGeneral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(215)))));
            this.btnTabGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabGeneral.Font = new System.Drawing.Font("NanumGothicOTF", 11F, System.Drawing.FontStyle.Bold);
            this.btnTabGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btnTabGeneral.Location = new System.Drawing.Point(165, 8);
            this.btnTabGeneral.Name = "btnTabGeneral";
            this.btnTabGeneral.Size = new System.Drawing.Size(140, 34);
            this.btnTabGeneral.TabIndex = 1;
            this.btnTabGeneral.Text = "일반 설정";
            this.btnTabGeneral.UseVisualStyleBackColor = false;
            this.btnTabGeneral.Click += new System.EventHandler(this.btnTabGeneral_Click);
            //
            // panelContent
            //
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.panelContent.Controls.Add(this.panelCommands);
            this.panelContent.Controls.Add(this.panelGeneral);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(2, 112);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(896, 486);
            this.panelContent.TabIndex = 2;
            //
            // panelCommands - 명령어 설정 패널
            //
            this.panelCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.panelCommands.Controls.Add(this.panelCommandContent);
            this.panelCommands.Controls.Add(this.panelInput);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommands.Location = new System.Drawing.Point(0, 0);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Padding = new System.Windows.Forms.Padding(3);
            this.panelCommands.Size = new System.Drawing.Size(896, 486);
            this.panelCommands.TabIndex = 0;
            //
            // panelCommandContent
            //
            this.panelCommandContent.Controls.Add(this.dataGridViewCommands);
            this.panelCommandContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommandContent.Location = new System.Drawing.Point(3, 3);
            this.panelCommandContent.Name = "panelCommandContent";
            this.panelCommandContent.Padding = new System.Windows.Forms.Padding(10);
            this.panelCommandContent.Size = new System.Drawing.Size(890, 290);
            this.panelCommandContent.TabIndex = 1;
            //
            // dataGridViewCommands
            //
            this.dataGridViewCommands.AllowUserToAddRows = false;
            this.dataGridViewCommands.AllowUserToDeleteRows = false;
            this.dataGridViewCommands.AllowUserToResizeRows = false;
            this.dataGridViewCommands.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCommands.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCommands.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewCommands.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dataGridViewCommands.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCommands.ColumnHeadersHeight = 40;
            this.dataGridViewCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCommands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEnabled,
            this.colName,
            this.colDescription,
            this.colPath,
            this.colType});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("NanumGothicOTF", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dataGridViewCommands.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCommands.EnableHeadersVisualStyles = false;
            this.dataGridViewCommands.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.dataGridViewCommands.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewCommands.MultiSelect = false;
            this.dataGridViewCommands.Name = "dataGridViewCommands";
            this.dataGridViewCommands.RowHeadersVisible = false;
            this.dataGridViewCommands.RowTemplate.Height = 35;
            this.dataGridViewCommands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCommands.Size = new System.Drawing.Size(870, 270);
            this.dataGridViewCommands.TabIndex = 0;
            this.dataGridViewCommands.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCommands_CellValueChanged);
            this.dataGridViewCommands.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewCommands_CurrentCellDirtyStateChanged);
            this.dataGridViewCommands.SelectionChanged += new System.EventHandler(this.dataGridViewCommands_SelectionChanged);
            //
            // colEnabled
            //
            this.colEnabled.FillWeight = 40F;
            this.colEnabled.HeaderText = "활성";
            this.colEnabled.Name = "colEnabled";
            //
            // colName
            //
            this.colName.FillWeight = 80F;
            this.colName.HeaderText = "명령어";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            //
            // colDescription
            //
            this.colDescription.FillWeight = 120F;
            this.colDescription.HeaderText = "설명";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            //
            // colPath
            //
            this.colPath.FillWeight = 200F;
            this.colPath.HeaderText = "경로";
            this.colPath.Name = "colPath";
            this.colPath.ReadOnly = true;
            //
            // colType
            //
            this.colType.FillWeight = 60F;
            this.colType.HeaderText = "타입";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            //
            // panelInput
            //
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
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
            this.panelInput.Location = new System.Drawing.Point(3, 293);
            this.panelInput.Name = "panelInput";
            this.panelInput.Padding = new System.Windows.Forms.Padding(15);
            this.panelInput.Size = new System.Drawing.Size(890, 190);
            this.panelInput.TabIndex = 0;
            //
            // btnBrowse
            //
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(150)))));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(820, 78);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(50, 30);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            //
            // btnClear
            //
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(150)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(15, 130);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 40);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "초기화";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnDelete
            //
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(780, 130);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 40);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnEdit
            //
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(680, 130);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 40);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "수정";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            //
            // btnAdd
            //
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(222)))), ((int)(((byte)(128)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(580, 130);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 40);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // txtPath
            //
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Font = new System.Drawing.Font("NanumGothicOTF", 11F);
            this.txtPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.txtPath.Location = new System.Drawing.Point(90, 78);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(724, 27);
            this.txtPath.TabIndex = 5;
            //
            // txtDescription
            //
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("NanumGothicOTF", 11F);
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.txtDescription.Location = new System.Drawing.Point(90, 45);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(780, 27);
            this.txtDescription.TabIndex = 4;
            //
            // txtName
            //
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("NanumGothicOTF", 11F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.txtName.Location = new System.Drawing.Point(90, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 27);
            this.txtName.TabIndex = 3;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(15, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "경로";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "설명";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "명령어";
            //
            // panelGeneral - 일반 설정 패널
            //
            this.panelGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.panelGeneral.Controls.Add(this.panelGeneralContent);
            this.panelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGeneral.Location = new System.Drawing.Point(0, 0);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.panelGeneral.Size = new System.Drawing.Size(896, 486);
            this.panelGeneral.TabIndex = 1;
            this.panelGeneral.Visible = false;
            //
            // panelGeneralContent
            //
            this.panelGeneralContent.Controls.Add(this.grpUtility);
            this.panelGeneralContent.Controls.Add(this.grpAppearance);
            this.panelGeneralContent.Controls.Add(this.grpFont);
            this.panelGeneralContent.Controls.Add(this.btnApplySettings);
            this.panelGeneralContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGeneralContent.Location = new System.Drawing.Point(3, 3);
            this.panelGeneralContent.Name = "panelGeneralContent";
            this.panelGeneralContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelGeneralContent.Size = new System.Drawing.Size(890, 480);
            this.panelGeneralContent.TabIndex = 0;
            //
            // grpFont
            //
            this.grpFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFont.Controls.Add(this.btnSelectFont);
            this.grpFont.Controls.Add(this.lblFontPreview);
            this.grpFont.Font = new System.Drawing.Font("NanumGothicOTF", 11F, System.Drawing.FontStyle.Bold);
            this.grpFont.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.grpFont.Location = new System.Drawing.Point(20, 20);
            this.grpFont.Name = "grpFont";
            this.grpFont.Size = new System.Drawing.Size(850, 100);
            this.grpFont.TabIndex = 0;
            this.grpFont.TabStop = false;
            this.grpFont.Text = "폰트 설정";
            //
            // btnSelectFont
            //
            this.btnSelectFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnSelectFont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectFont.FlatAppearance.BorderSize = 0;
            this.btnSelectFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFont.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.btnSelectFont.ForeColor = System.Drawing.Color.White;
            this.btnSelectFont.Location = new System.Drawing.Point(20, 50);
            this.btnSelectFont.Name = "btnSelectFont";
            this.btnSelectFont.Size = new System.Drawing.Size(120, 35);
            this.btnSelectFont.TabIndex = 0;
            this.btnSelectFont.Text = "폰트 선택...";
            this.btnSelectFont.UseVisualStyleBackColor = false;
            this.btnSelectFont.Click += new System.EventHandler(this.btnSelectFont_Click);
            //
            // lblFontPreview
            //
            this.lblFontPreview.AutoSize = true;
            this.lblFontPreview.Font = new System.Drawing.Font("NanumGothicOTF", 14F);
            this.lblFontPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblFontPreview.Location = new System.Drawing.Point(160, 55);
            this.lblFontPreview.Name = "lblFontPreview";
            this.lblFontPreview.Size = new System.Drawing.Size(200, 26);
            this.lblFontPreview.TabIndex = 1;
            this.lblFontPreview.Text = "NanumGothicOTF, 20pt";
            //
            // grpAppearance
            //
            this.grpAppearance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAppearance.Controls.Add(this.btnResetColors);
            this.grpAppearance.Controls.Add(this.panelTextColorPreview);
            this.grpAppearance.Controls.Add(this.btnTextColor);
            this.grpAppearance.Controls.Add(this.lblTextColor);
            this.grpAppearance.Controls.Add(this.panelBgColorPreview);
            this.grpAppearance.Controls.Add(this.btnBgColor);
            this.grpAppearance.Controls.Add(this.lblBgColor);
            this.grpAppearance.Font = new System.Drawing.Font("NanumGothicOTF", 11F, System.Drawing.FontStyle.Bold);
            this.grpAppearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.grpAppearance.Location = new System.Drawing.Point(20, 130);
            this.grpAppearance.Name = "grpAppearance";
            this.grpAppearance.Size = new System.Drawing.Size(850, 150);
            this.grpAppearance.TabIndex = 1;
            this.grpAppearance.TabStop = false;
            this.grpAppearance.Text = "색상 설정";
            //
            // lblBgColor
            //
            this.lblBgColor.AutoSize = true;
            this.lblBgColor.Font = new System.Drawing.Font("NanumGothicOTF", 10F);
            this.lblBgColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.lblBgColor.Location = new System.Drawing.Point(20, 45);
            this.lblBgColor.Name = "lblBgColor";
            this.lblBgColor.Size = new System.Drawing.Size(57, 19);
            this.lblBgColor.TabIndex = 0;
            this.lblBgColor.Text = "배경 색상";
            //
            // btnBgColor
            //
            this.btnBgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnBgColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBgColor.FlatAppearance.BorderSize = 0;
            this.btnBgColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBgColor.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.btnBgColor.ForeColor = System.Drawing.Color.White;
            this.btnBgColor.Location = new System.Drawing.Point(120, 40);
            this.btnBgColor.Name = "btnBgColor";
            this.btnBgColor.Size = new System.Drawing.Size(100, 30);
            this.btnBgColor.TabIndex = 1;
            this.btnBgColor.Text = "색상 선택...";
            this.btnBgColor.UseVisualStyleBackColor = false;
            this.btnBgColor.Click += new System.EventHandler(this.btnBgColor_Click);
            //
            // panelBgColorPreview
            //
            this.panelBgColorPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelBgColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBgColorPreview.Location = new System.Drawing.Point(230, 40);
            this.panelBgColorPreview.Name = "panelBgColorPreview";
            this.panelBgColorPreview.Size = new System.Drawing.Size(60, 30);
            this.panelBgColorPreview.TabIndex = 2;
            //
            // lblTextColor
            //
            this.lblTextColor.AutoSize = true;
            this.lblTextColor.Font = new System.Drawing.Font("NanumGothicOTF", 10F);
            this.lblTextColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.lblTextColor.Location = new System.Drawing.Point(20, 95);
            this.lblTextColor.Name = "lblTextColor";
            this.lblTextColor.Size = new System.Drawing.Size(71, 19);
            this.lblTextColor.TabIndex = 3;
            this.lblTextColor.Text = "텍스트 색상";
            //
            // btnTextColor
            //
            this.btnTextColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnTextColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTextColor.FlatAppearance.BorderSize = 0;
            this.btnTextColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTextColor.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.btnTextColor.ForeColor = System.Drawing.Color.White;
            this.btnTextColor.Location = new System.Drawing.Point(120, 90);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(100, 30);
            this.btnTextColor.TabIndex = 4;
            this.btnTextColor.Text = "색상 선택...";
            this.btnTextColor.UseVisualStyleBackColor = false;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            //
            // panelTextColorPreview
            //
            this.panelTextColorPreview.BackColor = System.Drawing.Color.White;
            this.panelTextColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTextColorPreview.Location = new System.Drawing.Point(230, 90);
            this.panelTextColorPreview.Name = "panelTextColorPreview";
            this.panelTextColorPreview.Size = new System.Drawing.Size(60, 30);
            this.panelTextColorPreview.TabIndex = 5;
            //
            // btnResetColors
            //
            this.btnResetColors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnResetColors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetColors.FlatAppearance.BorderSize = 0;
            this.btnResetColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetColors.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.btnResetColors.ForeColor = System.Drawing.Color.White;
            this.btnResetColors.Location = new System.Drawing.Point(320, 65);
            this.btnResetColors.Name = "btnResetColors";
            this.btnResetColors.Size = new System.Drawing.Size(100, 30);
            this.btnResetColors.TabIndex = 6;
            this.btnResetColors.Text = "기본값";
            this.btnResetColors.UseVisualStyleBackColor = false;
            this.btnResetColors.Click += new System.EventHandler(this.btnResetColors_Click);
            //
            // grpUtility
            //
            this.grpUtility.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUtility.Controls.Add(this.btnOpenFolder);
            this.grpUtility.Font = new System.Drawing.Font("NanumGothicOTF", 11F, System.Drawing.FontStyle.Bold);
            this.grpUtility.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.grpUtility.Location = new System.Drawing.Point(20, 290);
            this.grpUtility.Name = "grpUtility";
            this.grpUtility.Size = new System.Drawing.Size(850, 90);
            this.grpUtility.TabIndex = 2;
            this.grpUtility.TabStop = false;
            this.grpUtility.Text = "유틸리티";
            //
            // btnOpenFolder
            //
            this.btnOpenFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFolder.FlatAppearance.BorderSize = 0;
            this.btnOpenFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(150)))));
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFolder.Font = new System.Drawing.Font("NanumGothicOTF", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenFolder.ForeColor = System.Drawing.Color.White;
            this.btnOpenFolder.Location = new System.Drawing.Point(20, 40);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(180, 35);
            this.btnOpenFolder.TabIndex = 0;
            this.btnOpenFolder.Text = "설치 폴더 열기";
            this.btnOpenFolder.UseVisualStyleBackColor = false;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            //
            // btnApplySettings
            //
            this.btnApplySettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplySettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnApplySettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplySettings.FlatAppearance.BorderSize = 0;
            this.btnApplySettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplySettings.Font = new System.Drawing.Font("NanumGothicOTF", 12F, System.Drawing.FontStyle.Bold);
            this.btnApplySettings.ForeColor = System.Drawing.Color.White;
            this.btnApplySettings.Location = new System.Drawing.Point(740, 420);
            this.btnApplySettings.Name = "btnApplySettings";
            this.btnApplySettings.Size = new System.Drawing.Size(130, 40);
            this.btnApplySettings.TabIndex = 3;
            this.btnApplySettings.Text = "설정 적용";
            this.btnApplySettings.UseVisualStyleBackColor = false;
            this.btnApplySettings.Click += new System.EventHandler(this.btnApplySettings_Click);
            //
            // panelHeader
            //
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.lblTitleIcon);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(2, 2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(896, 60);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("NanumGothicOTF", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(846, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "\u2715";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // lblTitleIcon
            //
            this.lblTitleIcon.AutoSize = true;
            this.lblTitleIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 20F);
            this.lblTitleIcon.ForeColor = System.Drawing.Color.White;
            this.lblTitleIcon.Location = new System.Drawing.Point(15, 10);
            this.lblTitleIcon.Name = "lblTitleIcon";
            this.lblTitleIcon.Size = new System.Drawing.Size(44, 37);
            this.lblTitleIcon.TabIndex = 2;
            this.lblTitleIcon.Text = "\u2699";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("NanumGothicOTF", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(60, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(54, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "설정";
            //
            // SettingsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("NanumGothicOTF", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "설정";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelCommands.ResumeLayout(false);
            this.panelCommandContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommands)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelGeneral.ResumeLayout(false);
            this.panelGeneralContent.ResumeLayout(false);
            this.grpFont.ResumeLayout(false);
            this.grpFont.PerformLayout();
            this.grpAppearance.ResumeLayout(false);
            this.grpAppearance.PerformLayout();
            this.grpUtility.ResumeLayout(false);
            this.panelTabNav.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitleIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        // 커스텀 탭 네비게이션
        private System.Windows.Forms.Panel panelTabNav;
        private System.Windows.Forms.Button btnTabCommands;
        private System.Windows.Forms.Button btnTabGeneral;
        // 콘텐츠 영역
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Panel panelGeneral;
        // 명령어 설정
        private System.Windows.Forms.Panel panelCommandContent;
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
        private System.Windows.Forms.Panel panelGeneralContent;
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
    }
}
