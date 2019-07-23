using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data
{
    internal static class Configuration
    {
        internal static string ConnectionString => "Server=.\\SQLEXPRESS;Database=MyBillsPaymentSystem;Integrated Security=True;";
    }
}
