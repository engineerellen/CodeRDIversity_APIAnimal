using Domain;

var bebe = new Humano(1, "Noah", 3, "meses");
Console.WriteLine(bebe.Nascer());
Console.WriteLine(bebe.Dormir());

Console.WriteLine("---------------------------------------");
var homem = new Humano(2, "Ricardão", 35, "anos");
Console.WriteLine(homem.Reproduzir());
Console.WriteLine(homem.Morrer());