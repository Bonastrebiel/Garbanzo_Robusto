namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.IniciarSesion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Desconectar = new System.Windows.Forms.Button();
            this.conectar = new System.Windows.Forms.Button();
            this.DarseAlta = new System.Windows.Forms.Button();
            this.contra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Minimo = new System.Windows.Forms.RadioButton();
            this.Maximo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(215, 38);
            this.nombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(157, 22);
            this.nombre.TabIndex = 3;
            // 
            // IniciarSesion
            // 
            this.IniciarSesion.Location = new System.Drawing.Point(215, 124);
            this.IniciarSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IniciarSesion.Name = "IniciarSesion";
            this.IniciarSesion.Size = new System.Drawing.Size(133, 29);
            this.IniciarSesion.TabIndex = 5;
            this.IniciarSesion.Text = "Iniciar sesión";
            this.IniciarSesion.UseVisualStyleBackColor = true;
            this.IniciarSesion.Click += new System.EventHandler(this.IniciarSesion_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Maximo);
            this.groupBox1.Controls.Add(this.Minimo);
            this.groupBox1.Controls.Add(this.Desconectar);
            this.groupBox1.Controls.Add(this.conectar);
            this.groupBox1.Controls.Add(this.DarseAlta);
            this.groupBox1.Controls.Add(this.contra);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.IniciarSesion);
            this.groupBox1.Controls.Add(this.nombre);
            this.groupBox1.Location = new System.Drawing.Point(16, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(836, 476);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            // 
            // Desconectar
            // 
            this.Desconectar.Location = new System.Drawing.Point(610, 149);
            this.Desconectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(177, 104);
            this.Desconectar.TabIndex = 12;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = true;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // conectar
            // 
            this.conectar.Location = new System.Drawing.Point(610, 30);
            this.conectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.conectar.Name = "conectar";
            this.conectar.Size = new System.Drawing.Size(172, 102);
            this.conectar.TabIndex = 11;
            this.conectar.Text = "Conectar";
            this.conectar.UseVisualStyleBackColor = true;
            this.conectar.Click += new System.EventHandler(this.conectar_Click);
            // 
            // DarseAlta
            // 
            this.DarseAlta.Location = new System.Drawing.Point(215, 174);
            this.DarseAlta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DarseAlta.Name = "DarseAlta";
            this.DarseAlta.Size = new System.Drawing.Size(133, 28);
            this.DarseAlta.TabIndex = 10;
            this.DarseAlta.Text = "Darse de alta";
            this.DarseAlta.UseVisualStyleBackColor = true;
            this.DarseAlta.Click += new System.EventHandler(this.button1_Click);
            // 
            // contra
            // 
            this.contra.Location = new System.Drawing.Point(215, 79);
            this.contra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contra.Name = "contra";
            this.contra.Size = new System.Drawing.Size(157, 22);
            this.contra.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contraseña";
            // 
            // Minimo
            // 
            this.Minimo.AutoSize = true;
            this.Minimo.Location = new System.Drawing.Point(26, 359);
            this.Minimo.Name = "Minimo";
            this.Minimo.Size = new System.Drawing.Size(73, 21);
            this.Minimo.TabIndex = 13;
            this.Minimo.TabStop = true;
            this.Minimo.Text = "Mínimo\r\n";
            this.Minimo.UseVisualStyleBackColor = true;
            // 
            // Maximo
            // 
            this.Maximo.AutoSize = true;
            this.Maximo.Location = new System.Drawing.Point(128, 359);
            this.Maximo.Name = "Maximo";
            this.Maximo.Size = new System.Drawing.Size(76, 21);
            this.Maximo.TabIndex = 14;
            this.Maximo.TabStop = true;
            this.Maximo.Text = "Máximo";
            this.Maximo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(33, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 92);
            this.label3.TabIndex = 15;
            this.label3.Text = "Numero de partidas ganadas por el jugador con la puntuación máxima o mínima\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 33);
            this.button1.TabIndex = 16;
            this.button1.Text = "Enviar\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(235, 401);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 33);
            this.button2.TabIndex = 17;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(220, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 92);
            this.label4.TabIndex = 18;
            this.label4.Text = "Puntuacion máxima del jugador que jugó el dia seleccionado:\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(215, 359);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 22);
            this.textBox1.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Consulta Uriel";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(382, 358);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(139, 22);
            this.textBox2.TabIndex = 21;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(395, 401);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 33);
            this.button3.TabIndex = 22;
            this.button3.Text = "Enviar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 692);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button IniciarSesion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox contra;
        private System.Windows.Forms.Button DarseAlta;
        private System.Windows.Forms.Button conectar;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Maximo;
        private System.Windows.Forms.RadioButton Minimo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
    }
}

