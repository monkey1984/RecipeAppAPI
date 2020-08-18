using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RecipeAppAPI.Models;

namespace RecipeAppAPI.Controllers
{
    /// <summary>
    /// This is you are given all information about Recipes.
    /// </summary>
    public class ValuesController : ApiController
    {
   
        Recipe_DL recData = new Recipe_DL();
        List<Recipe> recipes = null;

        public ValuesController()
        {
            recipes = recData.Getdata();  
        }

        // GET: api/Values
        public List<Recipe> Get()
        {
            return recipes;
        }

        /// <summary>
        /// This gets the recipe by RecipeID. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A recipe.</returns>
        // GET: api/Recipe/5
        public Recipe Get(int id)
        {
            return recipes.Where(x => x.RecipeID == id).FirstOrDefault();
        }
        /// <summary>
        /// This adds a recipe
        /// </summary>
        /// <param name="val"></param>
        // POST: api/Values 
        public void Post(Recipe val)
        {
                recData.SaveData(val);
        }

        /// <summary>
        /// This updates a recipe at id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        // PUT: api/Values/5
        public void Put(int id, Recipe val)
        {
            recipes[id] = val;
        }
        
        /// <summary>
        /// This deletes a recipe at id
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/Values/5
        public void Delete(int id)
        {
            recipes.RemoveAt(id);
        }
    }
}
