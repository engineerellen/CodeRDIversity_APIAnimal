namespace Domain
{
    internal interface IAnimal
    {
        int ID { get; set; }
        string Nome { get; set; }
        int Idade { get; set; }

        string Mover();
        string Olhar();
        string Comer();
        string Dormir();
        string Acordar();
        string Nascer();
        string Morrer();
        string Crescer(int tempoAmais);
        string Reproduzir();
        string EmitirSom();
    }
}