
using System;
using System.IO;
using System.Collections;
namespace Practica4
{
	public class LectorDeArchivos
	{
		private String path;
		public Queue filaDepalabras;
		
		public LectorDeArchivos(String ruta)
		{
			this.path = ruta;
			this.filaDepalabras = new Queue();
		}
		
		public void leer ()
		{
			String linea;
			if(File.Exists(path))
			{
				try
				{
					StreamReader lector = new StreamReader(this.path);
					linea = lector.ReadLine();
					Char[] caracteres = linea.ToCharArray();
					ingresarAFila(caracteres,filaDepalabras);
					while(lector.Peek()>1)
					{
						linea = lector.ReadLine();
						caracteres = linea.ToCharArray();
						ingresarAFila(caracteres,filaDepalabras);
					}
					lector.Close();
					
				}
				catch ( Exception e )
				{
					Console.WriteLine("Exception: " + e.Message);
				}
				finally
				{
					Console.WriteLine("Cerrando la lectura");
					Console.WriteLine();
				}
				imprimirArchivoCSV(filaDepalabras);
			}
		}
		
		private void ingresarAFila(Char[] arregloDeChars, Queue fila)
		{
			foreach(Char caracter in arregloDeChars)
			{
				fila.Enqueue(caracter);
				
			}
			
			//foreach(Char caracter in arregloDeChars)
			
			//	if( Char.IsLetterOrDigit(caracter) || Char.IsPunctuation(caracter) )
			//		filaDepalabras.Enqueue( caracter );
			//	else if(caracter.Equals( (Char)'\r' ) || caracter.Equals( (Char)'\n') )
			//		filaDepalabras.Enqueue("$");
		}
		
		private void imprimirArchivoCSV(Queue filaAimprimir)
		{
			foreach(Char simbolo in filaAimprimir)
					Console.Write("{0}",simbolo);
		}
	}
}
