using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoAEDII_N2
{
    class Disciplina
    {
        private long Cod_Disciplina;
        private string Nome_Disciplina;
        private float Nota_Minima;

        public Disciplina(long coddisc, string nomedisc, float notamin)
        {
            Cod_Disciplina = coddisc;
            Nome_Disciplina = nomedisc;
            Nota_Minima = notamin;
        }
        public long Get_CodDisciplina()

        {
            return Cod_Disciplina;
        }
        public void Set_CodDisciplina(int coddisc)
        {
            Cod_Disciplina = coddisc;
        }
        public string Get_NomeDisciplina()
        {
            return Nome_Disciplina;
        }
        public void Set_NomeDisciplina(string nomedisc)
        {
            Nome_Disciplina = nomedisc;
        }
        public float Get_NotaMinima()
        {
            return Nota_Minima;
        }
        public void Set_NotaMinima(float notamin)
        {
            Nota_Minima = notamin;
        }
    }
}
