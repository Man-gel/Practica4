
using System;
using System.IO;
using System.Collections;
namespace Practica4
{
	public class LectorDeArchivos
	{
		private String path;
		private ArrayList listaDeCampos;
		private Hashtable tabla;
		private ArrayList listaDeLLaves;
		
		public LectorDeArchivos(String rutaArchivo)
		{
			this.path = rutaArchivo;
			this.listaDeCampos = new ArrayList();
			this.tabla = new Hashtable();
			this.listaDeLLaves = new ArrayList();
			
		}
		
		public void leer ()
		{
			String linea;
			StreamReader lector;
			if(File.Exists(this.path))
			{
				try
				{
					lector = new StreamReader(this.path);
					linea = lector.ReadLine();
					this.listaDeCampos = convertirLineaEnCampos( linea );
					while(lector.Peek() > -1)
					{
						linea = lector.ReadLine();
						this.listaDeCampos = convertirLineaEnCampos( linea );
					}
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
				imprimirArchivoCSV();
			}
			else
				Console.WriteLine("ERROR: El nombre de archivo no es correcto o no existe.");
		}
		
		
		private ArrayList convertirLineaEnCampos(String lineaAconvertir )
		{
			ArrayList arraylistDeCampos = new ArrayList();
			String nuevaLinea ="";
			int contadorComas = 0;
			String key ="";
			Char[] arregloChars = lineaAconvertir.ToCharArray();
			
			foreach(Char simbolo in arregloChars)
			{
				if( !simbolo.Equals(',') )
					nuevaLinea += simbolo;
				else
				{
					if(contadorComas == 0){
						key = nuevaLinea;
						this.listaDeLLaves.Add(key);
						contadorComas++;
						nuevaLinea ="";
					}
					arraylistDeCampos.Add(nuevaLinea);
					contadorComas++;
				}
			}
			this.tabla.Add(key,arraylistDeCampos);
			return arraylistDeCampos;
		}
		
		private void imprimirBordesdeTabla()
		{
			Console.Write("+");			
			for(int cont = 0; cont < obtenerAnchoDeColumnaPrimaria()+2; cont++)
				Console.Write("-");
			
			Console.Write("+");
			Console.WriteLine();
		}
		
		private int obtenerAnchoDeColumnaPrimaria()
		{
			int ancho = 0;
			ICollection keyColl = this.tabla.Keys;
			String cadenaMayor = "";
			foreach(Object valorLLaveTabla in keyColl)
			{
				if( valorLLaveTabla.ToString().Length > cadenaMayor.Length )
					cadenaMayor = valorLLaveTabla.ToString();
				ancho= cadenaMayor.Length;
			}
			return ancho;
		}
		
		private void imprimirArchivoCSV()
		{
			Console.WriteLine("Imprimiendo...");
			Console.WriteLine();
			for(int indiceListaDeLLaves = 0; indiceListaDeLLaves< this.listaDeLLaves.Count; indiceListaDeLLaves++)
			{
				imrimirColumnaLLavesPrimarias(indiceListaDeLLaves);
			}
		}
		
		private void imrimirColumnaLLavesPrimarias(int indice)
		{
			String nuevaLinea = "| ";
			ICollection keyColl = this.tabla.Keys;
			String espaciado = "";
			int espaciosDeLinea = obtenerAnchoDeColumnaPrimaria();
			
			for(int i = 0; i < espaciosDeLinea; i++)
				espaciado += " ";
			foreach(Object valorLLaveTabla in keyColl){
				if( this.listaDeLLaves[indice].Equals(valorLLaveTabla) ){
					
					if( this.listaDeLLaves[indice].ToString().Length < espaciado.Length ){
						nuevaLinea += valorLLaveTabla + espaciado +"|";
					}else
						nuevaLinea += valorLLaveTabla + " |";
					
				}
			}
			
			imprimirBordesdeTabla();
			Console.WriteLine(nuevaLinea);
		}
		
	}
}