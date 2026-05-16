using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TrabalhoAEDII_N2
{
    class Arquivo
    {
        public void CriacaodeArquivos()
        {
            if (!Directory.Exists("Dados"))
            {
                Directory.CreateDirectory("Dados");
                if (Directory.Exists("Dados"))
                {
                    Console.WriteLine("Diretório Criado");
                }
            }
            if (!File.Exists("Dados/Alunos.dat"))                                //CRIAÇÃO DOS ARQUIVOS DE REGISTRO
            {
                File.Create("Dados/Alunos.dat").Close();
                if (File.Exists("Dados/Alunos.dat"))
                {
                    Console.WriteLine("Arquivo Alunos.dat criado");
                }
            }
            if (!File.Exists("Dados/Disciplinas.dat"))
            {
                File.Create("Dados/Disciplinas.dat").Close();
                if (File.Exists("Dados/Disciplinas.dat"))
                {
                    Console.WriteLine("Arquivo Disciplinas.dat criado");
                }
            }
            if (!File.Exists("Dados/Matriculas.dat"))
            {
                File.Create("Dados/Matriculas.dat").Close();
                if (File.Exists("Dados/Matriculas.dat"))
                {
                    Console.WriteLine("Arquivo Matriculas.dat criado");
                }
            }
        }

        public void LerAlunos(ListaDupla<Aluno> alunos)
        {
            string[] linhas = File.ReadAllLines("Dados/Alunos.dat");

            for (int i = 0; i < linhas.Length; i++)
            {
                if (linhas[i] == "") continue;

                string[] dados = linhas[i].Split(';');

                if (dados.Length < 3) continue;

                long.TryParse(dados[0], out long matricula);
                string nome = dados[1];
                int.TryParse(dados[2], out int idade);

                alunos.Adicionar(new Aluno(matricula, nome, idade));
            }
        }
        public void LerDisciplina(ListaDupla<Disciplina> disciplinas)
        {
            string[] linhas = File.ReadAllLines("Dados/Disciplinas.dat");
            int i = 0;
            for (i = 0; i < linhas.Length; i++)
            {
                if (linhas[i] == "") continue;
                string[] dados = linhas[i].Split(";");
                if (dados.Length < 3) continue;
                int.TryParse(dados[0], out int CodDisc);
                string Nome = dados[1];
                float.TryParse(dados[2], out float NotaMin);
                disciplinas.Adicionar(new Disciplina(CodDisc, Nome, NotaMin));
                Console.WriteLine(dados[0] + " | " + dados[1] + " | " + dados[2]);

            }
        }
        public void LerMatricula(ListaDupla<Matricula> matriculas)
        {
            string[] linhas = File.ReadAllLines("Dados/Matriculas.dat");
            int i = 0;
            for (i = 0; i < linhas.Length; i++)
            {
                if (linhas[i] == "") continue;
                string[] dados = linhas[i].Split(";");
                if (dados.Length < 4) continue;
                int.TryParse(dados[0], out int matricula);
                int.TryParse(dados[1], out int CodDisciplina);
                float.TryParse(dados[2], out float Nota1);
                float.TryParse(dados[3], out float Nota2);
                matriculas.Adicionar(new Matricula(matricula, CodDisciplina, Nota1, Nota2));
                Console.WriteLine(dados[0] + " | " + dados[1] + " | " + dados[2]);

            }
        }


        public void LerArquivos(ListaDupla<Aluno> alunos, ListaDupla<Disciplina> disciplinas, ListaDupla<Matricula> matriculas)
        {
            LerAlunos(alunos);
            LerDisciplina(disciplinas);              //Leitura de todos os arquivos e preenchimento dos vetores
            LerMatricula(matriculas);
        }

        public static void ListarAlunos(ListaDupla<Aluno> alunos)
        {
            for (int i = 0; i < alunos.Quantidade(); i++)
            {
                Console.WriteLine("Matricula: " + alunos.Obter(i).get_Matricula());
                Console.WriteLine("Nome: " + alunos.Obter(i).get_Nome());
                Console.WriteLine("Idade: " + alunos.Obter(i).get_Idade());
                Console.WriteLine("-------------------");
            }
        }
        public static int GerarMatriculaUnica(ListaDupla<Aluno> alunos)
        {
            Random rnd = new Random();
            int matricula;
            bool existe;

            do
            {
                matricula = rnd.Next(100000000, 999999999);

                existe = false;

                for (int i = 0; i < alunos.Quantidade(); i++)
                {
                    if (alunos.Obter(i).get_Matricula() == matricula)
                    {
                        existe = true;
                        break;
                    }
                }

            } while (existe);

            return matricula;
        }
        public static int GerarCodigo(ListaDupla<Disciplina> disciplinas)
        {
            Random rnd = new Random();
            int codigo;
            bool existe;

            do
            {
                codigo = rnd.Next(1000, 9999);
                existe = false;

                for (int i = 0; i < disciplinas.Quantidade(); i++)
                {
                    if (disciplinas.Obter(i).Get_CodDisciplina() == codigo)
                    {
                        existe = true;
                        break;
                    }
                }

            } while (existe);

            return codigo;
        }
        public void SalvarAlunos(ListaDupla<Aluno> alunos)
        {
            string[] linhas = new string[alunos.Quantidade()];

            for (int i = 0; i < alunos.Quantidade(); i++)
            {
                linhas[i] =
                    alunos.Obter(i).get_Matricula() + ";" +
                    alunos.Obter(i).get_Nome() + ";" +
                    alunos.Obter(i).get_Idade();
            }

            File.WriteAllLines("Dados/Alunos.dat", linhas);
        }
        public void SalvarDisciplinas(ListaDupla<Disciplina> disciplinas)
        {
            string[] linhas = new string[disciplinas.Quantidade()];

            for (int i = 0; i < disciplinas.Quantidade(); i++)
            {
                linhas[i] = disciplinas.Obter(i).Get_CodDisciplina() + ";" +
                            disciplinas.Obter(i).Get_NomeDisciplina() + ";" +
                            disciplinas.Obter(i).Get_NotaMinima();
            }

            File.WriteAllLines("Dados/Disciplinas.dat", linhas);

        }
        public void SalvarMatriculas(ListaDupla<Matricula> matriculas)
        {
            string[] linhas = new string[matriculas.Quantidade()];

            for (int i = 0; i < matriculas.Quantidade(); i++)
            {
                linhas[i] = matriculas.Obter(i).Get_Matricula_Aluno() + ";" +
                            matriculas.Obter(i).Get_CodDisciplina() + ";" +
                            matriculas.Obter(i).Get_Nota1() + ";" +
                            matriculas.Obter(i).Get_Nota2();

            }

            File.WriteAllLines("Dados/Matriculas.dat", linhas);
        }


        public void SalvarTudo(ListaDupla<Aluno> alunos,
                      ListaDupla<Disciplina> disciplinas,
                      ListaDupla<Matricula> matriculas)
        {
            SalvarAlunos(alunos);
            SalvarDisciplinas(disciplinas);
            SalvarMatriculas(matriculas);

            Console.WriteLine("Dados salvos com sucesso!");
        }
    }
}
