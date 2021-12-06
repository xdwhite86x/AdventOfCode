//
// Created by jaksl on 12/4/2021.
//

#ifndef ADVENTOFCODE_DAY4BINGO_H
#define ADVENTOFCODE_DAY4BINGO_H
#include <stdint.h>
#include <stdbool.h>

typedef struct
{
    uint16_t value;
    bool     isCalled;
} bingoNumber_t;

typedef struct
{
    bingoNumber_t board[5][5];
    uint8_t       boardNumber;
}bingoBoard_t;



uint32_t day4_Part1();
uint32_t day4_Part2();
void ParseInputFile();

#endif //ADVENTOFCODE_DAY4BINGO_H
