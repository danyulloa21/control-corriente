// See https://aka.ms/new-console-template for more information
using System;

namespace MotorControlApp
{
    class Program
    {
        static bool isMotorOn = false;
        static int motorSpeed = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al control del motor!");

            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "on":
                        TurnOn();
                        break;
                    case "off":
                        TurnOff();
                        break;
                    case "speed":
                        AdjustSpeed();
                        break;
                    case "exit":
                        Console.WriteLine("Saliendo de la aplicación.");
                        return;
                    default:
                        Console.WriteLine("Comando no reconocido. Por favor, intenta de nuevo.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("  - Encender motor: 'on'");
            Console.WriteLine("  - Apagar motor: 'off'");
            Console.WriteLine("  - Ajustar velocidad: 'speed'");
            Console.WriteLine("  - Salir de la aplicación: 'exit'");
            Console.Write("Ingresa tu elección: ");
        }

        static void TurnOn()
        {
            if (!isMotorOn)
            {
                isMotorOn = true;
                Console.WriteLine("El motor ha sido encendido.");
            }
            else
            {
                Console.WriteLine("El motor ya está encendido.");
            }
        }

        static void TurnOff()
        {
            if (isMotorOn)
            {
                isMotorOn = false;
                motorSpeed = 0;
                Console.WriteLine("El motor ha sido apagado.");
            }
            else
            {
                Console.WriteLine("El motor ya está apagado.");
            }
        }

        static void AdjustSpeed()
        {
            if (!isMotorOn)
            {
                Console.WriteLine("El motor no está encendido. Enciéndelo primero.");
                return;
            }

            Console.Write("Ingrese la velocidad deseada (0-100): ");
            if (int.TryParse(Console.ReadLine(), out int speedInput))
            {
                if (speedInput >= 0 && speedInput <= 100)
                {
                    motorSpeed = speedInput;
                    Console.WriteLine("La velocidad del motor se ha ajustado a " + motorSpeed);
                }
                else
                {
                    Console.WriteLine("La velocidad ingresada está fuera del rango válido (0-100).");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Ingrese un número entre 0 y 100.");
            }
        }
    }
}