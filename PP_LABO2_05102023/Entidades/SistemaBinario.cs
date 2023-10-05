using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaBinario : Numeracion
    {

        //CONSTRUCTORES
        public SistemaBinario(string valor)
            :base(valor)
        {

        }

        //PROPIEDAD
        internal override double ValorNumerico
        {
            get
            {
                return this.ValorNumerico;
            }
        }

        //METODOS
        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            return new SistemaBinario(base.valor);
        }

        protected override bool EsNumeracionValida(string valor)
        {
            return base.EsNumeracionValida(valor) && this.EsSistemaBinarioValido(valor);
        }

        private bool EsSistemaBinarioValido(string valor)
        {
            string patronDeBusqueda = "^[0|1]+$";

            return Regex.IsMatch(valor, patronDeBusqueda);
        }

        private SistemaDecimal BinarioADecimal()
        {
            if(base.valor == Numeracion.msgError)
            {
                return new SistemaDecimal(double.MinValue.ToString());
            }
            else
            {
                double resultado = 0;
                int cantidadCaracteres = valor.Length;

                foreach (char caracter in valor)
                {
                    cantidadCaracteres--;
                    if (caracter == '1')
                    {
                        resultado += (int)Math.Pow(2, cantidadCaracteres);
                    }
                }
                return new SistemaDecimal(resultado.ToString());
            }
        }

        public static implicit operator SistemaBinario(string valor)
        {
            return new SistemaBinario(valor);
        }



    }
}
