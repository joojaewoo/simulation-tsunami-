package simple;

import java.util.Random;

public class simul {
static public void main(String args[]) {
	double goC=0.4;
	double goS=0.3;
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
			map[j][i]=new type(2,0,0.8);
		}
		}
	for(int i=0;i<50;i++) {
		map[i][0].E=ran.nextDouble()*200;
		map[i][0].water=2;}
	for(int i=0;i<49;i++){
		System.out.println(i+1);
		for(int j=0;j<50;j++) {
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
				System.out.print(map[x][y].water+" ");
			System.out.println();
		}
	System.out.println();
	}
}
}
