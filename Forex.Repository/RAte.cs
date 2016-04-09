using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Forex.Repository
{

    public static class Rate
    {

        public static bool SaveRate(Model.Rate rate)
        {
            using( SqlConnection con = new SqlConnection(@"Data Source = VIVEK-PC\SQLEXPRESS; Initial Catalog=Forex; Integrated Security=SSPI;"))
            {
                con.Open();
                using (SqlCommand comm = new SqlCommand("dbo.SaveRates", con))
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@currency", rate.CurrencyPair));
                    comm.Parameters.Add(new SqlParameter("@inDate", rate.RateDateTime));
                    comm.Parameters.Add(new SqlParameter("@bid", rate.Bid));
                    comm.Parameters.Add(new SqlParameter("@ask", rate.Ask));
                    comm.ExecuteNonQuery();
                }
                con.Close();
            }
            return true;
        }

    }

}
