using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SogHelper
/// </summary>
public class SogHelper
{
    private List<_Produkt> _ProduktsListe;
    public SogHelper(List<_Produkt> listofProds)
    {
        _ProduktsListe = listofProds;
    }
    public List<_Produkt> TagResultatAfSogning(int kategori, int mearke, string fritext, decimal maxpris)
    {
        if (maxpris == 0) maxpris = int.MaxValue; // Maxpris sættes til maxvalue som default

        // Konverter strenge til småbogstaver
        fritext = fritext.ToLowerInvariant();

        // Vi kan nu lave en filtreret søgning på alt
        // Hint contains "" (blank) er altid sand
        // Alle kolonner med string konverteres til lowercase
        /*  var result = _ProduktsListe.Where(p =>
              p.fk_kategori_id.Equals(kategori)
              && p.fk_mearke_id.Equals(mearke)
              // fritekst
              && (p.produktdetaljer.ToLowerInvariant().Contains(fritext)
                  || p.beskrivelse.ToLowerInvariant().Contains(fritext))
              // min / max pris
              && (p.pris <= maxpris)
              ).ToList();
          */

        List<_Produkt> result = new List<_Produkt>();


         if (kategori == 0 && mearke == 0)
        {
            result = _ProduktsListe.Where(p =>
         (p.produktdetaljer.ToLowerInvariant().Contains(fritext)
                || p.beskrivelse.ToLowerInvariant().Contains(fritext))
             // min / max pris
            && (p.pris <= maxpris)
            ).ToList();
        }
        else if (mearke == 0)
        {
            result = _ProduktsListe.Where(p =>
            p.fk_kategori_id.Equals(kategori)
                // fritekst
            && (p.produktdetaljer.ToLowerInvariant().Contains(fritext)
                || p.beskrivelse.ToLowerInvariant().Contains(fritext))
                // min / max pris
            && (p.pris <= maxpris)
            ).ToList();
        }
        else if (kategori == 0)
        {
            result = _ProduktsListe.Where(p =>
           p.fk_mearke_id.Equals(mearke)
               // fritekst
            && (p.produktdetaljer.ToLowerInvariant().Contains(fritext)
                || p.beskrivelse.ToLowerInvariant().Contains(fritext))
               // min / max pris
            && (p.pris <= maxpris)
            ).ToList();
        }
        else
        {
            result = _ProduktsListe.Where(p =>
            p.fk_kategori_id.Equals(kategori)
            && p.fk_mearke_id.Equals(mearke)
                // fritekst
            && (p.produktdetaljer.ToLowerInvariant().Contains(fritext)
                || p.beskrivelse.ToLowerInvariant().Contains(fritext))
                // min / max pris
            && (p.pris <= maxpris)
            ).ToList();

        }




        return result;
    }



}