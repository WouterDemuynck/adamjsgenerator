namespace Adam.JSGenerator.Demonstration
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Basics", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("2", System.Windows.Forms.HorizontalAlignment.Left);
            this.listPanel = new System.Windows.Forms.Panel();
            this.demonstrationList = new System.Windows.Forms.ListView();
            this.hostPanel = new System.Windows.Forms.Panel();
            this.browser = new System.Windows.Forms.WebBrowser();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.outputLabel = new System.Windows.Forms.Label();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.listPanel.SuspendLayout();
            this.hostPanel.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPanel
            // 
            this.listPanel.Controls.Add(this.demonstrationList);
            this.listPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.listPanel.Location = new System.Drawing.Point(5, 5);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(200, 593);
            this.listPanel.TabIndex = 0;
            // 
            // demonstrationList
            // 
            this.demonstrationList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.demonstrationList.Dock = System.Windows.Forms.DockStyle.Left;
            this.demonstrationList.FullRowSelect = true;
            listViewGroup1.Header = "Basics";
            listViewGroup1.Name = "basicsGroup";
            listViewGroup2.Header = "2";
            listViewGroup2.Name = "listViewGroup2";
            this.demonstrationList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.demonstrationList.HideSelection = false;
            this.demonstrationList.Location = new System.Drawing.Point(0, 0);
            this.demonstrationList.MultiSelect = false;
            this.demonstrationList.Name = "demonstrationList";
            this.demonstrationList.Size = new System.Drawing.Size(194, 593);
            this.demonstrationList.TabIndex = 0;
            this.demonstrationList.TabStop = false;
            this.demonstrationList.UseCompatibleStateImageBehavior = false;
            this.demonstrationList.View = System.Windows.Forms.View.Tile;
            this.demonstrationList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.DemonstrationListItemSelectionChanged);
            // 
            // hostPanel
            // 
            this.hostPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hostPanel.Controls.Add(this.browser);
            this.hostPanel.Controls.Add(this.actionPanel);
            this.hostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostPanel.Location = new System.Drawing.Point(205, 5);
            this.hostPanel.Name = "hostPanel";
            this.hostPanel.Size = new System.Drawing.Size(579, 593);
            this.hostPanel.TabIndex = 1;
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Location = new System.Drawing.Point(0, 0);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(577, 504);
            this.browser.TabIndex = 0;
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.outputLabel);
            this.actionPanel.Controls.Add(this.outputBox);
            this.actionPanel.Controls.Add(this.runButton);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionPanel.Location = new System.Drawing.Point(0, 504);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(577, 87);
            this.actionPanel.TabIndex = 1;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(87, 11);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(42, 13);
            this.outputLabel.TabIndex = 2;
            this.outputLabel.Text = "Output:";
            // 
            // outputBox
            // 
            this.outputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputBox.Location = new System.Drawing.Point(135, 8);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(439, 76);
            this.outputBox.TabIndex = 1;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(5, 6);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.RunButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 603);
            this.Controls.Add(this.hostPanel);
            this.Controls.Add(this.listPanel);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Adam.JSGenerator Demonstration";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Shown += new System.EventHandler(this.MainFormShown);
            this.listPanel.ResumeLayout(false);
            this.hostPanel.ResumeLayout(false);
            this.actionPanel.ResumeLayout(false);
            this.actionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.ListView demonstrationList;
        private System.Windows.Forms.Panel hostPanel;
        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Label outputLabel;

    }
}

