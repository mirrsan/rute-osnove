using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace frrstBildStudioProject.Models
{
    public class Korisnik
    {
        public static List<Korisnik> Korisnici
        {
            get
            {
                var jsonLoad = File.ReadAllText("MOCK_DATA.json");
                var list = JsonConvert.DeserializeObject<List<Korisnik>>(jsonLoad);
                return list;
            }
        }


        public long id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public string MestoRodjenja { get; set; }

        public string Email { get; set; }

    }
}