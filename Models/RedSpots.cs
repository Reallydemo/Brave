//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RedSpots
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RedSpots()
        {
            this.RedShare = new HashSet<RedShare>();
            this.CommentRedSpots = new HashSet<CommentRedSpots>();
        }
    
        public int RedSpots_id { get; set; }
        public string RedSpotsName { get; set; }
        public string RedSpotsDes { get; set; }
        public string Location { get; set; }
        public Nullable<int> RedSpotsClick { get; set; }
        public string RedImage { get; set; }
        public string RedAbstract { get; set; }
        public string RedArea { get; set; }
        public int RedSection_id { get; set; }
    
        public virtual RedSection RedSection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RedShare> RedShare { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentRedSpots> CommentRedSpots { get; set; }
    }
}
