# Tinder.Net
Wrapper for Tinder's api. Use this at your own risk. You'll very likely get shadow banned within a day.

# Warning Again
Like I sadi before, use at your own risk. I take no responsibility if you get hammered.

# If something is broken
If something breaks send the stacktrace and the api response. I will try my best to bodge a fix or addition

# Example
Note: This will only work for those in the UK and via SMS Authentication. However, I do aim to change this later on.

```cs
static async Task Main(string[] args)
{
  //Initialise the client
  var client = new TinderClient();
  //Start Tidner, params: Callback is a method used to get the auth code from the user and the number is in format <AreaCode><FullNumber>
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
