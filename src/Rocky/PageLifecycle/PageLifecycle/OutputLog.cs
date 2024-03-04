namespace PageLifecycle
{
  public class OutputLog
  {
    public List<string> Data = new List<string>();

    public void Log(string message)
    {
      Data.Add(message);
    }
  }
}
