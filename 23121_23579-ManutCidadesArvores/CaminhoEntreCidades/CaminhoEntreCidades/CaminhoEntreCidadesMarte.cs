using System;
using System.IO;

namespace apCaminhosEmMarte
{
    public class CaminhoEntreCidadesMarte : IRegistro, IComparable<CaminhoEntreCidadesMarte>
    {
        const int tamNome = 15; // Tamanho fixo para os nomes
        const int tamDistancia = sizeof(int); // Distância (5 posições)
        const int tamTempo = sizeof(int); // Tempo (4 posições)
        const int tamCusto = sizeof(int); // Custo (5 posições)
        const int tamanhoRegistro = (2 * tamNome) + tamDistancia + tamTempo + tamCusto; // Tamanho total do registro

        private string cidadeOrigem;
        private string cidadeDestino;
        private int distancia;
        private int tempo;
        private int custo;

        public int TamanhoRegistro => tamanhoRegistro;

        public CaminhoEntreCidadesMarte()
        {
            CidadeOrigem = "";
            CidadeDestino = "";
            Distancia = 0;
            Tempo = 0;
            Custo = 0;
        }

        public CaminhoEntreCidadesMarte(string origem, string destino, int distancia, int tempo, int custo)
        {
            CidadeOrigem = origem;
            CidadeDestino = destino;
            Distancia = distancia;
            Tempo = tempo;
            Custo = custo;
        }

        public string CidadeOrigem
        {
            get => cidadeOrigem;
            set => cidadeOrigem = value.PadRight(tamNome, ' ').Substring(0, tamNome);
        } 

        public string CidadeDestino
        {
            get => cidadeDestino;
            set => cidadeDestino = value.PadRight(tamNome, ' ').Substring(0, tamNome);
        }

        public int Distancia
        {
            get => distancia;
            set
            {
                if (value < 0 || value > 99999)
                    throw new Exception("Distância deve estar entre 0 e 99999.");
                distancia = value;
            }
        }

        public int Tempo
        {
            get => tempo;
            set
            {
                if (value < 0 || value > 9999)
                    throw new Exception("Tempo deve estar entre 0 e 9999.");
                tempo = value;
            }
        }

        public int Custo
        {
            get => custo;
            set
            {
                if (value < 0 || value > 99999)
                    throw new Exception("Custo deve estar entre 0 e 99999.");
                custo = value;
            }
        }

        public void LerRegistro(BinaryReader arquivo, long qualRegistro)
        {
            if (arquivo != null)
            {
                try
                {
                    long posicao = qualRegistro * TamanhoRegistro;
                    arquivo.BaseStream.Seek(posicao, SeekOrigin.Begin);

                    // Ler os nomes fixos
                    char[] origemChars = arquivo.ReadChars(tamNome);
                    char[] destinoChars = arquivo.ReadChars(tamNome);

                    CidadeOrigem = new string(origemChars).Replace("\0", string.Empty).Trim();
                    CidadeDestino = new string(destinoChars).Replace("\0", string.Empty).Trim();

                    // Ler os valores numéricos
                    Distancia = arquivo.ReadInt32();
                    Tempo = arquivo.ReadInt32();
                    Custo = arquivo.ReadInt32();
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
                    // Gravar os nomes com tamanho fixo
                    char[] origemChars = CidadeOrigem.ToCharArray();
                    char[] destinoChars = CidadeDestino.ToCharArray();
                    arquivo.Write(origemChars);
                    arquivo.Write(destinoChars);

                    // Gravar os valores numéricos
                    arquivo.Write(Distancia);
                    arquivo.Write(Tempo);
                    arquivo.Write(Custo);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao gravar o registro: {e.Message}");
                }
            }
        }

        public override string ToString()
        {
            return $"{CidadeOrigem.Trim()} -> {CidadeDestino.Trim()} | Distância: {Distancia} | Tempo: {Tempo} | Custo: {Custo}";
        }

        // Implementando o método CompareTo corretamente
        public int CompareTo(CaminhoEntreCidadesMarte outroCaminho)
        {
            if (outroCaminho.cidadeOrigem == this.cidadeOrigem && this.cidadeDestino == outroCaminho.cidadeDestino)
            {
                return 0;
            }
            return 1;
        }

       
    }
}
