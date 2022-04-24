using Database.Domain.Entities;
using Database.Domain.Interfaces;
using DatabaseAccess.EFCore;
using DatabaseAccess.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
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
        public class AccountController
        {
            public class LoginAction
            {
                public static string HttpPost { get { return "Permision.Account.Login.HttpPost/D85202DC-4C79-4FA3-816C-BD4E03EF93CE"; } }
                public static string HttpGet { get { return "Permision.Account.Login.HttpGet/9CA368C5-8EE9-47C5-A601-A238CBE23FB1"; } }
            }
        }

        public class HomeController
        {
            public class IndexAction
            {
                public static string HttpPost { get { return "Permision.Home.Index.HttpPost/8C782231-9FC5-423D-BA14-752956456A4C"; } }
                public static string HttpGet { get { return "Permision.Home.Index.HttpGet/25A67B3C-EAB9-45FF-A4CE-DF63B627C64F"; } }
            }
            public class TestAction
            {
                public static string HttpGet { get { return "Permision.Home.Test.HttpGet/AB7826A4-C5A3-4462-BFC7-841B1D7A918F"; } }
            }
        }

        public class TestController
        {
            public class IndexAction
            {
                public static string HttpPost { get { return "Permision.Test.Index.HttpPost/4C529D65-E442-4CFE-9388-6B4F42C96B5C"; } }
                public static string HttpGet { get { return "Permision.Test.Index.HttpGet/7785109F-C308-4A7B-A46A-DFDC845A56DD"; } }
            }
        }

        public List<KeyValuePair<string, string>> GetPrmisions()
        {
            #region Permision Checker

            var mainClass = new PermisionManager();
            var types = new PermisionManager().GetType().GetNestedTypes().ToList();

            for (int i = 0; i < types.Count; i++)
            {
                var typeInfo = types[i];
                var nestedTypesInfo = types[i].GetNestedTypes();
                if (nestedTypesInfo.Length > 0)
                {
                    types.AddRange(nestedTypesInfo);
                }
            }

            var properties = new List<KeyValuePair<PropertyInfo, object>>();

            foreach (var item in types)
            {
                var propertyInfos = item.GetProperties();
                if (propertyInfos.Length > 0)
                {
                    foreach (var item1 in propertyInfos)
                    {
                        properties.Add(new KeyValuePair<PropertyInfo, object>(item1, Activator.CreateInstance(item)));
                    }
                }
            }

            var permisions = new List<KeyValuePair<string, string>>();

            foreach (var item in properties)
            {
                var val = item.Key.GetValue(item.Value);
                var title = val.ToString().Split('/')[0];
                var permision = val.ToString().Split('/')[1];

                permisions.Add(new KeyValuePair<string, string>(title, permision));
            }


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
