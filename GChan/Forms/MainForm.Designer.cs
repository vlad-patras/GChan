﻿using GChan.ViewModels;

namespace GChan.Forms
{
    partial class MainForm {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            openFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            openLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            changelogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            updateAvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            listsTabControl = new System.Windows.Forms.TabControl();
            threadsTabPage = new System.Windows.Forms.TabPage();
            threadGridView = new Controls.PreferencesDataGridView();
            threadGridSubjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            threadGridSiteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            threadGridBoardCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            threadGridFileCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            threadsContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copyURLToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            threadsBindingSource = new System.Windows.Forms.BindingSource(components);
            mainFormModelBindingSource = new System.Windows.Forms.BindingSource(components);
            boardsTabPage = new System.Windows.Forms.TabPage();
            boardsListBox = new System.Windows.Forms.ListBox();
            boardsContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            boardsContextMenuOpenFolderButton = new System.Windows.Forms.ToolStripMenuItem();
            boardsContextMenuOpenInBrowserButton = new System.Windows.Forms.ToolStripMenuItem();
            boardsContextMenuRemoveButton = new System.Windows.Forms.ToolStripMenuItem();
            boardsBindingSource = new System.Windows.Forms.BindingSource(components);
            addButton = new System.Windows.Forms.Button();
            urlTextBox = new System.Windows.Forms.TextBox();
            systemTrayNotifyIcon = new System.Windows.Forms.NotifyIcon(components);
            systemTrayContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            systemTrayOpenFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            systemTrayExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearAllButton = new System.Windows.Forms.Button();
            clipboardButton = new System.Windows.Forms.Button();
            toolTip = new System.Windows.Forms.ToolTip(components);
            menuStrip.SuspendLayout();
            listsTabControl.SuspendLayout();
            threadsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)threadGridView).BeginInit();
            threadsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)threadsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainFormModelBindingSource).BeginInit();
            boardsTabPage.SuspendLayout();
            boardsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)boardsBindingSource).BeginInit();
            systemTrayContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem, updateAvailableToolStripMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip.Size = new System.Drawing.Size(679, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "msHead";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { settingsToolStripMenuItem1, openFolderToolStripMenuItem1, openLogsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem1
            // 
            settingsToolStripMenuItem1.Image = Properties.Resources.settings_wrench;
            settingsToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            settingsToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            settingsToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            settingsToolStripMenuItem1.Text = "&Settings";
            settingsToolStripMenuItem1.Click += settingsToolStripMenuItem_Click;
            // 
            // openFolderToolStripMenuItem1
            // 
            openFolderToolStripMenuItem1.Image = Properties.Resources.folder;
            openFolderToolStripMenuItem1.Name = "openFolderToolStripMenuItem1";
            openFolderToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F;
            openFolderToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            openFolderToolStripMenuItem1.Text = "Open &Folder";
            openFolderToolStripMenuItem1.Click += openFolderToolStripMenuItem1_Click;
            // 
            // openLogsToolStripMenuItem
            // 
            openLogsToolStripMenuItem.Image = Properties.Resources.file;
            openLogsToolStripMenuItem.Name = "openLogsToolStripMenuItem";
            openLogsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P;
            openLogsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            openLogsToolStripMenuItem.Text = "Open Logs";
            openLogsToolStripMenuItem.ToolTipText = "The ProgramData folder contains the files used to store saved threads & boards, and also crash logs to help with debugging.";
            openLogsToolStripMenuItem.Click += openLogsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = Properties.Resources.close;
            exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q;
            exitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { changelogToolStripMenuItem1, aboutToolStripMenuItem1, checkForUpdatesToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // changelogToolStripMenuItem1
            // 
            changelogToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Control;
            changelogToolStripMenuItem1.Image = Properties.Resources.alert;
            changelogToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            changelogToolStripMenuItem1.Name = "changelogToolStripMenuItem1";
            changelogToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            changelogToolStripMenuItem1.Text = "&Changelog";
            changelogToolStripMenuItem1.Click += changelogToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Image = Properties.Resources.question;
            aboutToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            aboutToolStripMenuItem1.Text = "&About";
            aboutToolStripMenuItem1.Click += aboutToolStripMenuItem_Click;
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            checkForUpdatesToolStripMenuItem.Image = Properties.Resources.download;
            checkForUpdatesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            checkForUpdatesToolStripMenuItem.Click += checkForUpdatesToolStripMenuItem_Click;
            // 
            // updateAvailableToolStripMenuItem
            // 
            updateAvailableToolStripMenuItem.Image = Properties.Resources.alert;
            updateAvailableToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            updateAvailableToolStripMenuItem.Name = "updateAvailableToolStripMenuItem";
            updateAvailableToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            updateAvailableToolStripMenuItem.Text = "Update Available!";
            updateAvailableToolStripMenuItem.ToolTipText = "An update is available for GChan! Click here for more info.";
            updateAvailableToolStripMenuItem.Visible = false;
            updateAvailableToolStripMenuItem.Click += updateAvailableToolStripMenuItem_Click;
            // 
            // listsTabControl
            // 
            listsTabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listsTabControl.Controls.Add(threadsTabPage);
            listsTabControl.Controls.Add(boardsTabPage);
            listsTabControl.Location = new System.Drawing.Point(14, 65);
            listsTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listsTabControl.Name = "listsTabControl";
            listsTabControl.SelectedIndex = 0;
            listsTabControl.Size = new System.Drawing.Size(651, 256);
            listsTabControl.TabIndex = 1;
            // 
            // threadsTabPage
            // 
            threadsTabPage.Controls.Add(threadGridView);
            threadsTabPage.Location = new System.Drawing.Point(4, 24);
            threadsTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            threadsTabPage.Name = "threadsTabPage";
            threadsTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            threadsTabPage.Size = new System.Drawing.Size(643, 228);
            threadsTabPage.TabIndex = 0;
            threadsTabPage.Text = "Threads (0)";
            threadsTabPage.UseVisualStyleBackColor = true;
            // 
            // threadGridView
            // 
            threadGridView.AllowUserToAddRows = false;
            threadGridView.AllowUserToDeleteRows = false;
            threadGridView.AllowUserToOrderColumns = true;
            threadGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            dataGridViewCellStyle1.NullValue = " ";
            threadGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            threadGridView.AutoGenerateColumns = false;
            threadGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            threadGridView.BackgroundColor = System.Drawing.Color.White;
            threadGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            threadGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            threadGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { threadGridSubjectColumn, threadGridSiteColumn, threadGridBoardCodeColumn, threadGridFileCountColumn });
            threadGridView.ContextMenuStrip = threadsContextMenu;
            threadGridView.DataSource = threadsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = " ";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            threadGridView.DefaultCellStyle = dataGridViewCellStyle2;
            threadGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            threadGridView.GridColor = System.Drawing.SystemColors.Window;
            threadGridView.Location = new System.Drawing.Point(4, 3);
            threadGridView.Margin = new System.Windows.Forms.Padding(0);
            threadGridView.MultiSelect = false;
            threadGridView.Name = "threadGridView";
            threadGridView.ReadOnly = true;
            threadGridView.RowHeadersVisible = false;
            threadGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            threadGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            threadGridView.ShowCellErrors = false;
            threadGridView.ShowEditingIcon = false;
            threadGridView.ShowRowErrors = false;
            threadGridView.Size = new System.Drawing.Size(635, 222);
            threadGridView.TabIndex = 1;
            threadGridView.DataError += threadGridView_DataError;
            threadGridView.MouseDown += threadGridView_MouseDown;
            // 
            // threadGridSubjectColumn
            // 
            threadGridSubjectColumn.DataPropertyName = "Subject";
            threadGridSubjectColumn.FillWeight = 25F;
            threadGridSubjectColumn.HeaderText = "Subject";
            threadGridSubjectColumn.Name = "threadGridSubjectColumn";
            threadGridSubjectColumn.ReadOnly = true;
            // 
            // threadGridSiteColumn
            // 
            threadGridSiteColumn.DataPropertyName = "SiteDisplayName";
            threadGridSiteColumn.FillWeight = 8F;
            threadGridSiteColumn.HeaderText = "Site";
            threadGridSiteColumn.Name = "threadGridSiteColumn";
            threadGridSiteColumn.ReadOnly = true;
            threadGridSiteColumn.ToolTipText = "The website the thread is hosted on.";
            // 
            // threadGridBoardCodeColumn
            // 
            threadGridBoardCodeColumn.DataPropertyName = "BoardCode";
            threadGridBoardCodeColumn.FillWeight = 8.387236F;
            threadGridBoardCodeColumn.HeaderText = "Board";
            threadGridBoardCodeColumn.Name = "threadGridBoardCodeColumn";
            threadGridBoardCodeColumn.ReadOnly = true;
            // 
            // threadGridFileCountColumn
            // 
            threadGridFileCountColumn.DataPropertyName = "FileCount";
            threadGridFileCountColumn.FillWeight = 8.387236F;
            threadGridFileCountColumn.HeaderText = "File Count";
            threadGridFileCountColumn.Name = "threadGridFileCountColumn";
            threadGridFileCountColumn.ReadOnly = true;
            // 
            // threadsContextMenu
            // 
            threadsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openFolderToolStripMenuItem, openInBrowserToolStripMenuItem, copyURLToClipboardToolStripMenuItem, renameToolStripMenuItem, deleteToolStripMenuItem });
            threadsContextMenu.Name = "cmThreads";
            threadsContextMenu.Size = new System.Drawing.Size(238, 114);
            // 
            // openFolderToolStripMenuItem
            // 
            openFolderToolStripMenuItem.Image = Properties.Resources.folder;
            openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            openFolderToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F;
            openFolderToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            openFolderToolStripMenuItem.Text = "Open &Folder";
            openFolderToolStripMenuItem.Click += openFolderToolStripMenuItem_Click;
            // 
            // openInBrowserToolStripMenuItem
            // 
            openInBrowserToolStripMenuItem.AutoSize = false;
            openInBrowserToolStripMenuItem.Image = Properties.Resources.world;
            openInBrowserToolStripMenuItem.Name = "openInBrowserToolStripMenuItem";
            openInBrowserToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B;
            openInBrowserToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            openInBrowserToolStripMenuItem.Text = "Open in &Browser";
            openInBrowserToolStripMenuItem.Click += openInBrowserToolStripMenuItem_Click;
            // 
            // copyURLToClipboardToolStripMenuItem
            // 
            copyURLToClipboardToolStripMenuItem.Image = Properties.Resources.clipboard;
            copyURLToClipboardToolStripMenuItem.Name = "copyURLToClipboardToolStripMenuItem";
            copyURLToClipboardToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C;
            copyURLToClipboardToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            copyURLToClipboardToolStripMenuItem.Text = "Copy &URL to Clipboard";
            copyURLToClipboardToolStripMenuItem.Click += copyURLToClipboardToolStripMenuItem_Click;
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Image = Properties.Resources.Rename;
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            renameToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            renameToolStripMenuItem.Text = "&Rename";
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = Properties.Resources.close;
            deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            deleteToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            deleteToolStripMenuItem.Text = "R&emove";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // threadsBindingSource
            // 
            threadsBindingSource.DataMember = "Threads";
            threadsBindingSource.DataSource = mainFormModelBindingSource;
            // 
            // mainFormModelBindingSource
            // 
            mainFormModelBindingSource.DataSource = typeof(MainFormModel);
            // 
            // boardsTabPage
            // 
            boardsTabPage.Controls.Add(boardsListBox);
            boardsTabPage.Location = new System.Drawing.Point(4, 24);
            boardsTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            boardsTabPage.Name = "boardsTabPage";
            boardsTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            boardsTabPage.Size = new System.Drawing.Size(643, 228);
            boardsTabPage.TabIndex = 1;
            boardsTabPage.Text = "Boards (0)";
            boardsTabPage.UseVisualStyleBackColor = true;
            // 
            // boardsListBox
            // 
            boardsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            boardsListBox.ContextMenuStrip = boardsContextMenu;
            boardsListBox.DataSource = boardsBindingSource;
            boardsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            boardsListBox.FormattingEnabled = true;
            boardsListBox.ItemHeight = 15;
            boardsListBox.Location = new System.Drawing.Point(4, 3);
            boardsListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            boardsListBox.Name = "boardsListBox";
            boardsListBox.Size = new System.Drawing.Size(635, 222);
            boardsListBox.TabIndex = 1;
            boardsListBox.MouseDoubleClick += boardsListBox_MouseDoubleClick;
            // 
            // boardsContextMenu
            // 
            boardsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { boardsContextMenuOpenFolderButton, boardsContextMenuOpenInBrowserButton, boardsContextMenuRemoveButton });
            boardsContextMenu.Name = "cmThreads";
            boardsContextMenu.Size = new System.Drawing.Size(203, 70);
            // 
            // boardsContextMenuOpenFolderButton
            // 
            boardsContextMenuOpenFolderButton.Image = Properties.Resources.folder;
            boardsContextMenuOpenFolderButton.Name = "boardsContextMenuOpenFolderButton";
            boardsContextMenuOpenFolderButton.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F;
            boardsContextMenuOpenFolderButton.Size = new System.Drawing.Size(202, 22);
            boardsContextMenuOpenFolderButton.Text = "Open Folder";
            boardsContextMenuOpenFolderButton.Click += openBoardFolderToolStripMenuItem_Click;
            // 
            // boardsContextMenuOpenInBrowserButton
            // 
            boardsContextMenuOpenInBrowserButton.Image = Properties.Resources.world;
            boardsContextMenuOpenInBrowserButton.Name = "boardsContextMenuOpenInBrowserButton";
            boardsContextMenuOpenInBrowserButton.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B;
            boardsContextMenuOpenInBrowserButton.Size = new System.Drawing.Size(202, 22);
            boardsContextMenuOpenInBrowserButton.Text = "Open in Browser";
            boardsContextMenuOpenInBrowserButton.Click += openBoardURLToolStripMenuItem_Click;
            // 
            // boardsContextMenuRemoveButton
            // 
            boardsContextMenuRemoveButton.Image = Properties.Resources.close;
            boardsContextMenuRemoveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            boardsContextMenuRemoveButton.Name = "boardsContextMenuRemoveButton";
            boardsContextMenuRemoveButton.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            boardsContextMenuRemoveButton.Size = new System.Drawing.Size(202, 22);
            boardsContextMenuRemoveButton.Text = "Remove";
            boardsContextMenuRemoveButton.Click += deleteBoardToolStripMenuItem_Click;
            // 
            // boardsBindingSource
            // 
            boardsBindingSource.DataMember = "Boards";
            boardsBindingSource.DataSource = mainFormModelBindingSource;
            // 
            // addButton
            // 
            addButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            addButton.Location = new System.Drawing.Point(448, 32);
            addButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            addButton.Name = "addButton";
            addButton.Size = new System.Drawing.Size(86, 27);
            addButton.TabIndex = 2;
            addButton.Text = "Add";
            toolTip.SetToolTip(addButton, "Add the entered thread/board to tracking.\r\nCopies text from clipboard if textbox is empty.");
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // urlTextBox
            // 
            urlTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            urlTextBox.Location = new System.Drawing.Point(14, 35);
            urlTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new System.Drawing.Size(426, 23);
            urlTextBox.TabIndex = 3;
            // 
            // systemTrayNotifyIcon
            // 
            systemTrayNotifyIcon.ContextMenuStrip = systemTrayContextMenu;
            systemTrayNotifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("systemTrayNotifyIcon.Icon");
            systemTrayNotifyIcon.Text = "Click to open/hide";
            systemTrayNotifyIcon.Visible = true;
            systemTrayNotifyIcon.MouseDown += systemTrayNotifyIcon_MouseDown;
            systemTrayNotifyIcon.MouseMove += systemTrayNotifyIcon_MouseMove;
            // 
            // systemTrayContextMenu
            // 
            systemTrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { systemTrayOpenFolderToolStripMenuItem, systemTrayExitToolStripMenuItem });
            systemTrayContextMenu.Name = "cmTray";
            systemTrayContextMenu.Size = new System.Drawing.Size(140, 48);
            // 
            // systemTrayOpenFolderToolStripMenuItem
            // 
            systemTrayOpenFolderToolStripMenuItem.Image = Properties.Resources.folder;
            systemTrayOpenFolderToolStripMenuItem.Name = "systemTrayOpenFolderToolStripMenuItem";
            systemTrayOpenFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            systemTrayOpenFolderToolStripMenuItem.Text = "Open &Folder";
            systemTrayOpenFolderToolStripMenuItem.Click += systemTrayOpenFolderToolStripMenuItem_Click;
            // 
            // systemTrayExitToolStripMenuItem
            // 
            systemTrayExitToolStripMenuItem.Image = Properties.Resources.close;
            systemTrayExitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            systemTrayExitToolStripMenuItem.Name = "systemTrayExitToolStripMenuItem";
            systemTrayExitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            systemTrayExitToolStripMenuItem.Text = "&Exit";
            systemTrayExitToolStripMenuItem.Click += systemTrayExitToolStripMenuItem_Click;
            // 
            // clearAllButton
            // 
            clearAllButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            clearAllButton.Location = new System.Drawing.Point(541, 32);
            clearAllButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            clearAllButton.Name = "clearAllButton";
            clearAllButton.Size = new System.Drawing.Size(86, 27);
            clearAllButton.TabIndex = 4;
            clearAllButton.Text = "Clear";
            clearAllButton.UseVisualStyleBackColor = true;
            clearAllButton.Click += clearAllButton_Click;
            // 
            // clipboardButton
            // 
            clipboardButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            clipboardButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            clipboardButton.Location = new System.Drawing.Point(635, 32);
            clipboardButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            clipboardButton.Name = "clipboardButton";
            clipboardButton.Size = new System.Drawing.Size(30, 27);
            clipboardButton.TabIndex = 5;
            clipboardButton.Text = "📋";
            toolTip.SetToolTip(clipboardButton, "Copy Thread URLs to Clipboard (Delimited by commas)");
            clipboardButton.UseVisualStyleBackColor = true;
            clipboardButton.Click += clipboardButton_Click;
            // 
            // MainForm
            // 
            AcceptButton = addButton;
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(679, 339);
            Controls.Add(clipboardButton);
            Controls.Add(clearAllButton);
            Controls.Add(urlTextBox);
            Controls.Add(addButton);
            Controls.Add(listsTabControl);
            Controls.Add(menuStrip);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "GChan";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            SizeChanged += MainForm_SizeChanged;
            DragDrop += DragDropHandler;
            DragEnter += DragEnterHandler;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            listsTabControl.ResumeLayout(false);
            threadsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)threadGridView).EndInit();
            threadsContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)threadsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)mainFormModelBindingSource).EndInit();
            boardsTabPage.ResumeLayout(false);
            boardsContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)boardsBindingSource).EndInit();
            systemTrayContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TabControl listsTabControl;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox boardsListBox;
        private System.Windows.Forms.ContextMenuStrip threadsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip boardsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem boardsContextMenuOpenFolderButton;
        private System.Windows.Forms.ToolStripMenuItem boardsContextMenuOpenInBrowserButton;
        private System.Windows.Forms.ToolStripMenuItem boardsContextMenuRemoveButton;
        private System.Windows.Forms.ContextMenuStrip systemTrayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem systemTrayOpenFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemTrayExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem1;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.Button clipboardButton;
        private System.Windows.Forms.ToolStripMenuItem copyURLToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn threadsTabTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boardsTabTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notificationTrayTooltipDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource threadsBindingSource;
        private System.Windows.Forms.BindingSource boardsBindingSource;
        internal System.Windows.Forms.TabPage threadsTabPage;
        internal System.Windows.Forms.TabPage boardsTabPage;
        internal Controls.PreferencesDataGridView threadGridView;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        internal System.Windows.Forms.MenuStrip menuStrip;
        internal System.Windows.Forms.ToolTip toolTip;
        internal System.Windows.Forms.BindingSource mainFormModelBindingSource;
        internal System.Windows.Forms.NotifyIcon systemTrayNotifyIcon;
        internal System.Windows.Forms.TextBox urlTextBox;
        internal System.Windows.Forms.ToolStripMenuItem updateAvailableToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn threadGridSubjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn threadGridSiteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn threadGridBoardCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn threadGridIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn threadGridFileCountColumn;
    }
}

