using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class Stats {
	public string name;
	public string className;
	public int health;
	public int magic;
	public int strength;
	public int defense;
	public int specialDefense;
	public int agility;
	public int luck;
	public int level;
	public int experience;
	public int toNextLevel;

	public Stats() {
		name = "";
		className = "";
		health = 0;
		magic = 0;
		strength = 0;
		defense = 0;
		specialDefense = 0;
		agility = 0;
		luck = 0;
		level = 0;
		experience = 0;
		toNextLevel = 0;
	}

	public Stats(string n, string cn, int hp, int mp, int str, 
	           int def, int sd, int agi, int luc, int lev, int exp, int tnl) {
		name = n;
		className = cn;
		health = hp;
		magic = mp;
		strength = str;
		defense = def;
		specialDefense = sd;
		agility = agi;
		luck = luc;
		level = lev;
		experience = exp;
		toNextLevel = tnl;
	}
}