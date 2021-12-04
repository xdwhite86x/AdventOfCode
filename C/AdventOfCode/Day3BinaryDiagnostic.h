//
// Created by danw on 12/3/21.
//

#ifndef ADVENTOFCODE_DAY3BINARYDIAGNOSTIC_H
#define ADVENTOFCODE_DAY3BINARYDIAGNOSTIC_H
#include <stdint-gcc.h>

uint16_t day3_binaryDiagnosticPart1();
uint16_t day3_binaryDiagnosticPart2();
int convert(const char* n);


typedef struct
{
    char*  str[13];
    uint16_t value;
} day3_entry_t;
#endif //ADVENTOFCODE_DAY3BINARYDIAGNOSTIC_H
