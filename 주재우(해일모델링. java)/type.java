package simple;

public class type {
int status; //1 �ٴ�//2 �� // 3 �ǹ�
int water=0; //ħ������ 1ħ�� 0�ƴ�
double E; // ���� �Ǻ� ���� ��� E
double E1; // ���� �����ټ� �ִ� E ,�����ָ� 0�̵�
double E2; // ���� E ������ ���
double Friction; // ������ ������ 0 ������ 0.2
int dir =0 ;// ��1 �� 2 �� 3 �� 4;
int dir1=0;
public type(int status,double E,double E1,double Friction) {
	this.status=status; 
	this.E=E;
	this.E1=E1;
	this.Friction=Friction;
}
}