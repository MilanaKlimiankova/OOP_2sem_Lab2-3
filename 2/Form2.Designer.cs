namespace _2
{
    partial class Form2
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
            this.Input = new System.Windows.Forms.TextBox();
            this.ResultList = new System.Windows.Forms.ListBox();
            this.Search = new System.Windows.Forms.Button();
            this.FlatList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(11, 186);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(231, 22);
            this.Input.TabIndex = 4;
            // 
            // ResultList
            // 
            this.ResultList.FormattingEnabled = true;
            this.ResultList.ItemHeight = 16;
            this.ResultList.Location = new System.Drawing.Point(12, 281);
            this.ResultList.Name = "ResultList";
            this.ResultList.Size = new System.Drawing.Size(230, 180);
            this.ResultList.TabIndex = 9;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(12, 229);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(230, 23);
            this.Search.TabIndex = 10;
            this.Search.Text = "Поиск";
            this.Search.UseVisualStyleBackColor = true;
            // 
            // FlatList
            // 
            this.FlatList.Location = new System.Drawing.Point(12, 12);
            this.FlatList.Multiline = true;
            this.FlatList.Name = "FlatList";
            this.FlatList.Size = new System.Drawing.Size(230, 156);
            this.FlatList.TabIndex = 13;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 477);
            this.Controls.Add(this.FlatList);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.ResultList);
            this.Controls.Add(this.Input);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.ListBox ResultList;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TextBox FlatList;
    }
}