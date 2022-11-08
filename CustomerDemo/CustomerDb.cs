using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace CustomerDemo
{
    public class CustomerDb
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        public CustomerDb()
        {
            string constr = "server=.\\SQLEXPRESS;database=SoleraEmployees;user id=sa;pwd=sa";
            conn = new SqlConnection(constr);
        }
        //private List<Customer> lcs;
        //public CustomerCollection()
        //{
        //    lcs = new List<Customer>();
        //}

        public int GenerateID()
        {
            string cmdstr = "select max(cid) from Customer";
            cmd = new SqlCommand(cmdstr, conn);
            int genid = 0;
            try
            {    
                conn.Open();
                object data = cmd.ExecuteScalar();
                if (data.ToString().Equals(""))
                {
                    genid = 1; ;
                }
                 else
                 {
                    genid= Convert.ToInt32(data)+1;
                 }       
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if(conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return genid;
        }

        public void AddCustomer(Customer c)
        {
            string insStr = $"insert into Customer values({c.CID},'{c.CNAME}','{c.CGENDER}','{c.ADDRESS}','{c.MOBILE}')";
            cmd = new SqlCommand(insStr, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
                ////Console.WriteLine("Inserted Successgully");
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

        }
        public bool UpdateCustomer(int cid, Customer c)
        {
            string uptstr = $"update Customer set cid={c.CID},cname='{c.CNAME}',cgender='{c.CGENDER}',caddress='{c.ADDRESS}',cmobile='{c.MOBILE}' where cid={cid}";
            cmd = new SqlCommand(uptstr, conn);
            try
            {
                conn.Open();
                int rEffect=cmd.ExecuteNonQuery();
                if (rEffect == 0)
                    return false;
                else
                    return true;
            }
            catch (SqlException ex)
            {
                throw ex;
                ////Console.WriteLine("Inserted Successgully");
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
        public bool DeleteCustomer(int cid)
        {
            string dlt = $"delete from Customer where cid={cid}";
            cmd = new SqlCommand(dlt, conn);
            try
            {
                conn.Open();
                int rEffect = cmd.ExecuteNonQuery();
                if (rEffect == 0)
                {
                    Console.WriteLine("Not updated");
                    return false;
                }
                else
                {
                    Console.WriteLine("Updated Successfully");
                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
                ////Console.WriteLine("Inserted Successgully");
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }


        public Customer FindCustomer(int cid)
        {
            string flt = $"select * from Customer where cid={cid}";
            cmd = new SqlCommand(flt, conn);
            SqlDataReader dr = null;
            Customer cr=null;
            try
            {
                conn.Open();
                dr= cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    cr = new Customer
                    {
                        CID = dr.GetInt32(0),
                        CNAME = dr.GetString(1),
                        CGENDER = dr.GetString(2),
                        ADDRESS = dr.GetString(3),
                        MOBILE = dr.GetString(4)
                    };
                    return cr;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw ex;
                ////Console.WriteLine("Inserted Successgully");
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> lcst= new List<Customer>(); 
            string sltStr = "select * from Customer";
            cmd = new SqlCommand(sltStr, conn);
            SqlDataReader dr = null;
            Customer cr = null;
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    cr = new Customer
                    {
                        CID = dr.GetInt32(0),
                        CNAME = dr.GetString(1),
                        CGENDER = dr.GetString(2),
                        ADDRESS = dr.GetString(3),
                        MOBILE = dr.GetString(4)
                    };
                    lcst.Add(cr);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
                ////Console.WriteLine("Inserted Successgully");
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return lcst;
        }


    }
}
