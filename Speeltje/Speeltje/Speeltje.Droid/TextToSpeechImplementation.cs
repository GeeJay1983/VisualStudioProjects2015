using System;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Speeltje.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace Speeltje.Droid
{
  public class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
  {
    private string _toSpeak;
    private TextToSpeech _speaker;

    public TextToSpeechImplementation() { }
    public TextToSpeechImplementation(IntPtr a, JniHandleOwnership b) : base(a, b) { }

    public void Speak(string text)
    {
      var context = Forms.Context; // useful for many Android SDK features
      _toSpeak = text;
      if (_speaker == null)
      {
        _speaker = new TextToSpeech(context, this);
      }
      else
      {
        _speaker.Speak(_toSpeak, QueueMode.Flush, Bundle.Empty, Guid.NewGuid().ToString());
      }
    }

    public void OnInit(OperationResult status)
    {
      if (status.Equals(OperationResult.Success))
      {
        if (_speaker != null && _toSpeak != null)
        {
          _speaker.Speak(_toSpeak, QueueMode.Flush, Bundle.Empty, Guid.NewGuid().ToString());
        }
      }
    }

    public void Dispose() { }

    public IntPtr Handle { get; }
  }
}