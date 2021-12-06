//
// Created by jaksl on 12/4/2021.
//

#include <stdio.h>
#include "day4Bingo.h"
#include <string.h>
#include <stdlib.h>


bingoBoard_t gameBoards[100];
uint16_t     calledNumbers[100];

uint32_t day4_Part1()
{
  ParseInputFile();
  for (int i = 0; i< 100; ++i)
    printf("num: %i \n", calledNumbers[i]);
//  for (int i = 0; i < 100; ++i)
//  {
//    for (int j = 0; j < 5; ++j)
//    {
//      for (int k = 0; k < 5; ++k)
//      {
//        printf(" %i ", gameBoards[i].board[j][k].value);
//      }
//    }
//  }
}

void ParseInputFile()
{
  FILE *fp;
  char buffer[500];
  fp = fopen("../input-4.txt", "r");
  char* buffPtr = buffer;
  char numBuffer[4];
  char* numBuffPtr = numBuffer;
  int count = 0;
  //read in the comma separated list of called numbers
  fgets(buffer, sizeof(buffer), fp);
  while (*buffPtr != '\0')
  {
    *numBuffPtr = *buffPtr;
    ++numBuffPtr;
    ++buffPtr;
    if (*buffPtr == ',')
    {
      *numBuffPtr = '\0';
      memcpy(calledNumbers[count], atoi(numBuffPtr), sizeof(calledNumbers[count]));
      numBuffPtr = numBuffer;
      ++count;
    }
  }

  while (fgets(buffer, sizeof(buffer), fp) != NULL)
  {

  }
}

uint32_t day4_Part2()
{

}