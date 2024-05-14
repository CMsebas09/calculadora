using System; // Importa el espacio de nombres System que contiene las clases básicas del framework .NET
using System.Globalization; // Importa el espacio de nombres System.Globalization que proporciona clases específicas para la cultura o región, como CultureInfo

namespace Calculadora // Declara un espacio de nombres llamado Calculadora para organizar el código
{
    class Program // Declara una clase llamada Program
    {
        static bool trabajarConEnteros = true; // Declara una variable estática de tipo booleano llamada trabajarConEnteros y la inicializa en true

        static void Main(string[] args) // Declara el método Main, que es el punto de entrada del programa y recibe argumentos de línea de comandos
        {
            do // Inicia un bucle do-while que se ejecutará al menos una vez y luego continuará ejecutándose mientras la condición especificada se evalúe como verdadera
            {
                Console.WriteLine("¿Desea trabajar con enteros (1), decimal (2), o salir (3)?"); // Muestra un mensaje en la consola solicitando al usuario que elija entre trabajar con enteros, decimales o salir
                int tipoNumero = Convert.ToInt32(Console.ReadLine()); // Lee l   a entrada del usuario desde la consola y la convierte a un entero

                if (tipoNumero == 3) // Verifica si el usuario eligió la opción de salir
                    return; // Termina la ejecución del programa

                trabajarConEnteros = tipoNumero == 1; // Actualiza el valor de la variable trabajarConEnteros según la opción seleccionada por el usuario

                bool salir = false; // Declara una variable local llamada salir y la inicializa en false

                do // Inicia un bucle do-while que se ejecutará al menos una vez y luego continuará ejecutándose mientras la condición especificada se evalúe como verdadera
                {
                    Console.WriteLine("---------------CALCULADORA------------"); // Muestra un mensaje en la consola indicando que se trata de una calculadora
                    Console.WriteLine("Introduce el primer número:"); // Muestra un mensaje en la consola solicitando al usuario que introduzca el primer número
                    double a = LeerNumero(); // Llama al método LeerNumero para leer y devolver el primer número introducido por el usuario

                    Console.WriteLine("Introduzca el segundo número: "); // Muestra un mensaje en la consola solicitando al usuario que introduzca el segundo número
                    double b = LeerNumero(); // Llama al método LeerNumero para leer y devolver el segundo número introducido por el usuario

                    Console.WriteLine("Elija una opción:"); // Muestra un mensaje en la consola solicitando al usuario que elija una opción
                    Console.WriteLine("1- Sumar\n2 - Restar \n3 - Dividir \n4 - Multiplicar\n5 - Cambiar tipo de número\n6 - Salir "); // Muestra las opciones disponibles para realizar operaciones aritméticas
                    int opcion = Convert.ToInt32(Console.ReadLine()); // Lee la opción seleccionada por el usuario desde la consola y la convierte a un entero

                    switch (opcion) // Inicia una estructura de control switch para seleccionar el comportamiento del programa según la opción seleccionada por el usuario
                    {
                        case 1: // Si la opción seleccionada es 1
                            suma(a, b); // Llama al método suma y pasa como argumentos los números introducidos por el usuario
                            break; // Sale del switch
                        case 2: // Si la opción seleccionada es 2
                            resta(a, b); // Llama al método resta y pasa como argumentos los números introducidos por el usuario
                            break; // Sale del switch
                        case 3: // Si la opción seleccionada es 3
                            division(a, b); // Llama al método division y pasa como argumentos los números introducidos por el usuario
                            break; // Sale del switch
                        case 4: // Si la opción seleccionada es 4
                            multiplicacion(a, b); // Llama al método multiplicacion y pasa como argumentos los números introducidos por el usuario
                            break; // Sale del switch
                        case 5: // Si la opción seleccionada es 5
                            trabajarConEnteros = !trabajarConEnteros; // Cambia el valor de la variable trabajarConEnteros de true a false o viceversa
                            break; // Sale del switch
                        case 6: // Si la opción seleccionada es 6
                            salir = true; // Asigna true a la variable salir para indicar que se debe salir del bucle interno
                            break; // Sale del switch
                        default: // Si la opción seleccionada no coincide con ningún caso anterior
                            Console.WriteLine("Opción inválida."); // Muestra un mensaje en la consola indicando que la opción seleccionada es inválida
                            Console.ReadLine(); // Espera a que el usuario presione Enter antes de continuar
                            break; // Sale del switch
                    }

                    if (opcion != 5 && opcion != 6) // Verifica si la opción seleccionada no es cambiar tipo de número ni salir
                    {
                        Console.WriteLine("Desea continuar: 1=si/0=no"); // Muestra un mensaje en la consola solicitando al usuario que indique si desea continuar
                        int OP = Convert.ToInt32(Console.ReadLine()); // Lee la respuesta del usuario desde la consola y la convierte a un entero
                        if (OP == 0) // Verifica si el usuario eligió no continuar
                            salir = true; // Asigna true a la variable salir para indicar que se debe salir del bucle interno
                    }

                } while (!salir); // Continúa ejecutando el bucle interno mientras la variable salir sea false

            } while (true); // Continúa ejecutando el bucle externo indefinidamente
        }

        static double LeerNumero() // Declara un método estático llamado LeerNumero que devuelve un número introducido por el usuario
        {
            string input = Console.ReadLine(); // Lee la entrada del usuario desde la consola y la guarda en una variable llamada input
            if (trabajarConEnteros) // Verifica si se debe trabajar con enteros
            {
                if (!EsNumeroEntero(input)) // Verifica si el número introducido por el usuario no es un número entero
                {
                    Console.WriteLine("Error: Debe ingresar un número entero."); // Muestra un mensaje en la consola indicando que se debe ingresar un número entero
                    return LeerNumero(); // Llama recursivamente al método LeerNumero para volver a solicitar al usuario que introduzca un número entero
                }
                return Convert.ToInt32(input); // Convierte el número introducido por el usuario a un entero y lo devuelve
            }
            else // Si no se debe trabajar con enteros
            {
                if (EsNumeroEntero(input)) // Verifica si el número introducido por el usuario es un número entero
                {
                    Console.WriteLine("Error: Debe ingresar un número decimal."); // Muestra un mensaje en la consola indicando que se debe ingresar un número decimal
                    return LeerNumero(); // Llama recursivamente al método LeerNumero para volver a solicitar al usuario que introduzca un número decimal
                }
                return Convert.ToDouble(input); // Convierte el número introducido por el usuario a un número de punto flotante y lo devuelve
            }
        }

        private static bool EsNumeroEntero(string input) // Declara un método privado llamado EsNumeroEntero que recibe una cadena y devuelve true si la cadena representa un número entero, de lo contrario devuelve false
        {
            int result; // Declara una variable de tipo entero llamada result
            return int.TryParse(input, out result); // Intenta convertir la cadena a un número entero y devuelve true si tiene éxito, de lo contrario devuelve false
        }

        private static void multiplicacion(double a, double b) // Declara un método privado llamado multiplicacion que recibe dos números de punto flotante y muestra el resultado de su multiplicación
        {
            double result = a * b; // Calcula el producto de los dos números y lo guarda en una variable llamada result
            if (trabajarConEnteros) // Verifica si se debe trabajar con enteros
            {
                Console.WriteLine((int)result); // Convierte el resultado a un entero y lo muestra en la consola
            }
            else // Si no se debe trabajar con enteros
            {
                string resultString = result.ToString(CultureInfo.InvariantCulture); // Convierte el resultado a una cadena utilizando la configuración cultural invariante
                int decimalIndex = resultString.IndexOf('.'); // Busca el índice del punto decimal en la cadena
                if (decimalIndex != -1) // Verifica si se encontró un punto decimal en la cadena
                {
                    Console.WriteLine(resultString.Substring(decimalIndex)); // Muestra solo la parte decimal del resultado en la consola
                }
                else // Si no se encontró un punto decimal en la cadena
                {
                    Console.WriteLine("0"); // Muestra "0" en la consola
                }
            }
        }

        private static void division(double a, double b) // Declara un método privado llamado division que recibe dos números de punto flotante y muestra el resultado de su división
        {
            if (b == 0) // Verifica si el divisor es cero
            {
                Console.WriteLine("La división es indeterminada"); // Muestra un mensaje en la consola indicando que la división es indeterminada
                return; // Sale del método division
            }

            double result = a / b; // Calcula el cociente de los dos números y lo guarda en una variable llamada result
            if (trabajarConEnteros) // Verifica si se debe trabajar con enteros
            {
                Console.WriteLine((int)result); // Convierte el resultado a un entero y lo muestra en la consola
            }
            else // Si no se debe trabajar con enteros
            {
                string resultString = result.ToString(CultureInfo.InvariantCulture); // Convierte el resultado a una cadena utilizando la configuración cultural invariante
                int decimalIndex = resultString.IndexOf('.'); // Busca el índice del punto decimal en la cadena
                if (decimalIndex != -1) // Verifica si se encontró un punto decimal en la cadena
                {
                    Console.WriteLine(resultString.Substring(decimalIndex)); // Muestra solo la parte decimal del resultado en la consola
                }
                else // Si no se encontró un punto decimal en la cadena
                {
                    Console.WriteLine("0"); // Muestra "0" en la consola
                }
            }
        }

        private static void resta(double a, double b) // Declara un método privado llamado resta que recibe dos números de punto flotante y muestra el resultado de su resta
        {
            double result = a - b; // Calcula la diferencia entre los dos números y lo guarda en una variable llamada result
            if (trabajarConEnteros) // Verifica si se debe trabajar con enteros
            {
                Console.WriteLine((int)result); // Convierte el resultado a un entero y lo muestra en la consola
            }
            else // Si no se debe trabajar con enteros
            {
                string resultString = result.ToString(CultureInfo.InvariantCulture); // Convierte el resultado a una cadena utilizando la configuración cultural invariante
                int decimalIndex = resultString.IndexOf('.'); // Busca el índice del punto decimal en la cadena
                if (decimalIndex != -1) // Verifica si se encontró un punto decimal en la cadena
                {
                    Console.WriteLine(resultString.Substring(decimalIndex)); // Muestra solo la parte decimal del resultado en la consola
                }
                else // Si no se encontró un punto decimal en la cadena
                {
                    Console.WriteLine("0"); // Muestra "0" en la consola
                }
            }
        }

        private static void suma(double a, double b) // Declara un método privado llamado suma que recibe dos números de punto flotante y muestra el resultado de su suma
        {
            double result = a + b; // Calcula la suma de los dos números y lo guarda en una variable llamada result
            if (trabajarConEnteros) // Verifica si se debe trabajar con enteros
            {
                Console.WriteLine((int)result); // Convierte el resultado a un entero y lo muestra en la consola
            }
            else // Si no se debe trabajar con enteros
            {
                string resultString = result.ToString(CultureInfo.InvariantCulture); // Convierte el resultado a una cadena utilizando la configuración cultural invariante
                int decimalIndex = resultString.IndexOf('.'); // Busca el índice del punto decimal en la cadena
                if (decimalIndex != -1) // Verifica si se encontró un punto decimal en la cadena
                {
                    Console.WriteLine(resultString.Substring(decimalIndex)); // Muestra solo la parte decimal del resultado en la consola
                }
                else // Si no se encontró un punto decimal en la cadena
                {
                    Console.WriteLine("0"); // Muestra "0" en la consola
                }
            }
        }
    }
}
