using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoAEDII_N2
{
    // Representa um aluno cadastrado no sistema.
    internal class Aluno
    {
        // Matrícula única do aluno.
        private long _Matricula;
        
        // Nome completo do aluno.
        private string _Nome;

        // Idade do aluno.
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
