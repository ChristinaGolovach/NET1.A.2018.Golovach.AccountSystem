//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORMDBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public int Id { get; set; }
        public int AccountTypeId { get; set; }
        public int AccountOwnerId { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public int BonusPoints { get; set; }
        public bool IsOponed { get; set; }
    
        public virtual AccountOwner AccountOwner { get; set; }
        public virtual AccountType AccountType { get; set; }
    }
}
