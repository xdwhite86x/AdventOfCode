#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>

#include "main.h"
#include "day1Sonar.h"
#include "Day2Dive.h"
#include "Day3BinaryDiagnostic.h"
int main()
{
  printf("%i\n", day1_SonarPart1());
  printf("%i\n", day1_SonarPart2());

  printf("%lu\n", day2_DivePart1());
  printf("%lu\n", day2_DivePart2());

  uint16_t temp = day3_binaryDiagnosticPart1();
  uint16_t temp2 = ~temp;
  temp2 = temp2 & 0b0000111111111111;
  //temp2 = temp2 << 5;
  //temp2 = temp2 >> 5;
  uint32_t temp3 = temp * temp2;
  printf("%u \n", temp);
  printf("%u \n", temp2);
  printf("%u \n", temp3);
  //printf("%i\n", day3_binaryDiagnosticPart1());
//  printf("%i\n", convert("010011001001"));
}

uint8_t myPrintf(const char* format, ...)
{
  return 0;
}
