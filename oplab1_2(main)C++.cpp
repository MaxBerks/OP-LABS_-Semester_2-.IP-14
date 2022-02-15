#include <iostream>
#include <string>
#include <fstream>

#include "Source.h"

using namespace std;

int main()
{
	string FirstPath = FileInput();				//створення файла				

	string count;

	string text = FromFile(FirstPath);			//взяття інформації з файлу
	

	string textcp = DelSymbol(text, count);		//видалення лишніх крапок, ком та пробілів
	

	string textnew = DelWrds(textcp, count);	//видалення односимвольних слів
	
	WriteFile(textnew);							//запис інформації у файл
	
}