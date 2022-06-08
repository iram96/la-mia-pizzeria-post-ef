using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{



    public class PizzaController : Controller
    {


        public static PizzaContext db = new PizzaContext();

        //List<Pizza> pizzaList = new List<Pizza>();
        public static pizzaList pizze = null;
        public IActionResult Pizzeria()
        {

            if (pizze == null)
            {
                Pizza Margherita = new Pizza("Margherita", "Ingredienti: Mozzarella, Pomodoro e Basilico", 6);
                Pizza Boscaiola = new Pizza("Boscaiola", "Ingredienti: Mozzarella, Salsiccia e Funghi", 7);
                Pizza Bufala = new Pizza("Bufala", "Ingredienti: Mozzarella di bufala, Pomodoro e Basilico", 7);
                Pizza Formaggi = new Pizza("Formaggi", "Ingredienti: Mozzarella, Gorgonzola, Fontina e Taleggio", 9);
                Pizza Salame = new Pizza("Salame", "Ingredienti: Mozzarella, pomodoro e Salame piccante", 8);
                Pizza Funghi = new Pizza("Funghi", "Ingredienti: Mozzarella, pomodoro e Funghi", 7);

                pizze = new();
                //pizze.ListaPizze.Add(Margherita);
                //pizze.ListaPizze.Add(Boscaiola);
                //pizze.ListaPizze.Add(Bufala);
                //pizze.ListaPizze.Add(Formaggi);
                //pizze.ListaPizze.Add(Salame);
                //pizze.ListaPizze.Add(Funghi);

                db.Add(Margherita);
                db.Add(Boscaiola);
                db.Add(Bufala);
                db.SaveChanges();

                //List<Pizza> Pizze = db.Pizzas.OrderBy(pizza => pizza.Nome).ToList<Pizza>();
                //Console.WriteLine(Pizze);
            }


            return View(db);
        }




        public IActionResult CreaPizza()
        {
            Pizza MiaPizza = new Pizza()
            {
                Nome = "",
                Desc = "",
                Prezzo = 0
            };
            return View(MiaPizza);

        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreaSchedaPizza(Pizza DatiPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("CreaPizza", DatiPizza);
            }


            Pizza MiaPizza = new Pizza()
            {
                Nome = DatiPizza.Nome,
                Desc = DatiPizza.Desc,
                Prezzo = DatiPizza.Prezzo
            };
            return View(MiaPizza);
        }

        public IActionResult ShowPizza(int id)
        {
            return View("ShowPizza", db.Pizzas.Find(id));

        }

        public IActionResult AggiornaPizza(Pizza pizza)
        {

            return View("AggiornaPizza", pizza);
        }



        public IActionResult RimuoviPizza(Pizza pizza)
        {

            return View("RimuoviPizza", pizza);
        }




        public IActionResult EditPizza(Pizza pizza)
        {
            //Pizza updatePizza = new Pizza();
            //updatePizza = (Pizza)pizze.pizzas.Where(x => x.Id == pizza.Id);

            Pizza updatePizza = db.Pizzas.Find(pizza.Id);

            updatePizza.Nome = pizza.Nome;
            updatePizza.Desc = pizza.Desc;
            updatePizza.Prezzo = pizza.Prezzo;
            //if (updatePizza.Photo != pizza.Photo)
            //{
            //    updatePizza.Photo = pizza.Photo;
            //}



            return View("ShowPizza", updatePizza);
        }







        [HttpPost]
        public IActionResult Delete(Pizza pizza)
        {
            Pizza updatePizza = db.Pizzas.Find(pizza.Id);
            if (updatePizza.Id == pizza.Id)
            {
                db.Pizzas.Remove(updatePizza);
                db.SaveChanges();
                //Console.WriteLine(ok);
            }
            return RedirectToAction("Pizzeria", pizze);
        }




        // !!! DATABASE !!!






    }
}
