//
// Created by jaksl on 12/6/2021.
//

#include "Day6.h"
#include <string.h>
#include <stdio.h>
#include <stdlib.h>

#define ARRAY_SIZE 0x7FFFFFFF
void Day6Part1()
{
  FILE* fp = fopen("../input-6.txt", "r");
  uint8_t *lanternFish = malloc(ARRAY_SIZE * sizeof(uint8_t));
  char buffer[5000];
  char* pBuff = buffer;
  char temp[5];
  char* pTemp = temp;
  fgets(buffer, sizeof(buffer), fp);
  size_t count = 0;
  while (*pBuff != '\0')
  {
    *pTemp = *pBuff;
    ++pTemp;
    ++pBuff;
    if (*pBuff == ',')
    {
      *pTemp = '\0';
      memcpy(lanternFish[count], atoi(pTemp), sizeof(lanternFish[count]));
      pTemp = temp;
      ++count;
    }
  }

  for (int i = 0; i < count; ++i )
  {
    printf("%i", lanternFish[i]);
  }
  free(lanternFish);
}