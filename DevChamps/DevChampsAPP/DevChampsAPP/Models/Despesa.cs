using System;
namespace DevChampsAPP
{
    public class Despesa : EntidadeBase
    {
        public decimal Habitacao { get; set; }
        public decimal Alimentacao { get; set; }
        public decimal Saude { get; set; }
        public decimal Transporte { get; set; }
        public decimal Lazer { get; set; }
        public decimal Educacao { get; set; }
    }
}
