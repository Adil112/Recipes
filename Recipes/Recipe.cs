using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Recipes
{
    public class RecMas
    {
        public Recipe[] recipes { get; set; }
    }
    public class Recipe
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string[] Images { get; set; }
        public string LastUpdated { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int Difficulty { get; set; }
    }
    public class ReadJson
    {
        public RecMas Read()
        {
            var recipe = JsonConvert.DeserializeObject<RecMas>(File.ReadAllText("Recipes.json"));
            return recipe;
        }
       
    }

    
}
