namespace TrabalhoAEDII_N2
{
    // Representa um nó da lista duplamente encadeada.
    // Armazena um valor e referências para o próximo
    // e para o nó anterior da lista.
    public class No<T> // O <T> permite utilizar qualquer tipo de dado.
    {
        // Valor armazenado no nó.
        public T Valor;

        // Referência para o próximo nó da lista.
        public No<T> Prox;

        // Referência para o nó anterior da lista.
        public No<T> Ante;

        // Construtor responsável por criar um nó
        // e inicializar suas referências.
        public No(T valor)
        {
            Valor = valor;

            // Como o nó acaba de ser criado,
            // inicialmente não possui ligações.
            Prox = null!;
            Ante = null!;
        }
    }
}