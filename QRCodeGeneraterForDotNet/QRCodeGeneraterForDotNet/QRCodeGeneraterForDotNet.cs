﻿// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;

namespace QRCodeGeneraterForDotNet
{
	public class QRCodeGeneraterForDotNet
	{
		
		public int Width { get; set; }
		public int Height { get; set; }
		
		public QRCodeGeneraterForDotNet ()
		{

		}

		public writeableBitmap GenerateQRCode (string source,short width,short height)
		{
			Width  = width;
			Height = height;
		}
	}
}

