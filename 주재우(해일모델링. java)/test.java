package simple;

import java.util.Random;

public class test {

	public static void main(String[] args) {
		type [][] map=new type[20][11];
		Random ran=new Random();
		for(int j=1;j<9;j++){
			if(j%3==0) {
				for(int i=0;i<11;i++) {
					map[j][i]=new type(2,0,0.85-ran.nextDouble()*0.1);
				}}
			else {
				for(int i=0;i<11;i++) {
					if(i==3 ||i==7) map[j][i]=new type(2,0,0.85-ran.nextDouble()*0.1);
					else map[j][i]=new type(3,0,0);
				}
			}
		}
		for(int i=0;i<11;i++) {
			map[0][i]=new type(1,70+ran.nextDouble()*50,0);
			map[0][i].water=2;}
		for(int i=9;i<20;i++ ) {
			for(int j=0;j<11;j++)
				map[i][j]=new type(2,0,0.85-ran.nextDouble()*0.1);
		}
		int z=0;
			while(z<30) {
				for(int x=14;x>=0;x--){
					for(int y=0;y<10;y++)
						if(map[x][y].water==0)
							if(map[x][y].status==3)
								System.out.print(ConsoleColor.BLACK + "■ " + ConsoleColor.RESET);
							else
								System.out.print("□ ");
						else if(map[x][y].water==1)
							System.out.print(ConsoleColor.BLUE_BRIGHT + "■ " + ConsoleColor.RESET);
						else if(map[x][y].water==2)
							System.out.print(ConsoleColor.RED_BRIGHT + "■ " + ConsoleColor.RESET);
					System.out.println();
				}
				System.out.println();
			for(int i=0;i<11;i++) {
				int j=0,k=0;
				while(k<15) {
					if(map[k][i].water==2) j=k;
					k++;
				}	
				if(isWall(j+1,i,map)){
					if(i!=0) {
					// 벽 찾아서
					}
				}
				if(i!=10&&map[j][i+1].status==2&&map[j][i+1].water==0) {
					map[j][i+1].E=map[j][i].E*0.3;
					map[j][i+1].E1=map[j][i].E*0.3;
				}
				if(i!=0&&map[j][i-1].status==2&&map[j][i-1].water==0) {
					map[j][i-1].E=map[j][i].E*0.3;
				}
			}
			for(int i=0;i<11;i++) {
				int j=0,k=0;
				while(k<15) {
					if(map[k][i].water==2) j=k;
					k++;
				}
				if(!isWall(j+1,i,map)) {
				map[j+1][i].E=map[j][i].E*map[j+1][i].Friction;
				map[j+1][i].water=2;}}
			for(int a=0;a<20;a++)
				for(int b=0;b<11;b++)
					if(map[a][b].E>=0.4&&map[a][b].water!=2)
						map[a][b].water=2;
	}
	}
	static boolean isWall(int i,int j,type map[][]) {
		if(map[i][j].status==3) return true;		
		return false;
	}
}
