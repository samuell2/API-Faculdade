using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain.Interfaces
{
    public interface IFreteRepository
    {
        public double CalculoPeso(Frete frete);
        public double TaxaEstado(Frete frete);
        public double TaxaQuebravel(Frete frete);
    }
}