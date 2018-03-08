namespace DenisApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ts_length = new System.Windows.Forms.TextBox();
            this.ts_state = new System.Windows.Forms.TextBox();
            this.ts_graph = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.ts_prev = new System.Windows.Forms.ComboBox();
            this.ts_name = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Продолжительность";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Состояние";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "График";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Начать после";
            // 
            // ts_length
            // 
            this.ts_length.Location = new System.Drawing.Point(146, 31);
            this.ts_length.Name = "ts_length";
            this.ts_length.Size = new System.Drawing.Size(100, 20);
            this.ts_length.TabIndex = 7;
            this.ts_length.Text = "0";
            this.ts_length.TextChanged += new System.EventHandler(this.ts_length_TextChanged);
            // 
            // ts_state
            // 
            this.ts_state.Location = new System.Drawing.Point(146, 57);
            this.ts_state.Name = "ts_state";
            this.ts_state.Size = new System.Drawing.Size(100, 20);
            this.ts_state.TabIndex = 8;
            this.ts_state.Text = "0";
            this.ts_state.TextChanged += new System.EventHandler(this.ts_state_TextChanged);
            // 
            // ts_graph
            // 
            this.ts_graph.Location = new System.Drawing.Point(146, 83);
            this.ts_graph.Name = "ts_graph";
            this.ts_graph.Size = new System.Drawing.Size(100, 20);
            this.ts_graph.TabIndex = 9;
            this.ts_graph.Text = "0";
            this.ts_graph.TextChanged += new System.EventHandler(this.ts_graph_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Готово";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(90, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(147, 172);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 30);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Не влиять \r\nна следующий";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(147, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Цвет";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // ts_prev
            // 
            this.ts_prev.FormattingEnabled = true;
            this.ts_prev.Location = new System.Drawing.Point(146, 109);
            this.ts_prev.Name = "ts_prev";
            this.ts_prev.Size = new System.Drawing.Size(100, 21);
            this.ts_prev.TabIndex = 16;
            // 
            // ts_name
            // 
            this.ts_name.FormattingEnabled = true;
            this.ts_name.Location = new System.Drawing.Point(146, 6);
            this.ts_name.Name = "ts_name";
            this.ts_name.Size = new System.Drawing.Size(103, 21);
            this.ts_name.TabIndex = 17;
            this.ts_name.TextChanged += new System.EventHandler(this.ts_name_TextChanged_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 237);
            this.Controls.Add(this.ts_name);
            this.Controls.Add(this.ts_prev);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ts_graph);
            this.Controls.Add(this.ts_state);
            this.Controls.Add(this.ts_length);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Изменить";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ts_length;
        private System.Windows.Forms.TextBox ts_state;
        private System.Windows.Forms.TextBox ts_graph;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ts_prev;
        private System.Windows.Forms.ComboBox ts_name;
    }
}