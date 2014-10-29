/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 29/10/2014
 * Time: 03:55 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections;

namespace Practica4
{
	
	public class LectorDeArchivos
	{
		private String path;
		
		public LectorDeArchivos(String ruta)
		{
			this.path = ruta;
		}
		
		public void leer ()
		{
			ArrayList arrayListDepalabras = new ArrayList();
			String linea;
			try
			{
				StreamReader lector = new StreamReader(this.path);
				arrayListDepalabras.Add( lector.ReadLine());
				linea = lector.ReadLine();
				while(linea != null)
				{
					
					linea = lector.ReadLine();

					//Console.WriteLine(linea);
					arrayListDepalabras.Add( lector.ReadLine() );
									
				}
				lector.Close();
				//Console.ReadLine();
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
			foreach(String palabra in arrayListDepalabras)
					Console.Write(palabra);
		}
		
		private void ingresarAlArrayList(Char charQueSeLee)
		{
			
		}
		
		private void imprimirArchivoCSV()
		{
			
		}
	}
}
