using System;
namespace DevChampsAPP
{
    public class Resultado : EntidadeBase
    {
        public decimal Target { get; set; }
        public decimal Contribuicao { get; set; }
        public decimal DespesaAtual { get; set; }
        public decimal DespesaAposentadoria { get; set; }
    }
}
