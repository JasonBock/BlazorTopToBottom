using DeviceAPIAccess.Services;

namespace DeviceAPIAccess.Platforms.Services
{
  public class GetText : IGetText
  {
    string IGetText.GetText()
    {
      return "Hello from Mac";
    }
  }
}
