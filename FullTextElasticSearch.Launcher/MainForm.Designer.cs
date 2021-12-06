namespace FullTextElasticSearch.Launcher
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnImportaDaStored = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCreaNuovoIndice = new System.Windows.Forms.Button();
            this.tbIdDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAggiornaDocumento = new System.Windows.Forms.Button();
            this.btnEliminaDocumento = new System.Windows.Forms.Button();
            this.btnImportaSacdenzeDaStored = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImportaDaStored
            // 
            this.btnImportaDaStored.Location = new System.Drawing.Point(130, 12);
            this.btnImportaDaStored.Name = "btnImportaDaStored";
            this.btnImportaDaStored.Size = new System.Drawing.Size(163, 23);
            this.btnImportaDaStored.TabIndex = 0;
            this.btnImportaDaStored.Text = "Indicizza documenti";
            this.btnImportaDaStored.UseVisualStyleBackColor = true;
            this.btnImportaDaStored.Click += new System.EventHandler(this.btnImportaDaStored_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 96);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(758, 265);
            this.textBox1.TabIndex = 1;
            // 
            // btnCreaNuovoIndice
            // 
            this.btnCreaNuovoIndice.Location = new System.Drawing.Point(12, 12);
            this.btnCreaNuovoIndice.Name = "btnCreaNuovoIndice";
            this.btnCreaNuovoIndice.Size = new System.Drawing.Size(112, 23);
            this.btnCreaNuovoIndice.TabIndex = 2;
            this.btnCreaNuovoIndice.Text = "Crea nuovo indice";
            this.btnCreaNuovoIndice.UseVisualStyleBackColor = true;
            this.btnCreaNuovoIndice.Click += new System.EventHandler(this.btnCreaNuovoIndice_Click);
            // 
            // tbIdDocumento
            // 
            this.tbIdDocumento.Location = new System.Drawing.Point(19, 67);
            this.tbIdDocumento.Name = "tbIdDocumento";
            this.tbIdDocumento.Size = new System.Drawing.Size(100, 20);
            this.tbIdDocumento.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Id documento";
            // 
            // btnAggiornaDocumento
            // 
            this.btnAggiornaDocumento.Location = new System.Drawing.Point(130, 67);
            this.btnAggiornaDocumento.Name = "btnAggiornaDocumento";
            this.btnAggiornaDocumento.Size = new System.Drawing.Size(112, 23);
            this.btnAggiornaDocumento.TabIndex = 9;
            this.btnAggiornaDocumento.Text = "Aggiorna documento";
            this.btnAggiornaDocumento.UseVisualStyleBackColor = true;
            this.btnAggiornaDocumento.Click += new System.EventHandler(this.btnAggiornaDocumento_Click);
            // 
            // btnEliminaDocumento
            // 
            this.btnEliminaDocumento.Location = new System.Drawing.Point(248, 67);
            this.btnEliminaDocumento.Name = "btnEliminaDocumento";
            this.btnEliminaDocumento.Size = new System.Drawing.Size(112, 23);
            this.btnEliminaDocumento.TabIndex = 10;
            this.btnEliminaDocumento.Text = "Elimina documento";
            this.btnEliminaDocumento.UseVisualStyleBackColor = true;
            this.btnEliminaDocumento.Click += new System.EventHandler(this.btnEliminaDocumento_Click);
            // 
            // btnImportaSacdenzeDaStored
            // 
            this.btnImportaSacdenzeDaStored.Location = new System.Drawing.Point(299, 12);
            this.btnImportaSacdenzeDaStored.Name = "btnImportaSacdenzeDaStored";
            this.btnImportaSacdenzeDaStored.Size = new System.Drawing.Size(163, 23);
            this.btnImportaSacdenzeDaStored.TabIndex = 11;
            this.btnImportaSacdenzeDaStored.Text = "Indicizza scadenze";
            this.btnImportaSacdenzeDaStored.UseVisualStyleBackColor = true;
            this.btnImportaSacdenzeDaStored.Click += new System.EventHandler(this.btnImportaSacdenzeDaStored_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 364);
            this.Controls.Add(this.btnImportaSacdenzeDaStored);
            this.Controls.Add(this.btnEliminaDocumento);
            this.Controls.Add(this.btnAggiornaDocumento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbIdDocumento);
            this.Controls.Add(this.btnCreaNuovoIndice);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnImportaDaStored);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ESLauncher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportaDaStored;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCreaNuovoIndice;
        private System.Windows.Forms.TextBox tbIdDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAggiornaDocumento;
        private System.Windows.Forms.Button btnEliminaDocumento;
        private System.Windows.Forms.Button btnImportaSacdenzeDaStored;
    }
}

