#include <iostream>
#include <string>
#include <fstream>
#include <ctype.h>
#include "Source.h"

using namespace std;

string FileInput()		//��������� �����
{
	string path;
	cout << "Enter name of file with .txt: ";
	cin >> path;
	ofstream file(path);
	string str;
	cout << "Enter text. If you finished, press Ctrl+D and Enter in new line: \n\n";
	char ends = 4;
	do		//����� ����� � ������ � ����
	{
		getline(cin, str);
		if (str.find(ends) == string::npos && !str.empty())
			file << str << '\n';
	} while (str.find(ends) == string::npos);
	file.close();
	
	return path;
}

string FromFile(string path)		//������ ���������� � �����
{
	ifstream outfile;
	string msg;
	string text;


	outfile.open(path);
	if (!outfile.is_open())cout << "Error with opening your file!" << endl;		//�������� �������� �����
	else cout << "\nFile opened!" << endl << endl;

	while (!outfile.eof())		//������ ���������� � �����
	{
		msg = "";
		getline(outfile, msg);
		text += msg + " " + "\n";
	}

	outfile.close();

	cout << "Information from your file:" << endl << endl << text << endl;

	return text;
}

void WriteFile(string text)		//����� ���������� � ����
{
	string path;

	cout << "Enter name of new file with .txt: ";
	cin >> path;

	ofstream infile;

	infile.open(path);

	if (!infile.is_open())cout << "Error" << endl;		//�������� �������� �����
	else cout << endl << "New file created!" << endl << endl;

	infile << text;

	cout << "Information for your new file:" << endl << endl << text << endl;

	infile.close();
}

string DelSymbol(string text, string& count)		//��������� ����� ������, ��� �� ������
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
		if (text[i] == text[i + 1] && text[i] == coma)		//�������� �� � ������ ����� �� �� ������� �� ����������
		{
			countcoma++;
		}
		else if (text[i] == text[i + 1] && text[i] == dot)	//�������� �� � ������ ������� �� �� ������� �� ����������
		{
			countdot++;
		}
		else if (text[i] == text[i + 1] && text[i] == space)//�������� �� � ������ ������� �� �� ������� �� ����������
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

string DelWrds(string textcp, string& count)		//��������� �������������� ���
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
		pos = textcp.find(delim);	//����������� ������� ������� ������

		temp = textcp.substr(0, pos);	//������ ������� �����
		if (temp == "\n")		//���� ���������� ���� ���������
		{
			break;
		}

		else if (temp.length() == 1)		//���� ������� ����� ������� 1, �������� �� �� �� ����, ������ ��� �����
		{
			if (temp == "," || temp == "." || temp == " ")
			{
				textnew += temp + " ";
			}
			else
			{
				countwrd++;
			}
			textcp.erase(0, pos + delim.length());	//��������� ������� ����� � ������� ������
		}

		else if (temp[0] == '\n')		//���� ����� ���������� � ������� ��������, ������� �� ���'������ ��� ��������� ������ ��������
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

		else //���� �� ������ �����, �� ���� ������ ������
		{
			textnew += temp + " ";
			textcp.erase(0, pos + delim.length());
		}
	}

	string count2 = "Num of deleted words: " + to_string(countwrd);

	textnew += "\n\n" + count + count2;		//������� ���������� ��� ��������� � �����

	return textnew;
}

