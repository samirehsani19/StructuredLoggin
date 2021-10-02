using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StructuredLogging.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("You requested the Index page");
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    if(i == 5)
                    {
                        throw new Exception("An error has occured inside the loop");
                    }
                    else
                    {
                        _logger.LogInformation("The value of i is {iVariable}", i);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError("We caught this exception in the Index Get call {Exception}", e);
            }
        }
    }
}
