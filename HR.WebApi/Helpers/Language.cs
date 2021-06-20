using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Helpers
{
    public class Language
    {

        public static string GetCyrillicLetter(string str)
        {
            if (str != null)
            {
                var cyrlString = string.Empty;
                cyrlString = str;
                var st = cyrlString.Replace("B", "Б")
                    .Replace("b", "б")
                    .Replace("C", "Ц")
                    .Replace("c", "ц")
                    .Replace("Č", "Ч")
                    .Replace("č", "ч")
                    .Replace("Ć", "Ћ")
                    .Replace("ć", "ћ")
                    .Replace("D", "Д")
                    .Replace("d", "д")
                    .Replace("Dž", "Џ")
                    .Replace("dž", "џ")
                    .Replace("Đ", "Ђ")
                    .Replace("đ", "ђ")
                    .Replace("F", "Ф")
                    .Replace("f", "ф")
                    .Replace("G", "Г")
                    .Replace("g", "г")
                    .Replace("H", "X")
                    .Replace("h", "x")
                    .Replace("I", "И")
                    .Replace("i", "и")
                    .Replace("k", "к")
                    .Replace("L", "Л")
                    .Replace("l", "л")
                    .Replace("Lj", "Љ")
                    .Replace("lj", "љ")
                    .Replace("m", "м")
                    .Replace("N", "H")
                    .Replace("n", "н")
                    .Replace("Nj", "Њ")
                    .Replace("nj", "њ")
                    .Replace("P", "П")
                    .Replace("p", "п")
                    .Replace("R", "P")
                    .Replace("r", "p")
                    .Replace("S", "C")
                    .Replace("s", "с")
                    .Replace("Š", "Ш")
                    .Replace("š", "ш")
                    .Replace("t", "т")
                    .Replace("U", "Y")
                    .Replace("u", "y")
                    .Replace("V", "B")
                    .Replace("v", "в")
                    .Replace("Z", "З")
                    .Replace("z", "з")
                    .Replace("Ž", "Ж")
                    .Replace("ž", "ж");   
                return st;
            }
            else
            {
                return str;
            }
        }

        public static string GetLatinLetter(string str)
        {
            if (str != null)
            {
                var latnString = string.Empty;
                latnString = str;
                var stL = latnString
                    .Replace("Б", "B")
                    .Replace("б", "b")
                    .Replace("Ц", "C")
                    .Replace("ц", "c")
                    .Replace("Ч", "Č")
                    .Replace("ч", "č")
                    .Replace("Ћ", "Ć")
                    .Replace("ћ", "ć")
                    .Replace("Д", "D")
                    .Replace("д", "d")
                    .Replace("Џ", "Dž")
                    .Replace("џ", "dž")
                    .Replace("Ђ", "Đ")
                    .Replace("ђ", "đ")
                    .Replace("Ф", "F")
                    .Replace("ф", "f")
                    .Replace("Г", "G")
                    .Replace("г", "g")
                    .Replace("X", "H")
                    .Replace("x", "h")
                    .Replace("И", "I")
                    .Replace("и", "i")
                    .Replace("к", "k")
                    .Replace("Л", "L")
                    .Replace("л", "l")
                    .Replace("Љ", "Lj")
                    .Replace("љ", "lj")
                    .Replace("м", "m")
                    .Replace("H", "N")
                    .Replace("н", "n")
                    .Replace("Њ", "Nj")
                    .Replace("њ", "nj")
                    .Replace("П", "P")
                    .Replace("п", "p")
                    .Replace("P", "R")
                    .Replace("p", "r")
                    .Replace("C", "S")
                    .Replace("с", "s")
                    .Replace("Ш", "Š")
                    .Replace("ш", "š")
                    .Replace("т", "t")
                    .Replace("Y", "U")
                    .Replace("y", "u")
                    .Replace("B", "V")
                    .Replace("в", "v")
                    .Replace("З", "Z")
                    .Replace("з", "z")
                    .Replace("Ж", "Ž")
                    .Replace("ж", "ž");
                return stL;
            }
            else
            {
                return str;
            }
        }

    }
}
