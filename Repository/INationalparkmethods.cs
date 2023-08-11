using System.Data.SqlClient;
using Nationalparks.Model;


namespace Nationalparks.Repository
{
    public interface INationalparkmethods
    {
        public nationalpark addnationalpark(nationalpark nationalpark);
        public nationalpark GetNationalpark(int id); 
        public List<nationalpark> GetAllNationalparks();
        public nationalpark updatenationalpark(int id,nationalpark nationalpark);
        public int removenationalpark(int id);  

    }
    public class Nationalparkmethods : INationalparkmethods
    {
        SqlConnection conn = null;
        public Nationalparkmethods()
        {
            conn = new SqlConnection("Data Source=LTPCHE032529213\\sqlexpress;Initial Catalog=nationalparks;Integrated Security=True");
        }
        public nationalpark addnationalpark(nationalpark nationalpark)
        {
         
            SqlCommand cmd = new SqlCommand("[dbo].[insertProcedure]",conn);
            conn.Open();
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param2", nationalpark.name);
            cmd.Parameters.AddWithValue("@param3", nationalpark.place);
            cmd.Parameters.AddWithValue("@param4", nationalpark.state);
            cmd.Parameters.AddWithValue("@param5", nationalpark.image);
            int k=cmd.ExecuteNonQuery();
            conn.Close();
          
            if(k > 0)
            {
                return nationalpark;
            }
            else
            {
                return null;
            }
        }

        public List<nationalpark> GetAllNationalparks()
        {
            List<nationalpark> k = new List<nationalpark>();
        
         
            SqlCommand cmd = new SqlCommand("Select * from nationalpark",conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    nationalpark p = new nationalpark();
                    p.Sno = Convert.ToInt32(dr["Sno"]);
                    p.name = dr["name"].ToString();
                    p.place = dr["place"].ToString();
                    p.state = dr["state"].ToString();
                    p.image = dr["pic"].ToString();
                    k.Add(p);

                }
            }
            else
            {
                k = null;
            }
            conn.Close();
            return k;

            
        }

        public nationalpark GetNationalpark(int id)
        {  
            SqlCommand cmd = new SqlCommand($"Select * from nationalpark where Sno={id}",conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            nationalpark p=new nationalpark();
            if (dr.Read())
            {
                p.Sno = Convert.ToInt32(dr["Sno"]);
                p.name = dr["name"].ToString();
                p.place = dr["place"].ToString();
                p.state = dr["state"].ToString();
                p.image = dr["pic"].ToString();


            }
            conn.Close();
            return p;

        }

        public int removenationalpark(int id)
        {
            
            
            SqlCommand cmd = new SqlCommand($"Delete from nationalpark where Sno={id}", conn);
            conn.Open();
             int k = cmd.ExecuteNonQuery();
            conn.Close();
            if (k > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public nationalpark updatenationalpark(int id, nationalpark nationalpark)
        {
            
           
            SqlCommand cmd = new SqlCommand("[dbo].[updateProcedure]", conn);
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param2", nationalpark.name);
            cmd.Parameters.AddWithValue("@param3", nationalpark.place);
            cmd.Parameters.AddWithValue("@param4", nationalpark.state);
            cmd.Parameters.AddWithValue("@param5", nationalpark.image);
            cmd.Parameters.AddWithValue("@param6", id);
            int k = cmd.ExecuteNonQuery();
            conn.Close();
            if (k > 0)
            {
                return nationalpark;
            }
            else
            {
                return null;
            }
        }
    }
}
