using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using frrstBildStudioProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace frrstBildStudioProject.Controllers
{
    [Route("api/[controller]/[action]")]
    public class KorisnikController : Controller
    {
        private readonly TodoContext _context;

        public KorisnikController(TodoContext todoContext)
        {
            _context = todoContext;
            _context.Database.EnsureCreated();
        }

        // za brisanje korisnika
        [HttpDelete("{id}:int")]
        public async Task<ActionResult<Korisnik>> DeleteKorisnik(long id)
        {
            var korisnik = await _context.Korisnici.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            _context.Korisnici.Remove(korisnik);
            await _context.SaveChangesAsync();

            return korisnik;
        }

        // ispis svih korisnika
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Korisnik>>> SviKorisnici()
        {
            return await _context.Korisnici.ToListAsync();
        }
        
        // izmena podataka korisnika
        [HttpPut("{id}:int/korisnikNovi")]
        public async Task<ActionResult<Korisnik>> IzmenaPodataka(long id, Korisnik korisnikNovi)
        {
            Korisnik korisnikStari = await _context.Korisnici.FindAsync(id);

            korisnikStari.Ime = korisnikNovi.Ime;
            korisnikStari.Prezime = korisnikNovi.Prezime;
            korisnikStari.DatumRodjenja = korisnikNovi.DatumRodjenja;
            korisnikStari.MestoRodjenja = korisnikNovi.MestoRodjenja;
            korisnikStari.Email = korisnikNovi.Email;
            await _context.SaveChangesAsync();

            return korisnikStari;
        }
        
        // pretraga po imenu i prezimenu
        [HttpGet("[action]/{ime}/{prezime}")]
        public async Task<ActionResult<Korisnik>> Pretraga(string ime, string prezime)
        {
            List<Korisnik> korisniks = await _context.Korisnici.ToListAsync();
            for (int i = 0; i < korisniks.Count; i++)
            {
                Korisnik kkk = korisniks[i];
                if (kkk.Ime == ime && kkk.Prezime == prezime)
                {
                    return kkk;
                }
            }
            return NotFound();
        }

        // pretraga po mail-u
        [HttpGet("[action]/{mail}")]
        public async Task<ActionResult<Korisnik>> PretragaMail(string mail)
        {
            List<Korisnik> korisniks = await _context.Korisnici.ToListAsync();
            var brr = from e in korisniks where e.Email == mail select e;

            return brr.FirstOrDefault(); 
        }

        //pretraga po datumu
        [HttpGet("[action]/{datum}")]
        public async Task<ActionResult<Korisnik>> PretragaDatum(DateTime datum)
        {
            List<Korisnik> korisniks = await _context.Korisnici.ToListAsync();
            for (int i = 0; i < korisniks.Count; i++)
            {
                Korisnik kkk = korisniks[i];
                if (kkk.DatumRodjenja == datum)
                {
                    return kkk;
                }
            }
            return NotFound();
        }


    }
}