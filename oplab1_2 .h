#pragma once

#include <iostream>
#include <string>
#include <fstream>

using namespace std;

string FileInput();

string FromFile(string path1);
void WriteFile(string text);
string DelSymbol(string text, string& count);
string DelWrds(string textcp, string& count);