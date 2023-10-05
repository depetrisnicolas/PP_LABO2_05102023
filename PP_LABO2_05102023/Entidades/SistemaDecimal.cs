using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaDecimal : Numeracion
    {

        //CONSTRUCTOR
        public SistemaDecimal(string valor)
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

        //METODOS - !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            return new SistemaDecimal(base.valor);
        }

        protected override bool EsNumeracionValida (string valor)
        {
            return base.EsNumeracionValida(valor) && this.EsSistemaDecimalValido(valor);
        }

        private bool EsSistemaDecimalValido(string valor)
        {
            return double.TryParse(valor, out _);
        }

        private SistemaBinario DecimalABinario()
        {
            string numeroBinario = string.Empty;
            string resultado = string.Empty;
            int resultadoDivision = (int)this.ValorNumerico;

            while (true)
            {
                if (resultadoDivision >= 0)
                {
                    int bit = resultadoDivision % 2;
                    resultadoDivision /= 2;

                    numeroBinario = bit.ToString() + numeroBinario;

                    if (resultadoDivision == 0)
                    {
                        resultado = numeroBinario;
                        break;
                    }
                }
                else
                {
                    return new SistemaBinario(Numeracion.msgError);
                }
            }
            return new SistemaBinario(resultado);
        }

        //SOBRECARGAS

        public static implicit operator SistemaDecimal(double valor)
        {
            return new SistemaDecimal(valor.ToString());
        }

        public static implicit operator SistemaDecimal(string valor) 
        {
            return new SistemaDecimal(valor);
        }



    }
}
