using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Speeltje.Droid
{
  [Activity(Label = "Speeltje", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle bundle)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(bundle);

      var words = LoadWords("words.txt");
      var extraWords = LoadWords("extrawords.txt");
      var nouns = LoadWords("nouns.txt");

      global::Xamarin.Forms.Forms.Init(this, bundle);
      LoadApplication(new App(words, extraWords, nouns));
    }
    private List<string> LoadWords(string assetName)
    {
      string words;

      using (var wordsStream = Assets.Open(assetName))
      using (var streamReader = new StreamReader(wordsStream))
      {
        words = streamReader.ReadToEnd();
      }

      var wordList = new List<string>();

      using (var stringReader = new StringReader(words))
      {
        var word = stringReader.ReadLine();

        while (word != null)
        {
          wordList.Add(word);

          word = stringReader.ReadLine();
        }
      }

      return wordList;
    }
  }

}

