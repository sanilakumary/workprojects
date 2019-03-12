using CustomUpholstery.DataObject;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Helper;


namespace CustomUpholstery.DataAccessLayer
{
    public class ApplicationRoleRetriever : BaseClass
    {
        public List<ApplicationRoleDO> GetApplicationRole(string actionMode, int CompanyCode)
        {

            List<ApplicationRoleDO> roles = new List<ApplicationRoleDO>();
            var ApplicationRoleDO;
            for (int i = 1; i <= 5; i++)
            {
                role = new ApplicationRoleDO();

                role.AllicationId = i;
                role.ApplicationDesc = "description" + i.ToString();
                role.CompanyCode = 200;
                role.Status = 100;
                //currentAttribute.EditMode = currentjsonAD.IsEditable.ToLower() == "y" ? true : false;
                applicationCollection.Add(role);

            }

            return roles;
        }
        }
    }

            
//            const string functionName = "appMaster";

//            string URL = String.Format("{0}?functionName={1}&mode={2}&CompanyCode={3}",
//                _serviceUrl,
//                functionName,
//                actionMode,
//                CompanyCode);

//            HttpResponseMessage response = CallWebService(URL);

//            JsonAttributeDO jsonAttribute = null;
//            List<ApplicationRoleDO> applicationCollection = null;

//            if (response.IsSuccessStatusCode)
//            {
//                jsonApplication = JsonConvert.DeserializeObject<JsonApplicationDO>(response.Content.ReadAsStringAsync().Result);
//            }
//            else if (response.StatusCode == HttpStatusCode.BadRequest)
//            {
//                jsonErrorMessage ErrorMessage = JsonConvert.DeserializeObject<jsonErrorMessage>(response.Content.ReadAsStringAsync().Result);
//                Exception error = new Exception(ErrorMessage.error[0].code + " - " + ErrorMessage.error[0].message + " - " + URL);
//                ExceptionHandler.HandleException(error);
//                return null;
//            }
//            else
//            {
//                Exception error = new Exception(response.StatusCode + " - " + URL);
//                ExceptionHandler.HandleException(error);
//                return null;
//            }

//            if (jsonApplication != null && jsonApplication.Applications.Count > 0)
//            {
//                applicationCollection = new List<ApplicationRoleDO>();

//                foreach (Applications currentjsonAP in jsonAttribute.Applications)
//                {
//                    ApplicationRoleDO currentApplication = ObjectFactory<ApplicationRoleDO>.CreateObject("ApplicationRoleDO");
//                    currentApplication.AllicationId = Converter.ConvertToInteger(currentjsonAP.ApplicationId);
//                    currentApplication.ApplicationDesc = currentjsonAP.ApplicationDesc;
//                    currentApplication.CompanyCode = currentjsonAP.CompanyCode;
//                    currentApplication.Status = Converter.ConvertToInteger(currentjsonAP.Status);
//                    //currentAttribute.EditMode = currentjsonAD.IsEditable.ToLower() == "y" ? true : false;
//                    applicationCollection.Add(currentApplication);
//                }
//            }

//            return applicationCollection;
//        }
//    }
//}

    

