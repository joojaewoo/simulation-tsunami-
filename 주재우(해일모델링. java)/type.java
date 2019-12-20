package simple;

public class type {
int status; //1 바다//2 땅 // 3 건물
int water=0; //침수여부 1침수 0아님
double E; // 높이 판별 셀의 모든 E
double E1; // 현재 나눠줄수 있는 E ,나눠주면 0이됨
double E2; // 받은 E 다음에 사용
double Friction; // 마찰력 물에서 0 땅에서 0.2
int dir =0 ;// 앞1 왼 2 오 3 뒤 4;
int dir1=0;
public type(int status,double E,double E1,double Friction) {
	this.status=status; 
	this.E=E;
	this.E1=E1;
	this.Friction=Friction;
}
}