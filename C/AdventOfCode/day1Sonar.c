//
// Created by danw on 12/3/21.
//

#include <stdio.h>
#include <stdlib.h>
#include "day1Sonar.h"
#include "main.h"

uint16_t day1_SonarPart1()
{
  FILE* fp;
  char buffer[10];


  fp = fopen("../input-1.txt", "r");
  int16_t current = -1;
  int16_t last = -1;
  int16_t increased = 0;
  int16_t decreased = 0;
  int16_t equal = 0;
  while (fgets(buffer, sizeof(buffer), fp) != NULL)
  {
    if (current != -1)
      last = current;

    current = (int16_t)atoi(buffer);
    myPrintf("%i VS %i", current, last);

    if (last != -1)
    {
      if (current > last)
      {
        myPrintf("    INCREASED  \n");
        ++increased;
      }
      else
      {
        myPrintf("    DECREASED  \n");
        ++decreased;
      }
    }
  }
  myPrintf("Increased %i times, decreased %i times, equal %i times ", increased, decreased, equal);

  fclose(fp);
  return increased;

}
uint16_t day1_SonarPart2()
{
  FILE* fp;
  uint16_t increased = 0;
  char buffer[10];
  uint16_t file[2000];
  uint16_t sum1;
  uint16_t sum2;
  fp = fopen("../input-1.txt", "r");

  int i = 0;
  while (fgets(buffer, sizeof(buffer), fp) != NULL)
  {
    file[i] = atoi(buffer);
    ++i;
  }

  for (i = 0; i < 2000 - 2; ++i )
  {
    if (i + 3 > 2000)
      break;

    uint16_t sum1 = (file[i] + file[i + 1] + file[i + 2]);
    uint16_t sum2 = (file[i + 1] + file[i + 2] + file[i + 3]);
    if (sum2 > sum1)
      ++increased;
  }

    fclose(fp);
    return increased;




}