using System;
using Xamarin.Forms;

using artina = UXDivers.Artina;

namespace DevChampsAPP
{
    public static class AppConstants
    {
        public static Color BaseTextColor = Color.FromHex("#37474f");

        public static Style FontIcon = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = Label.FontFamilyProperty,
                    Value = artina.Shared.FontAwesome.FontName
                },
                new Setter
                {
                    Property = Label.TextColorProperty,
                    Value = BaseTextColor
                }
            }
        };
    }
}