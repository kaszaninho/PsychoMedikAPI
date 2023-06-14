﻿using PsychoMedikAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychoMedikAPI.ViewModels
{
    public class PacjentForView : DescriptionTable
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public bool Plec { get; set; }
        public int? IdPracownikaProwadzacego { get; set; }
        public string ImieNazwiskoPracownikaProwadzacego { get; set; }

    }
}