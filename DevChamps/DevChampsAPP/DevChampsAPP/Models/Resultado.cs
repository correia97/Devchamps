using System;
namespace DevChampsAPP
{
    public class Resultado : EntidadeBase
    {
        public decimal Taret { get; set; }
        public decimal Contribuicao { get; set; }
        public decimal DespesaAtual { get; set; }
        public decimal DespesaAposentadoria { get; set; }
    }
}
