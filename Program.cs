using TrabalhoAEDII_N2;
using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

class Program
{

    static void Main(string[] args)
    {
        // Estruturas principais do sistema.
        // Armazenam os alunos, disciplinas e matrículas.
        ListaDupla<Aluno> alunos = new ListaDupla<Aluno>();
        ListaDupla<Disciplina> disciplinas = new ListaDupla<Disciplina>();
        ListaDupla<Matricula> matriculas = new ListaDupla<Matricula>();

        // Inicializa os arquivos do sistema e carrega os dados
        // persistidos em disco para as listas em memória.
        Arquivo arquivo = new Arquivo();
        arquivo.CriacaodeArquivos();
        arquivo.LerArquivos(alunos, disciplinas, matriculas);
        Console.WriteLine("Alunos carregados: " + alunos.Quantidade());


        int option = 0;

        // Menu principal do sistema.
        Console.WriteLine("                       MENU                          ");
        Console.WriteLine("_____________________________________________________");
        Console.WriteLine("|                                                   |");
        Console.WriteLine("|         Consulta e Cadastro de Matriculas         |");
        Console.WriteLine("|                                                   |");


        
        // Loop principal do sistema.
        // Permanece em execução até o usuário escolher a opção Sair.
        while (option != 4)
        {
            Console.WriteLine("1-Consultas");
            Console.WriteLine("2-Cadastro");
            Console.WriteLine("3-Salvar");
            Console.WriteLine("4-Sair");

            string a = Console.ReadLine()!;
            int.TryParse(a, out option);

            switch (option)
            {
                // Consultas disponíveis para o usuário.
                case 1:
                    Console.WriteLine("Escolha uma das opções abaixo");
                    Console.WriteLine("1 - Alunos");
                    Console.WriteLine("2 - Disciplinas");
                    Console.WriteLine("3 - Alunos da Disciplina");
                    Console.WriteLine("4 - Disciplinas do Aluno");
                    int opConsulta = int.Parse(Console.ReadLine()!);

                    switch (opConsulta)
                    {
                        
                        //Alunos
                        case 1:

                            Arquivo.ListarAlunos(alunos);

                            break;

                        
                            //Disciplinas
                        case 2:

                            for (int i = 0; i < disciplinas.Quantidade(); i++)
                            {
                                Console.WriteLine(disciplinas.Obter(i).Get_CodDisciplina() + " | " +
                                                  disciplinas.Obter(i).Get_NomeDisciplina() + " | " +
                                                  disciplinas.Obter(i).Get_NotaMinima());
                            }

                            break;
                        
                            //Alunos da Disciplinas
                        case 3:
                            
                            Console.WriteLine("Disciplinas disponíveis:");
                            for (int i = 0; i < disciplinas.Quantidade(); i++)
                            {
                                Console.WriteLine(disciplinas.Obter(i).Get_CodDisciplina() + " - " +
                                                  disciplinas.Obter(i).Get_NomeDisciplina());
                            }

                            Console.WriteLine("Digite o código da disciplina");
                            int code = int.Parse(Console.ReadLine()!);

                            bool achouAluno = false;

                            // Procura todas as matrículas vinculadas à disciplina informada.
                            // Em seguida localiza os alunos correspondentes e exibe seus nomes.
                            for (int i = 0; i < matriculas.Quantidade(); i++)
                            {
                                if (matriculas.Obter(i).Get_CodDisciplina() == code)
                                {
                                    long matAluno = matriculas.Obter(i).Get_Matricula_Aluno();
                                    
                                    // Busca o aluno na lista através da matrícula encontrada.
                                    for (int j = 0; j < alunos.Quantidade(); j++)
                                    {
                                        if (alunos.Obter(j).get_Matricula() == matAluno)
                                        {
                                            Console.WriteLine(alunos.Obter(j).get_Nome());
                                            achouAluno = true;
                                        }
                                    }
                                }
                            }

                            if (!achouAluno)
                            {
                                Console.WriteLine("Nenhum aluno matriculado nessa disciplina.");
                            }

                            break;

                        //disciplina do aluno
                        case 4:

                            Console.WriteLine("Digite o código do aluno");
                            string b = Console.ReadLine()!;
                            long.TryParse(b, out long matriculaAluno);

                            string nomeAluno = "Não encontrado";

                            // Recupera o nome do aluno a partir da matrícula informada.
                            for (int i = 0; i < alunos.Quantidade(); i++)
                            {
                                if (alunos.Obter(i).get_Matricula() == matriculaAluno)
                                {
                                    nomeAluno = alunos.Obter(i).get_Nome();
                                    break;
                                }
                            }

                            // Localiza todas as disciplinas em que o aluno está matriculado.
                            for (int i = 0; i < matriculas.Quantidade(); i++)
                            {
                                if (matriculas.Obter(i).Get_Matricula_Aluno() == matriculaAluno)
                                {
                                    long codDisc = matriculas.Obter(i).Get_CodDisciplina();

                                    for (int j = 0; j < disciplinas.Quantidade(); j++)
                                    {
                                        if (disciplinas.Obter(j).Get_CodDisciplina() == codDisc)
                                        {
                                            string nomeD = disciplinas.Obter(j).Get_NomeDisciplina();
                                            float nmin = disciplinas.Obter(j).Get_NotaMinima();

                                            float n1 = matriculas.Obter(i).Get_Nota1();
                                            float n2 = matriculas.Obter(i).Get_Nota2();

                                            // Calcula a situação do aluno na disciplina
                                            // comparando sua média com a nota mínima exigida.
                                            float media = matriculas.Obter(i).Calculo_Media();

                                            string status = media >= nmin ? "Aprovado" : "Reprovado";

                                            Console.WriteLine(nomeAluno + ";" + nomeD + ";" + media + ";" + status);
                                        }
                                    }

                                }
                            }
                            break;

                    }
                    break;

                // Funcionalidades de cadastro e atualização de dados.
                case 2:
                    Console.WriteLine("Escolha uma das opções abaixo");
                    Console.WriteLine("1-Cadastrar Aluno");
                    Console.WriteLine("2-Cadastrar Disciplina");
                    Console.WriteLine("3-Cadastrar Matriculas");
                    Console.WriteLine("4-Atribuir nota ao aluno");
                    int resp = int.Parse(Console.ReadLine()!);

                    switch (resp)
                    {
                        case 1:

                            Console.WriteLine("Digite o nome completo do Aluno");
                            string name = Console.ReadLine()!;
                            Console.WriteLine("Digite a idade do aluno");
                            int idade = int.Parse(Console.ReadLine()!);

                            // Validação de idade conforme regra de negócio do sistema.
                            if (idade < 18 || idade>100)
                            {
                                Console.WriteLine("Este aluno não pode ser cadastrado");
                                Console.WriteLine("Idade Inválida");
                            }
                            else
                            {
                                // Gera uma matrícula única para evitar duplicidade de alunos.
                                long matricula = Arquivo.GerarMatriculaUnica(alunos);
                                alunos.Adicionar(new Aluno(matricula, name, idade)); ;

                                Console.WriteLine("Aluno cadastrado com sucesso!!");
                                Console.WriteLine(matricula + ";" + name + ";" + idade);
                                arquivo.SalvarTudo(alunos, disciplinas, matriculas);

                            }
                            break;
                        case 2:

                            Console.WriteLine("Digite o nome da disciplina");
                            string nameD = Console.ReadLine()!;
                            Console.WriteLine("Digite a nota mínima da disciplina");
                            float.TryParse(Console.ReadLine(), out float notamin);

                            // Gera automaticamente um código único para a disciplina.
                            long codigoindex = Arquivo.GerarCodigo(disciplinas);

                            disciplinas.Adicionar(new Disciplina(codigoindex, nameD, notamin));
                            Console.WriteLine("Disciplina criada com sucesso");
                            arquivo.SalvarTudo(alunos, disciplinas, matriculas);
                            Console.WriteLine($"{codigoindex};{nameD};{notamin}");
                            Console.WriteLine($"quantidade de disciplinas:{disciplinas.Quantidade()} ");



                            break;
                        case 3:
                            long matriculaAluno = -1;

                            // Permite localizar o aluno pelo nome ou pela matrícula.
                            int resposta = 0;
                            Console.WriteLine("Selecione uma das opções abaixo");
                            Console.WriteLine("1-Inserir o nome do aluno  2-Inserir o código do aluno");
                            int.TryParse(Console.ReadLine(), out resposta);

                            if (resposta == 1)
                            {
                                Console.WriteLine("Alunos cadastrados:");
                                for (int i = 0; i < alunos.Quantidade(); i++)
                                {
                                    Console.WriteLine(alunos.Obter(i).get_Matricula() + " - " +
                                                      alunos.Obter(i).get_Nome());
                                }
                                Console.WriteLine("Insira o nome do aluno");
                                string nomeBusca = Console.ReadLine()!;

                                int count = 0;
                                for (int i = 0; i < alunos.Quantidade(); i++)
                                {
                                    if (alunos.Obter(i).get_Nome().Equals(nomeBusca, StringComparison.OrdinalIgnoreCase))
                                    {
                                        matriculaAluno = alunos.Obter(i).get_Matricula();
                                        count++;
                                    }
                                }
                                if (count > 1)
                                {
                                    Console.WriteLine("Mais de um aluno encontrado com esse nome. Use o código.");
                                    matriculaAluno = -1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Alunos cadastrados:");
                                for (int i = 0; i < alunos.Quantidade(); i++)
                                {
                                    Console.WriteLine(alunos.Obter(i).get_Matricula() + " - " +
                                                      alunos.Obter(i).get_Nome());
                                }

                                Console.WriteLine("Digite o código do aluno");
                                matriculaAluno = long.Parse(Console.ReadLine()!);
                            }
                            long codDisciplina = -1;

                            if (resposta == 1)
                            {
                                Console.WriteLine("Disciplinas disponíveis:");
                                for (int i = 0; i < disciplinas.Quantidade(); i++)
                                {
                                    Console.WriteLine(disciplinas.Obter(i).Get_CodDisciplina() + " - " +
                                                      disciplinas.Obter(i).Get_NomeDisciplina());
                                }
                                Console.WriteLine("Insira o nome da matéria");
                                string nomeDisc = Console.ReadLine()!;

                                for (int i = 0; i < disciplinas.Quantidade(); i++)
                                {

                                    if (disciplinas.Obter(i).Get_NomeDisciplina().Equals(nomeDisc, StringComparison.OrdinalIgnoreCase))
                                    {
                                        codDisciplina = disciplinas.Obter(i).Get_CodDisciplina();

                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Insira o código da matéria");
                                codDisciplina = int.Parse(Console.ReadLine()!);
                            }

                            // Verifica se o aluno e a disciplina foram encontrados
                            // antes de realizar a matrícula.
                            if (matriculaAluno == -1 || codDisciplina == -1)
                            {
                                Console.WriteLine("Aluno ou disciplina não encontrado!");
                                break;
                            }
                            else
                            {
                                //Verifica se já existe antes de cadastrar
                                bool jaExiste = false;
                                for (int i = 0; i < matriculas.Quantidade(); i++)
                                {
                                    if (matriculas.Obter(i).Get_Matricula_Aluno() == matriculaAluno &&
                                        matriculas.Obter(i).Get_CodDisciplina() == codDisciplina)
                                    {
                                        jaExiste = true;
                                        break;
                                    }
                                }

                                if (jaExiste)
                                {
                                    Console.WriteLine("Este aluno já está matriculado nessa disciplina!");
                                }
                                else
                                {
                                    matriculas.Adicionar(new Matricula(matriculaAluno, codDisciplina, 0, 0));
                                    Console.WriteLine("Matrícula realizada com sucesso!");
                                    arquivo.SalvarTudo(alunos, disciplinas, matriculas);
                                }
                            }
                            break;
                        

                        case 4:

                            matriculaAluno = -1;

                            Console.WriteLine("Insira uma das opções abaixo");
                            Console.Write("1-Inserir nome do aluno"); Console.WriteLine(" 2- inserir código do aluno");
                            int resp1 = int.Parse(Console.ReadLine()!);

                            if (resp1 == 1)
                            {
                                Console.WriteLine("Insira o nome do aluno");
                                string Buscarnome = Console.ReadLine()!;

                                int count = 0;
                                for (int i = 0; i < alunos.Quantidade(); i++)
                                {
                                    if (alunos.Obter(i).get_Nome().Equals(Buscarnome, StringComparison.OrdinalIgnoreCase))
                                    {
                                        matriculaAluno = alunos.Obter(i).get_Matricula();
                                        count++;
                                    }
                                }
                                if (count > 1)
                                {
                                    Console.WriteLine("Mais de um aluno encontrado com esse nome. Use o código.");
                                    matriculaAluno = -1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Insira o código do aluno");
                                matriculaAluno = long.Parse(Console.ReadLine()!);
                            }
                            Console.WriteLine("Insira uma das opções abaixo");
                            Console.Write("1-Inserir nome da Disciplina"); Console.WriteLine(" 2- inserir código da Disciplina");
                            int resp2 = int.Parse(Console.ReadLine()!);
                            codDisciplina = -1;
                            if (resp2 == 1)
                            {
                                Console.WriteLine("Insira o nome da disciplina");
                                string buscarDisc = Console.ReadLine()!;

                                for (int j = 0; j < disciplinas.Quantidade(); j++)
                                {
                                    if (disciplinas.Obter(j).Get_NomeDisciplina().Equals(buscarDisc, StringComparison.OrdinalIgnoreCase))
                                    {
                                        codDisciplina = disciplinas.Obter(j).Get_CodDisciplina();
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Insira o código da disciplina");
                                codDisciplina = long.Parse(Console.ReadLine()!);

                            }
                            if (matriculaAluno == -1 || codDisciplina == -1)
                            {
                                Console.WriteLine("Aluno ou disciplina não encontrado!");
                                break;
                            }
                            else
                            {
                                bool encontrou = false;

                                for (int i = 0; i < matriculas.Quantidade(); i++)
                                {
                                    if (matriculas.Obter(i).Get_Matricula_Aluno() == matriculaAluno &&
                                        matriculas.Obter(i).Get_CodDisciplina() == codDisciplina)
                                    {
                                        Console.WriteLine("Digite a nota 1:");
                                        float n1 = float.Parse(Console.ReadLine()!);

                                        Console.WriteLine("Digite a nota 2:");
                                        float n2 = float.Parse(Console.ReadLine()!);
                                        
                                        
                                        //Verificação para que não registre notas menores que 0 ou maiores que 10
                                        if (n1 < 0 || n1 > 10 || n2 < 0 || n2 > 10)
                                        {
                                            Console.WriteLine("Nota inválida! As notas devem estar entre 0 e 10.");
                                            break;
                                        }
                                        //

                                        matriculas.Obter(i).Set_Nota1(n1);
                                        matriculas.Obter(i).Set_Nota2(n2);

                                        Console.WriteLine("Notas atribuídas com sucesso!");
                                        arquivo.SalvarTudo(alunos, disciplinas, matriculas);
                                        encontrou = true;
                                        break;
                                    }
                                }
                                if (!encontrou)
                                {
                                    Console.WriteLine("Matrícula não encontrada!");
                                }

                            }

                            break;
                    }
                    break;

                
                //Salva as Alterações.
                case 3:
                    arquivo.SalvarTudo(alunos, disciplinas, matriculas);
                    break;

                //Termina a execução do Programa.
                case 4:
                    Console.WriteLine("Volte sempre");
                    arquivo.SalvarTudo(alunos, disciplinas, matriculas);
                    break;
            }
        }

    }
}


