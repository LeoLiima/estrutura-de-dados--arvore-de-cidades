using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ListaSimples<Dado> : IRegistro
             where Dado : IComparable<Dado>
{
    NoLista<Dado> primeiro, ultimo, anterior, atual;
    int quantosNos;
    bool primeiroAcessoDoPercurso;

    public ListaSimples()
    {
        primeiro = ultimo = anterior = atual = null;
        quantosNos = 0;
        primeiroAcessoDoPercurso = false;
    }

    public void PercorrerLista()
    {
        atual = primeiro;
        while (atual != null)
        {
            Console.WriteLine(atual.Info);
            atual = atual.Prox;
        }
    }
    public NoLista<Dado> Atual
    {
        get => atual;
        set => atual = value;
    }
    public bool EstaVazia
    {
        get => primeiro == null;
    }
    public NoLista<Dado> Primeiro
    {
        get => primeiro;
    }
    public NoLista<Dado> Ultimo
    {
        get => ultimo;
    }
    public int QuantosNos
    {
        get => quantosNos;
    }

    int IRegistro.TamanhoRegistro => throw new NotImplementedException();

    public void InserirAntesDoInicio(Dado novoDado)
    {
        var novoNo = new NoLista<Dado>(novoDado);

        if (EstaVazia)
            ultimo = novoNo;

        novoNo.Prox = primeiro;
        primeiro = novoNo;
        quantosNos++;
    }

    public void InserirAposFim(Dado novoDado)
    {
        var novoNo = new NoLista<Dado>(novoDado);

        if (EstaVazia)
            primeiro = novoNo;
        else
            ultimo.Prox = novoNo;

        ultimo = novoNo;
        quantosNos++;
    }

    public void Listar(ListBox lsb)
    {
        lsb.Items.Clear();
        atual = primeiro;
        while (atual != null)
        {
            lsb.Items.Add(atual.Info);
            atual = atual.Prox;
        }
    }

    

    public List<Dado> ObterListaCompleta()
    {
        var listaRetorno = new List<Dado>();

        atual = primeiro;
        while (atual != null)
        {
            listaRetorno.Add(atual.Info);
            atual = atual.Prox;
        }

        return listaRetorno;
    }

    public bool Buscar(Dado dadoProcurado)
    {
        atual = primeiro;
        while (atual != null)
        {
            if (atual.Info.CompareTo(dadoProcurado) == 0)
            {
                return true; // Elemento encontrado e "atual" já aponta para ele
            }
            atual = atual.Prox; // Avança para o próximo nó
        }
        return false; // Elemento não encontrado, "atual" será null
    }


    public bool Excluir(Dado aExcluir)
    {
        if (EstaVazia) return false; // Lista vazia, nada para excluir

        // Caso especial: o elemento a excluir está no primeiro nó
        if (primeiro.Info.CompareTo(aExcluir) == 0)
        {
            primeiro = primeiro.Prox; // Avança para o próximo nó
            if (primeiro == null)
                ultimo = null; // Lista ficou vazia
            quantosNos--;
            return true;
        }

        // Percorre a lista para encontrar o nó a excluir
        anterior = primeiro;
        atual = primeiro.Prox;

        while (atual != null)
        {
            if (atual.Info.CompareTo(aExcluir) == 0)
            {
                anterior.Prox = atual.Prox; // Ajusta o ponteiro do nó anterior
                if (atual == ultimo)
                    ultimo = anterior; // Ajusta o ponteiro do último nó se necessário
                quantosNos--;
                return true;
            }

            anterior = atual; // Avança o ponteiro anterior
            atual = atual.Prox; // Avança o ponteiro atual
        }

        return false; // Elemento não encontrado
    }


    //Apenas para não aparecer erro, pois o "Dado" deve implementar IRegistro e IComparable
    //na árvore a lista é tratada como um dado
    void IRegistro.LerRegistro(BinaryReader arquivo, long qualRegistro)
    {
        throw new NotImplementedException();
    }

    void IRegistro.GravarRegistro(BinaryWriter arquivo)
    {
        throw new NotImplementedException();
    }

}
