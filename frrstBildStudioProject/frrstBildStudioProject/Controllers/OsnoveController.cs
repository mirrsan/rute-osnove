using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using frrstBildStudioProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;

namespace frrstBildStudioProject.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OsnoveController : Controller
    {
        // citanje podataka sa fajla pomocu StreamReadera
        [HttpGet("[action]/{path}")]
        public string CitanjeFjjla(string @path)
        {
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string s = "";

                while ((s = reader.ReadLine()) != null)
                {
                    return s;
                }

                return "Nista brate nema";
            }
        }
        // enumeracija
        enum Meseci_ { Januar, Februar, Mart, April, Maj, Jun, Jul, Avgust, Septembar, Oktobar, Novembar, Decembar }

        // upotreba enumeracije i switch-a
        [HttpGet("[action]/{mesec}:int")]
        public string Meseci(int mesec)
        {
            if (mesec > 12)
            {
                return "Alo meseci ima samo 12, veseo bio";
            }

            switch (mesec)
            {
                case 1:
                    return Meseci_.Januar.ToString();
                    break;
                case 2:
                    return Meseci_.Februar.ToString();
                    break;
                case 3:
                    return Meseci_.Mart.ToString();
                    break;
                case 4:
                    return Meseci_.April.ToString();
                    break;
                case 5:
                    return Meseci_.Maj.ToString();
                    break;
                case 6:
                    return Meseci_.Jun.ToString();
                    break;
                case 7:
                    return Meseci_.Jul.ToString();
                    break;
                case 8:
                    return Meseci_.Avgust.ToString();
                    break;
                case 9:
                    return Meseci_.Septembar.ToString();
                    break;
                case 10:
                    return Meseci_.Oktobar.ToString();
                    break;
                case 11:
                    return Meseci_.Novembar.ToString();
                    break;
                case 12:
                    return Meseci_.Decembar.ToString();
                    break;
            }

            return null;
        }
        // serializacija
        [HttpGet("[action]/{path}/{id}/{name}")]
        public string Serializablee(string path, int id, string name)
        {
            Primeri pr = new Primeri(id, name);

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, pr);
            stream.Close();
            return "moze";
        }


    }


}
