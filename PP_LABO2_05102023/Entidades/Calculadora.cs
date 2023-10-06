using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        //ATRIBUTOS
        private string nombreAlumno;
        private List<string> operaciones;
        private Numeracion primerOperando;
        private Numeracion resultado;
        private Numeracion segundoOperando;
        private static ESistema sistema;


        //CONSTRUCTORES
        public Calculadora()
        {
            this.operaciones = new List<string>();
        }

        static Calculadora()
        {
            Calculadora.sistema = ESistema.Decimal;
        }

        public Calculadora(string nombreAlumno)
        {
            this.nombreAlumno = nombreAlumno;
        }

        //PROPIEDADES
        public string NombreAlumno
        {
            get
            {
                return this.nombreAlumno;
            }
            set
            {
                this.nombreAlumno = value;  
            }
        }

        public List<string> Operaciones
        {
            get
            {
                return this.operaciones;
            }
        }

        public Numeracion PrimerOperando
        {
            get
            {
                return this.primerOperando;
            }
            set
            {
                this.primerOperando = value;
            }
        }

        public Numeracion Resultado
        {
            get
            {
                return this.resultado;
            }
        }

        public Numeracion SegundoOperando
        {
            get
            {
                return this.segundoOperando;
            }
            set
            {
                this.segundoOperando = value;
            }
        }

        public ESistema Sistema
        {
            get
            {
                return Calculadora.sistema;
            }
            set
            {
                Calculadora.sistema = value;
            }
        }

        public void Calcular()
        {
            this.resultado = MapeaResultado(PrimerOperando.ValorNumerico + SegundoOperando.ValorNumerico);
        }

        public void Calcular(char operador)
        {
            if (this.PrimerOperando.GetType() == this.SegundoOperando.GetType())
            {
                switch (operador)
                {
                    case '-':
                        this.resultado = MapeaResultado(PrimerOperando.ValorNumerico - SegundoOperando.ValorNumerico);
                        break;

                    case '*':
                        this.resultado = MapeaResultado(PrimerOperando.ValorNumerico * SegundoOperando.ValorNumerico);
                        break;

                    case '/':
                        this.resultado = MapeaResultado(PrimerOperando.ValorNumerico / SegundoOperando.ValorNumerico);
                        break;

                    default:
                        Calcular();
                        break;
                }
            }
            else
            {
                this.resultado = MapeaResultado(double.MinValue);
            }
        }

        private Numeracion MapeaResultado(double valor)
        {
            switch (Calculadora.sistema)
            {
                case ESistema.Decimal:
                    return new SistemaDecimal(valor.ToString());
                default:
                    return new SistemaBinario(valor.ToString());
            }     
        }

        public void ActualizaHistorialDeOperaciones(char operador)
        {
            StringBuilder sb = new StringBuilder(); 
            sb.AppendLine($"Sistema: {Calculadora.sistema}");
            sb.AppendLine($"Primer operando {this.PrimerOperando.ValorNumerico.ToString()}");
            sb.AppendLine($"Segundo operando {this.SegundoOperando.ValorNumerico.ToString()}");  
            sb.AppendLine($"Operador: {operador}");

            sb.ToString();
        }

        public void EliminarHistorialDeOperaciones()
        {
            this.operaciones.Clear();
        }

    }
}
