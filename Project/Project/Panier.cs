using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public static class Panier
    {
        public static List<ArticlePanier> Articles { get; set; } = new List<ArticlePanier>();

        /*public Panier()
        {
            Articles = new List<ArticlePanier>();
        }*/
        public static void AjouterArticle(int idProduit, string nomProduit, decimal prixUnitaire, int
       quantite)
        {
            // Vérifier si l'article est déjà dans le panier
            var articleExist = Articles.FirstOrDefault(a => a.IdProduit == idProduit);
            if (articleExist != null)
            {
                // L'article existe déjà, mettre à jour la quantité
                articleExist.Quantite += quantite;
            }
            else
            {
                // Ajouter un nouvel article au panier
                Articles.Add(new ArticlePanier
                {
                    IdProduit = idProduit,
                    NomProduit = nomProduit,
                    PrixUnitaire = prixUnitaire,
                    Quantite = quantite
                });
            }
        }
        public static void RetirerArticle(int idProduit)
        {
            // Retirer l'article du panier
            var article = Articles.FirstOrDefault(a => a.IdProduit == idProduit);
            if (article != null)
            {
                Articles.Remove(article);
            }
        }
        public static decimal CalculerTotal()
        {
            // Calculer le total du panier
            return Articles.Sum(article => article.PrixUnitaire * article.Quantite);
        }
        public static void ViderPanier()
        {
            // Vider le panier
            Articles.Clear();
        }
    }
}
