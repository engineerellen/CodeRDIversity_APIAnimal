namespace Domain
{
    public abstract class Mamifero : IAnimal

    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }

        public virtual string Acordar() => "Acordou!";

        public virtual string Mover() => "Moveu!";

        public virtual string Comer() => "Comeu!";

        public virtual string Crescer(int tempoAmais) => $"Cresceu! Está com {Idade + tempoAmais}";

        public virtual string Dormir() => "Dormiu!";

        public virtual string EmitirSom() => "Emitiu Som!";

        public virtual string Morrer() => "Foi jogar no Vasco!";

        public virtual string Nascer() => "Silvio Santos reencarnou nele!";

        public virtual string Olhar() => "Olhou!";

        public virtual string Reproduzir() => "Coizou hmm danado!";
    }
}
