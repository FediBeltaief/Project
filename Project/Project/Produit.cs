﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Project
{
    public class Produit
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Nom { get; set; }
        public string Description { get; set; }
        [NotNull]
        public decimal Prix { get; set; }
        public string UrlImage { get; set; }
        [ForeignKey(typeof(Categorie))]
        public int IdCategorie { get; set; }
    }
}
