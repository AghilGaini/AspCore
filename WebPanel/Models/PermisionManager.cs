namespace WebPanel.Models
{
    public static class PermisionManager
    {

        public static class AccountController
        {
            public static class LoginAction
            {
                public static string HttpPost { get { return "1"; } }
                public static string HttpGet { get { return "2"; } }
            }
        }

        public static class HomeController
        {
            public static class IndexAction
            {
                public static string HttpPost { get { return "1"; } }
                public static string HttpGet { get { return "2"; } }
            }
        }

    }
}

