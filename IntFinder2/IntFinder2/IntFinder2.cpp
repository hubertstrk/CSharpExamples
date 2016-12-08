// IntFinder2.cpp : Defines the entry point for the console application.
//

#include <cstdlib>
#include "stdafx.h"
#include <iostream>
#include <vector>
#include <stdio.h>

using namespace std;

int main()
{
	int const min = 1;
	int const max = 25;
	int const anzahl = 300;
	int liste[anzahl];

	// zufallszahlen generieren und feld damit füllen
	for (int i = 0; i < anzahl; i++)
		liste[i] = min + (rand() % (int)(max - min + 1));

	// zur Kontrolle nochmals ausgeben
	for (int i = 0; i < anzahl; i++)
		cout << liste[i] << " ";
	cout << endl;

	// benutzer soll suche eingeben
	cout << "Suche nach: " << endl;
	int eingabe = 0;
	cin >> eingabe;

	// jetzt suche starten

	// variable enthält alle Stellen wo etwas gefunden wurde
	vector<int> gefundeneWerte;
	for (int i = 0; i < anzahl; i++)
	{
		if (liste[i] == eingabe)
		{
			// ah, wir haben ewas gefunden
			// => mit push_back an den vector anhängen
			// vector größe erweitert sich autmotisch um eins
			gefundeneWerte.push_back(i);
		}
		// else => nichts gefunde
	}

	// nun alle gefunden Werte ausgeben
	if (gefundeneWerte.size() > 0)
	{
		cout << "Folgende Stellen wurden gefunden: ";

		// iteriere durch alle gefunden werte
		for (int i = 0; i < gefundeneWerte.size(); i++)
		{
			cout << gefundeneWerte[i] << " ";
		}
		cout << endl;
	}
	else
	{
		// da die größe des vectors immer noch 0 ist haben wir auch nichts gefunden	
		cout << "Nix gefunden" << endl;
	}

    return 0;
}

