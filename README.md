# Tinder.Net
Because why not?

# Why?
I am a very bored person so created whatever this is.

# Example
So far this will only work for those in the UK and via SMS Authentication. I do aim to change this later on.
```cs
static async Task Main(string[] args)
{
  var client = new TinderClient();
  await client.StartTinderAsync(Callback, 4412345678901);
  Console.ReadKey();
}

public static async Task<int> Callback()
{
  Console.Write("Auth Code: ");
  var code = int.Parse(Console.ReadLine());
  return code;
}
```
