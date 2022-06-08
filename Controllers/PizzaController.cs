using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        //List<Pizza> pizzaList = new List<Pizza>();
        public static pizzaList pizze;
        public IActionResult Pizzeria()
        {
            pizze = new pizzaList();


            Pizza Pizza1 = new Pizza(0, "Margherita", "Pomodoro Mozzarella", 10);

            Pizza Pizza2 = new Pizza(1, "Marinara", "Pomodoro Origano", 10);

            Pizza Pizza3 = new Pizza(2, "Diavola", "Pomodoro Mozzarella Salame piccante", 15);


            pizze.ListaPizze.Add(Pizza1);
            pizze.ListaPizze.Add(Pizza2);
            pizze.ListaPizze.Add(Pizza3);

            return View(pizze);
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
            return View("ShowPizza", pizze.ListaPizze[id]);
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

            Pizza updatePizza = pizze.ListaPizze.Find(x => x.Id == pizza.Id);

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
            Pizza updatePizza = pizze.ListaPizze.Find(x => x.Id == pizza.Id);
            if (updatePizza.Id == pizza.Id)
            {
                pizze.ListaPizze.Remove(updatePizza);
                //Console.WriteLine(ok);
            }
            return RedirectToAction("Pizzeria");
        }
    }
}
