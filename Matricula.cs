using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoAEDII_N2
{
    // Representa o vínculo entre um aluno e uma disciplina,
    // armazenando também as notas obtidas.
    class Matricula
    {
        private long _Matricula_Aluno;
        private long _CodDisciplina;
        private float _Nota1;
        private float _Nota2;

        public Matricula(long matricula_Aluno, long codDisciplina, float nota1, float nota2)
        {
            _Matricula_Aluno = matricula_Aluno;
            _CodDisciplina = codDisciplina;
            _Nota1 = nota1;
            _Nota2 = nota2;
        }
        public long Get_Matricula_Aluno()

        {
            return _Matricula_Aluno;
        }
        public void Set_Matricula_Aluno(int matricula)
        {
            _Matricula_Aluno = matricula;
        }
        public long Get_CodDisciplina()

        {
            return _CodDisciplina;
        }
        public void Set_CodDisciplina(int coddisc)
        {
            _CodDisciplina = coddisc;
        }
        public float Get_Nota1()
        {
            return _Nota1;
        }
        public void Set_Nota1(float nota)
        {
            _Nota1 = nota;
        }
        public float Get_Nota2()
        {
            return _Nota2;
        }
        public void Set_Nota2(float nota)
        {
            _Nota2 = nota;
        }

        // Calcula a média final do aluno na disciplina.
        public float Calculo_Media()
        {
            return (_Nota1 + _Nota2) / 2;
        }
    }
}
