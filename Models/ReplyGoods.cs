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
    
    public partial class ReplyGoods
    {
        public int ReplyGoods_id { get; set; }
        public int CommentGoods_id { get; set; }
        public int User_id { get; set; }
        public string Content { get; set; }
        public System.DateTime ReplyTime { get; set; }
    
        public virtual CommentGoods CommentGoods { get; set; }
        public virtual Users Users { get; set; }
    }
}
