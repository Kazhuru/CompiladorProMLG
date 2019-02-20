namespace CompiladorProMLG
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.inputGram = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Lr1TablaBtn = new System.Windows.Forms.Button();
            this.EpsilonBtn = new System.Windows.Forms.Button();
            this.AnalizarBtn = new System.Windows.Forms.Button();
            this.Lr1Btn = new System.Windows.Forms.Button();
            this.SiguienteBtn = new System.Windows.Forms.Button();
            this.PrimerosBtn = new System.Windows.Forms.Button();
            this.StringAnalisis = new System.Windows.Forms.TextBox();
            this.LalrTablaBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inputResult = new System.Windows.Forms.RichTextBox();
            this.LalrBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputGram
            // 
            this.inputGram.BackColor = System.Drawing.SystemColors.ControlDark;
            this.inputGram.Location = new System.Drawing.Point(6, 19);
            this.inputGram.Name = "inputGram";
            this.inputGram.Size = new System.Drawing.Size(513, 135);
            this.inputGram.TabIndex = 0;
            this.inputGram.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Lr1TablaBtn
            // 
            this.Lr1TablaBtn.Location = new System.Drawing.Point(250, 230);
            this.Lr1TablaBtn.Name = "Lr1TablaBtn";
            this.Lr1TablaBtn.Size = new System.Drawing.Size(107, 23);
            this.Lr1TablaBtn.TabIndex = 2;
            this.Lr1TablaBtn.Text = "LR(1) Tabla";
            this.Lr1TablaBtn.UseVisualStyleBackColor = true;
            this.Lr1TablaBtn.Click += new System.EventHandler(this.Lr1TablaBtn_Click);
            // 
            // EpsilonBtn
            // 
            this.EpsilonBtn.Location = new System.Drawing.Point(6, 160);
            this.EpsilonBtn.Name = "EpsilonBtn";
            this.EpsilonBtn.Size = new System.Drawing.Size(75, 23);
            this.EpsilonBtn.TabIndex = 3;
            this.EpsilonBtn.Text = "Ɛ";
            this.EpsilonBtn.UseVisualStyleBackColor = true;
            this.EpsilonBtn.Click += new System.EventHandler(this.EpsilonBtn_Click);
            // 
            // AnalizarBtn
            // 
            this.AnalizarBtn.Location = new System.Drawing.Point(6, 230);
            this.AnalizarBtn.Name = "AnalizarBtn";
            this.AnalizarBtn.Size = new System.Drawing.Size(75, 23);
            this.AnalizarBtn.TabIndex = 4;
            this.AnalizarBtn.Text = "Lex. Analizar";
            this.AnalizarBtn.UseVisualStyleBackColor = true;
            this.AnalizarBtn.Click += new System.EventHandler(this.AnalizarBtn_Click);
            // 
            // Lr1Btn
            // 
            this.Lr1Btn.Location = new System.Drawing.Point(250, 201);
            this.Lr1Btn.Name = "Lr1Btn";
            this.Lr1Btn.Size = new System.Drawing.Size(107, 23);
            this.Lr1Btn.TabIndex = 5;
            this.Lr1Btn.Text = "LR(1) Check";
            this.Lr1Btn.UseVisualStyleBackColor = true;
            this.Lr1Btn.Click += new System.EventHandler(this.Lr1Btn_Click);
            // 
            // SiguienteBtn
            // 
            this.SiguienteBtn.Location = new System.Drawing.Point(168, 230);
            this.SiguienteBtn.Name = "SiguienteBtn";
            this.SiguienteBtn.Size = new System.Drawing.Size(75, 23);
            this.SiguienteBtn.TabIndex = 6;
            this.SiguienteBtn.Text = "Siguientes";
            this.SiguienteBtn.UseVisualStyleBackColor = true;
            this.SiguienteBtn.Click += new System.EventHandler(this.SiguienteBtn_Click);
            // 
            // PrimerosBtn
            // 
            this.PrimerosBtn.Location = new System.Drawing.Point(87, 230);
            this.PrimerosBtn.Name = "PrimerosBtn";
            this.PrimerosBtn.Size = new System.Drawing.Size(75, 23);
            this.PrimerosBtn.TabIndex = 7;
            this.PrimerosBtn.Text = "Primeros";
            this.PrimerosBtn.UseVisualStyleBackColor = true;
            this.PrimerosBtn.Click += new System.EventHandler(this.PrimerosBtn_Click);
            // 
            // StringAnalisis
            // 
            this.StringAnalisis.Location = new System.Drawing.Point(250, 174);
            this.StringAnalisis.Name = "StringAnalisis";
            this.StringAnalisis.Size = new System.Drawing.Size(269, 20);
            this.StringAnalisis.TabIndex = 8;
            // 
            // LalrTablaBtn
            // 
            this.LalrTablaBtn.Location = new System.Drawing.Point(424, 230);
            this.LalrTablaBtn.Name = "LalrTablaBtn";
            this.LalrTablaBtn.Size = new System.Drawing.Size(95, 23);
            this.LalrTablaBtn.TabIndex = 9;
            this.LalrTablaBtn.Text = "LALR Tabla";
            this.LalrTablaBtn.UseVisualStyleBackColor = true;
            this.LalrTablaBtn.Click += new System.EventHandler(this.LalrTablaBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LalrBtn);
            this.groupBox1.Controls.Add(this.SiguienteBtn);
            this.groupBox1.Controls.Add(this.EpsilonBtn);
            this.groupBox1.Controls.Add(this.StringAnalisis);
            this.groupBox1.Controls.Add(this.PrimerosBtn);
            this.groupBox1.Controls.Add(this.inputGram);
            this.groupBox1.Controls.Add(this.LalrTablaBtn);
            this.groupBox1.Controls.Add(this.AnalizarBtn);
            this.groupBox1.Controls.Add(this.Lr1TablaBtn);
            this.groupBox1.Controls.Add(this.Lr1Btn);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 259);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrada y control";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inputResult);
            this.groupBox2.Location = new System.Drawing.Point(539, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 259);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // inputResult
            // 
            this.inputResult.BackColor = System.Drawing.SystemColors.ControlDark;
            this.inputResult.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputResult.Location = new System.Drawing.Point(7, 20);
            this.inputResult.Name = "inputResult";
            this.inputResult.Size = new System.Drawing.Size(491, 229);
            this.inputResult.TabIndex = 0;
            this.inputResult.Text = "";
            // 
            // LalrBtn
            // 
            this.LalrBtn.Location = new System.Drawing.Point(424, 201);
            this.LalrBtn.Name = "LalrBtn";
            this.LalrBtn.Size = new System.Drawing.Size(95, 23);
            this.LalrBtn.TabIndex = 10;
            this.LalrBtn.Text = "LALR Check";
            this.LalrBtn.UseVisualStyleBackColor = true;
            this.LalrBtn.Click += new System.EventHandler(this.LalrBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(8, 263);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1035, 249);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tablas Resultantes";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.richTextBox1.Location = new System.Drawing.Point(7, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1022, 224);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "String de Analisis";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1050, 517);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox inputGram;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button Lr1TablaBtn;
        private System.Windows.Forms.Button EpsilonBtn;
        private System.Windows.Forms.Button AnalizarBtn;
        private System.Windows.Forms.Button Lr1Btn;
        private System.Windows.Forms.Button SiguienteBtn;
        private System.Windows.Forms.Button PrimerosBtn;
        private System.Windows.Forms.TextBox StringAnalisis;
        private System.Windows.Forms.Button LalrTablaBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox inputResult;
        private System.Windows.Forms.Button LalrBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

