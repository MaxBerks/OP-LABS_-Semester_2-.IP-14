#include <iostream>
#include <string>
#include <fstream>
#include <ctype.h>
#include "Source.h"

using namespace std;

string FileInput()		//створення файла
{
	string path;
	cout << "Enter name of file with .txt: ";
	cin >> path;
	ofstream file(path);
	string str;
	cout << "Enter text. If you finished, press Ctrl+D and Enter in new line: \n\n";
	char ends = 4;
	do		//запис даних з консолі у файл
	{
		getline(cin, str);
		if (str.find(ends) == string::npos && !str.empty())
			file << str << '\n';
	} while (str.find(ends) == string::npos);
	file.close();
	
	return path;
}

string FromFile(string path)		//взяття інформації з файлу
{
	ifstream outfile;
	string msg;
	string text;


	outfile.open(path);
	if (!outfile.is_open())cout << "Error with opening your file!" << endl;		//перевірка відкриття файла
	else cout << "\nFile opened!" << endl << endl;

	while (!outfile.eof())		//взяття інформації з файлу
	{
		msg = "";
		getline(outfile, msg);
		text += msg + " " + "\n";
	}

	outfile.close();

	cout << "Information from your file:" << endl << endl << text << endl;

	return text;
}

void WriteFile(string text)		//запис інформації у файл
{
	string path;

	cout << "Enter name of new file with .txt: ";
	cin >> path;

	ofstream infile;

	infile.open(path);

	if (!infile.is_open())cout << "Error" << endl;		//перевірка відкриття файла
	else cout << endl << "New file created!" << endl << endl;

	infile << text;

	cout << "Information for your new file:" << endl << endl << text << endl;

	infile.close();
}

string DelSymbol(string text, string& count)		//видалення лишніх крапок, ком та пробілів
{
	char coma = ',';
	char dot = '.';
	char space = ' ';

	string comaS = ",";
	string dotS = ".";
	string spaceS = " ";

	int countcoma = 0;
	int countdot = 0;
	int countspace = 0;

	string textcp;

	int size = text.size();

	for (int i = 0; i < size - 1; i++)
	{
		if (text[i] == text[i + 1] && text[i] == coma)		//перевірка чи є символ комою та чи дорівнює він наступному
		{
			countcoma++;
		}
		else if (text[i] == text[i + 1] && text[i] == dot)	//перевірка чи є символ крапкою та чи дорівнює він наступному
		{
			countdot++;
		}
		else if (text[i] == text[i + 1] && text[i] == space)//перевірка чи є символ пробілом та чи дорівнює він наступному
		{
			countspace++;
		}
		else
		{
			textcp += text[i];
		}
	}

	count = "Num of deleted commas: " + to_string(countcoma) + "\nNum of deleted dots: " + to_string(countdot) + "\nNum of deleted spaces: " + to_string(countspace) + "\n";

	return textcp;
}

string DelWrds(string textcp, string& count)		//видалення односимвольних слів
{
	string text;
	string str;
	string newstr;
	size_t pos = 0;
	size_t strpos = 0;
	string delim = " ";
	string delimtext = "\n";
	string temp;
	string newtemp;
	string textnew;

	int countwrd = 0;

	text = textcp;

	while (pos = textcp.find(delim) != string::npos)
	{
		pos = textcp.find(delim);	//знаходження позиції першого пробіла

		temp = textcp.substr(0, pos);	//взяття першого слова
		if (temp == "\n")		//якщо залишились лишні перненоси
		{
			break;
		}

		else if (temp.length() == 1)		//якщо довжина слова дорівнює 1, перевірка чи це не кома, крапка або пробіл
		{
			if (temp == "," || temp == "." || temp == " ")
			{
				textnew += temp + " ";
			}
			else
			{
				countwrd++;
			}
			textcp.erase(0, pos + delim.length());	//видалення першого слова з старого тексту
		}

		else if (temp[0] == '\n')		//якщо слово починається з символу переносу, потрібно їх роз'єднати для корректної роботи програми
		{
			textnew += "\n";
			newtemp = temp.erase(0, 1);

			if (newtemp.length() == 1)
			{
				if (newtemp == "," || newtemp == "." || newtemp == " ")
				{
					textnew += newtemp + " ";
				}
				else
				{
					countwrd++;
				}
				textcp.erase(0, pos + delim.length());
			}
			else
			{
				textnew += newtemp + " ";
				textcp.erase(0, pos + delim.length());
			}
		}

		else //якщо це просто слово, ми його просто додаємо
		{
			textnew += temp + " ";
			textcp.erase(0, pos + delim.length());
		}
	}

	string count2 = "Num of deleted words: " + to_string(countwrd);

	textnew += "\n\n" + count + count2;		//додання інформації про лічильники в текст

	return textnew;
}

