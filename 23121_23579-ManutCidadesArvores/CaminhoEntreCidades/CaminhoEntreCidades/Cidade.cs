using apCaminhosEmMarte;
using System.IO;
using System;
using System.Collections.Generic;

public class Cidade : IRegistro, IComparable<Cidade>
{
    const int tamNome = 15; // tamanho fixo do nome
    const int tamanhoRegistro = tamNome + sizeof(double) + sizeof(double); // tamanho total do registro

    private string nomeCidade;
    private double x, y;
    public ListaSimples<CaminhoEntreCidadesMarte> Caminhos { get; set; } // Lista de caminhos

    public int TamanhoRegistro => tamanhoRegistro;

    public Cidade()
    {
        NomeCidade = "";
        X = 0.0;
        Y = 0.0;
        Caminhos = new ListaSimples<CaminhoEntreCidadesMarte>(); // Inicializa a lista de caminhos
    }

    public Cidade(string nome, double x, double y)
    {
        NomeCidade = nome;
        X = x;
        Y = y;
        Caminhos = new ListaSimples<CaminhoEntreCidadesMarte>(); // Inicializa a lista de caminhos
    }

    public string Chave => NomeCidade;

    public string NomeCidade
    {
        get => nomeCidade;
        set => nomeCidade = value.PadRight(tamNome, ' ').Substring(0, tamNome);
    }

    public double X
    {
        get => x;
        set
        {
            if (value < 0 || value > 1)
                throw new Exception("X fora do intervalo de 0 a 1");
            x = value;
        }
    }

    public double Y
    {
        get => y;
        set
        {
            if (value < 0 || value > 1)
                throw new Exception("Y fora do intervalo de 0 a 1");
            y = value;
        }
    }

    // Método para adicionar um caminho à lista de caminhos
    public void AdicionarCaminho(CaminhoEntreCidadesMarte caminho)
    {
        Caminhos.InserirAposFim(caminho); // Supondo que ListaSimples tenha um método Inserir
    }

    // Método para exibir todos os caminhos


    public void LerRegistro(BinaryReader arquivo, long qualRegistro)
    {
        if (arquivo != null)
        {
            try
            {
                long posicao = qualRegistro * TamanhoRegistro;
                arquivo.BaseStream.Seek(posicao, SeekOrigin.Begin);

                // Ler o nome fixo
                char[] nomeChars = arquivo.ReadChars(tamNome);
                NomeCidade = new string(nomeChars).Replace("\0", string.Empty);

                // Ler os valores de X e Y
                X = arquivo.ReadDouble();
                Y = arquivo.ReadDouble();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler o registro: {e.Message}");
            }
        }
    }

    public void GravarRegistro(BinaryWriter arquivo)
    {
        if (arquivo != null)
        {
            try
            {
                // Gravar o nome com tamanho fixo
                char[] nomeChars = NomeCidade.ToCharArray();
                arquivo.Write(nomeChars);

                // Gravar os valores de X e Y
                arquivo.Write(X);
                arquivo.Write(Y);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao gravar o registro: {e.Message}");
            }
        }
    }


    public override string ToString()
    {
        return $"{NomeCidade.Trim()} {Caminhos.QuantosNos}";
    }

    public int CompareTo(Cidade outraCidade)
    {
        if (outraCidade.nomeCidade == null)
        {
            // Se a outra cidade for null, a cidade atual é considerada maior
            return 1;
        }

        // Compara as cidades pelo nome
        return NomeCidade.Replace("\0", string.Empty).CompareTo(outraCidade.NomeCidade);
    }

}
