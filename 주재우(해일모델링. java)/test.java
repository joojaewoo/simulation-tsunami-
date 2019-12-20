package simple;

import java.io.*;
import java.util.*;

public class test {
	static int x=215,y=108;
	static double C=0.55;
	static double S=0.225;
	static double _C=0.7;
	static double _S=0.3;
	static double stop = 0.05;
	public static void main(String[] args) {
		type [][] map=new type[y][x];
		Random ran=new Random();
		int q=107;
		try {
			File file = new File("output.txt");
			Scanner scan= new Scanner(file);
			while(scan.hasNext()) {
				String buf= scan.next();
				for(int w=0;w<x;w++) {
					int a=Integer.parseInt(buf.substring(w,w+1));
					if(a==0) {
						map[q][w]=new type(2,0,0,0.95-ran.nextDouble()*0.02);
					}
					else if(a==1) {
						map[q][w]=new type(3,0,0,0);
					}
					else if(a==2) {
						map[q][w]=new type(1,0,0,1);
						//map[q][w].water=1;
					}
					else if(a==3) {
						map[q][w]=new type(2,0,0,0.99-ran.nextDouble()*0.02);
					}
				}
				q--;
			}
		}
		catch(IOException e) {
			System.out.println("error");	
		}

		//		for(int j=1;j<12;j++){
		//			if(j%4==0||j%4==3) {
		//				for(int i=0;i<x;i++) {
		//					map[j][i]=new type(2,0,0,0.85-ran.nextDouble()*0.1);
		//				}}
		//			else {
		//				for(int i=0;i<x;i++) {
		//					if(i==3||i==4||i==7||i==8) map[j][i]=new type(2,0,0,0.85-ran.nextDouble()*0.1);
		//					else map[j][i]=new type(3,0,0,0);
		//				}
		//			}
		//		}
		for(int i=0;i<x;i++) {
			if(map[0][i].status==1) {
				map[0][i]=new type(1,250000+ran.nextDouble()*50000,0,0);
				map[0][i].E1=map[0][i].E;
				map[0][i].dir=1;
				map[0][i].water=1;
			}
		}
		//		}
		//		for(int i=9;i<y;i++ ) {
		//			for(int j=0;j<12;j++)
		//				map[i][j]=new type(2,0,0,0.85-ran.nextDouble()*0.1);
		//		}
		//		map[2][0].status=2;
		//		map[2][0].Friction=0.85-ran.nextDouble()*0.1;
		//		map[2][1].status=2;
		//		map[2][1].Friction=0.85-ran.nextDouble()*0.1;
		//		System.out.println();
		//		System.out.println();
		//		System.out.println();
		//		System.out.println();
		//		System.out.println();
		//		System.out.println();
		//		System.out.println();
		int step=0;
		File file1=new File("result.txt");
		while(true) {
			int a=0;
			try {
				FileWriter fw= new FileWriter(file1);
				fw.write("STEP : " + step++ +"\n\n");
				for(int i=y-1;i>=0;i--) {
					for(int j=0;j<x;j++) {
						if(map[i][j].water==0) {
							if(map[i][j].status==3)
								fw.write("1");
							else if(map[i][j].status==1)
								fw.write("3");
							else
								fw.write("0");
						}
						//			                  else if(map[i][j].water==1)
						//			                     fw.write(ConsoleColor.BLUE_BRIGHT + "■ " + ConsoleColor.RESET);
						else
							//							if(map[i][j].E1<stop)
							fw.write("2");
						//							else
						//								fw.write("3");
						//						else if(map[i][j].dir==1)
						//							fw.write("↑ ");
						//						else if(map[i][j].dir==2)
						//							fw.write("← ");
						//						else if(map[i][j].dir==3)
						//							fw.write("→ ");
						//						else if(map[i][j].dir==4)
						//							fw.write("↓ ");
					}
					fw.write("\n");
				}
				fw.write("\n\n");
				fw.close();
			}
			catch(IOException e) {

			}
			//			System.out.println("STEP : " + step++);
			//			for(int i=y-1;i>=0;i--) {
			//				for(int j=0;j<x;j++) {
			//					if(map[i][j].water==0) {
			//						if(map[i][j].status==3)
			//							System.out.print("■ ");
			//						else
			//							System.out.print("□ ");
			//					}
			//					//			                  else if(map[i][j].water==1)
			//					//			                     fw.write(ConsoleColor.BLUE_BRIGHT + "■ " + ConsoleColor.RESET);
			//					else if(map[i][j].water==1)
			//						if(map[i][j].E1<stop)
			//							System.out.print(ConsoleColor.RED_BRIGHT + "■ " + ConsoleColor.RESET);
			//						else if(map[i][j].dir==1)
			//							System.out.print("↑ ");
			//						else if(map[i][j].dir==2)
			//							System.out.print("← ");
			//						else if(map[i][j].dir==3)
			//							System.out.print("→ ");
			//						else if(map[i][j].dir==4)
			//							System.out.print("↓ ");
			//				}
			//				System.out.println();
			//			}
			//			if (step==47)
			//				System.out.print(step);
			//			if(map[0][206].E!=0)
			//				System.out.print(step);
			for(int i=0;i<y-1;i++)
				for(int j=0;j<x;j++) {
					if(j==204)
						System.out.print("");
					if(map[i][j].E1>stop) {
						a++;
						set(i,j,map);
					}
				}
			for(int i=0;i<y;i++) {
				for(int j=0;j<x;j++) {
					if(map[i][j].E2!=0) {
						map[i][j].E1+=map[i][j].E2;
						map[i][j].E+=map[i][j].E2;
						if(map[i][j].dir1!=0)
							map[i][j].dir=map[i][j].dir1;
					}
					map[i][j].E2=0;
					if(map[i][j].water==0&&map[i][j].E>stop&&map[i][j].status!=3)
						map[i][j].water=1;
				}
			}
			if(a==0) {
				System.out.print("end");
				break;	
			}
		}
	}
	static int isWall(int i,int j,type map[][]) {
		if(i>=y||i<0||j>=x||j<0)
			return -1;
		if(map[i][j].status==3) return 0;		
		return 1;
	}
	static int dir(int i,int j,type map[][]) {
		int dir = map[i][j].dir;
		if(dir==1) return isWall(i+1,j,map);
		else if(dir==2) return isWall(i,j-1,map);
		else if(dir==3) return isWall(i,j+1,map);
		else return isWall(i-1,j,map);
	}
	static void seekDir(int i,int j,type map[][]) {
		if(map[i][j].dir==1)
			setPowerF(i,j,map,1);
		else if(map[i][j].dir==2)
			setPowerS(i,j,map,-1); //왼쪽
		else if(map[i][j].dir==3)
			setPowerS(i,j,map,1); // 오른쪽
		else
			setPowerF(i,j,map,-1);
	}
	static void setPowerF(int i,int j,type map[][],int k) { 
		double E=0;
		if(isWall(i,j+1,map)!=0&&isWall(i,j-1,map)!=0) { //3방향으로 갈수 있을때
			if(isWall(i+k,j,map)==1) {
				if(map[i+k][j].water==0) {
					E=map[i][j].E1*map[i+k][j].Friction*C;
				}
				else 
					E=map[i][j].E1*C;				
				if(map[i+k][j].E<E)
					if(k==1)
						map[i+k][j].dir1=1;
					else
						map[i+k][j].dir1=4;
				map[i+k][j].E2+=E;
			}
			if(isWall(i,j-1,map)==1) {
				if(map[i][j-1].water==0) {
					E=map[i][j].E1*map[i][j-1].Friction*S;
					map[i][j-1].E2+=E;
					map[i][j-1].dir1=2;
				}
				else {
					E=map[i][j].E1*S;
					if(map[i][j-1].dir==3) {
						break_FL(i,j,map,E);
					}
					else {
						if(map[i][j-1].E<E) 
							map[i][j-1].dir1=2;
						map[i][j-1].E2+=E;
					}
				}
			}
			if(isWall(i,j+1,map)==1) {
				if(map[i][j+1].water==0) {
					E=map[i][j].E1*map[i][j+1].Friction*S;
					map[i][j+1].E2+=E;
					map[i][j+1].dir1=3;
				}
				else {
					E=map[i][j].E1*S;
					if(map[i][j+1].dir==2) {
						break_FR(i,j,map,E);
					}
					else {
						if(map[i][j+1].E<E) 
							map[i][j+1].dir1=3;
						map[i][j+1].E2+=E;
					}
				}
			}
		}
		else if(isWall(i,j+1,map)!=0) { // 앞과 우측으로만 갈수 있을 때
			if(map[i+k][j].water==0) {
				E=map[i][j].E1*map[i+1][j].Friction*_C;
				if(k==1)
					map[i+k][j].dir1=1;
				else
					map[i+k][j].dir1=4;
			}
			else {
				E=map[i][j].E1*0.7;
				if(map[i+k][j].E<E) {
					if(k==1)
						map[i+k][j].dir1=1;
					else
						map[i+k][j].dir1=4;
				}
			}
			map[k+1][j].E2+=E;
			if(isWall(i,j+1,map)==1) {
				if(map[i][j+1].water==0) {
					map[i][j+1].dir1=3;
					E=map[i][j].E1*map[i][j+1].Friction*_S;
					map[i][j+1].E2+=E;
				}
				else {
					E=map[i][j].E1*0.3;
					if(map[i][j+1].dir==2) {
						break_FR(i,j,map,E);
					}
					else {
						if(map[i][j+1].E<E)
							map[i][j+1].dir1=3;
						map[i][j+1].E2+=E;
					}
				}
			}
		}
		else if(isWall(i,j-1,map)!=0) { // 앞과 좌측으로만 갈수 있을 때
			if(map[k+1][j].water==0) {
				E=map[i][j].E1*map[k+1][j].Friction*_C;
				if(k==1)
					map[i+k][j].dir1=1;
				else
					map[i+k][j].dir1=4;
			}
			else {
				E=map[i][j].E1*0.7;
				if(map[i+k][j].E<E) {
					if(k==1)
						map[i+k][j].dir1=1;
					else
						map[i+k][j].dir1=4;
				}
			}
			map[i+k][j].E2+=E;
			if(isWall(i,j-1,map)==1) {
				if(map[i][j-1].water==0) {
					map[i][j-1].dir1=2;
					E=map[i][j].E1*map[i][j-1].Friction*_S;
					map[i][j-1].E2+=E;
				}
				else {
					E=map[i][j].E1*0.3;
					if(map[i][j-1].dir==3) {
						break_FL(i,j,map,E);
					}
					else {
						if(map[i][j-1].E<E)
							map[i][j-1].dir1=2;
						map[i][j-1].E2+=E;
					}
				}
			}
		}
		else {
			if(map[i+k][j].water==0)
			{
				E=map[i][j].E1*map[i+k][j].Friction;
				if(k==1)
					map[i+k][j].dir1=1;
				else
					map[i+k][j].dir1=4;
			}
			else {
				E=map[i][j].E1;
				if(map[i+k][j].E<E)
					if(k==1)
						map[i+k][j].dir1=1;
					else
						map[i+k][j].dir1=4;
			}
			map[i+k][j].E2+=E;
		}
	}
	static void setPowerS(int i,int j,type map[][],int k) {
		double E=0;
		if(isWall(i+1,j,map)!=0&&isWall(i-1,j,map)!=0) { //3방향 으로 갈때
			if(isWall(i+1,j,map)==1) { //앞이 길일때
				if(map[i+1][j].water==0) {
					E=map[i][j].E1*map[i+1][j].Friction*S;
					map[i+1][j].dir1=1;
				}
				else {
					E=map[i][j].E1*S;
					if(map[i+1][j].E<E)
						map[i+1][j].dir1=1;
				}
				map[i+1][j].E2+=E;
			}
			if(isWall(i-1,j,map)==1) {
				if(map[i-1][j].water==0) {
					E=map[i][j].E1*map[i+1][j].Friction*S;
					map[i-1][j].dir1=4;
				}
				else {
					E=map[i][j].E1*S;
					if(map[i+1][j].E<E)
						map[i+1][j].dir1=4;
				}
				map[i-1][j].E2+=E;
			}
			if(map[i][j+k].water==0) {
				E=map[i][j].E1*map[i][j+k].Friction*C;
				map[i][j+k].E2+=E;
				if(k==1)
					map[i][j+k].dir1=3;
				else
					map[i][j+k].dir1=2;
			}
			else {
				E=map[i][j].E1*C;
				if(k==1&&map[i][j+k].dir==2) {
					break_R(i,j,map,E);
				}
				else if(k==-1&&map[i][j+k].dir==3) {
					break_L(i,j,map,E);
				}
				else {
					if(map[i][j+k].E<E)
						if(k==1)
							map[i][j+k].dir1=3;
						else
							map[i][j+k].dir1=2;
					map[i][j+k].E2+=E;
				}
			}
		}
		else if(isWall(i+1,j,map)!=0) { // 앞과 좌 or 우로 갈수있을때
			if(isWall(i+1,j,map)==1) { //앞이 길일때
				if(map[i+1][j].water==0) {
					E=map[i][j].E1*map[i+1][j].Friction*_S;
					map[i+1][j].dir1=1;
				}
				else {
					E=map[i][j].E1*0.3;
					if(map[i+1][j].E<E)
						map[i+1][j].dir1=1;
				}
				map[i+1][j].E2+=E;
			}
			if(map[i][j+k].water==0) {
				E=map[i][j].E1*map[i][j+k].Friction*_C;
				map[i][j+k].E2+=E;
				if(k==1)
					map[i][j+k].dir1=3;
				else
					map[i][j+k].dir1=2;
			}
			else {
				E=map[i][j].E1*0.7;
				if(k==1&&map[i][j+k].dir==2) {
					break_R(i,j,map,E);
				}
				else if(k==-1&&map[i][j+k].dir==3) {
					break_L(i,j,map,E);
				}
				else {
					if(map[i][j+k].E<E)
						if(k==1)
							map[i][j+k].dir1=3;
						else
							map[i][j+k].dir1=2;
					map[i][j+k].E2+=E;
				}
			}
		}
		else if(isWall(i-1,j,map)!=0) { // 앞과 좌 or 우측으로만 갈수 있을 때
			if(isWall(i-1,j,map)==1) { //앞이 길일때
				if(map[i-1][j].water==0) {
					E=map[i][j].E1*map[i-1][j].Friction*_S;
					map[i-1][j].dir1=4;
				}
				else {
					E=map[i][j].E1*0.3;
					if(map[i-1][j].E<E)
						map[i-1][j].dir1=4;
				}
				map[i-1][j].E2+=E;
			}
			if(map[i][j+k].water==0) {
				E=map[i][j].E1*map[i][j+k].Friction*_C;
				map[i][j+k].E2+=E;
				if(k==1)
					map[i][j+k].dir1=3;
				else
					map[i][j+k].dir1=2;
			}
			else {
				E=map[i][j].E1*0.7;
				if(k==1&&map[i][j+k].dir==2) {
					break_R(i,j,map,E);
				}
				else if(k==-1&&map[i][j+k].dir==3) {
					break_L(i,j,map,E);
				}
				else {
					if(map[i][j+k].E<E)
						if(k==1)
							map[i][j+k].dir1=3;
						else
							map[i][j+k].dir1=2;
					map[i][j+k].E2+=E;
				}
			}
		}
		else {//앞으로만 갈수있을때  todo
			if(map[i][j+k].water==0) {
				E=map[i][j].E1*map[i][j+k].Friction;
				map[i][j+k].E2+=E;
				if(k==1)
					map[i][j+k].dir1=3;
				else
					map[i][j+k].dir1=2;
			}
			else {
				E=map[i][j].E1;
				if(k==1&&map[i][j+k].dir==2) {
					break_R(i,j,map,E);

				}
				else if(k==-1&&map[i][j+k].dir==3) {
					break_L(i,j,map,E);
				}
				else {
					if(map[i][j+k].E<E)
						if(k==1)
							map[i][j+k].dir1=3;
						else
							map[i][j+k].dir1=2;
					map[i][j+k].E2+=E;
				}
			}
		}
	}
	static public void set(int i,int j, type map[][]) {
		if(dir(i,j,map)==0) { //진행방향이 벽일때
			double E=0;
			double E1=0;
			int r=0;
			if(map[i][j].dir==1||map[i][j].dir==4) {
				if(map[i][j].dir==1) r=1;
				int R=search_R(i+r,j,map,1);
				int L=search_L(i+r,j,map,1);
				if(R>L) {
					if(L>0) {
						map[i][j].dir1=2;
						if(isWall(i,j+1,map)==1&&isWall(i,j+1,map)==1) {
							if(map[i][j+1].water==0) {
								E1=map[i][j].E1*map[i][j+1].Friction*0.4;
								map[i][j].E1*=0.5;
								map[i][j+1].E2+=E1;
								map[i][j+1].dir1=3;								
							}
						}
						if(map[i][j-1].water==0) {
							E=map[i][j].E1*map[i][j-1].Friction*0.8;
							map[i][j-1].E2+=E;
						}
						else {
							E=map[i][j].E1*0.8;
							if(map[i][j-1].dir==3)
								break_L(i,j,map,E);
							else {
								map[i][j-1].E2+=E;
							}
						}
					}
					else {
						map[i][j].dir1=3;
						if(isWall(i,j-1,map)==1&&map[i][j-1].water==0) {
							E1=map[i][j].E1*map[i][j-1].Friction*0.4;
							map[i][j].E1*=0.5;
							map[i][j-1].E2+=E1;
							map[i][j-1].dir1=2;		
						}						
						if(map[i][j+1].water==0) {
							E=map[i][j].E1*map[i][j+1].Friction*0.8;
							map[i][j+1].E2+=E;
						}
						else {
							E=map[i][j].E1*0.8;
							if(map[i][j+1].dir==3) {
								break_R(i,j,map,E);

							}
							else {
								map[i][j+1].E2+=E;
							}
						}
					}
				}
				else if(L>R) {
					if(R<0) {
						map[i][j].dir1=2;
						if(isWall(i,j+1,map)==1&&map[i][j+1].water==0) {
							E1=map[i][j].E1*map[i][j+1].Friction*0.4;
							map[i][j].E1*=0.5;
							map[i][j+1].E2+=E1;
							map[i][j+1].dir1=3;		
						}						
						if(map[i][j-1].water==0) {
							E=map[i][j].E1*map[i][j-1].Friction*0.8;
							map[i][j-1].E2+=E;
						}
						else {
							E=map[i][j].E1*0.8;
							if(map[i][j-1].dir==3)
								break_L(i,j,map,E);
							else {
								map[i][j-1].E2+=E;
							}
						}
					}
					else  {
						map[i][j].dir1=3;
						if(isWall(i,j-1,map)==1&&map[i][j-1].water==0) {
							E1=map[i][j].E1*map[i][j-1].Friction*0.4;
							map[i][j].E1*=0.5;
							map[i][j-1].E2+=E1;
							map[i][j-1].dir1=2;		
						}					
						if(map[i][j+1].water==0) {
							E=map[i][j].E1*map[i][j+1].Friction*0.8;
							map[i][j+1].E2+=E;
						}
						else {
							E=map[i][j].E1*0.8;
							if(map[i][j+1].dir==3) {
								break_R(i,j,map,E);

							}
							else {
								map[i][j+1].E2+=E;
							}
						}
					}
				}
				else {
					Random rand=new Random();
					boolean k = rand.nextBoolean();
					if(k) map[i][j].dir1=2;
					else map[i][j].dir1=3;
					if(map[i][j-1].water==1) {
						E=map[i][j].E1*0.4;
						if(map[i][j-1].dir==3) {
							break_L(i,j,map,E);
						}
						else
							map[i][j-1].E2+=E;
					}
					else {
						E=map[i][j].E1*map[i][j-1].Friction*0.4;
						map[i][j-1].E2+=E;
					}
					if(map[i][j+1].water==1) {
						E=map[i][j].E1*0.4;
						if(map[i][j+1].dir==2) {
							break_R(i,j,map,E);
						}
						else
							map[i][j+1].E2+=E;
					}
					else {
						E=map[i][j].E1*map[i][j+1].Friction*0.4;
						map[i][j+1].E2+=E;
					}
				}
			}
			else {
				E=map[i][j].E1*0.4;
				if(isWall(i+1,j,map)!=0&&isWall(i-1,j,map)!=0) {
					map[i][j].dir1=1;
					if(map[i+1][j].E<E)
					map[i+1][j].dir1=1;
					map[i+1][j].E2=E;
					if(map[i-1][j].E<E)
					map[i-1][j].dir1=4;
					map[i-1][j].E2=E;
				}
				else if(isWall(i+1,j,map)!=0) {
					map[i][j].dir1=1;
					if(map[i+1][j].E<E)
					map[i+1][j].dir1=1;
					map[i+1][j].E2=E*2;	
				}
				else if(isWall(i-1,j,map)!=0){
					map[i][j].dir1=4;
					if(map[i-1][j].E<E)
					map[i-1][j].dir1=4;
					map[i-1][j].E2=E*2;
				}
				//				int F=search_F(i,j+r,map,1);
				//				int B=search_B(i,j+r,map,1);
				//				if(F>B) {
				//					if(B>0) {
				//						map[i][j].dir1=4;
				//						if(map[i-1][j].water==0) {
				//							E=map[i][j].E1*map[i-1][j].Friction*0.8;
				//							map[i-1][j].E2+=E;
				//						}
				//						else {
				//							E=map[i][j].E1*0.8;
				//							//							if(map[i-1][j].dir==3)
				//							//								break_L(i,j,map,E);
				//							//							else {
				//							map[i-1][j].E2+=E;
				//							//								}
				//						}
				//					}
				//					else {
				//						map[i][j].dir1=1;
				//						if(map[i+1][j].water==0) {
				//							E=map[i][j].E1*map[i+1][j].Friction*0.8;
				//							map[i+1][j].E2+=E;
				//						}
				//						else {
				//							E=map[i][j].E1*0.8;
				//							//							if(map[i][j+1].dir==3) {
				//							//								break_R(i,j,map,E);
				//							//
				//							//							}
				//							//							else {
				//							map[i+1][j].E2+=E;
				//							//							}
				//						}
				//					}
				//				}
				//				else if(B>F) {
				//					if(B>0) {
				//						map[i][j].dir1=4;
				//						if(map[i-1][j].water==0) {
				//							E=map[i][j].E1*map[i-1][j].Friction*0.8;
				//							map[i-1][j].E2+=E;
				//						}
				//						else {
				//							E=map[i][j].E1*0.8;
				//							//							if(map[i-1][j].dir==3)
				//							//								break_L(i,j,map,E);
				//							//							else {
				//							map[i-1][j].E2+=E;
				//							//								}
				//						}
				//					}
				//					else {
				//						map[i][j].dir1=1;
				//						if(map[i+1][j].water==0) {
				//							E=map[i][j].E1*map[i+1][j].Friction*0.8;
				//							map[i+1][j].E2+=E;
				//						}
				//						else {
				//							E=map[i][j].E1*0.8;
				//							//							if(map[i][j+1].dir==3) {
				//							//								break_R(i,j,map,E);
				//							//
				//							//							}
				//							//							else {
				//							map[i+1][j].E2+=E;
				//							//							}
				//						}
				//					}		
				//				}
				//				else {
				//					Random rand=new Random();
				//					boolean k = rand.nextBoolean();
				//					if(k) map[i][j].dir1=1;
				//					else map[i][j].dir1=4;
				//					if(map[i-1][j].water==1) {
				//						E=map[i][j].E1*0.4;
				//						//						if(map[i-1][j-1].dir==3) {
				//						//							break_L(i,j,map,E);
				//						//						}
				//						//						else
				//						map[i-1][j].E2+=E;
				//					}
				//					else {
				//						E=map[i][j].E1*map[i-1][j].Friction*0.4;
				//						map[i-1][j].E2+=E;
				//					}
				//					if(map[i+1][j].water==1) {
				//						E=map[i][j].E1*0.4;
				//						//						if(map[i][j].dir==2) {
				//						//							break_R(i,j,map,E);
				//						//						}
				//						//						else
				//						map[i+1][j].E2+=E;
				//					}
				//					else {
				//						E=map[i][j].E1*map[i+1][j].Friction*0.4;
				//						map[i+1][j].E2+=E;
				//					}
				//				}
				//			}
			}
		}
		else if(dir(i,j,map)==1) {
			seekDir(i,j,map);
		}
		map[i][j].E1=0;
	}
	static public int search_R(int i,int j,type map[][],int k) {
		if(isWall(i,j+k,map)==-1)
			return -1;
		else if(isWall(i,j+k,map)==1) 
			return k;
		else
			return search_R(i,j,map,k+1);

	}
	static public int search_L(int i,int j,type map[][],int k) {
		if(isWall(i,j-k,map)==-1)
			return -1;
		else if(isWall(i,j-k,map)==1)
			return k;
		else
			return search_L(i,j,map,k+1);
	}
	static public int search_F(int i,int j,type map[][],int k) {
		if(isWall(i+k,j,map)==-1)
			return -1;
		else if(isWall(i+k,j,map)==1) 
			return k;
		else
			return search_R(i,j,map,k+1);

	}
	static public int search_B(int i,int j,type map[][],int k) {
		if(isWall(i-k,j,map)==-1)
			return -1;
		else if(isWall(i-k,j,map)==1)
			return k;
		else
			return search_L(i,j,map,k+1);
	}
	static public void break_L(int i,int j,type map[][],double E) {
		double a=map[i][j-1].E2;
		double b=map[i][j].E1;
		if(a>b) {
			map[i][j-1].E2-=E;
			map[i][j].dir=3;
			map[i][j].dir1=3;
		}
		else if(a<b) {
			if(E>a)
				map[i][j-1].E1=E-a;
			else
				map[i][j-1].E1=0;
			map[i][j-1].dir=2;
			map[i][j-1].dir1=2;
		}
		else {
			map[i][j-1].E2=0;
		}
	}
	static public void break_R(int i,int j,type map[][],double E) {
		double a=map[i][j+1].E1;
		double b=map[i][j].E1;
		if(a>b) {
			map[i][j+1].E1-=E;
			map[i][j].dir=2;
			map[i][j].dir1=2;
		}
		else if(a<b) {
			if(E>a)
				map[i][j+1].E1=E-a;
			else
				map[i][j+1].E1=0;
			map[i][j+1].dir=3;
			map[i][j+1].dir1=3;
		}
		else {
			map[i][j+1].E1=0;
		}
	}
	static public void break_FR(int i,int j,type map[][],double E) {
		double a=map[i][j+1].E1;
		if(a>E) {
			map[i][j+1].E1-=E;
		}
		else {
			map[i][j+1].E1=0;
		}
	}
	static public void break_FL(int i,int j,type map[][],double E) {
		double a=map[i][j-1].E1;
		if(a>E) {
			map[i][j-1].E1-=E;
		}
		else {
			map[i][j-1].E1=0;
		}
	}
}
