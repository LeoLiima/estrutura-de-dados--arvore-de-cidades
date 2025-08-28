using apCaminhosEmMarte;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text.Json.Serialization;
using System.Text.Json;

using System.Collections.Generic;


namespace CaminhoEntreCidades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Arvore<Cidade> arvoreCidades = new Arvore<Cidade>();

        private void CarregarCidadesDoArquivo()
        {
            dlgCidades.Title = "Escolha um arquivo de Cidade"; //título da janela


            if (dlgCidades.ShowDialog() == DialogResult.OK)
            {
                string arquivoCidade = dlgCidades.FileName;
                arvoreCidades.LerArquivoDeRegistros(arquivoCidade);

            }
        }

        private void CarregarCaminhosDoArquivo()
        {
            dlgCaminhos.Title = "Selecione o arquivo de caminhos entre cidades";
            if (dlgCaminhos.ShowDialog() == DialogResult.OK)
            {
                // Abre o arquivo selecionado
                using (var origem = new System.IO.FileStream(dlgCaminhos.FileName, FileMode.OpenOrCreate))
                using (var arquivo = new BinaryReader(origem))
                {
                    LerCaminhosInOrdem(arvoreCidades.Raiz, arquivo);
                }
            }
        }

        //Percorre a arvore em Ordem para ler a lista de caminhos referente a cidade
        public void LerCaminhosInOrdem(NoArvore<Cidade> atual, BinaryReader arquivo)
        {

            if (atual != null)
            {
                LerCaminhosInOrdem(atual.Esq, arquivo);
                LerCaminhosRecursivo(arquivo, 0, atual.Info);
                LerCaminhosInOrdem(atual.Dir, arquivo);
            }
        }

        
        private static void LerCaminhosRecursivo(BinaryReader arquivo, long qualRegistro, Cidade cidade)
        {
            
            if (arquivo.BaseStream.Position < arquivo.BaseStream.Length)
            {
                CaminhoEntreCidadesMarte caminho = new CaminhoEntreCidadesMarte();
                caminho.LerRegistro(arquivo, qualRegistro); 
               
                if (caminho.CidadeOrigem.Trim() == cidade.NomeCidade.Trim())
                {
                 
                    cidade.Caminhos.InserirAposFim(caminho);
                }
                LerCaminhosRecursivo(arquivo, qualRegistro + 1, cidade);
            }
            else
            {
               
                arquivo.BaseStream.Position = 0;

               
            }
        }


        //atualiza o ComboBox
        public void PreencherCombo(NoArvore<Cidade> atual, ComboBox comboBox)
        {
            if (atual != null)
            {

                PreencherCombo(atual.Esq, comboBox);

                comboBox.Items.Add(atual.Info.NomeCidade);


                PreencherCombo(atual.Dir, comboBox);
            }
        }

        private void btnInserirCidade_Click(object sender, EventArgs e)
        {
           
            string nomeCidade = txtCidade.Text.Trim();
            double coordenadaX = (double)nudX.Value;
            double coordenadaY = (double)nudY.Value;

            
            if (string.IsNullOrEmpty(nomeCidade))
            {
                MessageBox.Show("Por favor, insira o nome da cidade.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (coordenadaX < 0 || coordenadaY < 0)
            {
                MessageBox.Show("As coordenadas (X e Y) devem ser valores não negativos.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                Cidade adicionar = new Cidade(nomeCidade, coordenadaX, coordenadaY);
                arvoreCidades.IncluirNovoRegistro(adicionar);

                AtualizarCombos();

                MessageBox.Show("Cidade inserida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                limparCampos();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro ao incluir cidade: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pbMapa.Invalidate();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarCidadesDoArquivo();
            CarregarCaminhosDoArquivo();
            ConfigurarDataGridView();

            PreencherCombo(arvoreCidades.Raiz, cbxDestino);
            pbMapa.Invalidate();

        }

        public void limparCampos()
        {
            txtCidade.Clear();
            nudX.Value = 0;
            nudY.Value = 0;
        }

        public void AtualizarCombos()
        {
            cbxDestino.Items.Clear();
            PreencherCombo(arvoreCidades.Raiz, cbxDestino);
        }

        private void btnExibirCidade_Click(object sender, EventArgs e)
        {
            Cidade cidadeAux = new Cidade(txtCidade.Text, 0.0, 0.0);
            string nomeCidade = txtCidade.Text.Replace("\0", string.Empty);
            NoArvore<Cidade> busca = arvoreCidades.ExisteNo(cidadeAux);

            if (busca.Info.NomeCidade.Trim() == nomeCidade)
            {
                nudX.Value = Convert.ToDecimal(busca.Info.X);
                nudY.Value = Convert.ToDecimal(busca.Info.Y);
            }
            else
            {
                MessageBox.Show("Cidade não encontrada");
            }
        }

        private void btnExcluirCidade_Click(object sender, EventArgs e)
        {
            string nomeCidade = txtCidade.Text.Trim();

            if (string.IsNullOrEmpty(nomeCidade))
            {
                MessageBox.Show("Por favor, insira o nome da cidade que deseja remover.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cidade cidadeARemover = new Cidade(nomeCidade, 0, 0);
            try
            {

                bool sucessoRemocao = arvoreCidades.RemoverRegistro(cidadeARemover);
                if (sucessoRemocao)
                {
                    MessageBox.Show("Cidade removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarCombos();
                }
                else
                {
                    MessageBox.Show("Cidade não encontrada na árvore.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                limparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar remover a cidade: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pbMapa.Invalidate();
        }

        //Usamos o método "Existe()", que ao terminar deixa o apontador atual 
        //na posição onde o dado passado de parâmetro esta.                  -> Fizemos isso em diversos métodos
        private void btnAlterarCidade_Click(object sender, EventArgs e)
        {
            Cidade cidadeAux = new Cidade(txtCidade.Text, Convert.ToDouble(nudX.Value), Convert.ToDouble(nudY.Value));
            NoArvore<Cidade> noAux = arvoreCidades.ExisteNo(cidadeAux);
            if (arvoreCidades.Existe(noAux.Info))
            {
                noAux.Info.X = Convert.ToDouble(nudX.Value);
                noAux.Info.Y = Convert.ToDouble(nudY.Value);
                arvoreCidades.Atual.Info = noAux.Info; 
                MessageBox.Show("Cidade alterada com sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao encontrar a cidade");
            }
            pbMapa.Invalidate();
        }


        private void ConfigurarDataGridView()
        {
            dgvCaminhos.Columns.Clear();
            dgvCaminhos.Columns.Add("Destino", "Cidade Destino");
            dgvCaminhos.Columns.Add("Distancia", "Distância");
            dgvCaminhos.Columns.Add("Tempo", "Tempo");
            dgvCaminhos.Columns.Add("Custo", "Custo");

            dgvCaminhos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInserirCaminho_Click(object sender, EventArgs e)
        {
            string origem = txtCidade.Text.Trim();
            string destino = cbxDestino.SelectedItem.ToString();
            int custo = (int)nudCusto.Value;
            int distancia = (int)nudDistancia.Value;
            int tempo = (int)nudTempo.Value;

            Cidade cidadeAux = new Cidade(origem, 0, 0);

            if (destino != origem)
            {
                CaminhoEntreCidadesMarte novoCaminho = new CaminhoEntreCidadesMarte(origem, destino, distancia, tempo, custo);

                if (arvoreCidades.Existe(cidadeAux))
                {
                    arvoreCidades.Atual.Info.Caminhos.InserirAposFim(novoCaminho);
                    MessageBox.Show("Caminho Incluido com sucesso");
                }
                else
                {
                    MessageBox.Show($"A cidade de Origem não existe", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("As cidades devem ser diferentes uma das outras");
            }


        }

        private void btnExibirCaminho_Click(object sender, EventArgs e)
        {

            if (txtCidade.Text == "")
            {
                MessageBox.Show("Digite uma cidade para exbir seus respectivos caminhos");
            }
            else
                ExibirCaminhos();
            Pen caneta = new Pen(Color.Red);
            Cidade cidade = new Cidade(txtCidade.Text.Trim(), 0, 0);
            if (arvoreCidades.Existe(cidade))
            {
                DesenharCaminhos(arvoreCidades.Atual, pbMapa.CreateGraphics(), caneta);
            }


        }



        private void ExibirCaminhos()
        {
            dgvCaminhos.Rows.Clear(); 


            PreencherCaminhosNoGrid(arvoreCidades.Raiz);

        }

        public void DesenharCaminhos(NoArvore<Cidade> atual, Graphics g, Pen pen)
        {

            var list = atual.Info.Caminhos.ObterListaCompleta();

            if (txtCidade.Text == atual.Info.NomeCidade.Trim())
            {
                foreach (var elemento in list)
                {
                    float escalaX = pbMapa.Width;
                    float escalaY = pbMapa.Height;

                    double xDestino = 0;
                    double yDestino = 0;

                    float xOrigem = (float)atual.Info.X * escalaX;
                    float yOrigem = (float)atual.Info.Y * escalaY;

                    Cidade cidadeAux = new Cidade(elemento.CidadeDestino, 0, 0);
                    if (arvoreCidades.Existe(cidadeAux))
                    {
                        xDestino = arvoreCidades.Atual.Info.X * escalaX;
                        yDestino = arvoreCidades.Atual.Info.Y * escalaY;
                    }

                    g.DrawLine(pen, xOrigem, yOrigem, (float)xDestino, (float)yDestino);
                }
            }
        }

        //Ao clicar em Exibir o grid lista os caminhos de uma cidade digitada
        private void PreencherCaminhosNoGrid(NoArvore<Cidade> atual)
        {
            if (atual != null)
            {
 
                PreencherCaminhosNoGrid(atual.Esq);

                var list = atual.Info.Caminhos.ObterListaCompleta();

                foreach (var caminho in list)
                {
                    if (txtCidade.Text == atual.Info.NomeCidade.Trim())
                    {
                        dgvCaminhos.Rows.Add(
                        caminho.CidadeDestino.Trim(), 
                        caminho.Distancia,            
                        caminho.Tempo,                
                        caminho.Custo                 
                    );
                    }
                }

               
                PreencherCaminhosNoGrid(atual.Dir);
            }
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            var ondeDesenhar = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Black, 2);
            var fonte = new Font("Segoe UI", 8);

            var buscaFonte = new Font("Segoe UI", 10, FontStyle.Bold);
            SolidBrush buscaBrush = new SolidBrush(Color.Red); 
            
            DesenharCidadesNoMapa(arvoreCidades.Raiz, ondeDesenhar, brush, pen, fonte);
        }

        //método que desenha no mapa os destinos de acordo com a cidade de origem digitada 
        private void DesenharCidadesNoMapa(NoArvore<Cidade> atual, Graphics g, SolidBrush brush, Pen pen, Font fonte)
        {
            if (atual != null)
            {
                DesenharCidadesNoMapa(atual.Esq, g, brush, pen, fonte);
                Cidade cidade = atual.Info;

                float escalaX = pbMapa.Width;
                float escalaY = pbMapa.Height;

                float x = (float)cidade.X * escalaX;
                float y = (float)cidade.Y * escalaY;
                float tamanhoPonto = 10f;

                g.FillEllipse(brush, x - tamanhoPonto / 2, y - tamanhoPonto / 2, tamanhoPonto, tamanhoPonto);
                g.DrawString(cidade.NomeCidade.Trim(), fonte, brush, x + tamanhoPonto, y);

                DesenharCidadesNoMapa(atual.Dir, g, brush, pen, fonte);
            }
        }

       



        private void tabPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl; //usado para ter o controle quando mudar de tabpage no formulario
            if (tabControl.SelectedTab == tabArvore)
            {
                pbArvore.Invalidate();
            }
            pbArvore.Invalidate();
        }


        private void btnExcluirCaminho_Click(object sender, EventArgs e)
        {
            Cidade cidadeAux = new Cidade(txtCidade.Text.Trim(), 0, 0);
            if (arvoreCidades.Existe(cidadeAux))
            {
                Cidade cidadeCaminhos = arvoreCidades.Atual.Info;
                ListaSimples<CaminhoEntreCidadesMarte> listaCamimhos = cidadeCaminhos.Caminhos;

                CaminhoEntreCidadesMarte caminhoAux = new CaminhoEntreCidadesMarte(txtCidade.Text.Trim(), cbxDestino.SelectedItem.ToString(), 0, 0, 0);


                bool deu = listaCamimhos.Excluir(caminhoAux);

                if (deu)
                {
                    MessageBox.Show("Exclusão concluída");

                }
                else
                {
                    MessageBox.Show("Erro ao excluir");
                }
                txtCidade.Clear();
            }


        }
       
        
        private void btnAlterarCaminho_Click(object sender, EventArgs e)
        {
            Cidade cidadeAux = new Cidade(txtCidade.Text.Trim(), 0, 0);
            if (arvoreCidades.Existe(cidadeAux))
            {
                Cidade cidadeCaminhos = arvoreCidades.Atual.Info;
                ListaSimples<CaminhoEntreCidadesMarte> listaCamimhos = cidadeCaminhos.Caminhos;

                CaminhoEntreCidadesMarte caminhoAux = new CaminhoEntreCidadesMarte(txtCidade.Text.Trim(),
                    cbxDestino.SelectedItem.ToString(), (int)nudDistancia.Value, (int)nudTempo.Value, (int)nudCusto.Value);
                bool achou = listaCamimhos.Buscar(caminhoAux);
                if (achou)
                {
                    listaCamimhos.Atual.Info = caminhoAux;
                    MessageBox.Show("Dado com sucesso: " + caminhoAux.ToString());
                }
                else
                {
                    MessageBox.Show("Erro ao alterar Caminho");
                }

            }
        }

        //fizemos a funçao de desenhar arvore no form,
        //pois precisavamos pegar a lista de caminhos que se encontra na classe caminhos,
        //e por a arvore ser uma classe generica, optamos por realiazar o metodo de desenhar no próprio formulario

        private void DesenharArvore(NoArvore<Cidade> noAtual, Graphics g, int x, int y, int nivel, int espacamento)
        {
            if (noAtual == null) return;

            
            Font fonte = new Font("Arial", 10);
            Brush preenchimento = Brushes.LightGray;
            Pen borda = Pens.Black;
            Brush textoCor = Brushes.Black;

           
            int larguraNo = 90;
            int alturaNo = 40;

           
            Rectangle retangulo = new Rectangle(x - larguraNo / 2, y, larguraNo, alturaNo);
            g.FillRectangle(preenchimento, retangulo);
            g.DrawRectangle(borda, retangulo);

            string texto = $"{noAtual.Info.NomeCidade}\n{noAtual.Info.Caminhos.QuantosNos} caminho(s)";
            StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }; //usado para deixar mais apresentavel 
            g.DrawString(texto, fonte, textoCor, retangulo, format);

            
            int yFilho = y + 80;
            int espacamentoFilhos = espacamento; 
            
            if (noAtual.Esq != null)
            {
                int xFilhoEsq = x - espacamentoFilhos;
                g.DrawLine(borda, x, y + alturaNo, xFilhoEsq, yFilho);
                DesenharArvore(noAtual.Esq, g, xFilhoEsq, yFilho, nivel + 1, espacamento);
            }

            if (noAtual.Dir != null)
            {
                int xFilhoDir = x + espacamentoFilhos;
                g.DrawLine(borda, x, y + alturaNo, xFilhoDir, yFilho);
                DesenharArvore(noAtual.Dir, g, xFilhoDir, yFilho, nivel + 1, espacamento);
            }
        }

        
        private void pbArvore_Paint(object sender, PaintEventArgs e)
        {
            int larguraInicial = pbArvore.Width / 2;
            int alturaInicial = 20;
            int espacamentoInicial = 90; 

            if (arvoreCidades.Raiz != null)
            {
                DesenharArvore(arvoreCidades.Raiz, e.Graphics, larguraInicial, alturaInicial, 0, espacamentoInicial);
            }
        }


        //JSon de 
        private void ExportarArvoreParaJSON(string caminhoArquivo)
        {
            StreamWriter jsonArq = new StreamWriter(caminhoArquivo);
            List<Cidade> listaCidades = new List<Cidade>();
            ColetarCidades(arvoreCidades.Raiz, listaCidades);

            var opcoes = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(listaCidades, opcoes);

            File.WriteAllText(caminhoArquivo, json);
        }

        private void ColetarCidades(NoArvore<Cidade> atual, List<Cidade> lista)
        {
            if (atual != null)
            {
                ColetarCidades(atual.Esq, lista);
                lista.Add(atual.Info);
                ColetarCidades(atual.Dir, lista);
            }
        }
        private void ExportarCaminhosParaJSON(string caminhoArquivo)
        {
            StreamWriter jsonArq = new StreamWriter(caminhoArquivo);
            List<CaminhoEntreCidadesMarte> listaCaminhos = new List<CaminhoEntreCidadesMarte>();
            ColetarCaminhos(arvoreCidades.Raiz, listaCaminhos);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(listaCaminhos, options);

            File.WriteAllText(caminhoArquivo, json);
        }

        private void ColetarCaminhos(NoArvore<Cidade> atual, List<CaminhoEntreCidadesMarte> lista)
        {
            if (atual != null)
            {
                ColetarCaminhos(atual.Esq, lista);
                lista.AddRange(atual.Info.Caminhos.ObterListaCompleta());
                ColetarCaminhos(atual.Dir, lista);
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //Ao fechar chama os métodos de salvamento
        {
            string arquivoSalvar = dlgCidades.FileName;
            //GravarCaminhos();
            arvoreCidades.GravarArquivoDeRegistros(arquivoSalvar);
            ExportarArvoreParaJSON("C:\\Users\\u23121\\Desktop\\Arvore.json");
            ExportarCaminhosParaJSON("C:\\Users\u23121\\Desktop\\caminhos.json");

        }

       




        //Percorre a Arvore inOrdem pegando na lista dado por dado
        //Chama o metodo GravarRegistro() da classe CaminhosEntreCidadesMarte


        /*public void GravarCaminhos()
        {
            var destino = new FileStream(dlgCidades.FileName, FileMode.Create);
            var arquivo = new BinaryWriter(destino);
            GravarCaminhos(arvoreCidades.Raiz, arquivo);

        }

        private void GravarCaminhos(NoArvore<Cidade> atual, BinaryWriter writer)
        {
            if (atual != null)
            {

                GravarCaminhos(atual.Esq, writer);


                ListaSimples<CaminhoEntreCidadesMarte> listaCidades = arvoreCidades.Atual.Info.Caminhos;


                while (listaCidades.Atual != null)
                {
                    listaCidades.Atual.Info.GravarRegistro(writer);
                    listaCidades.Atual = listaCidades.Atual.Prox;
                }

                GravarCaminhos(atual.Dir, writer);
            }*/
    }

}

