using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace la_mia_pizzeria_static.Models
{

    [Table("pizzaNuova")]
    public class PizzaNuova
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il Nome è obbligatorio")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "La Descrizione è obbligatoria")]
        //[StringLength(10, ErrorMessage = "Più conciso dai")]
        public string? Desc { get; set; }

        [Required(ErrorMessage = "Il Prezzo è obbligatorio")]

        [Range(1, int.MaxValue, ErrorMessage = "Che fai, gli paghi per fargli mangiare la pizza?")]
        public int? Prezzo { get; set; }
        public PizzaNuova(/*int Id,*/ string Nome, string Desc, int Prezzo)
        {
            //this.Id = Id;
            this.Nome = Nome;
            this.Desc = Desc;
            this.Prezzo = Prezzo;
        }

        public PizzaNuova()
        {
        }
    }

    //public class pizzaList
    //{
    //    public List<Pizza> ListaPizze { get; set; }

    //    public pizzaList()
    //    {
    //        ListaPizze = new();

    //    }
    //}

    public class PizzaNuovaContext : DbContext
    {
        public DbSet<PizzaNuova> Pizzas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Pizzeria;Integrated Security=True;Pooling=False");
        }
    }
}
