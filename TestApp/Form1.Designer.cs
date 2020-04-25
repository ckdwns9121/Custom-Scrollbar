namespace TestApp {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BasicScroll = new System.Windows.Forms.VScrollBar();
            this.outerPanel = new System.Windows.Forms.Panel();
            this.innerPanel = new System.Windows.Forms.Panel();
            this.btnHidePanelScrollbar = new System.Windows.Forms.Button();
            this.customScrollbar1 = new CustomControls.CustomScrollbar();
            this.outerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasicScroll
            // 
            this.BasicScroll.LargeChange = 15;
            this.BasicScroll.Location = new System.Drawing.Point(282, 7);
            this.BasicScroll.Maximum = 250;
            this.BasicScroll.Name = "BasicScroll";
            this.BasicScroll.Size = new System.Drawing.Size(17, 162);
            this.BasicScroll.TabIndex = 1;
            this.BasicScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // outerPanel
            // 
            this.outerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outerPanel.Controls.Add(this.innerPanel);
            this.outerPanel.Location = new System.Drawing.Point(3, 5);
            this.outerPanel.Name = "outerPanel";
            this.outerPanel.Size = new System.Drawing.Size(233, 165);
            this.outerPanel.TabIndex = 3;
            // 
            // innerPanel
            // 
            this.innerPanel.AutoScroll = true;
            this.innerPanel.Location = new System.Drawing.Point(0, 0);
            this.innerPanel.Name = "innerPanel";
            this.innerPanel.Size = new System.Drawing.Size(228, 162);
            this.innerPanel.TabIndex = 0;
            this.innerPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.item_scroll);
            // 
            // btnHidePanelScrollbar
            // 
            this.btnHidePanelScrollbar.Location = new System.Drawing.Point(3, 188);
            this.btnHidePanelScrollbar.Name = "btnHidePanelScrollbar";
            this.btnHidePanelScrollbar.Size = new System.Drawing.Size(233, 21);
            this.btnHidePanelScrollbar.TabIndex = 4;
            this.btnHidePanelScrollbar.Text = "Hide Panel Scrollbar";
            this.btnHidePanelScrollbar.UseVisualStyleBackColor = true;
            this.btnHidePanelScrollbar.Click += new System.EventHandler(this.btnHidePanelScrollbar_Click);
            // 
            // customScrollbar1
            // 
            this.customScrollbar1.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customScrollbar1.DownArrowImage = null;
            this.customScrollbar1.LargeChange = 10;
            this.customScrollbar1.Location = new System.Drawing.Point(242, 5);
            this.customScrollbar1.Maximum = 100;
            this.customScrollbar1.Minimum = 0;
            this.customScrollbar1.MinimumSize = new System.Drawing.Size(10, 85);
            this.customScrollbar1.Name = "customScrollbar1";
            this.customScrollbar1.Size = new System.Drawing.Size(10, 165);
            this.customScrollbar1.SmallChange = 1;
            this.customScrollbar1.TabIndex = 5;
            this.customScrollbar1.ThumbBottomImage = ((System.Drawing.Image)(resources.GetObject("customScrollbar1.ThumbBottomImage")));
            this.customScrollbar1.ThumbBottomSpanImage = ((System.Drawing.Image)(resources.GetObject("customScrollbar1.ThumbBottomSpanImage")));
            this.customScrollbar1.ThumbHoverImage = ((System.Drawing.Image)(resources.GetObject("customScrollbar1.ThumbHoverImage")));
            this.customScrollbar1.ThumbMiddleImage = ((System.Drawing.Image)(resources.GetObject("customScrollbar1.ThumbMiddleImage")));
            this.customScrollbar1.ThumbNomalImage = ((System.Drawing.Image)(resources.GetObject("customScrollbar1.ThumbNomalImage")));
            this.customScrollbar1.ThumbTopImage = ((System.Drawing.Image)(resources.GetObject("customScrollbar1.ThumbTopImage")));
            this.customScrollbar1.ThumbTopSpanImage = ((System.Drawing.Image)(resources.GetObject("customScrollbar1.ThumbTopSpanImage")));
            this.customScrollbar1.UpArrowImage = null;
            this.customScrollbar1.Value = 0;
            this.customScrollbar1.Scroll += new System.EventHandler(this.customScrollbar1_Scroll);
            this.customScrollbar1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.realScroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(351, 240);
            this.Controls.Add(this.customScrollbar1);
            this.Controls.Add(this.btnHidePanelScrollbar);
            this.Controls.Add(this.outerPanel);
            this.Controls.Add(this.BasicScroll);
            this.Name = "Form1";
            this.Text = "Custom Scrollbar Test";
            this.outerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar BasicScroll;
        private System.Windows.Forms.Panel outerPanel;
        private System.Windows.Forms.Panel innerPanel;
        private System.Windows.Forms.Button btnHidePanelScrollbar;
        private CustomControls.CustomScrollbar customScrollbar1;
    }
}

