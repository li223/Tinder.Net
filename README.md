# Tinder.Net
Wrapper for Tinder's api. Use this at your own risk. You'll very likely get shadow banned within a day.

# Warning Again
Like I said before, use at your own risk. I take no responsibility if you get hammered.

# Note
Tinder's API is, as far as I can tell, completely undocumented as it isn't meant to be fully OSS. However, using the magic of dev tools I just looked at the URL, headers, and bodies to firgure it out. Also cost me my Tinder account but ¯\_(ツ)_/¯

# If something is broken
If something breaks send the stacktrace and the api response. I will try my best to bodge a fix or addition

# Example
Note: This will only work for those in the UK and via SMS Authentication. However, I do aim to change this later on.

```cs
static async Task Main(string[] args)
{
  //Initialise the client
  var client = new TinderClient();
  //Start Tidner, params: Callback is a method used to get the auth code from the user. The first number is the area code, the second the user's full phone number'
  await client.StartTinderAsync(Callback, 44, 07123456789);
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
