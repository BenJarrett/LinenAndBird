using LinenAndBird.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinenAndBird.Controllers
{
    [Route("api/hats")] // exposed at this endpoint //
    [ApiController] // an api controller, so it returns JSON or XML //
    public class HatsController : ControllerBase
    {

        static List<Hat> _hats = new List<Hat>
            {
                new Hat
                {
                    Color = "Blue",
                    Designer = "Charlie",
                    Style = HatStyle.OpenBack
    },
                 new Hat
                {
                    Color = "Black",
                    Designer = "Nathan",
                    Style = HatStyle.WideBrim
},
                  new Hat
                  {
                      Color = "Magenta",
                      Designer = "Charlie",
                      Style = HatStyle.Normal
                  },
            };

        [HttpGet]
        public List<Hat> GetAllHats()
        {
            return _hats;
        }

        // More Efficient //
        // GET /api/hats/styles/1 -> All open backed hats //
        [HttpGet("styles/{style}")]
        public IEnumerable<Hat> GetHatsByStyle(HatStyle style)
        {
            var matches = _hats.Where(hat => hat.Style == style);
            return matches;
        }
        // 

        // OR //
        // More Taxing //
        //  public List<Hat> GetHatsByStyle(HatStyle style)
        //{
        // var matches = _hats.Where(hat => hat.Style == style);
        // return matches.ToList();
        // } 

        // OR // 
        //  public List<Hat> GetHatsByStyle(HatStyle style)
        //{
        // return _hats.Where(hat => hat.Style == style);
        // 
        // } 


        [HttpPost]
        public void AddAHat(Hat newHat)
        {
            _hats.Add(newHat);
        }


    }
}
