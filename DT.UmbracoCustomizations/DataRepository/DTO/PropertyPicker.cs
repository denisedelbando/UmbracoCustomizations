using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DT.UmbracoCustomizations.DataRepository.DTO
{
    public class PropertyPickerDTO
    {
        public string PropertyAlias { get; set; }
        public string PropertyName { get; set; }
        public bool Mandatory { get; set; }
        public string ContentTypeAlias { get; set; }
    }
}