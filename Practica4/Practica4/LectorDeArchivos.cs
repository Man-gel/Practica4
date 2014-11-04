
using System;
using System.IO;
using System.Collections;
namespace Practica4
{
	public class LectorDeArchivos
	{
		private String path;
		private Hashtable tabla;
		private ArrayList listaDeLLaves;
		
		public LectorDeArchivos(String rutaArchivo)
		{
			this.path = rutaArchivo;
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
					convertirLineaEnCampos( linea );
					while(lector.Peek() > -1)
					{
						linea = lector.ReadLine();
						convertirLineaEnCampos( linea );
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
		
		
		private void convertirLineaEnCampos(String lineaAconvertir )
		{
			ArrayList arraylistDeCampos = new ArrayList();
			String nuevaPalabra ="";
			int contadorComas = 0;
			String key ="";
			String[] linea = lineaAconvertir.Split(new char[] {','});
			foreach(String palabra in linea)
			{
				nuevaPalabra += palabra;
				if( contadorComas == 0){
					key = nuevaPalabra;
					this.listaDeLLaves.Add(key);
					nuevaPalabra = "";
					contadorComas++;
				}else{
					arraylistDeCampos.Add(nuevaPalabra);
					nuevaPalabra = "";
					contadorComas++;
				}
			}
			this.tabla.Add(key,arraylistDeCampos);
		}
		
		private void imprimirBordesdeTabla()
		{
			bool esColumnaPrimaria = true;
			Console.Write("+");
			ICollection val = this.tabla.Values;
				for(int cont = 0; cont < obtenerAnchoDeColumna(esColumnaPrimaria) +2; cont++)
					Console.Write("-");
			Console.Write("+");
			esColumnaPrimaria = false;
			
				for(int cont = 0; cont < obtenerAnchoDeColumna(esColumnaPrimaria) +2; cont++)
					Console.Write("-");
			Console.Write("+");
			Console.WriteLine();
		}
		
		private int obtenerAnchoDeColumna(bool esTablaPrimaria)
		{
			int ancho = 0;
			ICollection keyColl = this.tabla.Keys;
			ICollection valColl = this.tabla.Values;
			String cadenaMayor = "";
			
			if( esTablaPrimaria){
				foreach(Object valorLLaveTabla in keyColl)
					if( valorLLaveTabla.ToString().Length > cadenaMayor.Length ){
					cadenaMayor = valorLLaveTabla.ToString();
					ancho= cadenaMayor.Length;
				}
				
			}else{
				foreach(ArrayList valorEnTabla in valColl)
					foreach(String palabra in valorEnTabla)
						if( palabra.Length > cadenaMayor.Length ){
					cadenaMayor = palabra;
					ancho= cadenaMayor.Length;
				}
			}
			return ancho;
		}
		
		private void imprimirArchivoCSV()
		{
			Console.WriteLine("Imprimiendo...");
			Console.WriteLine();
			bool esPrimaryCol = true;
			imprimirBordesdeTabla();
				for(int indiceListaDeLLaves = 0; indiceListaDeLLaves< this.listaDeLLaves.Count; indiceListaDeLLaves++)
					imprimirColumna(indiceListaDeLLaves,esPrimaryCol);
				esPrimaryCol= false;
				imprimirBordesdeTabla();
		}
		
		private void imprimirColumna(int indice, bool esPrimaryKey)
		{
			String nuevaLinea = "| ";
			bool esTablaPrimaria = true;
			ICollection keyColl = this.tabla.Keys;
			ICollection valueColl = this.tabla.Values;
			String espaciadoMaximo = "";
			int espaciosDeLinea = obtenerAnchoDeColumna(esTablaPrimaria);
			if(indice == 1)
				imprimirBordesdeTabla();
			
			foreach(Object valorLLaveTabla in keyColl){
				for(int i = valorLLaveTabla.ToString().Length; i < espaciosDeLinea; i++)
					espaciadoMaximo += " ";
				
				if( this.listaDeLLaves[indice].Equals(valorLLaveTabla) )
					nuevaLinea +=  valorLLaveTabla + espaciadoMaximo + " |";
				
				espaciadoMaximo ="";
			}
			Console.WriteLine(nuevaLinea);
			if(indice == this.listaDeLLaves.Count-1)
				imprimirBordesdeTabla();
		}
		
		
		private String obtenerColumnaApartirDeArrayList( )
		{
			ICollection valCollection = this.tabla.Values;
			int indicePalabra = 0;
			String campo = "";
			
			foreach(ArrayList listaDeValores in valCollection)
				foreach(String palabra in listaDeValores)
					campo = palabra;
			return campo;
		}
		
	}
}