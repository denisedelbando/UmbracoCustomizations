//using System;
//using System.Linq;
//using Umbraco.Core;
//using Umbraco.Core.Events;
//using Umbraco.Core.Logging;
//using Umbraco.Core.Models;
//using Umbraco.Core.Services;

//namespace DT.UmbracoCustomizations
//{
//    #region todo
//    //ToDo
//    //What to do when:
//    //if there are documents of that content type
//    //if there are mandatory field. does it publish?
//    //what about compositions?
//    #endregion
//    public class InitializeDTCustomCreateValue : ApplicationEventHandler
//    {
//        //FIND THIS DOCUMENT TYPE
//        string alias = "DTCustomCreateValue";

//        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
//        {
//            LogHelper.Info(
//                        typeof(InitializeDTCustomCreateValue),
//                        "DT.UmbracoCustomization initialized");
//            //when content type (document type) is saved
//            ContentTypeService.SavedContentType += ContentTypeService_SavedContentType;

//            //when the data type itself is saved
//            DataTypeService.Saved += DataTypeService_Saved;
//        }
//        private void ContentTypeService_SavedContentType(IContentTypeService sender, SaveEventArgs<IContentType> e)
//        {
//            LogHelper.Info(
//                        typeof(InitializeDTCustomCreateValue),
//                        "DT.UmbracoCustomization ContentTypeService_SavedContentType called");
//            var cs = ApplicationContext.Current.Services.ContentService;
//            var cts = ApplicationContext.Current.Services.ContentTypeService;
//            var dts = ApplicationContext.Current.Services.DataTypeService;
//            try
//            {
//                foreach (var savedEntity in e.SavedEntities)
//                {
//                    var newProperties = savedEntity.PropertyTypes.Where(xx => xx.IsNewEntity() && xx.PropertyEditorAlias == alias);
//                    bool hasupdate = false;
//                    if (newProperties.Any())
//                    {
//                        //get all content with this content type
//                        foreach (var content in cs.GetContentOfContentType(savedEntity.Id).Where(xx => xx.Published))
//                        {

//                            foreach (var property in newProperties)
//                            {
//                                var prevalues = dts.GetPreValuesByDataTypeId(property.DataTypeDefinitionId);

//                                if (prevalues.Any())
//                                {
//                                    content.SetValue(property.Alias, prevalues.First());
//                                    cs.SaveAndPublishWithStatus(content);
//                                    hasupdate = true;
//                                }
//                            }
//                        }


//                    }
//                    if (hasupdate)
//                    {
//                        LogHelper.Info(
//                        typeof(InitializeDTCustomCreateValue),
//                        string.Format(
//                            "DT.UmbracoCustomization successful update on pages with content type {0}",
//                            savedEntity.Name));
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                LogHelper.Error(
//                    typeof(InitializeDTCustomCreateValue),
//                    string.Format(
//                        "DT.UmbracoCustomization error. Unable to save content type. \n Source: {0} \nMessage: {1}",
//                        ex.Source,
//                        ex.Message),
//                    ex);

//                throw ex;

//            }
//        }

//        private void DataTypeService_Saved(IDataTypeService sender, SaveEventArgs<IDataTypeDefinition> e)
//        {
//            try
//            {
//                LogHelper.Info(
//                        typeof(InitializeDTCustomCreateValue),
//                        "DT.UmbracoCustomization DataTypeService_Saved called");
//                //we add create date < update date to make sure that it is an update not a create event
//                var savedEntities = e.SavedEntities.Where(xx => xx.PropertyEditorAlias == alias && xx.CreateDate < xx.UpdateDate);
//                if (savedEntities.Any())
//                {
//                    string updateon = "";
//                    var cts = ApplicationContext.Current.Services.ContentTypeService;
//                    var cs = ApplicationContext.Current.Services.ContentService;
//                    var dts = ApplicationContext.Current.Services.DataTypeService;
//                    var allContentTypes = cts.GetAllContentTypes();
//                    foreach (var savedEntity in savedEntities)
//                    {
//                        //get all content type
//                        foreach (var contentType in allContentTypes)
//                        {
//                            bool hasupdate = false;
//                            //find if content type has this id
//                            var propertyTypeList = contentType.PropertyTypes.Where(xx => xx.DataTypeDefinitionId == savedEntity.Id);
//                            if (propertyTypeList.Any())
//                            {
//                                //get all published content with this content type
//                                foreach (var content in cs.GetContentOfContentType(contentType.Id).Where(xx => xx.Published))
//                                {

//                                    foreach (var property in propertyTypeList)
//                                    {
//                                        var prevalues = dts.GetPreValuesByDataTypeId(property.DataTypeDefinitionId);

//                                        if (prevalues.Any())
//                                        {
//                                            content.SetValue(property.Alias, prevalues.First());
//                                            cs.SaveAndPublishWithStatus(content);
//                                            hasupdate = true;
//                                        }
//                                    }

//                                }
//                            }
//                            if (hasupdate)
//                            {
//                                updateon += contentType.Name + ", ";
//                            }
//                        }
//                        if (!string.IsNullOrEmpty(updateon))
//                        {
//                            LogHelper.Info(
//                            typeof(InitializeDTCustomCreateValue),
//                            string.Format(
//                                "DT.UmbracoCustomization successful update on pages with content types {0}",
//                                updateon));
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                LogHelper.Error(
//                    typeof(InitializeDTCustomCreateValue),
//                    string.Format(
//                        "DT.UmbracoCustomization error. Unable to save content type. \n Source: {0} \nMessage: {1}",
//                        ex.Source,
//                        ex.Message),
//                    ex);

//                throw ex;

//            }
//        }
//    }
//}