﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_Util
{
    public static class WebConfig
    {
        public static string GetStrinConnection =>
        @"Data Source=LAPTOP-PQH9GV4C;Initial Catalog=Equals_Elir;User ID={usuario_db};password={senha_db}";

        public static string naoprocessados => @"C:\naoprocessados\";
        public static string processados => @"C:\processados\";


    }
}
