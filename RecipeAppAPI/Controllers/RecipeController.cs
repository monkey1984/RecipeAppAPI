using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeAppAPI.Models;

namespace RecipeAppAPI.Controllers
{
    
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Recipes()
        {
            Recipe_DL recData = new Recipe_DL();
            List<Recipe> rec = recData.Getdata();
            return View(rec);
        }

        public ActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRecipe(Recipe recipe)
        {
            ViewBag.Title = "Add Recipe";

            try
            {
                if (ModelState.IsValid)
                {
                    Recipe_DL db = new Recipe_DL();
                    if (db.SaveData(recipe))
                    {
                        ModelState.Clear();
                    }
                }
                return View("Confirmation", recipe);
            }
            catch
            {
                return View();
            }
        }
    }
}
