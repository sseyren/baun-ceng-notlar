#include <stdio.h>

int array[2], size = 2, top = 0;

int pop(){
	return array[--top];
}

void push(int value){
	array[top++] = value;
}

void look(){
	for(int i = 0; i < top; i++){
		printf("%d -> %d\n", i, array[i]);
	}
}

int main(){
	push(10);
	push(20);
	look();
	printf("popped -> %d\n", pop());
	printf("popped -> %d\n", pop());
	return 0;
}
