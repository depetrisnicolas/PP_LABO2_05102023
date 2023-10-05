using System.Runtime.CompilerServices;

namespace Entidades
{
    public abstract class Numeracion
    {
        //ATRIBUTOS
        protected static string msgError;
        protected string valor;

        //CONSTRUCTORES
        static Numeracion()
        {
            Numeracion.msgError = "Numero inválido";
        }

        protected Numeracion(string valor)
        {
            InicializaValor(valor);
        }

        //PROPIEDADES
        public string Valor
        {
            get
            {
                return this.valor;
            }
        }

        internal abstract double ValorNumerico
        {
            get;
        }

        //METODOS
        public abstract Numeracion CambiarSistemaDeNumeracion(ESistema sistema);
 
        protected virtual bool EsNumeracionValida(string valor)
        {
            return valor != null || valor != string.Empty;
        }

        private void InicializaValor (string valor)
        {
            if (EsNumeracionValida(valor))
            {
                this.valor = valor;
            }
            else
            {
                this.valor = "Mensaje de error";
            }
        }

        public static bool operator == (Numeracion n1, Numeracion n2)
        {
            return (n1.valor != null && n2.valor != null) && (n1.GetType() == n2.GetType());
        }

        public static bool operator != (Numeracion n1, Numeracion n2)
        {
            return !(n1 == n2);
        }

        public static explicit operator double(Numeracion numeracion)
        {
            double.TryParse(numeracion.Valor, out double valorAux);

            return valorAux;
        }

    }
}