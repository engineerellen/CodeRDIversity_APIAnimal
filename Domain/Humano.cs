namespace Domain
{
    public class Humano : Mamifero
    {
        public string TempoVida { get; set; }
        public Humano(int id, string nome, int idade, string tempoVida)
        {

            base.Nome = nome;
            base.Idade = idade;
            TempoVida = tempoVida;
            ID = id;
        }

        public override string Acordar() => $"{Nome} {base.Acordar()}";

        public override string Mover() => $"{Nome} {base.Mover()}";

        public override string Comer() => $"{Nome} {base.Comer()}";

        public override string Crescer(int tempoAmais) => $"É aniversário de {Nome} ! Está fazendo {Idade + tempoAmais} {TempoVida}!";

        public override string Dormir() => $"{Nome} {base.Dormir()}";

        public override string EmitirSom() => $"{Nome} está falando!";

        public override string Morrer() => $"{Nome} {base.Morrer()}";

        public override string Nascer() => $"{Nome} {base.Nascer()}";

        public override string Olhar() => $"{Nome} {base.Olhar()}";

        public override string Reproduzir() => $"{Nome} {base.Reproduzir()}";

    }
}