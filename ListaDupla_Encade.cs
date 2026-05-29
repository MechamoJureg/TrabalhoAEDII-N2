using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoAEDII_N2
{
    public class ListaDupla<T>
    {
        private No<T> inicio;
        private No<T> fim;
        private int quantidade;

        public ListaDupla()
        {
            inicio = null;
            fim = null;
            quantidade = 0;
        }
        public int Quantidade()
        {
            return quantidade;
        }


        public void Adicionar(T valor)
        {
            No<T> novo = new No<T>(valor);
            if (inicio == null)
            {
                inicio = novo;
                fim = novo;
            }
            else
            {
                novo.Ante = fim;
                fim.Prox = novo;
                fim = novo;
            }
            quantidade++;
        }

        public T Obter(int indice)
        {
            if (indice < 0 || indice >= quantidade)
            {
                throw new Exception("Índice Inválido");
            }

            No<T> atual = inicio;
            int i = 0;
            for (i = 0; i < indice; i++)
            {
                atual = atual.Prox;
            }
            return atual.Valor;
        }

    }
}
