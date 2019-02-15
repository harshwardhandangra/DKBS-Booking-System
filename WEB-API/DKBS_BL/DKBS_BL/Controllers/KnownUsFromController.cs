using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DKBS.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.Controllers
{
    [Route("api/KnownUsFrom")]
    [ApiController]
    public class KnownUsFromController : ControllerBase
    {
        IDictionary<int, string> SocialMediaNames = new Dictionary<int, string>();
        public KnownUsFromController()
        {
            SocialMediaNames.Add(1, "FaceBook");
            SocialMediaNames.Add(2, "LinkedIn");
            SocialMediaNames.Add(3, "Kollega");
            SocialMediaNames.Add(4, "Har tidligere brugt jer");
            SocialMediaNames.Add(5, "Kundearrangement");
            SocialMediaNames.Add(6, "Google");
        }
        // GET: api/KnownUsFrom
        [HttpGet]
        public IEnumerable<KnowUsFrom> Get()
        {
            ICollection<KnowUsFrom> SocialMediaCollection = new List<KnowUsFrom>();
            foreach (int key in SocialMediaNames.Keys)
            {
                KnowUsFrom socialMedia = new KnowUsFrom();
                socialMedia.Id = key;
                socialMedia.SocialMediaName = SocialMediaNames[key];
                SocialMediaCollection.Add(socialMedia);
            }
            return SocialMediaCollection;
        }

       
    }
}
