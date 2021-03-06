﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ankiety_PZ
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ankiety> Ankiety { get; set; }
        public virtual DbSet<Pytania> Pytania { get; set; }
        public virtual DbSet<Uzytkownicy> Uzytkownicy { get; set; }
        public virtual DbSet<Wyniki> Wyniki { get; set; }
        public virtual DbSet<Wynik> Wynik { get; set; }
        public virtual DbSet<WyswietlAnkiety> WyswietlAnkiety { get; set; }
    
        public virtual ObjectResult<WypelnijAnkiete_Result> WypelnijAnkiete(Nullable<int> idankiety)
        {
            var idankietyParameter = idankiety.HasValue ?
                new ObjectParameter("idankiety", idankiety) :
                new ObjectParameter("idankiety", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WypelnijAnkiete_Result>("WypelnijAnkiete", idankietyParameter);
        }
    
        public virtual int AktualizujWynik(Nullable<int> idankiety, Nullable<int> idpytania, Nullable<int> nrodpowiedzi)
        {
            var idankietyParameter = idankiety.HasValue ?
                new ObjectParameter("idankiety", idankiety) :
                new ObjectParameter("idankiety", typeof(int));
    
            var idpytaniaParameter = idpytania.HasValue ?
                new ObjectParameter("idpytania", idpytania) :
                new ObjectParameter("idpytania", typeof(int));
    
            var nrodpowiedziParameter = nrodpowiedzi.HasValue ?
                new ObjectParameter("nrodpowiedzi", nrodpowiedzi) :
                new ObjectParameter("nrodpowiedzi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AktualizujWynik", idankietyParameter, idpytaniaParameter, nrodpowiedziParameter);
        }
    
        public virtual int DodajPytanie(Nullable<int> idankiety, Nullable<bool> kilka, string pytanie, string odp1, string odp2, string odp3, string odp4, string odp5, string odp6, string odp7, string odp8, string odp9, string odp10)
        {
            var idankietyParameter = idankiety.HasValue ?
                new ObjectParameter("idankiety", idankiety) :
                new ObjectParameter("idankiety", typeof(int));
    
            var kilkaParameter = kilka.HasValue ?
                new ObjectParameter("kilka", kilka) :
                new ObjectParameter("kilka", typeof(bool));
    
            var pytanieParameter = pytanie != null ?
                new ObjectParameter("pytanie", pytanie) :
                new ObjectParameter("pytanie", typeof(string));
    
            var odp1Parameter = odp1 != null ?
                new ObjectParameter("odp1", odp1) :
                new ObjectParameter("odp1", typeof(string));
    
            var odp2Parameter = odp2 != null ?
                new ObjectParameter("odp2", odp2) :
                new ObjectParameter("odp2", typeof(string));
    
            var odp3Parameter = odp3 != null ?
                new ObjectParameter("odp3", odp3) :
                new ObjectParameter("odp3", typeof(string));
    
            var odp4Parameter = odp4 != null ?
                new ObjectParameter("odp4", odp4) :
                new ObjectParameter("odp4", typeof(string));
    
            var odp5Parameter = odp5 != null ?
                new ObjectParameter("odp5", odp5) :
                new ObjectParameter("odp5", typeof(string));
    
            var odp6Parameter = odp6 != null ?
                new ObjectParameter("odp6", odp6) :
                new ObjectParameter("odp6", typeof(string));
    
            var odp7Parameter = odp7 != null ?
                new ObjectParameter("odp7", odp7) :
                new ObjectParameter("odp7", typeof(string));
    
            var odp8Parameter = odp8 != null ?
                new ObjectParameter("odp8", odp8) :
                new ObjectParameter("odp8", typeof(string));
    
            var odp9Parameter = odp9 != null ?
                new ObjectParameter("odp9", odp9) :
                new ObjectParameter("odp9", typeof(string));
    
            var odp10Parameter = odp10 != null ?
                new ObjectParameter("odp10", odp10) :
                new ObjectParameter("odp10", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DodajPytanie", idankietyParameter, kilkaParameter, pytanieParameter, odp1Parameter, odp2Parameter, odp3Parameter, odp4Parameter, odp5Parameter, odp6Parameter, odp7Parameter, odp8Parameter, odp9Parameter, odp10Parameter);
        }
    
        public virtual ObjectResult<WyswietlPytania_Result> WyswietlPytania(Nullable<int> idankiety)
        {
            var idankietyParameter = idankiety.HasValue ?
                new ObjectParameter("idankiety", idankiety) :
                new ObjectParameter("idankiety", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WyswietlPytania_Result>("WyswietlPytania", idankietyParameter);
        }
    
        public virtual ObjectResult<WyswietlWynik_Result> WyswietlWynik(Nullable<int> idankiety)
        {
            var idankietyParameter = idankiety.HasValue ?
                new ObjectParameter("idankiety", idankiety) :
                new ObjectParameter("idankiety", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WyswietlWynik_Result>("WyswietlWynik", idankietyParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DodajAnkiete(string nazwa, Nullable<int> iduz)
        {
            var nazwaParameter = nazwa != null ?
                new ObjectParameter("nazwa", nazwa) :
                new ObjectParameter("nazwa", typeof(string));
    
            var iduzParameter = iduz.HasValue ?
                new ObjectParameter("iduz", iduz) :
                new ObjectParameter("iduz", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DodajAnkiete", nazwaParameter, iduzParameter);
        }
    
        public virtual int UsunAnkiete(Nullable<int> idankiety)
        {
            var idankietyParameter = idankiety.HasValue ?
                new ObjectParameter("idankiety", idankiety) :
                new ObjectParameter("idankiety", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsunAnkiete", idankietyParameter);
        }
    }
}
