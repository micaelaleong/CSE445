namespace Browser_Assignment1
{
    partial class Form1
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
            this.TempConverterTitle = new System.Windows.Forms.Label();
            this.givenTemp = new System.Windows.Forms.TextBox();
            this.c2fButton = new System.Windows.Forms.Button();
            this.f2cButton = new System.Windows.Forms.Button();
            this.convertedTempLabel = new System.Windows.Forms.Label();
            this.tempResultLabel = new System.Windows.Forms.Label();
            this.NumberSorterTitle = new System.Windows.Forms.Label();
            this.givenNumbers = new System.Windows.Forms.TextBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.sortedNumbersLabel = new System.Windows.Forms.Label();
            this.sortedNumResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TempConverterTitle
            // 
            this.TempConverterTitle.AutoSize = true;
            this.TempConverterTitle.Location = new System.Drawing.Point(12, 371);
            this.TempConverterTitle.Name = "TempConverterTitle";
            this.TempConverterTitle.Size = new System.Drawing.Size(116, 13);
            this.TempConverterTitle.TabIndex = 0;
            this.TempConverterTitle.Text = "Temperature Converter";
            this.TempConverterTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // givenTemp
            // 
            this.givenTemp.Location = new System.Drawing.Point(15, 398);
            this.givenTemp.Name = "givenTemp";
            this.givenTemp.Size = new System.Drawing.Size(100, 20);
            this.givenTemp.TabIndex = 1;
            // 
            // c2fButton
            // 
            this.c2fButton.Location = new System.Drawing.Point(121, 398);
            this.c2fButton.Name = "c2fButton";
            this.c2fButton.Size = new System.Drawing.Size(75, 23);
            this.c2fButton.TabIndex = 2;
            this.c2fButton.Text = "Convert to F";
            this.c2fButton.UseVisualStyleBackColor = true;
            this.c2fButton.Click += new System.EventHandler(this.c2fButton_Click);
            // 
            // f2cButton
            // 
            this.f2cButton.Location = new System.Drawing.Point(202, 398);
            this.f2cButton.Name = "f2cButton";
            this.f2cButton.Size = new System.Drawing.Size(75, 23);
            this.f2cButton.TabIndex = 3;
            this.f2cButton.Text = "Convert to C";
            this.f2cButton.UseVisualStyleBackColor = true;
            this.f2cButton.Click += new System.EventHandler(this.f2cButton_Click);
            // 
            // convertedTempLabel
            // 
            this.convertedTempLabel.AutoSize = true;
            this.convertedTempLabel.Location = new System.Drawing.Point(15, 425);
            this.convertedTempLabel.Name = "convertedTempLabel";
            this.convertedTempLabel.Size = new System.Drawing.Size(70, 13);
            this.convertedTempLabel.TabIndex = 4;
            this.convertedTempLabel.Text = "Temperature:";
            // 
            // tempResultLabel
            // 
            this.tempResultLabel.AutoSize = true;
            this.tempResultLabel.Location = new System.Drawing.Point(121, 425);
            this.tempResultLabel.Name = "tempResultLabel";
            this.tempResultLabel.Size = new System.Drawing.Size(0, 13);
            this.tempResultLabel.TabIndex = 5;
            // 
            // NumberSorterTitle
            // 
            this.NumberSorterTitle.AutoSize = true;
            this.NumberSorterTitle.Location = new System.Drawing.Point(553, 371);
            this.NumberSorterTitle.Name = "NumberSorterTitle";
            this.NumberSorterTitle.Size = new System.Drawing.Size(75, 13);
            this.NumberSorterTitle.TabIndex = 6;
            this.NumberSorterTitle.Text = "Number Sorter";
            // 
            // givenNumbers
            // 
            this.givenNumbers.Location = new System.Drawing.Point(556, 398);
            this.givenNumbers.Name = "givenNumbers";
            this.givenNumbers.Size = new System.Drawing.Size(100, 20);
            this.givenNumbers.TabIndex = 7;
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(682, 398);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(75, 23);
            this.sortButton.TabIndex = 8;
            this.sortButton.Text = "Sort";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // sortedNumbersLabel
            // 
            this.sortedNumbersLabel.AutoSize = true;
            this.sortedNumbersLabel.Location = new System.Drawing.Point(556, 425);
            this.sortedNumbersLabel.Name = "sortedNumbersLabel";
            this.sortedNumbersLabel.Size = new System.Drawing.Size(86, 13);
            this.sortedNumbersLabel.TabIndex = 9;
            this.sortedNumbersLabel.Text = "Sorted Numbers:";
            // 
            // sortedNumResult
            // 
            this.sortedNumResult.AutoSize = true;
            this.sortedNumResult.Location = new System.Drawing.Point(682, 425);
            this.sortedNumResult.Name = "sortedNumResult";
            this.sortedNumResult.Size = new System.Drawing.Size(0, 13);
            this.sortedNumResult.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sortedNumResult);
            this.Controls.Add(this.sortedNumbersLabel);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.givenNumbers);
            this.Controls.Add(this.NumberSorterTitle);
            this.Controls.Add(this.tempResultLabel);
            this.Controls.Add(this.convertedTempLabel);
            this.Controls.Add(this.f2cButton);
            this.Controls.Add(this.c2fButton);
            this.Controls.Add(this.givenTemp);
            this.Controls.Add(this.TempConverterTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TempConverterTitle;
        private System.Windows.Forms.TextBox givenTemp;
        private System.Windows.Forms.Button c2fButton;
        private System.Windows.Forms.Button f2cButton;
        private System.Windows.Forms.Label convertedTempLabel;
        private System.Windows.Forms.Label tempResultLabel;
        private System.Windows.Forms.Label NumberSorterTitle;
        private System.Windows.Forms.TextBox givenNumbers;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Label sortedNumbersLabel;
        private System.Windows.Forms.Label sortedNumResult;
    }
}

