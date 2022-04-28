using Database.Domain.Entities;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class PermisionManager
    {

        public static class Permisions
        {
            #region AccountController
            public const string Account_Login_HttpPost = "D85202DC-4C79-4FA3-816C-BD4E03EF93CE";
            public const string Account_Login_HttpGet = "9CA368C5-8EE9-47C5-A601-A238CBE23FB1";
            #endregion

            #region HomeController
            public const string Home_Index_HttpPost = "8C782231-9FC5-423D-BA14-752956456A4C";
            public const string Home_Index_HttpGet = "25A67B3C-EAB9-45FF-A4CE-DF63B627C64F";
            public const string Home_Test_HttpGet = "AB7826A4-C5A3-4462-BFC7-841B1D7A918F";
            #endregion

            #region TestCotnroller
            public const string Test_Index_HttpPost = "4C529D65-E442-4CFE-9388-6B4F42C96B5C";
            public const string Test_Index_HttpGet = "7785109F-C308-4A7B-A46A-DFDC845A56DD";
            #endregion

            #region UserController
            public const string User_Index_HttpGet = "464446D9-9291-4451-91C6-CD8E707CF69E";
            public const string User_Create_HttpGet = "6B2F6298-5E60-4ABD-9DB9-2E7430FDC391";
            public const string User_Create_HttpPost = "DCB158BE-24FA-4A95-B976-852F0D1C8ED2";
            public const string User_CreateUserRole_HttpGet = "298854A5-C897-4090-9636-A34165813C70";
            public const string User_CreateUserRole_HttpPost = "D59F036F-2170-4E2A-92AB-5C6DBE57CB93";
            #endregion

            #region RoleController
            public const string Role_Index_HttpGet = "E9B11EE6-22A7-4CB4-B1AF-A59F20FD7C57";
            public const string Role_Create_HttpGet = "33ED3712-2D21-481F-AFB2-032AAFB68B9C";
            public const string Role_Create_HttpPost = "D19EE06C-2815-424F-A296-6431664E6C87";
            public const string Role_CreateRoleUser_HttpPost = "6D3F4FC2-A964-4F0D-991E-FD77BD7CBA68";
            public const string Role_CreateRoleUser_HttpGet = "F2D39210-D5CD-4885-9889-907B5039ADA3";
            #endregion

            #region PermisionController
            public const string Permision_Index_HttpPost = "D86256A7-BE39-419F-99D8-505E1F99941D";
            public const string Permision_Index_HttpGet = "66813E4C-7204-4948-AA93-E4C9D4568416";
            #endregion

            #region StudentController
            public const string Student_Index_HttpGet = "ADDB26FC-8E7B-4B7D-8432-536D5BBF9347";
            public const string Student_Create_HttpGet = "4810303A-4A23-42E5-A7F7-6682C1EF5F47";
            public const string Student_Create_HttpPost = "E18733AC-318B-4C22-A004-54215E9ED8AE";
            #endregion

            #region CourseController
            public const string Course_Index_HttpGet = "76DC5DF5-A0D9-4B7D-8177-5F3188955835";
            #endregion

        }


        public List<KeyValuePair<string, string>> GetPrmisions()
        {
            var type = typeof(Permisions);
            var fileds = type.GetFields();
            var permisions = new List<KeyValuePair<string, string>>();

            foreach (var item in fileds)
            {
                var value = item.GetValue(type);
                var title = item.Name.Replace("_", " ");
                permisions.Add(new KeyValuePair<string, string>(title, value.ToString()));
            }


            #region Permision Checker

            //var mainClass = new PermisionManager();
            //var types = new PermisionManager().GetType().GetNestedTypes().ToList();

            //for (int i = 0; i < types.Count; i++)
            //{
            //    var typeInfo = types[i];
            //    var nestedTypesInfo = types[i].GetNestedTypes();
            //    if (nestedTypesInfo.Length > 0)
            //    {
            //        types.AddRange(nestedTypesInfo);
            //    }
            //}

            //var properties = new List<KeyValuePair<PropertyInfo, object>>();

            //foreach (var item in types)
            //{

            //    var propertyInfos = item.GetProperties();
            //    if (propertyInfos.Length > 0)
            //    {
            //        foreach (var item1 in propertyInfos)
            //        {
            //            properties.Add(new KeyValuePair<PropertyInfo, object>(item1, Activator.CreateInstance(item)));
            //        }
            //    }
            //}

            //var permisions = new List<KeyValuePair<string, string>>();

            //foreach (var item in properties)
            //{
            //    var val = item.Key.GetValue(item.Value);
            //    var title = val.ToString().Split('/')[0];
            //    var permision = val.ToString().Split('/')[1];

            //    permisions.Add(new KeyValuePair<string, string>(title, permision));
            //}

            return permisions;

            #endregion
        }

        public void SetPermisions(IUnitOfWorkRepository context)
        {
            var databasePermisions = context._permisionRepository.GetAll();
            var newPermisions = new List<PermisionDomain>();
            var res = new PermisionManager().GetPrmisions();
            foreach (var item in res)
            {
                if (!databasePermisions.Any(r => r.Value == item.Value))
                    newPermisions.Add(new PermisionDomain()
                    {
                        Title = item.Key,
                        Value = item.Value,
                    });
            }

            context._permisionRepository.AddRange(newPermisions);
            context.Complete();

        }

    }
}
