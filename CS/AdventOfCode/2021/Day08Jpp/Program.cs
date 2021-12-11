using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Day8Jpp
{
public class Day8b {

    public static int[] getNumber(String num) {
        int[] numArr = new int[7];
        foreach (String s in num.Split("")) {
            switch (s) {
                case "a": numArr[0] = 1; break;
                case "b": numArr[1] = 1; break;
                case "c": numArr[2] = 1; break;
                case "d": numArr[3] = 1; break;
                case "e": numArr[4] = 1; break;
                case "f": numArr[5] = 1; break;
                case "g": numArr[6] = 1; break;
            }
        }
        return numArr;
    }

    public static int[] getVal(Dictionary<String, int[]> numbersRev, String num) {
        int[] numArr = numbersRev[num];
        return (int[])numArr.Clone();
       // return Arrays.copyOf(numArr, 7);
    }

    public static Dictionary<int[], String> getMap(String input) {
        Dictionary<int[], String> numbers = new ();
        Dictionary<String, int[]> numbersRev = new ();

        List<int[]> fiveSeg = new();
        List<int[]> sixSeg = new ();

        foreach (String number in input.Trim().Split(" ")) {
            if (number.Length == 2) {
                numbers.Add(getNumber(number), "1");
                numbersRev.Add("1", getNumber(number));
            } else if (number.Length == 3) {
                numbers.Add(getNumber(number), "7");
                numbersRev.Add("7", getNumber(number));
            } else if (number.Length == 4) {
                numbers.Add(getNumber(number), "4");
                numbersRev.Add("4", getNumber(number));
            } else if (number.Length == 7) {
                numbers.Add(getNumber(number), "8");
                numbersRev.Add("8", getNumber(number));
            } else if (number.Length == 5) {
                fiveSeg.Add(getNumber(number));
            } else if (number.Length == 6) {
                sixSeg.Add(getNumber(number));
            }
        }

        int[] segmentA = getVal(numbersRev, "7");
        sub(segmentA, getVal(numbersRev, "1"));
        add(segmentA, getVal(numbersRev, "4"));

        int[] nine = similar(sixSeg, segmentA);

        numbers.Add(nine, "9");
        numbersRev.Add("9", nine);

        sixSeg.Remove(nine);

        int[] findFive = (int[])nine.Clone();
        sub(findFive, getVal(numbersRev, "1"));
        int[] five = similar(fiveSeg, findFive);

        numbers.Add(five, "5");
        numbersRev.Add("5", five);
        fiveSeg.Remove(five);

        int[] findThree = getVal(numbersRev, "5");
        sub(findThree, getVal(numbersRev, "4"));
        add(findThree, getVal(numbersRev, "1"));
        int[] three = similar(fiveSeg, findThree);

        numbers.Add(three, "3");
        numbersRev.Add("3", three);
        fiveSeg.Remove(three);

        int[] two = fiveSeg[0];
        numbers.Add(two, "2");
        numbersRev.Add("2", two);
        fiveSeg.Remove(two);

        int[] findZero = getVal(numbersRev, "2");
        sub(findZero, getVal(numbersRev, "4"));
        add(findZero, getVal(numbersRev, "1"));
        int[] zero = similar(sixSeg, findZero);
        numbers.Add(zero, "0");
        numbersRev.Add("0", zero);
        sixSeg.Remove(zero);

        int[] six = sixSeg[0];
        numbers.Add(six, "6");
        numbersRev.Add("6", six);
        sixSeg.Remove(six);

        return numbers;
    }

    public static int[] similar(List<int[]> values, int[] num) {
        int smallest = 7;
        int[] smallestNum = new int[7];
        foreach (int[] v in values) {
            int val = 0;
            for(int i = 0; i < 7; i++) {
                val += v[i] - num[i] > 0 ? 1 : 0;
            }
            if (val < smallest) {
                smallestNum = v;
                smallest = val;
            }
        }
        return smallestNum;
    }

    public static void add(int[] a, int[] b) {
        for(int i = 0; i < 7; i++) {
            a[i] += b[i];
            a[i] = Math.Min(a[i], 1);
        }
    }

    public static void sub(int[] a, int[] b) {
        for(int i = 0; i < 7; i++) {
            a[i] -= b[i];
            a[i] = Math.Max(a[i], 0);
        }
    }

    public static String getHashMapValue(Dictionary<int[], String> map, int[] val) {
        foreach (KeyValuePair<int[], String> entry in map) {
            if (Enumerable.SequenceEqual(entry.Key, val))
            {
                return entry.Value;
            }
        }
        return "";
    }

    public static void Main()
    {
        //String data = 

        try {
            using StreamReader sr = new (("./input-test.txt"));

            ulong count = 0;

            String line;
            //while ((line = sr.ReadLine()) != null)
            while (!(sr.EndOfStream))
            {
                line = sr.ReadLine();
                if (string.IsNullOrEmpty(line)) continue;
                String[] lineArr = line.Split("|");
                String input = lineArr[0];
                String output = lineArr[1];

                Dictionary<int[], String> numbers = getMap(input);

                String outputNum = "";
                foreach (String s in output.Trim().Split(" ")) {
                    int[] num = getNumber(s);
                    outputNum += getHashMapValue(numbers, num);
                }
                var bi = UInt64.Parse(outputNum);
                Console.WriteLine(outputNum);
                count += bi;
            }

            Console.WriteLine(count);
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
    }
}
}