//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Wyniki
    {
        public int IdWyniku { get; set; }
        public int IdPytania { get; set; }
        public int IdAnkiety { get; set; }
        public int Ile_Odp_1 { get; set; }
        public int Ile_Odp_2 { get; set; }
        public Nullable<int> Ile_Odp_3 { get; set; }
        public Nullable<int> Ile_Odp_4 { get; set; }
        public Nullable<int> Ile_Odp_5 { get; set; }
        public Nullable<int> Ile_Odp_6 { get; set; }
        public Nullable<int> Ile_Odp_7 { get; set; }
        public Nullable<int> Ile_Odp_8 { get; set; }
        public Nullable<int> Ile_Odp_9 { get; set; }
        public Nullable<int> Ile_Odp_10 { get; set; }
    
        public virtual Ankiety Ankiety { get; set; }
        public virtual Pytania Pytania { get; set; }
    }
}
