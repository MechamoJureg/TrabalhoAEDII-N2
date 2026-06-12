using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoAEDII_N2
{
    // Implementação de uma lista duplamente encadeada genérica.
    // Cada nó possui referência para o próximo e para o anterior.
    public class ListaDupla<T> // O <T> Permite a classe funcionar em qualquer tipo de dado, substituindo o tipo <t> por qualquer tipo que chame a lista
    {
        // Primeiro nó da lista. 
        private No<T> inicio;

        // Último nó da lista.
        private No<T> fim;


        // Quantidade atual de elementos armazenados.
        private int quantidade;


        // Inicializa uma lista vazia.
        public ListaDupla()
        {
            inicio = null!;
            fim = null!;
            quantidade = 0;
        }

        // Retorna a quantidade de elementos presentes na lista.
        public int Quantidade()
        {
            return quantidade;
        }

        // Insere um novo elemento no final da lista.
        public void Adicionar(T valor)
        {
            // Cria um novo nó para armazenar o valor informado.
            No<T> novo = new No<T>(valor);

            // Caso a lista esteja vazia,
            // o novo nó será o primeiro e o último.
            if (inicio == null)
            {
                inicio = novo;
                fim = novo;
            }

            // Liga o novo nó ao final da lista
            // e atualiza a referência do último elemento.
            else
            {
                novo.Ante = fim;
                fim.Prox = novo;
                fim = novo;
            }
            // Atualiza a quantidade de elementos da lista.
            quantidade++;
        }
        
        // Retorna o elemento armazenado na posição informada.
        public T Obter(int indice)
        {

            // Verifica se o índice informado está dentro
            // dos limites válidos da lista.
            if (indice < 0 || indice >= quantidade)
            {
                throw new Exception("Índice Inválido");
            }
            
            // Inicia a busca a partir do primeiro nó.
            No<T> atual = inicio;
            int i = 0;

            // Percorre a lista até alcançar
            // a posição solicitada.
            for (i = 0; i < indice; i++)
            {
                atual = atual.Prox;
            }
            // Retorna o valor armazenado no nó encontrado.
            return atual.Valor;
        }

    }
}
