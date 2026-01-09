using System;

Console.WriteLine("=== Identificador de Bandeira de Cartão de Crédito ===\n");

while (true)
{
    Console.Write("Digite o número do cartão (ou 'sair' para encerrar): ");
    string entrada = Console.ReadLine()?.Trim() ?? "";

    if (entrada.Equals("sair", StringComparison.OrdinalIgnoreCase))
        break;

    // Remove espaços
    string numero = entrada.Replace(" ", "");

    // Validação simples: só números
    if (string.IsNullOrWhiteSpace(numero) || !numero.All(char.IsDigit))
    {
        Console.WriteLine("Número inválido. Digite apenas números.\n");
        continue;
    }

    string bandeira = ObterBandeira(numero);
    Console.WriteLine($"Bandeira do cartão: {bandeira}\n");
}

// Função que retorna a bandeira do cartão
string ObterBandeira(string numero)
{
    // Visa: começa com 4, comprimento 13 ou 16
    if (numero.StartsWith("4") && (numero.Length == 13 || numero.Length == 16))
        return "Visa";

    // MasterCard: começa com 51-55, comprimento 16
    if (numero.Length == 16 && int.TryParse(numero.Substring(0, 2), out int doisDigitos)
        && doisDigitos >= 51 && doisDigitos <= 55)
        return "MasterCard";

    // American Express: começa com 34 ou 37, comprimento 15
    if (numero.Length == 15 && (numero.StartsWith("34") || numero.StartsWith("37")))
        return "American Express";

    // Discover: começa com 6011 ou 65, comprimento 16
    if (numero.Length == 16 && (numero.StartsWith("6011") || numero.StartsWith("65")))
        return "Discover";

    return "Bandeira desconhecida";
}
