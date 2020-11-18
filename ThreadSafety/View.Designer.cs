namespace ThreadSafety
{
    partial class View
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxWriter = new System.Windows.Forms.RichTextBox();
            this.richTextBoxReader = new System.Windows.Forms.RichTextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxWriter
            // 
            this.richTextBoxWriter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxWriter.Location = new System.Drawing.Point(38, 149);
            this.richTextBoxWriter.Name = "richTextBoxWriter";
            this.richTextBoxWriter.Size = new System.Drawing.Size(944, 1175);
            this.richTextBoxWriter.TabIndex = 0;
            this.richTextBoxWriter.Text = "";
            // 
            // richTextBoxReader
            // 
            this.richTextBoxReader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxReader.Location = new System.Drawing.Point(1020, 149);
            this.richTextBoxReader.Name = "richTextBoxReader";
            this.richTextBoxReader.Size = new System.Drawing.Size(944, 1175);
            this.richTextBoxReader.TabIndex = 1;
            this.richTextBoxReader.Text = "";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(878, 37);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(251, 60);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Начать";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2001, 1371);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.richTextBoxReader);
            this.Controls.Add(this.richTextBoxWriter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "View";
            this.Text = "Потоки";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxWriter;
        private System.Windows.Forms.RichTextBox richTextBoxReader;
        private System.Windows.Forms.Button buttonStart;
    }
}

