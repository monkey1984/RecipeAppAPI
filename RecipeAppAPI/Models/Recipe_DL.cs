using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace RecipeAppAPI.Models
{
    public class Recipe_DL
    {
        private string cs = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public List<Recipe> Getdata()
        {
            List<Recipe> li = new List<Recipe>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("sp_getRecipes", con);

                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Recipe rec = new Recipe();

                    rec.RecipeID = Convert.ToInt32(rdr.GetValue(0).ToString());
                    rec.RecipeName = rdr.GetValue(1).ToString();
                    rec.Rating = Convert.ToInt32(rdr.GetValue(2).ToString());
                    rec.Hours = Convert.ToInt32(rdr.GetValue(3).ToString());
                    rec.Minutes = Convert.ToInt32(rdr.GetValue(4).ToString());
                    rec.Instructions = rdr.GetValue(5).ToString();

                    li.Add(rec);
                }
                return li;

            }

        } // end GetData

        public bool SaveData(Recipe recipe)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("sp_saveRecipes", con);


                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
                cmd.Parameters.AddWithValue("@Rating", recipe.Rating);
                cmd.Parameters.AddWithValue("@Minutes", recipe.Minutes);
                cmd.Parameters.AddWithValue("@Hours", recipe.Hours);
                cmd.Parameters.AddWithValue("@Instructions", recipe.Instructions);
                con.Open();

                int i = cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("In save recipes");
                if (i >= 1)

                    return true;
                else

                    return false;

            }
        }
    }
}