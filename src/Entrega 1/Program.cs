using System.ComponentModel;
using System.Numerics;

String? line;
bool conversion;
Console.Clear();

Console.WriteLine("Olá jogador(a)");
Console.WriteLine("-----------------------");


// TRECHO PARA ATRIBUIR O NOME DO JOGADOR
Console.WriteLine("Nickname:");
String name = Console.ReadLine()!;
if (name == null || name == "")
{
    Console.WriteLine("ERRO na entrada 1 (Nickname): dado ausente.");
    Environment.Exit(1);
}
Console.WriteLine("-----------------------");


// TRECHO PARA ATRIBUIR A FAIXA ETARIA DO JOGADOR E VALIDANDO OS ERROS
Console.WriteLine("Faixa etaria:\n1 - Até 12 anos\n2 - 13 a 17 anos\n3 - 18 a 24 anos\n4 - 25 a 39 anos\n5 - 40 anos ou mais\n6 - Prefiro não informar");
line = Console.ReadLine();
int age_group;
conversion = int.TryParse(line, out age_group);
if (!conversion)
{
    Console.WriteLine($"ERRO na entrada 2 (Faixa Etária): Valor \"{line}\" inválido.");
    Environment.Exit(1);
}
if (age_group < 1 || age_group > 6)
{
    Console.WriteLine($"ERRO na entrada 2 (Faixa Etária): Valor \"{line}\" fora do intervalo de 1 a 6.");
    Environment.Exit(1);
}
String range = "Até 12 anos";
if (age_group == 2)
{
    range = "13 a 17 anos";
}
if (age_group == 3)
{
    range = "18 a 24 anos";
}
if (age_group == 4)
{
    range = "25 a 39 anos";
}
if (age_group == 5)
{
    range = "40 anos ou mais";
}
if (age_group == 6)
{
    range = "Prefiro não informar";
}
Console.WriteLine("-----------------------");


// TRECHO PARA ATRIBUIR QUANTIDADE DE PERGUNTAS FACEIS 
Console.WriteLine("Questões fáceis apresentadas: ");
line = Console.ReadLine();
int easy_questions;
conversion = int.TryParse(line, out easy_questions);
if (!conversion)
{
    Console.WriteLine($"ERRO na entrada 3 (Quantidade Fáceis): Valor \"{line}\" inválido.");
    Environment.Exit(1);
}
if (easy_questions < 0)
{
    Console.WriteLine($"ERRO na entrada 3 (Quantidade Fáceis): Valor \"{line}\" menor que zero.");
    Environment.Exit(1);
}
Console.WriteLine("-----------------------");


// TRECHO PARA ATRIBUIR QUANTIDADE DE ACERTOS NAS PERGUNTAS FACEIS
Console.WriteLine("Quantidade de acerto das perguntas fáceis: ");
line = Console.ReadLine();
int easy_correct;
conversion = int.TryParse(line, out easy_correct);
if(!conversion)
{
    Console.WriteLine($"ERRO na entrada 4 (Acertos Fáceis): Valor \"{line}\" inválido.");
    Environment.Exit(1);
}
if (easy_correct < 0 || easy_correct > easy_questions)
{
    Console.WriteLine($"ERRO na entrada 4 (Acertos Fáceis): valor \"{line}\" fora do intervalo de 0 a " + easy_questions + ".");
    Environment.Exit(1);
}
Console.WriteLine("-----------------------");


// TRECHO PARA ATRIBUIR QUANTIDADE DE PERGUNTAS MEDIAS
Console.WriteLine("Questões médias apresentadas:");
line = Console.ReadLine();
int medium_questions;
conversion = int.TryParse(line, out medium_questions);
if(!conversion)
{
    Console.WriteLine($"ERRO na entrada 5 (Quantidade Médias): Valor \"{line}\" inválido.");
    Environment.Exit(1);
}
if (medium_questions < 0)
{
    Console.WriteLine($"ERRO na entrada 5 (Quantidade Médias): Valor \"{line}\" menor que zero.");
    Environment.Exit(1);
}
Console.WriteLine("-----------------------");


// TRECHO PARA ATRIBUIR QUANTIDADE DE ACERTOS NAS PERGUNTAS MEDIAS
Console.WriteLine("Quantidade de acerto das perguntas médias: ");
line = Console.ReadLine();
int medium_correct;
conversion = int.TryParse(line, out medium_correct);
if(!conversion)
{
    Console.WriteLine($"ERRO na entrada 6 (Acertos Médios): Valor \"{line}\" inválido.");
    Environment.Exit(1);
}
if (medium_correct < 0 || medium_correct > medium_questions)
{
    Console.WriteLine($"ERRO na entrada 6 (Acertos Médios): valor \"{line}\" fora do intervalo de 0 a " + medium_questions + ".");
    Environment.Exit(1);
}
Console.WriteLine("-----------------------");


// TRECHO PARA ATRIBUIR QUANTIDADE DE PERGUNTAS DIFICEIS
Console.WriteLine("Questões difíceis apresentadas:");
line = Console.ReadLine();
int hard_questions;
conversion = int.TryParse(line, out hard_questions);
if(!conversion)
{
    Console.WriteLine($"ERRO na entrada 7 (Quantidade Difíceis): Valor \"{line}\" inválido.");
    Environment.Exit(1);
}
if (hard_questions < 0)
{
    Console.WriteLine($"ERRO na entrada 7 (Quantidade Difíceis): Valor \"{line}\" menor que zero.");
    Environment.Exit(1);
}
Console.WriteLine("-----------------------");


// TRECHO PARA ATRIBUIR QUANTIDADE DE ACERTOS NAS PERGUNTAS DIFICEIS
Console.WriteLine("Quantidade de acerto das perguntas difíceis: ");
line = Console.ReadLine();
int hard_correct;
conversion = int.TryParse(line, out hard_correct);
if(!conversion)
{
    Console.WriteLine($"ERRO na entrada 8 (Acertos Difíceis): Valor \"{line}\" inválido.");
    Environment.Exit(1);
}
if (hard_correct < 0 || hard_correct > hard_questions)
{
    Console.WriteLine($"ERRO na entrada 8 (Acertos Difíceis): Valor \"{line}\" fora do intervalo de 0 a " + hard_questions + ".");
    Environment.Exit(1);
}
Console.WriteLine("-----------------------");


// TRECHO PARA ATRIBUIR O TEMPO DA PARTIDA, ENTREDA APENAS EM SEGUNDOS
Console.WriteLine("Tempo total da partida, em segundos: ");
line = Console.ReadLine();
int time;
conversion = int.TryParse(line, out time);
if(!conversion)
{
    Console.WriteLine($"ERRO na entrada 9 (Tempo de Jogo): Valor \"{line}\" inválido.");
    Environment.Exit(1);
}
if(time <= 0)
{
     Console.WriteLine($"ERRO na entrada 9 (Tempo de Jogo): Valor \"{line}\" menor ou igual a zero.");
    Environment.Exit(1);
}
Console.WriteLine("-----------------------");


// CRIEI A VARIAVEL TOTAL DE QUESTOES AQUI PQ ELA NÃO PODE SER MENOR QUE A QUANTIDADE DE DICAS
int total_questions = easy_questions + medium_questions + hard_questions;


// TRECHO PARA A QUANTIDADE DE QUESTÕES SER EXATAMENTE 10 (NÃO PEDIDA NA ENTREGA)
/*if(total_questions != 10)
{
    Console.WriteLine($"ERRO (Quantidade totais de perguntas): Soma das questões = a {total_questions}, diferente de 10.");
    Environment.Exit(1);
}*/


// TRECHO PARA ATRIBUIR QUANTIDADE DE DICAS. OBS: 1 DICA POR PERGUNTA
Console.WriteLine("Dicas usadas na partida: ");
line = Console.ReadLine();
int tips;
conversion = int.TryParse(line, out tips);
if (!conversion)
{
    Console.WriteLine($"ERRO na entrada 10 (Dicas): Valor \"{line}\" inválido.");
    Environment.Exit(1);
}
if (tips > total_questions)
{
    Console.WriteLine($"ERRO na entrada 10 (Dicas): Valor de dicas \"{line}\" maior que quantidade totais de perguntas \"{total_questions}\".");
    Environment.Exit(1);
}
Console.WriteLine("-----------------------");


// TRECHO PARA ATRIBUIR  AS FÓRMULAS PEDIDA NA ENTREGA 
int total_correct = easy_correct + medium_correct + hard_correct;
int total_errors = total_questions - total_correct;
double total_percentage = total_correct * 100.0 / total_questions;
int possible_points = easy_questions * 10 + medium_questions * 20 + hard_questions * 30;
int penalties = tips * 5;
int points = easy_correct * 10 + medium_correct * 20 + hard_correct * 30 - penalties;
double percentage_points = points * 100.0 / possible_points;
double medium_time = time / total_questions;
int minutes = time / 60;
int seconds = time % 60;


// NESSE TRECHO OS PERCENTUAIS DE CADA NÍVEL TIVERAM QUE SER STRINGS 
// POIS QUANDO NÃO TIVER PERGUNTAS NO NIVEL, A SAIDA TEM QUE SER "NÃO JOGADO"
String easy_percentage = $"{easy_correct * 100.0 / easy_questions:F1}%";
String medium_percentage = $"{medium_correct * 100.0 / medium_questions:F1}%";
String hard_percentage = $"{hard_correct * 100.0 / hard_questions:F1}%";

if (easy_questions == 0)
{
    easy_percentage = "não jogado";
}
if (medium_questions == 0)
{
    medium_percentage = "não jogado";
}
if (hard_questions == 0)
{
    hard_percentage = "não jogado";
}


// TRECHO DA CONDIÇÃO SE OS PONTOS FOREM NEGATIVOS, A SAÍDA TEM QUE SER ZERO
if (points < 0)
{
    points = 0;
}
if (percentage_points < 0)
{
    percentage_points = 0;
}


// TRECHO QUE MOSTRA A CLASSIFICAÇÃO DO JOGADOR DE ACORDO COM O PERCENTUAL ACERTADO
String classification;
if (total_percentage >= 90)
{
   classification = "Mestre das Marcas";
} 
else if (total_percentage < 90 && total_percentage >= 70)
{
    classification = "Conhecedor de Marcas";
} 
else if (total_percentage < 70 && total_percentage >= 50)
{
    classification = "Aprendiz";
} 
else
{
    classification = "Iniciante";
}


// TRECHO QUE MOSTRA O RITMO DO JOGADOR EM RELAÇÃO AO TEMPO DE JOGO
String rate;
if (medium_time <= 10)
{
    rate = "Rápido";
}
else if (medium_time > 20)
{
    rate = "Pausado";
}
else
{
    rate = "Normal";
}


// TRECHO QUE MOSTRA QUAL NÍVEL O JOGADOR FOI MELHOR, LEVANDO EM CONSIDEREÇÃO O NIVEL EM CASO DE EMPATE
// OBS.: NÃO PUDE COLOCAR AS VARIAVEIS PERCENTUAIS POIS ELAS SÃO STRINGS
String best_level = "";
double largest_percentage = 0;
if (easy_questions > 0)
{
    largest_percentage = easy_correct * 100.0 / easy_questions;
    best_level = "Fácil";
}
if (medium_questions > 0)
{
    if (largest_percentage == 0 || (medium_correct * 100.0 / medium_questions) >= largest_percentage) {
        largest_percentage = medium_correct * 100.0 / medium_questions;
        best_level = "Médio";
    }
}
if (hard_questions > 0){ 
    if (largest_percentage == 0 || (hard_correct * 100.0 / hard_questions) >= largest_percentage){
        largest_percentage = hard_correct * 100.0 / hard_questions;
        best_level = "Difícil";
    }
}


// TRECHO QUE MOSTRA EM ASTERISCOS, CADA PERGUNTA CERTA NOS NIVEIS
String easy_performance = "";
for (int i = 1; i <= easy_correct; i++)
{
    easy_performance = easy_performance + "*";
}
String medium_performance = "";
for (int i = 1; i <= medium_correct; i++)
{
    medium_performance = medium_performance + "*";
}
String hard_performance = "";
for (int i = 1; i <= hard_correct; i++)
{
    hard_performance = hard_performance + "*";
}

// TRECHO DE EXIBIÇÃO DA SAIDA
Console.WriteLine("");
Console.WriteLine("===== ARCOR – DESAFIO DAS MARCAS: RESUMO DA PARTIDA =====");
Console.WriteLine("Jogador: " + name);
Console.WriteLine("Faixa etária: " + range);
Console.WriteLine("");
Console.WriteLine("Desempenho por nível:");
Console.WriteLine($"{"Fácil",-9} ({easy_correct}/{easy_questions}) {"",1} {easy_percentage,6} {easy_performance}");
Console.WriteLine($"{"Médio",-9} ({medium_correct}/{medium_questions}) {"",1} {medium_percentage,6} {medium_performance}");
Console.WriteLine($"{"Difícil",-9} ({hard_correct}/{hard_questions}) {"",1} {hard_percentage,6} {hard_performance}");
Console.WriteLine("");
Console.WriteLine($"Total: {total_correct} acertos e {total_errors} erros em {total_questions} questões ({total_percentage:F1}%)");
Console.WriteLine($"Pontuação: {points} de {possible_points} pontos possíveis ({percentage_points:F1}%)");
Console.WriteLine($"Dicas usadas: {tips} (penalidade de {penalties} pontos)");
Console.WriteLine($"Tempo total: {minutes} min {seconds} s | Média: {medium_time:F1} s por questão");
Console.WriteLine("Ritmo: " + rate);
Console.WriteLine("Melhor nível: " + best_level);
Console.WriteLine("Classificação: " + classification);
Console.WriteLine("=========================================================");
Console.WriteLine("");


/* TESTANDO AS SAÍDAS DAS VARIAVEIS
Console.WriteLine("Nickname do Jogador(a): " + name);
Console.WriteLine("Faixa Etaria: " + range);
Console.WriteLine("Quantidade Faceis: " + easy_questions);
Console.WriteLine("Acerto Faceis: " + easy_correct);
Console.WriteLine("Quantidade Médias: " + medium_questions);
Console.WriteLine("Acertos Médios: " + medium_correct);
Console.WriteLine("Quantidade Dificeis: " + hard_questions);
Console.WriteLine("Acertos Dificeis: " + hard_correct);
Console.WriteLine("Tempo de Jogo: " + time);
Console.WriteLine("Dicas Usadas: " + tips);
Console.WriteLine("Total Corretas: " + total_correct);
Console.WriteLine("Total de Erros: " + total_errors);
Console.WriteLine($"Percentual Faceis: {easy_percentage}");
Console.WriteLine($"Percentual Medias: {medium_percentage}");
Console.WriteLine($"Percental Dificeis: {hard_percentage}");
Console.WriteLine($"Percentual Total: {total_percentage:F1}%");
Console.WriteLine("Pontuação Possivel: " + possible_points);
Console.WriteLine("Penalidades: " + penalties);
Console.WriteLine("Pontuação: " + points);
Console.WriteLine($"Pontos Percentuais: {percentage_points:F1}%");
Console.WriteLine("Classificação: " + classification);
Console.WriteLine("Ritmo: " + rate);
Console.WriteLine("Tempo Médio: " + medium_time);
Console.WriteLine("Melhor Nível: " + best_level);
Console.WriteLine($"Tempo Minutos: {minutes}:{seconds}");
Console.WriteLine("Desempenho Fácil: " + easy_performance);
Console.WriteLine("Desempenho Médio: " + medium_performance);
Console.WriteLine("Desempenho Díficil: " + hard_performance);
*/

