using System.Collections.Generic;
using Xamarin.Forms;

namespace Speeltje
{
  public class SimpleContentPage : ContentPage
  {
    public SimpleContentPage(List<string> words, List<string> extraWords, List<string> nouns)
    {
      var label1 = new Label
      {
        Text = "Zingeving",
        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
        FontAttributes = FontAttributes.Bold
      };

      Zingeving.Zingeving.Init(words, extraWords, nouns);

      var button1 = new Button
      {
        Text = "Geef mij een zin"
      };

      button1.Clicked += (sender, e) =>
      {
        var sentence = Zingeving.Zingeving.Generate();
        label1.Text = sentence;
        DependencyService.Get<ITextToSpeech>().Speak(sentence);
      };

      Content = new StackLayout
      {
        Padding = 30,
        Spacing = 10,
        Children = {label1, button1}
      };
    }
  }
}
