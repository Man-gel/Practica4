﻿/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 29/10/2014
 * Time: 03:43 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Practica4
{
	
	public class Principal
	{
		public static void Main (String[] args)
		{
			LectorDeArchivos lector = new LectorDeArchivos("C:\\Users\\Usuario\\Desktop\\csvMSDOS.csv");
			lector.leer();
			Console.WriteLine();
			Console.WriteLine("Hola Mundo!");
			Console.ReadKey(true);
		}
	}
}
