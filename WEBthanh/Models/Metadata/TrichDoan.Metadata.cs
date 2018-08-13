using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WEBthanh.Models
{
    [MetadataTypeAttribute(typeof(TrichDoanMetadata))]
    public partial class TrichDoan
    {
        internal sealed class TrichDoanMetadata
        {
            public int MaTD { get; set; }
            public string TenTD { get; set; }
            public string Anh { get; set; }
            public Nullable<System.DateTime> NgayCapNhat { get; set; }
            public string TacGia { get; set; }
            public string MoTa { get; set; }

        }
    }
}