using BusinessCase.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace BusinessCase.Models
{
    public enum OrderBy
    {
        Id,
        Name,
        Date,
        Price
    }

    public enum OrderType
    {
        Ascending,
        Descending
    }

    public class ConfigurationModel
    {
        public ConfigurationModel(OrderBy orderBy, OrderType orderType)
        {
            this.orderBy = orderBy;
            this.orderType = orderType;
        }

        public OrderBy orderBy { get; set; }
        public OrderType orderType { get; set; }

        public override string ToString()
        {
            return $"\tOrderBy: {orderBy}\n" +
                   $"\tSort: {orderType}";
        }
    }


}
