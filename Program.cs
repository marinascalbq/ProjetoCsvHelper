using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;

//LerCSVComDynamic();
//LerCsvComClasse();
//LerCsvComOutroDelimitador();

EscreverCsv();


Console.WriteLine("Digite [enter] para finalizar...");
Console.ReadLine();


static void EscreverCsv()
{
    
var path = Path.Combine(
    Environment.CurrentDirectory,
    "Saída");

var di = new DirectoryInfo(path);
if(!di.Exists)
    di.Create();

path = Path.Combine(path, "usuarios.csv");
    
var pessoas = new List<Pessoa>()
    {
    new Pessoa()
    {
        Nome = "Ricardo Vincentini",
        Email = "ric_vicentin@hotmail.com",
        Telefone = 12225515,
    },  
   new Pessoa()
    {
        Nome = "Sergio Ramos",
        Email = "rramossegio@hotmail.com",
        Telefone = 66321525,
    },
    new Pessoa()
    {
        Nome = "Carla Sara",
        Email = "carlasara@hotmail.com",
        Telefone = 9595926,
    },
    new Pessoa()
    {
        Nome = "Souza Regis",
        Email = "souzaregis@hotmail.com",
        Telefone = 19895515,
    },
    };

    using var sr = new StreamWriter(path);

    var csvConfig = new CsvConfiguration(CultureInfo.InstalledUICulture)
        {
        Delimiter= "|"
        } ;
    

    using var csvWriter = new CsvWriter(sr, CultureInfo.InvariantCulture);

    csvWriter.WriteRecords(pessoas);
}
 

static void LerCsvComOutroDelimitador()
{
var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "livros-preco-com-virgula.csv");
var fi = new FileInfo(path);
if(!fi.Exists)
    throw new FileNotFoundException($" O arquivo {path} não existe!");

using var sr = new StreamReader(fi.FullName);
var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("pt-BR"))
{
  Delimiter = ";"
};

using var csvReader = new CsvReader(sr, csvConfig);
csvReader.Context.RegisterClassMap<LivroMap>();
var registros = csvReader.GetRecords<Livro>().ToList();

foreach (var registro in registros)
{
    Console.WriteLine($"Nome: {registro.Titulo}");
    Console.WriteLine($"Preço: {registro.Preco}");
    Console.WriteLine($"Autor: {registro.Autor}"); 
    Console.WriteLine($"Data de Lançamento: {registro.Lancamento}");      
    Console.WriteLine($"---------------");  
}

}


static void LerCsvComClasse()
{
var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "novos-usuarios.csv");
var fi = new FileInfo(path);
if(!fi.Exists)
    throw new FileNotFoundException($" O arquivo {path} não existe!");

using var sr = new StreamReader(fi.FullName);
var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
using var csvReader = new CsvReader(sr, csvConfig);

var registros = csvReader.GetRecords<Usuario>();

foreach (var registro in registros)
{
    Console.WriteLine($"Nome: {registro.Nome}");
    Console.WriteLine($"Marca: {registro.Email}");
    Console.WriteLine($"Preço: {registro.Telefone}");  
    Console.WriteLine($"---------------");  
}
}


static void LerCSVComDynamic()
{

var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "Produtos.csv");
var fi = new FileInfo(path);
if(!fi.Exists)
    throw new FileNotFoundException($" O arquivo {path} não existe!");

using var sr = new StreamReader(fi.FullName);
var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
using var csvReader = new CsvReader(sr, csvConfig);

var registros = csvReader.GetRecords<dynamic>();

foreach (var registro in registros)
{
    Console.WriteLine($"Nome: {registro.Produto}");
    Console.WriteLine($"Marca: {registro.Marca}");
    Console.WriteLine($"Preço: {registro.Preco}");  
    Console.WriteLine($"---------------");  
}
}
