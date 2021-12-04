//
// Created by danw on 12/3/21.
//

#include <stdio.h>
#include <stdlib.h>
#include "Day3BinaryDiagnostic.h"
#include <string.h>

uint16_t day3_binaryDiagnosticPart1()
{
  FILE* fp = fopen("../input-3.txt", "r");

  char buffer[13];
  uint16_t file[1000];
  int i = 0;
  char output[13] = { '0','0','0','0','0','0','0','0','0','0','0','0','\0'};
  while(fgets(buffer, sizeof(buffer), fp) != NULL)
  {
    if (i != 0)
      fgets(buffer, sizeof(buffer), fp);

    //uint16_t temp = atoi(buffer);
    file[i] = convert(buffer);
    ++i;
    memset(buffer, 0, sizeof(buffer));
  }
  int num1s;
  for (i = 0; i < 12; ++ i)
  {
    num1s = 0;
    for (int j = 0; j < 1000; j++)
    {
      //is there a 1 in the current bit?
      if (((file[j] >> (12 - (i + 1))) & 1U) == 1U)
      {
        ++num1s;
      }
    }
    if (num1s > 500)
    {
      output[i] = '1';
    }
  }

  return convert(output);

}
uint16_t day3_binaryDiagnosticPart2()
{

}

// function definition
int convert(const char *n)
{
  int dec = 0, i = 0, rem;
  int len = strlen(n);

  while (n[i] != '\0')
  {
    if (n[i] == '1')
    {
      dec += 1U << (len - (i + 1));
    }
    ++i;
  }

  return dec;
}