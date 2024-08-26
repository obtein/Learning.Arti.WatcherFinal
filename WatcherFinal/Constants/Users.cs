using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatcherFinal.Constants
{
    public static class Users
    {
        public static Dictionary<string,string> UserList;

         static Users ()
        {
            UserList = new Dictionary<string, string>();
            UserList.Add( "admin", "admin" );
            UserList.Add( "user", "user" );
        }
    }
}
