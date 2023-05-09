using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appPosto.Models
{
    public class PostosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do posto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o endereço do posto")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Digite o preço da gasolina comum do posto")]
        public float PrecoGasolinaComum { get; set; }

        [Required(ErrorMessage = "Digite o preço da gasolina aditivada")]
        public float PrecoGasolinaAditivada { get; set; }

        [Required(ErrorMessage = "Digite o preço do Diesel")]
        public float PrecoDiesel { get; set; }

        //nota: Os preços podem ser setados como 0, mas nunca como nulos. O usuário obrigatoriamente precisa informar ao sistema os valores e, caso inexistentes, colocar como 0.
    }
}
