using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Peer
{
    public static class Globals
    {
        public static int adminID;
        public static string connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Z:\CNIT255\GitHub\Peer\Peerdb_fixed.accdb;Persist Security Info=False";

    }
}
