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
    
    public partial class CommentForum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommentForum()
        {
            this.ReplyForum = new HashSet<ReplyForum>();
        }
    
        public int CommentForum_id { get; set; }
        public int Forum_id { get; set; }
        public System.DateTime CommentTime { get; set; }
        public string Content { get; set; }
        public int User_id { get; set; }
    
        public virtual Forum Forum { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReplyForum> ReplyForum { get; set; }
    }
}
