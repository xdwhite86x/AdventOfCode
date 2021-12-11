package com.company;

import java.io.BufferedReader;
import java.io.FileReader;
import java.math.BigInteger;
import java.util.*;


public class Day8b {

    public static int[] getNumber(String num) {
        int[] numArr = new int[7];
        for (String s : num.split("")) {
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

    public static int[] getVal(Map<String, int[]> numbersRev, String num) {
        int[] numArr = numbersRev.get(num);
        return Arrays.copyOf(numArr, 7);
    }

    public static Map<int[], String> getMap(String input) {
        Map<int[], String> numbers = new HashMap<>();
        Map<String, int[]> numbersRev = new HashMap<>();

        List<int[]> fiveSeg = new ArrayList<>();
        List<int[]> sixSeg = new ArrayList<>();

        for (String number : input.trim().split(" ")) {
            if (number.length() == 2) {
                numbers.put(getNumber(number), "1");
                numbersRev.put("1", getNumber(number));
            } else if (number.length() == 3) {
                numbers.put(getNumber(number), "7");
                numbersRev.put("7", getNumber(number));
            } else if (number.length() == 4) {
                numbers.put(getNumber(number), "4");
                numbersRev.put("4", getNumber(number));
            } else if (number.length() == 7) {
                numbers.put(getNumber(number), "8");
                numbersRev.put("8", getNumber(number));
            } else if (number.length() == 5) {
                fiveSeg.add(getNumber(number));
            } else if (number.length() == 6) {
                sixSeg.add(getNumber(number));
            }
        }

        int[] segmentA = getVal(numbersRev, "7");
        sub(segmentA, getVal(numbersRev, "1"));
        add(segmentA, getVal(numbersRev, "4"));

        int[] nine = similar(sixSeg, segmentA);

        numbers.put(nine, "9");
        numbersRev.put("9", nine);

        sixSeg.remove(nine);

        int[] findFive = Arrays.copyOf(nine, 7);
        sub(findFive, getVal(numbersRev, "1"));
        int[] five = similar(fiveSeg, findFive);

        numbers.put(five, "5");
        numbersRev.put("5", five);
        fiveSeg.remove(five);

        int[] findThree = getVal(numbersRev, "5");
        sub(findThree, getVal(numbersRev, "4"));
        add(findThree, getVal(numbersRev, "1"));
        int[] three = similar(fiveSeg, findThree);

        numbers.put(three, "3");
        numbersRev.put("3", three);
        fiveSeg.remove(three);

        int[] two = fiveSeg.get(0);
        numbers.put(two, "2");
        numbersRev.put("2", two);
        fiveSeg.remove(two);

        int[] findZero = getVal(numbersRev, "2");
        sub(findZero, getVal(numbersRev, "4"));
        add(findZero, getVal(numbersRev, "1"));
        int[] zero = similar(sixSeg, findZero);
        numbers.put(zero, "0");
        numbersRev.put("0", zero);
        sixSeg.remove(zero);

        int[] six = sixSeg.get(0);
        numbers.put(six, "6");
        numbersRev.put("6", six);
        sixSeg.remove(six);

        return numbers;
    }

    public static int[] similar(List<int[]> values, int[] num) {
        int smallest = 7;
        int[] smallestNum = new int[7];
        for (int[] v : values) {
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
            a[i] = Math.min(a[i], 1);
        }
    }

    public static void sub(int[] a, int[] b) {
        for(int i = 0; i < 7; i++) {
            a[i] -= b[i];
            a[i] = Math.max(a[i], 0);
        }
    }

    public static String getHashMapValue(Map<int[], String> map, int[] val) {
        for (Map.Entry<int[], String> entry : map.entrySet()) {
            if (Arrays.equals(entry.getKey(), val)) {
                return entry.getValue();
            }
        }
        return "";
    }

    public static void main(String[] args) {
        try {
            BufferedReader br = new BufferedReader(new FileReader("input/input.txt"));

            int count = 0;

            String line;
            while ((line = br.readLine()) != null) {
                //for (String line : data.split("\n")) {
                if (line.isBlank()) continue;
                String[] lineArr = line.split("\\|");
                String input = lineArr[0];
                String output = lineArr[1];

                Map<int[], String> numbers = getMap(input);

                String outputNum = "";
                for (String s : output.trim().split(" ")) {
                    int[] num = getNumber(s);
                    outputNum += getHashMapValue(numbers, num);
                }
                BigInteger bi = new BigInteger(outputNum);
                count += bi.intValue();
            }

            System.out.println(count);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}