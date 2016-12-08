// ArrayDoWhile.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;


int main()
{
	int feld1[10];
	int feld2[10];

	int index = 0;
	int werte = 10;

	while ( index < 10 )
	{
		feld1[index] = werte;
		index++;
		werte++;
	}

	do
	{
		feld2[index % 9] = feld1[index];
		index--;
	} while (index >=0);


	for (int i = 0; i < 10; i++)
	{
		cout << feld1[i] << " ";
	}
	cout << endl;

	for (int i = 0; i < 10; i++)
	{
		cout << feld2[i] << " ";
	}
	cout << endl;

	system("pause");
	return 0;
}

