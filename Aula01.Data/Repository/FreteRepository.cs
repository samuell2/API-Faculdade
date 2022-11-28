using Aula01.Domain;
using Aula01.Domain.Enum;
using Aula01.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Data.Repository
{
    public class FreteRepository : IFreteRepository
    {
        public double CalculoPeso(Frete frete)
        {
            if (frete.Peso >= 0 && frete.Peso <= 10) return 0.8 * frete.Peso;   
            else if (frete.Peso >= 10.1 && frete.Peso <= 20) return 0.96 * frete.Peso;
            else return 2.1 * frete.Peso;
        }

        public double TaxaEstado(Frete frete)
        {
            if (frete.UF == "MG" || frete.UF == "SP" || frete.UF == "ES") return frete.Peso * 5;
            else if (frete.UF == "PR" || frete.UF == "SC" || frete.UF == "RS") return frete.Peso * 15;
            else if (frete.UF == "AC" || frete.UF == "AM" || frete.UF == "RO" || frete.UF == "RR" || frete.UF == "AP" || frete.UF == "PA" || frete.UF == "TO") return frete.Peso * 50;
            else return frete.Peso * 35;
        }

        public double TaxaQuebravel(Frete frete)
        {
            if (frete.EhQuebravel) return CalculoPeso(frete) * 0.25;
            else return 0;
        }
    }
}