//
// Created by danw on 12/3/21.
//

#include <stdio.h>
#include <stdlib.h>
#include "Day2Dive.h"

uint64_t day2_DivePart1()
{
  FILE* fp = fopen("../input-2.txt", "r");
  int32_t xPos = 0;
  int32_t yPos = 0;
  char buffer[50];

  while(fgets(buffer, sizeof(buffer), fp) != NULL)
  {
    char* bPtr = buffer;
    switch(*bPtr)
    {
      case 'f':
        bPtr += 8;
        xPos += atoi(bPtr);
        break;
      case 'd':
        bPtr += 5;
        yPos += atoi(bPtr);
        break;
      case 'u':
        bPtr += 3;
        yPos -= atoi(bPtr);
        break;
      default:
        printf("unreachable");
    }


  }

  return xPos * yPos;
}
uint64_t day2_DivePart2()
{
  FILE* fp = fopen("../input-2.txt", "r");
  int32_t xPos = 0;
  int32_t yPos = 0;
  int32_t aim = 0;
  char buffer[50];

  while(fgets(buffer, sizeof(buffer), fp) != NULL)
  {
    char* bPtr = buffer;
    switch(*bPtr)
    {
      int32_t change = 0;
      case 'f':
        bPtr += 8;
        change = atoi(bPtr);
        xPos += change;
        yPos += aim * change;
        break;
      case 'd':
        bPtr += 5;
        change = atoi(bPtr);
        aim += change;
        break;
      case 'u':
        bPtr += 3;
        change = atoi(bPtr);
        aim -= change;
        break;
      default:
        printf("unreachable");
    }


  }

  return xPos * yPos;
}
