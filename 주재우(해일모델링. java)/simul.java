package simple;

import java.util.Random;

public class simul {
static public void main(String args[]) {
	type [][] map=new type[50][50];
	Random ran=new Random();
	for (int i=0;i<5;i++) {
	for(int j=0;j<50;j++) {
		map[j][i]=new type(1,0,1);
		map[j][i].water=1;
	}
	}
	for (int i=5;i<50;i++) {
		for(int j=0;j<50;j++) {
			map[j][i]=new type(2,0,0.85-ran.nextDouble()*0.1); 
		}
		}
	for(int i=0;i<50;i++) {
		map[i][0].E=70+ran.nextDouble()*50;
		map[i][0].water=2;}
	for(int i=0;i<49;i++){
		System.out.println(i+1);
		for(int j=0;j<50;j++) {
			double goC=1.0/(1.0+Math.sqrt(2))-0.1+ran.nextDouble()*0.1;
			double goS=(1-goC)/2-0.1+ran.nextDouble()*0.1;;
			if(j==0) {map[j][i+1].E+=map[j][i].E*map[j][i+1].Friction*goC;
				map[j+1][i+1].E+=map[j][i].E*map[j][i+1].Friction*goS;	
				}
				else if(j==49) {map[j][i+1].E+=map[j][i].E*map[j][i+1].Friction*goC;
				map[j-1][i+1].E+=map[j][i].E*map[j][i+1].Friction*goS;	
				}
				else {
					map[j][i+1].E+=map[j][i].E*map[j][i+1].Friction*goC;
					map[j-1][i+1].E+=map[j][i].E*map[j][i+1].Friction*goS;
					map[j+1][i+1].E+=map[j][i].E*map[j][i+1].Friction*goS;
				}
		}
		for(int j=0;j<50;j++) {
			if(/*map[j][i].water==0&&*/map[j][i].E>0.1) map[j][i].water=2;
		}
		for(int x=0;x<50;x++){
			for(int y=0;y<50;y++)
				if(map[x][y].water==0)
				System.out.print("бр ");
				else if(map[x][y].water==1)
					System.out.print(ConsoleColor.BLUE_BRIGHT + "бс " + ConsoleColor.RESET);
				else if(map[x][y].water==2)
					System.out.print(ConsoleColor.RED_BRIGHT + "бс " + ConsoleColor.RESET);
			System.out.println();
		}
	System.out.println();
	}
}
}
