using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace frrstBildStudioProject.Models
{
    public class Primeri
    {
        public int Id;
        public string Name;

        public Primeri(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        // citanje podataka sa fajla pomocu StreamReader-a
        public string CitanjePodataka(string path)
        {
            using (StreamReader reader = File.OpenText(path))
            {
                string s = "";

                while ((s = reader.ReadLine()) != null)
                {
                    return s;
                }

                return "Nista brate nema";
            }
        }

        //upisivanje u fail pomocu StreamWriter-a
        public string UpisivanjePodataka(string @path, string addText)
        {
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(addText);
                writer.Close();
            }

            return File.ReadAllText(path);
        }

        // ispis brojeva od do nekolko
        public int IspisBrojeva(int odBroja, int doBroja)
        {
            for (int i = odBroja; i < doBroja; i++)
            {
                Debug.WriteLine(i); 
            }

            return 0;
        }

        // primena File class-e
        public string CitanjeFajla(string @path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }

            return "Nema ti fajla";
        }

        // brisanje Faila
        public string BrisanjeFajla(string @path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return "Uspesno ste obrisali fajl";
            }

            return "Fajjl nije pronadjen";
        }

    }
}
