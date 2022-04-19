using System;

namespace WebPanel.Models
{
    public class PermisionManager
    {

        public class AccountController
        {
            public class LoginAction
            {
                public string HttpPost { get { return "Permision.Account.Login.HttpGet/D85202DC-4C79-4FA3-816C-BD4E03EF93CE"; } }
                public string HttpGet { get { return "Permision.Account.Login.HttpGet/9CA368C5-8EE9-47C5-A601-A238CBE23FB1"; } }
            }
        }

        public class HomeController
        {
            public class IndexAction
            {
                public string HttpPost { get { return "Permision.Home.Index.HttpPost/8C782231-9FC5-423D-BA14-752956456A4C"; } }
                public string HttpGet { get { return "Permision.Home.Index.HttpGet/25A67B3C-EAB9-45FF-A4CE-DF63B627C64F"; } }
            }
        }

    }
}

