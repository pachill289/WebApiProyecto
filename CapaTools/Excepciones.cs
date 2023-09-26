using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaTools
{
    public class Excepciones
    {
        public Exception Exception(Func<object> function)
        {
            if (function == null)
            {
                throw new ArgumentNullException(nameof(function));
            }

            try
            {
                // Llamar a la función proporcionada
                object result = function();

                // Evaluar el resultado de la función y lanzar una excepción si es necesario
                if (result != null)
                {
                    // Puedes personalizar este bloque para definir tu lógica de evaluación
                    throw new Exception("Se lanzó una excepción debido a la evaluación del resultado de la función.");
                }

                // Si el resultado de la función es null, no se lanza ninguna excepción
                return null;
            }
            catch (Exception ex)
            {
                // Capturar y devolver la excepción original si ocurre una excepción al llamar a la función
                return ex;
            }
        }
    }
}
