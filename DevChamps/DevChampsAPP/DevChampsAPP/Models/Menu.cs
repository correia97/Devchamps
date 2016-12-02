using System;
namespace DevChampsAPP
{
    public class Menu : EntidadeBase
    {
        public string Ico { get; set;}
        public string Descricao { get; set; }
        public int Ordem { get; set; }

        public Xamarin.Forms.Color BackgroundColor { get; set; }
    }
}