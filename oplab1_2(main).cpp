#include <iostream>
#include <string>
#include <fstream>

#include "Source.h"

using namespace std;

int main()
{
	string FirstPath = FileInput();				//��������� �����				

	string count;

	string text = FromFile(FirstPath);			//������ ���������� � �����
	

	string textcp = DelSymbol(text, count);		//��������� ����� ������, ��� �� ������
	

	string textnew = DelWrds(textcp, count);	//��������� �������������� ���
	
	WriteFile(textnew);							//����� ���������� � ����
	
}