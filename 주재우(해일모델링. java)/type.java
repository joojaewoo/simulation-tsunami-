package simple;

import java.util.Random;

public class type {
int status; //1 바다//2 땅 // 3 건물
int water=0; //침수여부 1침수 0아님
double E; // E
double E1;
double Friction; // 마찰력 물에서 0 땅에서 0.2
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