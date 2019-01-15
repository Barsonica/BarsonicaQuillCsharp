namespace Barsonica_Quill
{
    partial class StyleDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StyleDialog));
            this.Format_Text = new System.Windows.Forms.GroupBox();
            this.Text_FontSize = new System.Windows.Forms.NumericUpDown();
            this.Text_FontBox = new System.Windows.Forms.ComboBox();
            this.Text_UnderlineCheck = new System.Windows.Forms.CheckBox();
            this.Text_ItalicCheck = new System.Windows.Forms.CheckBox();
            this.Text_BoldCheck = new System.Windows.Forms.CheckBox();
            this.Text_BackColorBox = new System.Windows.Forms.PictureBox();
            this.Text_BackColorButton = new System.Windows.Forms.Button();
            this.Text_ColorBox = new System.Windows.Forms.PictureBox();
            this.Text_ColorButton = new System.Windows.Forms.Button();
            this.Alignment = new System.Windows.Forms.GroupBox();
            this.Alignment_Block = new System.Windows.Forms.CheckBox();
            this.Alignment_Left = new System.Windows.Forms.CheckBox();
            this.Alignment_Right = new System.Windows.Forms.CheckBox();
            this.Alignment_Center = new System.Windows.Forms.CheckBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.Format_Text.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Text_FontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_BackColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_ColorBox)).BeginInit();
            this.Alignment.SuspendLayout();
            this.SuspendLayout();
            // 
            // Format_Text
            // 
            this.Format_Text.Controls.Add(this.Text_FontSize);
            this.Format_Text.Controls.Add(this.Text_FontBox);
            this.Format_Text.Controls.Add(this.Text_UnderlineCheck);
            this.Format_Text.Controls.Add(this.Text_ItalicCheck);
            this.Format_Text.Controls.Add(this.Text_BoldCheck);
            this.Format_Text.Controls.Add(this.Text_BackColorBox);
            this.Format_Text.Controls.Add(this.Text_BackColorButton);
            this.Format_Text.Controls.Add(this.Text_ColorBox);
            this.Format_Text.Controls.Add(this.Text_ColorButton);
            this.Format_Text.Location = new System.Drawing.Point(12, 68);
            this.Format_Text.Name = "Format_Text";
            this.Format_Text.Size = new System.Drawing.Size(179, 120);
            this.Format_Text.TabIndex = 11;
            this.Format_Text.TabStop = false;
            this.Format_Text.Text = "Text";
            // 
            // Text_FontSize
            // 
            this.Text_FontSize.Location = new System.Drawing.Point(131, 20);
            this.Text_FontSize.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.Text_FontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.Text_FontSize.Name = "Text_FontSize";
            this.Text_FontSize.Size = new System.Drawing.Size(42, 20);
            this.Text_FontSize.TabIndex = 10;
            this.Text_FontSize.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // Text_FontBox
            // 
            this.Text_FontBox.FormattingEnabled = true;
            this.Text_FontBox.Location = new System.Drawing.Point(4, 19);
            this.Text_FontBox.Name = "Text_FontBox";
            this.Text_FontBox.Size = new System.Drawing.Size(121, 21);
            this.Text_FontBox.TabIndex = 9;
            // 
            // Text_UnderlineCheck
            // 
            this.Text_UnderlineCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.Text_UnderlineCheck.BackgroundImage = global::Barsonica_Quill.Properties.Resources.Underline;
            this.Text_UnderlineCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Text_UnderlineCheck.Location = new System.Drawing.Point(114, 82);
            this.Text_UnderlineCheck.Name = "Text_UnderlineCheck";
            this.Text_UnderlineCheck.Size = new System.Drawing.Size(30, 30);
            this.Text_UnderlineCheck.TabIndex = 8;
            this.Text_UnderlineCheck.UseVisualStyleBackColor = true;
            // 
            // Text_ItalicCheck
            // 
            this.Text_ItalicCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.Text_ItalicCheck.BackgroundImage = global::Barsonica_Quill.Properties.Resources.Italic;
            this.Text_ItalicCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Text_ItalicCheck.Location = new System.Drawing.Point(78, 82);
            this.Text_ItalicCheck.Name = "Text_ItalicCheck";
            this.Text_ItalicCheck.Size = new System.Drawing.Size(30, 30);
            this.Text_ItalicCheck.TabIndex = 7;
            this.Text_ItalicCheck.UseVisualStyleBackColor = true;
            // 
            // Text_BoldCheck
            // 
            this.Text_BoldCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.Text_BoldCheck.BackgroundImage = global::Barsonica_Quill.Properties.Resources.Bold;
            this.Text_BoldCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Text_BoldCheck.Location = new System.Drawing.Point(42, 82);
            this.Text_BoldCheck.Name = "Text_BoldCheck";
            this.Text_BoldCheck.Size = new System.Drawing.Size(30, 30);
            this.Text_BoldCheck.TabIndex = 6;
            this.Text_BoldCheck.UseVisualStyleBackColor = true;
            // 
            // Text_BackColorBox
            // 
            this.Text_BackColorBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Text_BackColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_BackColorBox.Location = new System.Drawing.Point(131, 46);
            this.Text_BackColorBox.Name = "Text_BackColorBox";
            this.Text_BackColorBox.Size = new System.Drawing.Size(30, 30);
            this.Text_BackColorBox.TabIndex = 5;
            this.Text_BackColorBox.TabStop = false;
            // 
            // Text_BackColorButton
            // 
            this.Text_BackColorButton.BackColor = System.Drawing.Color.Transparent;
            this.Text_BackColorButton.BackgroundImage = global::Barsonica_Quill.Properties.Resources.BackColor;
            this.Text_BackColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Text_BackColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Text_BackColorButton.Location = new System.Drawing.Point(95, 46);
            this.Text_BackColorButton.Name = "Text_BackColorButton";
            this.Text_BackColorButton.Size = new System.Drawing.Size(30, 30);
            this.Text_BackColorButton.TabIndex = 4;
            this.Text_BackColorButton.UseVisualStyleBackColor = false;
            this.Text_BackColorButton.Click += new System.EventHandler(this.Text_BackColorButton_Click);
            // 
            // Text_ColorBox
            // 
            this.Text_ColorBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Text_ColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text_ColorBox.Location = new System.Drawing.Point(59, 46);
            this.Text_ColorBox.Name = "Text_ColorBox";
            this.Text_ColorBox.Size = new System.Drawing.Size(30, 30);
            this.Text_ColorBox.TabIndex = 3;
            this.Text_ColorBox.TabStop = false;
            // 
            // Text_ColorButton
            // 
            this.Text_ColorButton.Location = new System.Drawing.Point(23, 46);
            this.Text_ColorButton.Name = "Text_ColorButton";
            this.Text_ColorButton.Size = new System.Drawing.Size(30, 30);
            this.Text_ColorButton.TabIndex = 2;
            this.Text_ColorButton.Text = "Select Color";
            this.Text_ColorButton.UseVisualStyleBackColor = true;
            this.Text_ColorButton.Click += new System.EventHandler(this.Text_ColorButton_Click);
            // 
            // Alignment
            // 
            this.Alignment.Controls.Add(this.Alignment_Block);
            this.Alignment.Controls.Add(this.Alignment_Left);
            this.Alignment.Controls.Add(this.Alignment_Right);
            this.Alignment.Controls.Add(this.Alignment_Center);
            this.Alignment.Location = new System.Drawing.Point(12, 12);
            this.Alignment.Name = "Alignment";
            this.Alignment.Size = new System.Drawing.Size(179, 50);
            this.Alignment.TabIndex = 12;
            this.Alignment.TabStop = false;
            this.Alignment.Text = "Alignment";
            // 
            // Alignment_Block
            // 
            this.Alignment_Block.Appearance = System.Windows.Forms.Appearance.Button;
            this.Alignment_Block.BackgroundImage = global::Barsonica_Quill.Properties.Resources.Arrangment_Block;
            this.Alignment_Block.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Alignment_Block.Location = new System.Drawing.Point(129, 14);
            this.Alignment_Block.Name = "Alignment_Block";
            this.Alignment_Block.Size = new System.Drawing.Size(30, 30);
            this.Alignment_Block.TabIndex = 20;
            this.Alignment_Block.UseVisualStyleBackColor = true;
            this.Alignment_Block.CheckedChanged += new System.EventHandler(this.ArrangmentChanged);
            // 
            // Alignment_Left
            // 
            this.Alignment_Left.Appearance = System.Windows.Forms.Appearance.Button;
            this.Alignment_Left.BackgroundImage = global::Barsonica_Quill.Properties.Resources.Arrangment_Left;
            this.Alignment_Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Alignment_Left.Location = new System.Drawing.Point(21, 14);
            this.Alignment_Left.Name = "Alignment_Left";
            this.Alignment_Left.Size = new System.Drawing.Size(30, 30);
            this.Alignment_Left.TabIndex = 18;
            this.Alignment_Left.UseVisualStyleBackColor = true;
            this.Alignment_Left.CheckedChanged += new System.EventHandler(this.ArrangmentChanged);
            // 
            // Alignment_Right
            // 
            this.Alignment_Right.Appearance = System.Windows.Forms.Appearance.Button;
            this.Alignment_Right.BackgroundImage = global::Barsonica_Quill.Properties.Resources.Arrangment_Right;
            this.Alignment_Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Alignment_Right.Location = new System.Drawing.Point(93, 14);
            this.Alignment_Right.Name = "Alignment_Right";
            this.Alignment_Right.Size = new System.Drawing.Size(30, 30);
            this.Alignment_Right.TabIndex = 19;
            this.Alignment_Right.UseVisualStyleBackColor = true;
            this.Alignment_Right.CheckedChanged += new System.EventHandler(this.ArrangmentChanged);
            // 
            // Alignment_Center
            // 
            this.Alignment_Center.Appearance = System.Windows.Forms.Appearance.Button;
            this.Alignment_Center.BackgroundImage = global::Barsonica_Quill.Properties.Resources.Arrangment_Center;
            this.Alignment_Center.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Alignment_Center.Location = new System.Drawing.Point(57, 14);
            this.Alignment_Center.Name = "Alignment_Center";
            this.Alignment_Center.Size = new System.Drawing.Size(30, 30);
            this.Alignment_Center.TabIndex = 17;
            this.Alignment_Center.UseVisualStyleBackColor = true;
            this.Alignment_Center.CheckedChanged += new System.EventHandler(this.ArrangmentChanged);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(54, 191);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(135, 20);
            this.NameTextBox.TabIndex = 13;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(13, 194);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 14;
            this.NameLabel.Text = "Name";
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(12, 217);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 15;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(116, 217);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 16;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // StyleDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 246);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.Format_Text);
            this.Controls.Add(this.Alignment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StyleDialog";
            this.Text = "StyleDialog";
            this.Format_Text.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Text_FontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_BackColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_ColorBox)).EndInit();
            this.Alignment.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Format_Text;
        private System.Windows.Forms.NumericUpDown Text_FontSize;
        private System.Windows.Forms.ComboBox Text_FontBox;
        private System.Windows.Forms.CheckBox Text_UnderlineCheck;
        private System.Windows.Forms.CheckBox Text_ItalicCheck;
        private System.Windows.Forms.CheckBox Text_BoldCheck;
        private System.Windows.Forms.PictureBox Text_BackColorBox;
        private System.Windows.Forms.Button Text_BackColorButton;
        private System.Windows.Forms.PictureBox Text_ColorBox;
        private System.Windows.Forms.Button Text_ColorButton;
        private System.Windows.Forms.GroupBox Alignment;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.CheckBox Alignment_Block;
        private System.Windows.Forms.CheckBox Alignment_Left;
        private System.Windows.Forms.CheckBox Alignment_Right;
        private System.Windows.Forms.CheckBox Alignment_Center;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}