using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day16;

public class BitsPacket
{
   private BitArray   _rawBitArray;
   private List<byte> _rawBytes = new();
   
   public BitsPacket(string transmission)
   {
      int bitIndex = 0;
      _rawBitArray  = new(transmission.Length * 4);
      
      for (int i = 0; i < transmission.Length; i = i + 2)
      {
         var temp = transmission.Substring(i, 2);
         var byt  = byte.Parse($"{temp}", NumberStyles.HexNumber, CultureInfo.InvariantCulture);
         _rawBytes.Add(byt);
         var bin = Convert.ToString(byt, 2);
         for (int j = 0; j < bin.Length; ++j)
         {
            _rawBitArray[bitIndex++] = bin[j] == '1';
         }
      }

      foreach (bool b in _rawBitArray)
      {
         Console.WriteLine(b ? "1" : "0");
      }
   }
}