using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoAEDII_N2
{
    internal class Aluno
    {
        private long _Matricula;
        private string _Nome;
        private int _Idade;

        public Aluno(long matricula, string nome, int idade)
        {
            _Matricula = matricula;
            _Nome = nome;
            _Idade = idade;
        }

        public long get_Matricula()

        {
            return _Matricula;
        }
        public void set_Matricula(int mat)
        {
            _Matricula = mat;
        }
        public string get_Nome()
        {
            return _Nome;
        }
        public void set_Nome(string nome)

        {
            _Nome = nome;
        }
        public int get_Idade()
        {
            return _Idade;
        }
        public void set_Idade(int idade)
        {
            _Idade = idade;
        }
    }
}
