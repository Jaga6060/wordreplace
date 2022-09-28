using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WordReplace.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WordReplaceController : ControllerBase
  {
    private readonly ILogger<WordReplaceController> _logger;
    private readonly IOptions<Dictionary<string, string>> _conf;
    public WordReplaceController(ILogger<WordReplaceController> logger, IOptions<Dictionary<string, string>> conf)
    {
      _logger = logger;
      _conf = conf;
    }
    [HttpGet(Name = "GetWordReplaced")]
    public string Get(string inputString)
    {
      _logger.LogTrace("Execution Started");
      
      string output = _conf.Value.Aggregate(inputString, (current, value) => current.Replace(value.Key, value.Value));

      _logger.LogTrace("Execution Completed");
      return output;
    }
  }
}