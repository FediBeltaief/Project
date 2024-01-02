using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Project
{
    public class LigneCommande
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Produit))]
        public int IdProduit { get; set; }

        [ForeignKey(typeof(Produit))]
        public string NomProduit { get; set; }

        [ForeignKey(typeof(Produit))]
        public decimal Prix { get; set; }

        public int Quantite { get; set; }

    }
}