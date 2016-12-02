using System;
namespace DevChampsAPP
{
    public class Pessoa : EntidadeBase
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Aposentadoria { get; set; }
        public string Endereco { get; set; }
        public int IdadeConjuge { get; set; }
        public int Dependente { get; set; }
    }
}