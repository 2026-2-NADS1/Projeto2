using System.Diagnostics;
using System.Net;
using Spectre.Console;

Console.OutputEncoding = System.Text.Encoding.UTF8;


// ===================== BANCO DE QUESTÕES =====================
string[] faixasEtarias = {
    "Até 12 anos", "13 a 17 anos", "18 a 24 anos",
    "25 a 39 anos", "40 anos ou mais", "Prefiro não informar"
};

string[] enunciados = {
    "Qual personagem mais icônica e carismática da arcor?",
    "Qual marca tem o slogan 'grande no tamanho, gigante no sabor'?",
    "Marca mais procurada para fazer collabs.",
    "Qual animal é caracterizado como a tortuguita?",
    "Famosa linha de guloseimas da Arcor, conhecida por seus sabores intensos e ácidos?",
    "Marca de bala de mel da arcor.",
    "Sabor bonobon considerado gentilmente como rafaello do pobre:",
    "Qual nome da linha da marca block para a campanha da copa do mundo no brasil?",
    "Qual nome da marca arcor faz alusão ao som de estouro ou explosão?",
    "Qual marca da arcor tem como seu principal igrediente amendoim?",
    "Marca conhecida entre o publico jovem por ser multissensorialidade.",
    "Assinale a alternativa que satisfaz a sequência:\nI. Tem um sabor gentilmente apelidado de rafaello do pobre;\nII. Tablete de chocolate;\nIII. Multissensorialidade: textura, surpresa e interação.",
    "Qual marca da arcor ganhou o prêmio grandes cases de embalagem?",
    "Marca da arcor que esteve muitos anos com parceria com o meio ambiente, por meio de seu apoio de longa data ao projeto tamar.",
    "Assinale a alternativa que satisfaz a sequência:\nI. Versão de 1k da Block para campanha da copa do mundo;\nII. Conhecida por seus sabores intensos, ácidos e experiências sensoriais diferentes;\nIII. Tem um personagem mais icônico e carismático da Arcor;\nIV. Sabor do tablete de chocolate da linha Block mais procurado da américa latina."
};

string[] niveis = { "F", "M", "M", "F", "D", "F", "M", "M", "F", "D", "D", "F", "D", "M", "D" };

string[] dicas = {
    "Parece uma tartaruga.",
    "Marca que teve campanha para copa do mundo 2026.",
    "Nome da marca vem do baralho italiano.",
    "Animal marítimo.",
    "Plutão já foi planeta?",
    "Como é “mel” em espanhol?",
    "Muuah",
    "Brasil já é Hexa?",
    "Tem uma casquinha crocante por fora e recheio líquido ou cremoso por dentro.",
    "Muito amor envolvido.",
    "Essa marca tem muitos conteúdos espontâneos no TikTok.",
    "BonoBon sabor Beijinho foi apelidado como Rafaello do Pobre",
    "Primeira marca de caramelos no Brasil a adotar o sistema de ziplock (fecho com zíper e selagem).",
    "Envolve um personagem muito carismático.",
    "Emirados Arabes."
};

string[,] alternativas = {
    { "Tortuguita", "Simpsons", "Magali", "Patrulha Canina" },
    { "Rocklets", "BigChokko", "Block", "Garoto" },
    { "7Belo", "Tortuguita", "Block", "Poosh" },
    { "Leão ", "Tamanduá", "Tartaruga", "Jabuti"},
    { "TNT", "Plutonita", "Trident X-Gamers", "7Belo"},
    { "Aerado", "7Belo", "Butter Toffees", "Honey Miel"},
    { "Phael", "Beijinho", "Prestígio", "Coco Queimado"},
    { "Block Hexagerado", "Block Brasileirado", "Block Blocazo", "Block Apaixonado"},
    { "Plutonita", "Poosh", "TopLine", "Rocklets"},
    { "7Belo", "Cereal Mix", "Amor sing's", "Turrón"},
    { "Poosh", "Plutonita", "Honey Miel", "Mogul360"},
    { "Bonobon, Block e Mogul360.", "Bonobon, Tortuguita e 7Belo.", "Tortuguita, Rocklets e Flics.", "BigBig, Poosh e Danix."},
    {"BigBig", "TopLine", "Butter toffees", "Embaré"},
    {"AMOR sing's", "Tortuguita", "Passion", "Aymoré"},
    {"Blocazo, BigBig, Tortuguita e Block Xangai Style.", "Triunfo, Mogul360, Honey Miel e Chokko.", "Block Hexagerado, Plutonita, Tortuguita e Block Dubai Style.", "Nenhuma das opções acima."}
    
};

int[] corretas = { 0, 2, 0, 2, 1, 3, 1, 0, 1, 2, 3, 0, 2, 1, 2 };

// ===================== INÍCIO DO JOGO =====================
MostrarAbertura();
string nickname = LerNickname();
string faixa = LerFaixaEtaria(faixasEtarias);

/* PROVISÓRIO: apagar no início do Bloco 3
for (int i = 0; i < enunciados.Length; i++)
{
    string[] opcoes = ExtrairAlternativas(alternativas, i);
    string nivel = niveis[i];
    string pergunta = Markup.Escape(enunciados[i]);
    string respCorreta = Markup.Escape(opcoes[corretas[i]]);
    AnsiConsole.MarkupLine($"[green]{nivel}[/] {pergunta} -> {respCorreta}");
}*/

int totalQuestoes = enunciados.Length;
int[] questoesPorNivel = new int[3];
int[] acertosPorNivel = new int[3];
bool[] usouDica = new bool[totalQuestoes];
bool terminou = false;

Stopwatch cronometro = Stopwatch.StartNew();

for (int i = 0; i < totalQuestoes; i++)
{
    int segundos = (int)cronometro.Elapsed.TotalSeconds;
    int minutos = segundos / 60;
    int segs = segundos % 60;
    AnsiConsole.Write(new Rule($"Questão {i + 1} de {totalQuestoes} | Tempo: {minutos} min {segs} s"));

    string[] opcoes = ExtrairAlternativas(alternativas, i);
    int resultado = MostrarQuestao(enunciados[i], opcoes, corretas[i], dicas[i], usouDica, i);

    if (resultado == -1)
    {
        terminou = true;
        break;
    }

    int nivel = IndiceNivel(niveis[i]);
    questoesPorNivel[nivel]++;

    if (resultado == 1)
    {
        acertosPorNivel[nivel]++;
        AnsiConsole.MarkupLine("[green]Você acertou![/]");
    }
    else
    {
        AnsiConsole.MarkupLine("[red]Você errou.[/]"); //+ Markup.Escape(opcoes[corretas[i]])); tirei a alterntiva correta exibida no console para ficar mais desafiador caso o jogador queira fazer de novo o quiz
    }
}

cronometro.Stop();

// adicionei o relatorio mesmo se o jogador terminar a partida antes de acabar as perguntas
if (terminou)
{
    AnsiConsole.MarkupLine("[yellow]Quiz encerrado pelo jogador. Até a próxima![/]");
    int tempo = (int)cronometro.Elapsed.TotalSeconds;
    int dicasUsadas = ContarDicas(usouDica);
    MostrarRelatorio(nickname, faixa, questoesPorNivel, acertosPorNivel, dicasUsadas, tempo);
}
else
{
    int tempo = (int)cronometro.Elapsed.TotalSeconds;
    int dicasUsadas = ContarDicas(usouDica);
    MostrarRelatorio(nickname, faixa, questoesPorNivel, acertosPorNivel, dicasUsadas, tempo);
}

// ===================== FUNÇÕES =====================

static void MostrarAbertura()
{
    Console.Clear();
    AnsiConsole.Write(new FigletText("Desafio das Marcas").Color(Color.Green));
    AnsiConsole.MarkupLine("[yellow]Bem-vindo ao quiz da Arcor![/]");
    AnsiConsole.MarkupLine("Use as setas para escolher a resposta e tecle Enter.");
    AnsiConsole.MarkupLine("Cada dica usada custa 5 pontos. Escolha TERMINAR para sair a qualquer momento.");
    Console.WriteLine();
}

static string LerNickname()
{
    return AnsiConsole.Ask<string>("Digite seu [green]nickname[/]:");
}

static string LerFaixaEtaria(string[] faixas)
{
    SelectionPrompt<string> prompt = new SelectionPrompt<string>();
    prompt.Title("Escolha sua [green]faixa etária[/]:");
    prompt.AddChoices(faixas);
    return AnsiConsole.Prompt(prompt);
}

static string[] ExtrairAlternativas(string[,] alternativas, int linha)
{
    int quantidade = alternativas.GetLength(1);
    string[] opcoes = new string[quantidade];
    for (int j = 0; j < quantidade; j++)
    {
        opcoes[j] = alternativas[linha, j];
    }
    return opcoes;
}

static int MostrarQuestao(string enunciado, string[] opcoes, int correta, string dica, bool[] usouDica, int indice)
{
    SelectionPrompt<string> prompt = new SelectionPrompt<string>();
    prompt.Title(Markup.Escape(enunciado));
    prompt.AddChoices(opcoes);
    prompt.AddChoices("MOSTRAR DICA", "TERMINAR");

    string escolha = AnsiConsole.Prompt(prompt);

    while (escolha == "MOSTRAR DICA")
    {
        usouDica[indice] = true;
        AnsiConsole.Status().Start("Buscando a dica...", ctx =>
        {
            Thread.Sleep(1500);
        });
        AnsiConsole.MarkupLine("[yellow]Dica:[/] " + Markup.Escape(dica));
        escolha = AnsiConsole.Prompt(prompt);
    }

    if (escolha == "TERMINAR")
    {
        return -1;
    }
    if (escolha == opcoes[correta])
    {
        return 1;
    }
    return 0;
}

static int IndiceNivel(string nivel)
{
    if (nivel == "F")
    {
        return 0;
    }
    else if (nivel == "M")
    {
        return 1;
    }
    return 2;
}

static int ContarDicas(bool[] usouDica)
{
    int total = 0;
    for (int i = 0; i < usouDica.Length; i++)
    {
        if (usouDica[i])
        {
            total++;
        }
    }
    return total;
}

static double Percentual(int acertos, int questoes)
{
    return acertos * 100.0 / questoes;
}

static int CalcularPontuacao(int[] acertosPorNivel, int dicas)
{
    int[] pesos = { 10, 20, 30 };
    int pontos = 0;
    for (int n = 0; n < 3; n++)
    {
        pontos = pontos + acertosPorNivel[n] * pesos[n];
    }
    pontos = pontos - dicas * 5;
    if (pontos < 0)
    {
        pontos = 0;
    }
    return pontos;
}

static int CalcularPontuacaoMaxima(int[] questoesPorNivel)
{
    int[] pesos = { 10, 20, 30 };
    int maximo = 0;
    for (int n = 0; n < 3; n++)
    {
        maximo = maximo + questoesPorNivel[n] * pesos[n];
    }
    return maximo;
}

static string Classificar(double percentual)
{
    if (percentual >= 90)
    {
        return "Mestre das Marcas";
    }
    else if (percentual >= 70)
    {
        return "Conhecedor de Marcas";
    }
    else if (percentual >= 50)
    {
        return "Aprendiz";
    }
    return "Iniciante";
}

static string GerarBarra(int acertos)
{
    string barra = "";
    for (int i = 0; i < acertos; i++)
    {
        barra = barra + "*";
    }
    return barra;
}

static string DefinirRitmo(double mediaPorQuestao)
{
    if (mediaPorQuestao <= 10) 
    {
        return "Rápido";
    }
    else if (mediaPorQuestao <= 20)
    {
        return "Normal";
    }
    else
    {
        return "Pausado";
    }
}

static string MelhorNivel(int[] questoesPorNivel, int[] acertosPorNivel, string[] nomesNiveis)
{
    int melhorIndice = -1;
    double maiorPercentual = -1;
    for (int i = 0; i < 3; i ++)
    {
        if (questoesPorNivel[i] == 0)
        {
            continue;
        }
    
        double percentual = Percentual(acertosPorNivel[i], questoesPorNivel[i]);

        if (percentual > maiorPercentual || (percentual == maiorPercentual && i > melhorIndice))
        {
            maiorPercentual = percentual;
            melhorIndice = i;
        }
    }
    if (melhorIndice == -1)
    {
        return "Nenhum nível jogado";
    }

    return nomesNiveis[melhorIndice];
}


static void MostrarRelatorio(string nickname, string faixa, int[] questoesPorNivel, int[] acertosPorNivel, int dicas, int tempo)
{
    string[] nomesNiveis = { "Fácil", "Médio", "Difícil" };

    int totalQuestoes = 0;
    int totalAcertos = 0;
    for (int n = 0; n < 3; n++)
    {
        totalQuestoes = totalQuestoes + questoesPorNivel[n];
        totalAcertos = totalAcertos + acertosPorNivel[n];
    }

    double percentualGeral = Percentual(totalAcertos, totalQuestoes);
    int pontos = CalcularPontuacao(acertosPorNivel, dicas);
    int maximo = CalcularPontuacaoMaxima(questoesPorNivel);
    double media = tempo * 1.0 / totalQuestoes;

    Console.WriteLine();
    Console.WriteLine("===== ARCOR – DESAFIO DAS MARCAS: RESUMO DA PARTIDA =====");
    Console.WriteLine("Jogador: " + nickname);
    Console.WriteLine("Faixa etária: " + faixa);
    Console.WriteLine();
    Console.WriteLine("Desempenho por nível:");
    for (int n = 0; n < 3; n++)
    {
        if (questoesPorNivel[n] == 0)
        {
            Console.WriteLine($"{nomesNiveis[n],-8}(0/0)  não jogado");
        }
        else
        {
            double p = Percentual(acertosPorNivel[n], questoesPorNivel[n]);
            Console.WriteLine($"{nomesNiveis[n],-8}({acertosPorNivel[n]}/{questoesPorNivel[n]})  {p,5:F1}%  {GerarBarra(acertosPorNivel[n])}");
        }
    }
    Console.WriteLine();
    Console.WriteLine($"Total: {totalAcertos} acertos e {totalQuestoes - totalAcertos} erros em {totalQuestoes} questões ({percentualGeral:F1}%)");
    Console.WriteLine($"Pontuação: {pontos} de {maximo} pontos possíveis ({pontos * 100.0 / maximo:F1}%)");
    Console.WriteLine($"Dicas usadas: {dicas} (penalidade de {dicas * 5} pontos)");
    Console.WriteLine($"Tempo total: {tempo / 60} min {tempo % 60} s | Média: {media:F1} s por questão");
    Console.WriteLine("Ritmo: " + DefinirRitmo(media));
    Console.WriteLine("Melhor nível: " + MelhorNivel(questoesPorNivel, acertosPorNivel, nomesNiveis));
    Console.WriteLine("Classificação: " + Classificar(percentualGeral));
    Console.WriteLine("=========================================================");
}