using Xamarin.Forms;

namespace CryptoMVVMprism.Helpers
{
    public class HeaderCell : ViewCell
    {
        public HeaderCell()
        {
            this.Height = 40;
            var title = new Label
            {
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
                FontFamily = "Alfa",
                //TextColor = Color.White,
                TextColor = Color.FromHex("#adddff"),
                VerticalOptions = LayoutOptions.Center
            };

            title.SetBinding(Label.TextProperty, "Key");

            View = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 40,
                BackgroundColor = Color.FromHex("#427ad4"),
                Padding = 5,
                Orientation = StackOrientation.Horizontal,
                Children = { title }

            };
        }
    }
}
