# Tinder.Net
Because why not?

# Why?
I am a very bored person, so I created whatever this is.

# Example
Note: This will only work for those in the UK and via SMS Authentication. However, I do aim to change this later on.

```cs
static async Task Main(string[] args)
{
  //Initialise the client
  var client = new TinderClient();
  //Start Tiner, params: Callback is a method used to get the auth code from the user and the number is in format <AreaCode><FullNumber>
  await client.StartTinderAsync(Callback, 4412345678901);
  //Keep Console Open
  Console.ReadKey();
}

public static async Task<int> Callback()
{
  //Ask for Auth Code
  Console.Write("Auth Code: ");
  //Parse it
  var code = int.Parse(Console.ReadLine());
  //Return
  return code;
}
```
