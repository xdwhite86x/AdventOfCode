cmake_minimum_required(VERSION 3.20)
project(AdventOfCode C)

set(CMAKE_C_STANDARD 99)

add_executable(AdventOfCode main.c main.h day1Sonar.c day1Sonar.h Day2Dive.c Day2Dive.h Day3BinaryDiagnostic.c Day3BinaryDiagnostic.h)
