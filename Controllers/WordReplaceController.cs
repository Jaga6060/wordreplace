using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace WordReplace.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WordReplaceController : ControllerBase
  {
    private readonly ILogger<WordReplaceController> _logger;
    public WordReplaceController(ILogger<WordReplaceController> logger)
    {
      _logger = logger;
    }
    [HttpGet(Name = "GetWordReplaced")]
    public string Get(string inputString)
    {
      _logger.LogTrace("Execution Started");
      StreamReader reader = new StreamReader("Tokens.json");
      string jsonString = reader.ReadToEnd();
      var tokens = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
      string output = tokens.Aggregate(inputString, (current, value) => current.Replace(value.Key, value.Value));
      _logger.LogTrace("Execution Completed");
      return output;
    }
  }
}