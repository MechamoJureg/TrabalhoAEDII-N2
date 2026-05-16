using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoAEDII_N2
{
    public class No<T> // O <T> Permite a classe funcionar em qualquer tipo de dado, substituindo o tipo <t> por qualquer tipo que chame a lista
    {
        public T Valor;
        public No<T> Prox;
        public No<T> Ante;


        public No(T valor)
        {
            Valor = valor;
            Prox = null;
            Ante=null;
        }

    }
}
