namespace CaminhoEntreCidades
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tabCidades = new System.Windows.Forms.TabPage();
            this.gbCidades = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.btnInserirCidade = new System.Windows.Forms.Button();
            this.btnExcluirCidade = new System.Windows.Forms.Button();
            this.btnExibirCidade = new System.Windows.Forms.Button();
            this.btnAlterarCidade = new System.Windows.Forms.Button();
            this.gbCaminho = new System.Windows.Forms.GroupBox();
            this.cbxDestino = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAlterarCaminho = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnExibirCaminho = new System.Windows.Forms.Button();
            this.btnExcluirCaminho = new System.Windows.Forms.Button();
            this.nudDistancia = new System.Windows.Forms.NumericUpDown();
            this.btnInserirCaminho = new System.Windows.Forms.Button();
            this.nudTempo = new System.Windows.Forms.NumericUpDown();
            this.nudCusto = new System.Windows.Forms.NumericUpDown();
            this.dgvCaminhos = new System.Windows.Forms.DataGridView();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.tabArvore = new System.Windows.Forms.TabPage();
            this.pbArvore = new System.Windows.Forms.PictureBox();
            this.dlgCidades = new System.Windows.Forms.OpenFileDialog();
            this.dlgCaminhos = new System.Windows.Forms.OpenFileDialog();
            this.tabPage.SuspendLayout();
            this.tabCidades.SuspendLayout();
            this.gbCidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            this.gbCaminho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.tabArvore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArvore)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage
            // 
            this.tabPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage.Controls.Add(this.tabCidades);
            this.tabPage.Controls.Add(this.tabArvore);
            this.tabPage.Location = new System.Drawing.Point(1, 1);
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(1046, 505);
            this.tabPage.TabIndex = 0;
            this.tabPage.SelectedIndexChanged += new System.EventHandler(this.tabPage_SelectedIndexChanged);
            // 
            // tabCidades
            // 
            this.tabCidades.Controls.Add(this.gbCidades);
            this.tabCidades.Controls.Add(this.gbCaminho);
            this.tabCidades.Controls.Add(this.dgvCaminhos);
            this.tabCidades.Controls.Add(this.pbMapa);
            this.tabCidades.Location = new System.Drawing.Point(4, 26);
            this.tabCidades.Name = "tabCidades";
            this.tabCidades.Padding = new System.Windows.Forms.Padding(3);
            this.tabCidades.Size = new System.Drawing.Size(1038, 475);
            this.tabCidades.TabIndex = 0;
            this.tabCidades.Text = "Cidades";
            this.tabCidades.UseVisualStyleBackColor = true;
            // 
            // gbCidades
            // 
            this.gbCidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCidades.Controls.Add(this.label1);
            this.gbCidades.Controls.Add(this.nudY);
            this.gbCidades.Controls.Add(this.label3);
            this.gbCidades.Controls.Add(this.label4);
            this.gbCidades.Controls.Add(this.label5);
            this.gbCidades.Controls.Add(this.txtCidade);
            this.gbCidades.Controls.Add(this.nudX);
            this.gbCidades.Controls.Add(this.btnInserirCidade);
            this.gbCidades.Controls.Add(this.btnExcluirCidade);
            this.gbCidades.Controls.Add(this.btnExibirCidade);
            this.gbCidades.Controls.Add(this.btnAlterarCidade);
            this.gbCidades.Location = new System.Drawing.Point(7, 6);
            this.gbCidades.Name = "gbCidades";
            this.gbCidades.Size = new System.Drawing.Size(544, 133);
            this.gbCidades.TabIndex = 1;
            this.gbCidades.TabStop = false;
            this.gbCidades.Text = "Cidades";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cidade";
            // 
            // nudY
            // 
            this.nudY.DecimalPlaces = 5;
            this.nudY.Location = new System.Drawing.Point(379, 71);
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(120, 23);
            this.nudY.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Y";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(6, 71);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(232, 23);
            this.txtCidade.TabIndex = 5;
            // 
            // nudX
            // 
            this.nudX.DecimalPlaces = 5;
            this.nudX.Location = new System.Drawing.Point(253, 71);
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(120, 23);
            this.nudX.TabIndex = 8;
            // 
            // btnInserirCidade
            // 
            this.btnInserirCidade.Location = new System.Drawing.Point(10, 100);
            this.btnInserirCidade.Name = "btnInserirCidade";
            this.btnInserirCidade.Size = new System.Drawing.Size(81, 28);
            this.btnInserirCidade.TabIndex = 9;
            this.btnInserirCidade.Text = "Inserir";
            this.btnInserirCidade.UseVisualStyleBackColor = true;
            this.btnInserirCidade.Click += new System.EventHandler(this.btnInserirCidade_Click);
            // 
            // btnExcluirCidade
            // 
            this.btnExcluirCidade.Location = new System.Drawing.Point(104, 100);
            this.btnExcluirCidade.Name = "btnExcluirCidade";
            this.btnExcluirCidade.Size = new System.Drawing.Size(81, 28);
            this.btnExcluirCidade.TabIndex = 10;
            this.btnExcluirCidade.Text = "Excluir";
            this.btnExcluirCidade.UseVisualStyleBackColor = true;
            this.btnExcluirCidade.Click += new System.EventHandler(this.btnExcluirCidade_Click);
            // 
            // btnExibirCidade
            // 
            this.btnExibirCidade.Location = new System.Drawing.Point(292, 100);
            this.btnExibirCidade.Name = "btnExibirCidade";
            this.btnExibirCidade.Size = new System.Drawing.Size(81, 28);
            this.btnExibirCidade.TabIndex = 12;
            this.btnExibirCidade.Text = "Exibir";
            this.btnExibirCidade.UseVisualStyleBackColor = true;
            this.btnExibirCidade.Click += new System.EventHandler(this.btnExibirCidade_Click);
            // 
            // btnAlterarCidade
            // 
            this.btnAlterarCidade.Location = new System.Drawing.Point(198, 100);
            this.btnAlterarCidade.Name = "btnAlterarCidade";
            this.btnAlterarCidade.Size = new System.Drawing.Size(81, 28);
            this.btnAlterarCidade.TabIndex = 13;
            this.btnAlterarCidade.Text = "Alterar";
            this.btnAlterarCidade.UseVisualStyleBackColor = true;
            this.btnAlterarCidade.Click += new System.EventHandler(this.btnAlterarCidade_Click);
            // 
            // gbCaminho
            // 
            this.gbCaminho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCaminho.Controls.Add(this.cbxDestino);
            this.gbCaminho.Controls.Add(this.label6);
            this.gbCaminho.Controls.Add(this.label2);
            this.gbCaminho.Controls.Add(this.label12);
            this.gbCaminho.Controls.Add(this.label11);
            this.gbCaminho.Controls.Add(this.btnAlterarCaminho);
            this.gbCaminho.Controls.Add(this.label10);
            this.gbCaminho.Controls.Add(this.btnExibirCaminho);
            this.gbCaminho.Controls.Add(this.btnExcluirCaminho);
            this.gbCaminho.Controls.Add(this.nudDistancia);
            this.gbCaminho.Controls.Add(this.btnInserirCaminho);
            this.gbCaminho.Controls.Add(this.nudTempo);
            this.gbCaminho.Controls.Add(this.nudCusto);
            this.gbCaminho.Location = new System.Drawing.Point(556, 6);
            this.gbCaminho.Name = "gbCaminho";
            this.gbCaminho.Size = new System.Drawing.Size(474, 192);
            this.gbCaminho.TabIndex = 62;
            this.gbCaminho.TabStop = false;
            this.gbCaminho.Text = "Caminhos";
            // 
            // cbxDestino
            // 
            this.cbxDestino.FormattingEnabled = true;
            this.cbxDestino.Location = new System.Drawing.Point(135, 69);
            this.cbxDestino.Name = "cbxDestino";
            this.cbxDestino.Size = new System.Drawing.Size(174, 25);
            this.cbxDestino.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 17);
            this.label6.TabIndex = 60;
            this.label6.Text = "Cidade de Destino";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 58;
            this.label2.Text = "Caminhos";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 17);
            this.label12.TabIndex = 47;
            this.label12.Text = "Distância";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(168, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 48;
            this.label11.Text = "Tempo";
            // 
            // btnAlterarCaminho
            // 
            this.btnAlterarCaminho.Location = new System.Drawing.Point(197, 164);
            this.btnAlterarCaminho.Name = "btnAlterarCaminho";
            this.btnAlterarCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnAlterarCaminho.TabIndex = 57;
            this.btnAlterarCaminho.Text = "Alterar";
            this.btnAlterarCaminho.UseVisualStyleBackColor = true;
            this.btnAlterarCaminho.Click += new System.EventHandler(this.btnAlterarCaminho_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(327, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 49;
            this.label10.Text = "Custo";
            // 
            // btnExibirCaminho
            // 
            this.btnExibirCaminho.Location = new System.Drawing.Point(291, 163);
            this.btnExibirCaminho.Name = "btnExibirCaminho";
            this.btnExibirCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnExibirCaminho.TabIndex = 56;
            this.btnExibirCaminho.Text = "Exibir";
            this.btnExibirCaminho.UseVisualStyleBackColor = true;
            this.btnExibirCaminho.Click += new System.EventHandler(this.btnExibirCaminho_Click);
            // 
            // btnExcluirCaminho
            // 
            this.btnExcluirCaminho.Location = new System.Drawing.Point(103, 164);
            this.btnExcluirCaminho.Name = "btnExcluirCaminho";
            this.btnExcluirCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirCaminho.TabIndex = 55;
            this.btnExcluirCaminho.Text = "Excluir";
            this.btnExcluirCaminho.UseVisualStyleBackColor = true;
            this.btnExcluirCaminho.Click += new System.EventHandler(this.btnExcluirCaminho_Click);
            // 
            // nudDistancia
            // 
            this.nudDistancia.Location = new System.Drawing.Point(15, 132);
            this.nudDistancia.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDistancia.Name = "nudDistancia";
            this.nudDistancia.Size = new System.Drawing.Size(111, 23);
            this.nudDistancia.TabIndex = 51;
            // 
            // btnInserirCaminho
            // 
            this.btnInserirCaminho.Location = new System.Drawing.Point(9, 163);
            this.btnInserirCaminho.Name = "btnInserirCaminho";
            this.btnInserirCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnInserirCaminho.TabIndex = 54;
            this.btnInserirCaminho.Text = "Inserir";
            this.btnInserirCaminho.UseVisualStyleBackColor = true;
            this.btnInserirCaminho.Click += new System.EventHandler(this.btnInserirCaminho_Click);
            // 
            // nudTempo
            // 
            this.nudTempo.Location = new System.Drawing.Point(171, 132);
            this.nudTempo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTempo.Name = "nudTempo";
            this.nudTempo.Size = new System.Drawing.Size(111, 23);
            this.nudTempo.TabIndex = 52;
            // 
            // nudCusto
            // 
            this.nudCusto.Location = new System.Drawing.Point(330, 132);
            this.nudCusto.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCusto.Name = "nudCusto";
            this.nudCusto.Size = new System.Drawing.Size(111, 23);
            this.nudCusto.TabIndex = 53;
            // 
            // dgvCaminhos
            // 
            this.dgvCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaminhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaminhos.Location = new System.Drawing.Point(555, 212);
            this.dgvCaminhos.Name = "dgvCaminhos";
            this.dgvCaminhos.Size = new System.Drawing.Size(475, 232);
            this.dgvCaminhos.TabIndex = 61;
            // 
            // pbMapa
            // 
            this.pbMapa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbMapa.Image = global::CaminhoEntreCidades.Properties.Resources.Mapa_Marte_sem_rotas;
            this.pbMapa.Location = new System.Drawing.Point(3, 152);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(548, 292);
            this.pbMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapa.TabIndex = 24;
            this.pbMapa.TabStop = false;
            this.pbMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMapa_Paint);
            // 
            // tabArvore
            // 
            this.tabArvore.Controls.Add(this.pbArvore);
            this.tabArvore.Location = new System.Drawing.Point(4, 22);
            this.tabArvore.Name = "tabArvore";
            this.tabArvore.Padding = new System.Windows.Forms.Padding(3);
            this.tabArvore.Size = new System.Drawing.Size(1038, 479);
            this.tabArvore.TabIndex = 2;
            this.tabArvore.Text = "Árvore";
            this.tabArvore.UseVisualStyleBackColor = true;
            // 
            // pbArvore
            // 
            this.pbArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbArvore.Location = new System.Drawing.Point(3, 6);
            this.pbArvore.Name = "pbArvore";
            this.pbArvore.Size = new System.Drawing.Size(1032, 463);
            this.pbArvore.TabIndex = 1;
            this.pbArvore.TabStop = false;
            this.pbArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.pbArvore_Paint);
            // 
            // dlgCidades
            // 
            this.dlgCidades.FileName = "openFileDialog1";
            this.dlgCidades.Title = "Selecione o arquivo de cidades";
            // 
            // dlgCaminhos
            // 
            this.dlgCaminhos.FileName = "dlgCaminhos";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1047, 500);
            this.Controls.Add(this.tabPage);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Manutenção de Cidades e suas Ligações";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage.ResumeLayout(false);
            this.tabCidades.ResumeLayout(false);
            this.gbCidades.ResumeLayout(false);
            this.gbCidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            this.gbCaminho.ResumeLayout(false);
            this.gbCaminho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.tabArvore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbArvore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.TabPage tabCidades;
        private System.Windows.Forms.Button btnAlterarCidade;
        private System.Windows.Forms.Button btnExibirCidade;
        private System.Windows.Forms.Button btnExcluirCidade;
        private System.Windows.Forms.Button btnInserirCidade;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.OpenFileDialog dlgCidades;
        private System.Windows.Forms.TabPage tabArvore;
        private System.Windows.Forms.PictureBox pbArvore;
        private System.Windows.Forms.DataGridView dgvCaminhos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAlterarCaminho;
        private System.Windows.Forms.Button btnExibirCaminho;
        private System.Windows.Forms.Button btnExcluirCaminho;
        private System.Windows.Forms.Button btnInserirCaminho;
        private System.Windows.Forms.NumericUpDown nudCusto;
        private System.Windows.Forms.NumericUpDown nudTempo;
        private System.Windows.Forms.NumericUpDown nudDistancia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gbCidades;
        private System.Windows.Forms.GroupBox gbCaminho;
        private System.Windows.Forms.ComboBox cbxDestino;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog dlgCaminhos;
    }
}
