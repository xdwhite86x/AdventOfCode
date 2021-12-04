#include <stdio.h>
#include <stdint.h>
#include <stdlib.h>

#include "main.h"
#include "day1Sonar.h"
#include "Day2Dive.h"
int main()
{
  printf("%i\n", day1_SonarPart1());
  printf("%i\n", day1_SonarPart2());

  printf("%lu\n", day2_DivePart1());
  printf("%lu\n", day2_DivePart2());
}

uint8_t myPrintf(const char* format, ...)
{
  return 0;
}
