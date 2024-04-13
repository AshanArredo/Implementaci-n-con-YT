using Reproductor1.Models;

namespace Reproductor1.Services
{
    public class DoubleLinkedList
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public Nodo? NodoActual { get; set; }
        public DoubleLinkedList()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            NodoActual = null;
        }

        public bool IsEmpty => PrimerNodo == null;

        public string AgregarNodoAlInicio(Nodo nuevoNodo)
        {
            if (IsEmpty)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.LigaSiguiente = PrimerNodo;
                PrimerNodo.LigaAnterior = nuevoNodo;
                PrimerNodo = nuevoNodo;
            }

            NodoActual = nuevoNodo;

            return "Nodo agregado al inicio...";
        }

        public string AgregarNodoAlFinal(Nodo nuevoNodo)
        {
            if (IsEmpty)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.LigaSiguiente = nuevoNodo;
                nuevoNodo.LigaAnterior = UltimoNodo;
                UltimoNodo = nuevoNodo;
            }

            return "Nodo agregado al final...";
        }

        public string AgregarNodoAntes(Nodo nuevoNodo, string urlVideo)
        {
            Nodo? nodoActual = PrimerNodo;

            // Buscar el nodo con la URL especificada
            while (nodoActual != null && nodoActual.Informacion != urlVideo)
            {
                nodoActual = nodoActual.LigaSiguiente;
            }

            if (nodoActual == null)
            {
                return "No se encontró el nodo con la URL especificada.";
            }

            // Si el nodo actual es el primer nodo, agregar el nuevo nodo al inicio
            if (nodoActual == PrimerNodo)
            {
                nuevoNodo.LigaSiguiente = PrimerNodo;
                PrimerNodo.LigaAnterior = nuevoNodo;
                PrimerNodo = nuevoNodo;
            }
            else
            {
                // Encontrar el nodo anterior al nodo actual
                Nodo? nodoAnterior = PrimerNodo;
                while (nodoAnterior != null && nodoAnterior.LigaSiguiente != nodoActual)
                {
                    nodoAnterior = nodoAnterior.LigaSiguiente;
                }

                // Actualizar las conexiones del nodo anterior y el nuevo nodo
                nodoAnterior.LigaSiguiente = nuevoNodo;
                nuevoNodo.LigaAnterior = nodoAnterior;

                // Conectar el nuevo nodo con el nodo encontrado
                nuevoNodo.LigaSiguiente = nodoActual;
                nodoActual.LigaAnterior = nuevoNodo;
            }

            return "Nodo agregado antes de la URL especificada.";
        }
        public string AgregarDespuesDeNodo(Nodo nuevoNodo, string urlVideo)
        {
            Nodo? nodoActual = PrimerNodo;

            while (nodoActual != null && nodoActual.Informacion != urlVideo)
            {
                nodoActual = nodoActual.LigaSiguiente;
            }

            if (nodoActual == null)
            {
                return "No se encontró el nodo con la URL especificada.";
            }

            if (nodoActual == UltimoNodo)
            {
                nuevoNodo.LigaAnterior = UltimoNodo;
                UltimoNodo.LigaSiguiente = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.LigaSiguiente = nodoActual.LigaSiguiente;
                nodoActual.LigaSiguiente.LigaAnterior = nuevoNodo;
                nuevoNodo.LigaAnterior = nodoActual;
                nodoActual.LigaSiguiente = nuevoNodo;
            }

            return "Nodo agregado después de la URL especificada.";
        }
        public string InsertarAntesDePosicion(Nodo nuevoNodo, int posicion)
        {
            if(posicion <= 0)
            {
                AgregarNodoAlInicio(nuevoNodo);
                return "Nodo insertado al inicio.";
            }

            Nodo? nodoActual = PrimerNodo;
            int index = 0;

            while(nodoActual != null && index < posicion)
            {
                nodoActual = nodoActual.LigaSiguiente;
                index++;
            }

            if(nodoActual == null)
            {
                AgregarNodoAlFinal(nuevoNodo);
                return "Nodo insertado al final.";
            }

            nuevoNodo.LigaAnterior = nodoActual.LigaAnterior;
            nuevoNodo.LigaSiguiente = nodoActual;

            if (nodoActual.LigaAnterior != null)
            {
                nodoActual.LigaAnterior.LigaSiguiente = nuevoNodo;
            }
            else
            {
                PrimerNodo = nuevoNodo;
            }

            nodoActual.LigaAnterior = nuevoNodo;

            return "Nodo insertado antes de la posición especificada.";
        }
        public string AgregarDespuesDePosicion(Nodo nuevoNodo, int posicion)
        {
            if (posicion < 0)
            {
                return "La posición debe ser un número positivo.";
            }

            Nodo? nodoActual = PrimerNodo;
            int contador = 0;

            while (nodoActual != null && contador < posicion)
            {
                nodoActual = nodoActual.LigaSiguiente;
                contador++;
            }

            if (nodoActual == null)
            {
                return "La lista no tiene suficientes nodos para insertar después de la posición especificada.";
            }

            if (nodoActual == UltimoNodo)
            {
                nuevoNodo.LigaAnterior = UltimoNodo;
                UltimoNodo.LigaSiguiente = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.LigaSiguiente = nodoActual.LigaSiguiente;
                nodoActual.LigaSiguiente.LigaAnterior = nuevoNodo;
                nuevoNodo.LigaAnterior = nodoActual;
                nodoActual.LigaSiguiente = nuevoNodo;
            }

            return "Nodo agregado después de la posición especificada.";
        }
        //Agregue...
        public string InsertarEnPosicion(Nodo nuevoNodo, int posicion)
        {
            if (posicion <= 0)
            {
                AgregarNodoAlInicio(nuevoNodo);
                return "Nodo insertado al inicio.";
            }

            Nodo? nodoActual = PrimerNodo;
            int index = 0;

            while (nodoActual != null && index < posicion)
            {
                nodoActual = nodoActual.LigaSiguiente;
                index++;
            }

            if (nodoActual == null)
            {
                AgregarNodoAlFinal(nuevoNodo);
                return "Nodo insertado al final.";
            }

            nuevoNodo.LigaAnterior = nodoActual.LigaAnterior;
            nuevoNodo.LigaSiguiente = nodoActual;

            if (nodoActual.LigaAnterior != null)
            {
                nodoActual.LigaAnterior.LigaSiguiente = nuevoNodo;
            }
            else
            {
                PrimerNodo = nuevoNodo;
            }

            nodoActual.LigaAnterior = nuevoNodo;

            return "Nodo insertado en la posición especificada.";
        }

        
        public string EliminarAlInicio()
        {
            if (IsEmpty)
            {
                return "La lista está vacía.";
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                PrimerNodo = PrimerNodo.LigaSiguiente;
                PrimerNodo.LigaAnterior = null;
            }

            NodoActual = PrimerNodo;

            return "Nodo eliminado del inicio.";
        }

        
        public string EliminarAlFinal()
        {
            if (IsEmpty)
            {
                return "La lista está vacía.";
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                UltimoNodo = UltimoNodo.LigaAnterior;
                UltimoNodo.LigaSiguiente = null;
            }

            NodoActual = UltimoNodo;

            return "Nodo eliminado al final.";
        }
        
        public string EliminarAntesDeDato(string informacion)
        {
            if (IsEmpty)
            {
                return "La lista está vacía.";
            }

            if (PrimerNodo.Informacion == informacion)
            {
                return "No hay ningún nodo antes del dato proporcionado.";
            }

            Nodo? nodoActual = PrimerNodo;

            while (nodoActual?.LigaSiguiente != null)
            {
                if (nodoActual.LigaSiguiente.Informacion == informacion)
                {
                    // Nodo a eliminar está antes del nodo actual
                    if (nodoActual == PrimerNodo)
                    {
                        PrimerNodo = nodoActual.LigaSiguiente;
                        PrimerNodo.LigaAnterior = null;
                    }
                    else
                    {
                        nodoActual.LigaAnterior.LigaSiguiente = nodoActual.LigaSiguiente;
                        nodoActual.LigaSiguiente.LigaAnterior = nodoActual.LigaAnterior;
                    }

                    NodoActual = PrimerNodo;

                    return "Nodo eliminado antes del dato especificado.";
                }

                nodoActual = nodoActual.LigaSiguiente;
            }

            return "No se encontró ningún nodo con el dato especificado.";
        }
        
        public string EliminarDespuesDeDato(string informacion)
        {
            if (IsEmpty)
            {
                return "La lista está vacía.";
            }

            Nodo? nodoActual = PrimerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.Informacion == informacion && nodoActual.LigaSiguiente != null)
                {
                    // Nodo a eliminar está después del nodo actual
                    Nodo nodoAEliminar = nodoActual.LigaSiguiente;
                    nodoActual.LigaSiguiente = nodoAEliminar.LigaSiguiente;

                    if (nodoAEliminar.LigaSiguiente != null)
                    {
                        nodoAEliminar.LigaSiguiente.LigaAnterior = nodoActual;
                    }
                    else
                    {
                        UltimoNodo = nodoActual;
                    }

                    NodoActual = PrimerNodo;

                    return "Nodo eliminado después del dato especificado.";
                }

                nodoActual = nodoActual.LigaSiguiente;
            }

            return "No se encontró ningún nodo con el dato especificado o el nodo está al final de la lista.";
        }

        
        public string EliminarAntesDePosicion(int posicion)
        {
            if (IsEmpty || posicion <= 0)
            {
                return "La lista está vacía o la posición no es válida.";
            }

            if (posicion == 1)
            {
                return "No hay ningún nodo antes de la primera posición.";
            }

            Nodo? nodoActual = PrimerNodo;
            int index = 1;

            while (nodoActual != null && index < posicion - 1)
            {
                nodoActual = nodoActual.LigaSiguiente;
                index++;
            }

            if (nodoActual == null || nodoActual.LigaSiguiente == null)
            {
                return "No se encontró la posición especificada o el nodo está al final de la lista.";
            }

            Nodo nodoAEliminar = nodoActual.LigaSiguiente;
            nodoActual.LigaSiguiente = nodoAEliminar.LigaSiguiente;

            if (nodoAEliminar.LigaSiguiente != null)
            {
                nodoAEliminar.LigaSiguiente.LigaAnterior = nodoActual;
            }
            else
            {
                UltimoNodo = nodoActual;
            }

            NodoActual = PrimerNodo;

            return "Nodo eliminado antes de la posición especificada.";
        }

        
        public string EliminarDespuesDePosicion(int posicion)
        {
            if (IsEmpty || posicion < 0)
            {
                return "La lista está vacía o la posición no es válida.";
            }

            Nodo? nodoActual = PrimerNodo;
            int index = 0;

            while (nodoActual != null && index < posicion)
            {
                nodoActual = nodoActual.LigaSiguiente;
                index++;
            }

            if (nodoActual == null || nodoActual.LigaSiguiente == null)
            {
                return "No se encontró la posición especificada o el nodo está al final de la lista.";
            }

            Nodo nodoAEliminar = nodoActual.LigaSiguiente;
            nodoActual.LigaSiguiente = nodoAEliminar.LigaSiguiente;

            if (nodoAEliminar.LigaSiguiente != null)
            {
                nodoAEliminar.LigaSiguiente.LigaAnterior = nodoActual;
            }
            else
            {
                UltimoNodo = nodoActual;
            }

            NodoActual = PrimerNodo;

            return "Nodo eliminado después de la posición especificada.";
        }
        
        public string EliminarEnPosicion(int posicion)
        {
            if (IsEmpty || posicion <= 0)
            {
                return "La lista está vacía o la posición no es válida.";
            }

            if (posicion == 1)
            {
                // Eliminar el primer nodo
                PrimerNodo = PrimerNodo?.LigaSiguiente;
                if (PrimerNodo != null)
                {
                    PrimerNodo.LigaAnterior = null;
                }
                else
                {
                    UltimoNodo = null;
                }
                NodoActual = PrimerNodo;
                return "Nodo en la primera posición eliminado.";
            }

            Nodo? nodoAnterior = null;
            Nodo? nodoActual = PrimerNodo;
            int index = 1;

            while (nodoActual != null && index < posicion)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.LigaSiguiente;
                index++;
            }

            if (nodoActual == null)
            {
                return "No se encontró la posición especificada.";
            }

            // Eliminar el nodo en la posición especificada
            nodoAnterior.LigaSiguiente = nodoActual.LigaSiguiente;
            if (nodoActual.LigaSiguiente != null)
            {
                nodoActual.LigaSiguiente.LigaAnterior = nodoAnterior;
            }
            else
            {
                UltimoNodo = nodoAnterior;
            }

            NodoActual = PrimerNodo;

            return "Nodo en la posición especificada eliminado.";
        }
        
        public string OrdenarUrls()
        {
            if (IsEmpty || PrimerNodo == UltimoNodo)
            {
                return "No hay suficientes elementos para ordenar.";
            }

            bool intercambio;
            do
            {
                intercambio = false;
                Nodo? nodoActual = PrimerNodo;
                while (nodoActual?.LigaSiguiente != null)
                {
                    if (string.Compare(nodoActual.Informacion, nodoActual.LigaSiguiente.Informacion) > 0)
                    {
                        // Intercambiar los valores de los nodos
                        string temp = nodoActual.Informacion;
                        nodoActual.Informacion = nodoActual.LigaSiguiente.Informacion;
                        nodoActual.LigaSiguiente.Informacion = temp;
                        intercambio = true;
                    }
                    nodoActual = nodoActual.LigaSiguiente;
                }
            } while (intercambio);

            NodoActual = PrimerNodo;

            return "URLs ordenados correctamente.";
        }

        private void LimpiarLista()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            NodoActual = null;
        }

        public Nodo Siguiente()
        {
            NodoActual = NodoActual.LigaSiguiente ?? UltimoNodo;
            return NodoActual;
        }

        public Nodo Anterior()
        {
            NodoActual = NodoActual.LigaAnterior ?? PrimerNodo;
            return NodoActual;
        }
    }
}