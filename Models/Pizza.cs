using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il Nome è obbligatorio")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "La Descrizione è obbligatoria")]
        [StringLength(10, ErrorMessage = "Più conciso dai")]
        public string? Desc { get; set; }

        [Required(ErrorMessage = "Il Prezzo è obbligatorio")]

        [Range(1, int.MaxValue, ErrorMessage = "Che fai, li paghi per fargli mangiare la pizza?")]
        public int? Prezzo { get; set; }
        public Pizza(int Id, string Nome, string Desc, int Prezzo)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Desc = Desc;
            this.Prezzo = Prezzo;
        }

        public Pizza()
        {
        }
    }

    public class pizzaList
    {
        public List<Pizza> ListaPizze { get; set; }

        public pizzaList()
        {
            ListaPizze = new();

        }
    }
}
