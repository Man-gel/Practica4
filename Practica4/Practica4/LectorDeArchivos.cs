
using System;
using System.IO;
using System.Collections;
namespace Practica4
{
	public class LectorDeArchivos
	{
		private String path;
		public Queue filaDepalabras;
		
		public LectorDeArchivos(String rutaArchivo)
		{
			this.path = rutaArchivo;
			this.filaDepalabras = new Queue();
		}
		
		public void leer ()
		{
			String linea;
			StreamReader lector;
			if(File.Exists(path))
			{
				try
				{
					lector = new StreamReader(this.path);
					do
					{
						linea = lector.ReadLine();
						filaDepalabras.Enqueue(linea);
						//Console.WriteLine(linea);
					} 
					while(lector.Peek() > -1);
					lector.Close();
					
				}
				catch ( Exception e )
				{
					Console.WriteLine("Exception: " + e.Message);
				}
				finally
				{
					Console.WriteLine("Cerrando la lectura...");
					Console.WriteLine();
				}
				imprimirArchivoCSV(filaDepalabras);
			}
		}
		
		private void ingresarAFila(String[] arregloDeLineas, Queue fila)
		{
			foreach(String linea in arregloDeLineas)
			{
				fila.Enqueue(linea);
			}
		}
		
		private void imprimirArchivoCSV(Queue filaAimprimir)
		{
			foreach(String linea in filaAimprimir)
			{
				
				Console.WriteLine(linea);
			}
				
		}
	}
}
