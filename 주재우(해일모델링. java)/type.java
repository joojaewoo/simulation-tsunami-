package simple;

import java.util.Random;

public class type {
int status; //1 �ٴ�//2 �� // 3 �ǹ�
int water=0; //ħ������ 1ħ�� 0�ƴ�
double E; // E
double E1;
double Friction; // ������ ������ 0 ������ 0.2
public type(int status,double E,double Friction) {
	this.status=status; 
	this.E=E;
	this.Friction=Friction;
}
}

class water {
	int stauts =1;
	int water = 0;
	double E =0;
	double Friction =0;
}

class ground{
	Random ran= new Random();
	int stauts =2;
	int water =0;
	double E=0;
	double Friction =0.85-ran.nextDouble()*0.1;
}