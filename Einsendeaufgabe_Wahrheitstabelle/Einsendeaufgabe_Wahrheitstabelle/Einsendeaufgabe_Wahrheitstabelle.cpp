// Einsendeaufgabe_Wahrheitstabelle.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <cstdio>

using namespace std;

bool BerechneErgebnis(bool, bool);
string Prettify(bool);
void PrintTitel();

int main()
{
	PrintTitel();
	
	cout << Prettify(true) << "\t" << Prettify(true) << "\t" << Prettify(BerechneErgebnis(true, true)) << endl;
	cout << Prettify(false) << "\t" << Prettify(false) << "\t" << Prettify(BerechneErgebnis(false, false)) << endl;
	cout << Prettify(true) << "\t" << Prettify(false) << "\t" << Prettify(BerechneErgebnis(true, false)) << endl;
	cout << Prettify(false) << "\t" << Prettify(true) << "\t" << Prettify(BerechneErgebnis(false, true)) << endl;

	std::getchar();
    return 0;
}

void PrintTitel()
{
	cout << "Wahrheitstabelle fuer den Audruck '!(A||B)'" << endl << endl;
	cout << "A" << "\t" << "B" << "\t" << "!(A||B)" << endl;
	cout << "-----------------------------" << endl;
}

bool BerechneErgebnis(bool A, bool B)
{
	return !(A | B);
}

string Prettify(bool wert)
{
	if (wert)
		return "wahr";
	return "falsch";
}

