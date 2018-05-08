namespace WindowsFormsApp_ParserXMLtoDatabase
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonWczytajXML = new System.Windows.Forms.Button();
            this.buttonViewDatabase = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonWczytajXML);
            this.flowLayoutPanel1.Controls.Add(this.buttonViewDatabase);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(700, 375);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonWczytajXML
            // 
            this.buttonWczytajXML.BackColor = System.Drawing.Color.Chartreuse;
            this.buttonWczytajXML.Font = new System.Drawing.Font("Sitka Small", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWczytajXML.Location = new System.Drawing.Point(3, 3);
            this.buttonWczytajXML.Name = "buttonWczytajXML";
            this.buttonWczytajXML.Size = new System.Drawing.Size(341, 365);
            this.buttonWczytajXML.TabIndex = 0;
            this.buttonWczytajXML.Text = "Wczytaj XML do bazy danych MYSQL!";
            this.buttonWczytajXML.UseVisualStyleBackColor = false;
            this.buttonWczytajXML.Click += new System.EventHandler(this.buttonWczytajXML_Click);
            // 
            // buttonViewDatabase
            // 
            this.buttonViewDatabase.BackColor = System.Drawing.Color.Aqua;
            this.buttonViewDatabase.Font = new System.Drawing.Font("Sitka Small", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonViewDatabase.Location = new System.Drawing.Point(350, 3);
            this.buttonViewDatabase.Name = "buttonViewDatabase";
            this.buttonViewDatabase.Size = new System.Drawing.Size(341, 365);
            this.buttonViewDatabase.TabIndex = 1;
            this.buttonViewDatabase.Text = "Wyświetl zawartość bazy danych MYSQL!";
            this.buttonViewDatabase.UseVisualStyleBackColor = false;
            this.buttonViewDatabase.Click += new System.EventHandler(this.buttonViewDatabase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 394);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonWczytajXML;
        private System.Windows.Forms.Button buttonViewDatabase;
    }
}

