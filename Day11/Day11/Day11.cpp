// Day11.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <stdio.h>
#include <vector>
using namespace std;

typedef double Batman;

enum Powers
{
    Invisibility = 5, LaserEyes = 50, FreezeBreath
};
void PrintMyPower(Powers myPow);
int main()
{
    Powers myPower = LaserEyes;
    PrintMyPower(myPower);
    Batman theBest = 5;
    //std -- standard namespace
    //:: -- scope resolution operator
    //<< -- insertion operator
    //cout -- console output stream
    std::cout << "Hello World!\n" << "Batman rules!" << 5 << "\n";
    cout << sizeof(char) << " (bytes)\n";

    std::string theMan = "Batman";

    char best[] = "Batman";//adds a \0, null terminator
    char meh[] = { 'A','q','u','a','m','a','n', '\0'};

    cout << best << "\n" << meh << "\n";

    for (char c : meh)//range-based for loop
        cout << c << ".";
    cout << "\n";

    for (int i = 0; i < sizeof(best)/sizeof(char); i++)
    {
        cout << best[i] << ".";
    }
    cout << "\n";

    srand(time(NULL));//seed the random # generator
    int randomNum = rand();//0-RAND_MAX (32767)
    int grade = rand() % 101;//0-100

    std::vector<int> highScores(6); //{ 5, 4, 3 };
    highScores.push_back(rand());//like the Add method
    highScores.push_back(rand());//like the Add method
    highScores.push_back(rand());//like the Add method
    highScores.push_back(rand());//like the Add method
    for (size_t i = 0; i < highScores.size(); i++)
    {
        cout << highScores[i] << "\n";
    }



    return 0;
}
void PrintMyPower(Powers myPow)
{
    switch (myPow)
    {
    case Invisibility:
        break;
    case LaserEyes:
        break;
    case FreezeBreath:
        break;
    default:
        break;
    }
}