using DT.UmbracoCustomizations.DataRepository.DTO;
using System.Collections.Generic;
using Umbraco.Web;

namespace DT.UmbracoCustomizations.DataRepository
{
    public class UmbracoRepositories
    {
        public IEnumerable<PropertyPickerDTO> GetContentProperties()
        {
            var res = UmbracoContext.Current.Application.DatabaseContext.Database.Fetch<PropertyPickerDTO>(@"
                SELECT cpt.[Alias] AS PropertyAlias
                    ,[Name] AS PropertyName
	                ,[mandatory] AS Mandatory
	                ,cct.alias AS ContentTypeAlias
	            FROM cmsPropertyType cpt
	            LEFT JOIN cmsContentType cct on cct.nodeId = cpt.contentTypeId
	            WHERE cct.Alias NOT IN ('Member','Folder','Image','File')
	            ORDER BY propertyTypeGroupId");


            var prebuildProps = new List<PropertyPickerDTO>();
            string globalProperties = "Global Properties";
            prebuildProps.Add(new PropertyPickerDTO()
            {
                ContentTypeAlias = globalProperties,
                Mandatory = true,
                PropertyName = "Page ID",
                PropertyAlias = "id"
            });
            prebuildProps.Add(new PropertyPickerDTO()
            {
                ContentTypeAlias = globalProperties,
                Mandatory = true,
                PropertyName = "Create Date",
                PropertyAlias = "createDate"
            });
            prebuildProps.Add(new PropertyPickerDTO()
            {
                ContentTypeAlias = globalProperties,
                Mandatory = true,
                PropertyName = "Last Update",
                PropertyAlias = "updateDate"
            });

            prebuildProps.AddRange(res);

            return prebuildProps;
        }
    }
}