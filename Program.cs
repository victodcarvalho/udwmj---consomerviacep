using static System.Console;

WriteLine("Digite o CEP que deseja consultar:");

var cep = ReadLine();

var enderecoURL = $"https://viacep.com.br/ws/{cep}/json/";

WriteLine($"Consultando o endereco na url: {enderecoURL}");

var client = new HttpClient();

try
{
    HttpResponseMessage response = await client.GetAsync(enderecoURL);
    response.EnsureSuccessStatusCode();

    string respostaAPI = await response.Content.ReadAsStringAsync();

    Endereco endereco = System.Text.Json.JsonSerializer.Deserialize<Endereco>(respostaAPI);
    
    WriteLine($"\nCEP: {endereco.Cep}");
    WriteLine($"\nRua: {endereco.Rua}");
    WriteLine($"\nComplemento: {endereco.Complemento}");
    WriteLine($"\nBairro: {endereco.Bairro}");
    WriteLine($"\nCidade: {endereco.Localidade}");
}
catch (Exception ex)
{
    WriteLine("Ocorreu um erro ao consultar o endereço: {ex.Message}");
}