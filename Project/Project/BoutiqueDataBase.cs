using Project;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BoutiqueDataBase
{
    private readonly SQLiteAsyncConnection _baseDeDonnees;
    public BoutiqueDataBase(string dbPath)
    {
        _baseDeDonnees = new SQLiteAsyncConnection(dbPath);
        //_baseDeDonnees.DropTableAsync<Admin>().Wait();
        _baseDeDonnees.CreateTableAsync<Admin>().Wait();

        //_baseDeDonnees.DropTableAsync<Categorie>().Wait();
        //_baseDeDonnees.DropTableAsync<Produit>().Wait();

        _baseDeDonnees.CreateTableAsync<Categorie>().Wait();
        _baseDeDonnees.CreateTableAsync<Produit>().Wait();
        //  _baseDeDonnees.DropTableAsync<LigneCommande>().Wait();
        _baseDeDonnees.CreateTableAsync<LigneCommande>().Wait();
        //  _baseDeDonnees.DropTableAsync<Commande>().Wait();
        _baseDeDonnees.CreateTableAsync<Commande>().Wait();
        var adminCount = _baseDeDonnees.Table<Admin>().CountAsync().Result;
        if (adminCount == 0)
        {
            _baseDeDonnees.InsertAsync(new Admin("admin", "admin")).Wait();
        }
    }


    // Opérations sur les catégories
    public Task<List<Categorie>> ObtenirCategories()
    {
        return _baseDeDonnees.Table<Categorie>().ToListAsync();
    }
    public async Task<Categorie> GetCategorieParId(int categoryId)
    {
        try
        {
            Categorie categorie = await _baseDeDonnees.Table<Categorie>().FirstAsync(c => c.Id == categoryId);
            return categorie;
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            return null;
        }
    }



    public Task<int> AjouterCategorieAsync(Categorie categorie)
    {
        if (categorie.Id != 0)
        {
            return _baseDeDonnees.UpdateAsync(categorie);
        }
        else
        {
            return _baseDeDonnees.InsertAsync(categorie);
        }
    }
    public Task<int> SaveCategorie(Categorie categorie)
    {
        if (categorie.Id != 0)
        {
            return _baseDeDonnees.UpdateAsync(categorie);
        }
        else
        {
            return _baseDeDonnees.InsertAsync(categorie);
        }
    }
    public async Task<int> SupprimerCategorie(int idCategorie)
    {
        var products = await _baseDeDonnees.Table<Produit>().Where(p => p.IdCategorie == idCategorie).ToListAsync();

        if (products.Any())
        {
            return -1; 
        }
        else
        {
            return await _baseDeDonnees.DeleteAsync<Categorie>(idCategorie);
        }
    }


    public Task<List<Produit>> ObtenirProduits(int idCategorie)
    {
        return _baseDeDonnees.Table<Produit>().Where(p => p.IdCategorie == idCategorie).ToListAsync();
    }
    /**/
    public Task<List<Produit>> ObtenirToutProduits()
    {
        return _baseDeDonnees.Table<Produit>().ToListAsync();
    }
    public Task<List<LigneCommande>> ObtenirToutigneCommande()
    {
        return _baseDeDonnees.Table<LigneCommande>().ToListAsync();
    }
    public decimal PrixParId(int i)
    {
        return _baseDeDonnees.Table<Produit>().Where(p => p.Id == i).FirstAsync().Result.Prix;
    }
    public Task<int> AjouterProduit(Produit produit)
    {
        if (produit.Id != 0)
        {
            return _baseDeDonnees.UpdateAsync(produit);
        }
        else
        {
            return _baseDeDonnees.InsertAsync(produit);
        }
    }

    public Task<int> SupprimerProduit(Produit produit)
    {
        return _baseDeDonnees.DeleteAsync(produit);
    }
    /*
    public void ModifierProduit(Produit produit)
    {
        _baseDeDonnees.Update(produit);
    }

    

    // Opérations sur les lignes de commande
    */
    public Task<int> AjouterLigneCommande(LigneCommande ligneCommande)
    {
        if (ligneCommande.Id != 0)
        {
            return _baseDeDonnees.UpdateAsync(ligneCommande);
        }
        else
        {
            return _baseDeDonnees.InsertAsync(ligneCommande);
        }
    }
    public async Task<int> AjouterLigneCommandewithId(LigneCommande ligneCommande)
    {
        await _baseDeDonnees.InsertAsync(ligneCommande);
        return ligneCommande.Id;
    }

    public Task<int> AjouterCommande(Commande commande)
    {
        return _baseDeDonnees.InsertAsync(commande);
    }
    public Task<List<Commande>> ObtenirToutCommande()
    {
        return _baseDeDonnees.Table<Commande>().ToListAsync();
    }
    public async Task<Commande> ObtenirCommande(int id)
    {
        return _baseDeDonnees.Table<Commande>().Where(p => p.Id == id).FirstAsync().Result;
    }
    public async Task<List<LigneCommande>> GetLigneCommandesByIds(List<int> ids)
    {
        var ligneCommandes = await _baseDeDonnees.Table<LigneCommande>().Where(l => ids.Contains(l.Id)).ToListAsync();
        return ligneCommandes;
    }
    public void UpdateAdmin(Admin admin)
    {
          _baseDeDonnees.UpdateAsync(admin);
    }
    public async Task<Admin> getAdmin()
    {
        try
        {
            return await _baseDeDonnees.Table<Admin>().FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }




    /*
    

    // Opérations sur les commandes
    public List<Produit> ObtenirCommande(int idCategorie)
    {
        return _baseDeDonnees.Table<Produit>().Where(p => p.IdCategorie == idCategorie).ToList();
    }
    
    public void ModifierCommande(Categorie categorie)
    {
        _baseDeDonnees.Update(categorie);
    }
    public void SupprimerCommande(int idCategorie)
    {
        _baseDeDonnees.Delete<Categorie>(idCategorie);
    }
    */

    // ... (ajoutez d'autres opérations selon vos besoins)
}