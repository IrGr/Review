using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DB
/// </summary>
public class DB
{
	public DB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

     public _Bruger TagBrugeren(DataClassesDataContext db, string brugernavn, string password)
     {
         return db._Brugers.Where(b => b.brugernavn.Equals(brugernavn) && b.password.Equals(password)).Single();
     }
     
     /// <summary>
     ///  Vælger et random produkt på listen
     /// items er det samme som list og vi henter og laver det til et unikt id (Guid)
     /// Guid er en unique værdi,der sikrer, at når man sorterer vil sorteringeren hele tiden blive forskellig
     /// </summary>
     /// <returns></returns>
    public List<_Billede> TagRandomHeaderBilleder(DataClassesDataContext db)
     {
         var items = db._Billedes.Where(b=>b.billede_navn.Contains("headerimage")).ToList();
         return items.OrderBy(z => Guid.NewGuid()).Take(1).ToList();
     }

    public List<_Tilbud> TagAlleTilbud(DataClassesDataContext db)
    {
        return db._Tilbuds.OrderByDescending(t=>t.startdato).ToList();
    }
    public List<_Tilbud> TagTilbud(DataClassesDataContext db)
    {
        return db._Tilbuds.Take(3).ToList();
    }

    public List<_Nyhed> TagAlleNyheder(DataClassesDataContext db)
    {
        return db._Nyheds.OrderByDescending(n => n.dato).ToList();
    }
    public List<_Nyhed> TagNyheder(DataClassesDataContext db)
    {
        return db._Nyheds.OrderByDescending(n => n.dato).Take(3).ToList();
    }
    public List<_Nyhed> TagFemNyheder(DataClassesDataContext db)
    {
        return db._Nyheds.OrderByDescending(n => n.dato).Take(5).ToList();
    }

    public _Nyhed TagEnNyhedMedId(DataClassesDataContext db, int id)
    {
        return db._Nyheds.Where(n => n.nyhed_id.Equals(id)).FirstOrDefault();
    }    

    /// <summary>
    /// Henter alle produkter
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public List<_Produkt> TagAlleProdukter(DataClassesDataContext db)
    {
        return db._Produkts.OrderByDescending(p=>p.id).ToList();
    }

    /// <summary>
    /// Henter et produkt med den valgte id
    /// </summary>
    /// <param name="db"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public _Produkt TagEtProdukt(DataClassesDataContext db,int id)
    {
        return db._Produkts.Where(p => p.id.Equals(id)).FirstOrDefault();
    }
    /// <summary>
    /// Tager alle produkter fra en kategori
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public List<_Produkt> TagAlleProdukterFraEnKategori(DataClassesDataContext db, int id)
    {
        return db._Produkts.Where(p=>p.fk_kategori_id.Equals(id)).OrderByDescending(p => p.id).ToList();
    }

    /// <summary>
    /// Henter alle kategorier
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public List<_Kategori> TagKategorier(DataClassesDataContext db)
    {
        return db._Kategoris.ToList();
    }

    /// <summary>
    /// Henter alle mærker fra Db
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public List<_Mearke> TagMearker(DataClassesDataContext db)
    {
        return db._Mearkes.ToList();
    }


    /// <summary>
    /// Tager et billede
    /// </summary>
    /// <param name="db"></param>
    /// <param name="billedeId"></param>
    /// <returns></returns>
    public _Billede TagEtBilledeEfterId(DataClassesDataContext db, int billedeId)
    {
        return db._Billedes.Where(b => b.billede_id.Equals(billedeId)).FirstOrDefault();
    }



    /// <summary>
    /// Alle Tilbud til et produkt
    /// </summary>
    /// <param name="db"></param>
    /// <param name="billedeId"></param>
    /// <returns></returns>
    public List<_Tilbud> TagTilbudTilEtProdukt(DataClassesDataContext db, int id)
    {
        return db._Tilbuds.Where(t => t.fk_prod_id.Equals(id)).ToList();
    }

    /// <summary>
    /// Udtrækker firmaets kontaktoplysninger ud fra DB
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public List<_Kontaktoplysninger> TagKontaktoplysninger(DataClassesDataContext db)
    {
        return db._Kontaktoplysningers.ToList();
    }

}