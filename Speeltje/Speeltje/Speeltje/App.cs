using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Speeltje
{
  public class App : Application
  {
    public App(List<string> words, List<string> extraWords, List<string> nouns)
    {
      MainPage = new NavigationPage(new SimpleContentPage(words, extraWords, nouns));
    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }
  }
}
