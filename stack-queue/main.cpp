#include <stdio.h>
#include "stack_arr.h"

int main(){
	sa_push(10);
	sa_push(20);
	sa_look();
	printf("popped -> %d\n", sa_pop());
	printf("popped -> %d\n", sa_pop());

	sa_push(10);
	sa_push(20);
	sa_push(30);
	sa_push(40);
	sa_push(50);
	sa_push(60);
	sa_look();
	printf("popped -> %d\n", sa_pop());
	sa_look();
	printf("popped -> %d\n", sa_pop());
	sa_look();
	printf("popped -> %d\n", sa_pop());
	sa_look();
	printf("popped -> %d\n", sa_pop());
	sa_look();
	printf("popped -> %d\n", sa_pop());
	sa_look();
	printf("popped -> %d\n", sa_pop());
	sa_look();
	printf("popped -> %d\n", sa_pop());
	sa_look();

	int loopcount = 268435456;

	int cursize = -1;
	for(int i = 0; i < loopcount; i++){
		sa_push(i);
		if(sa_currentSize() != cursize){
			printf("current size -> %d\n", sa_currentSize());
			cursize = sa_currentSize();
		}
	}

	for(int i = 0; i < loopcount; i++){
		sa_pop();
		if(sa_currentSize() != cursize){
			printf("current size -> %d\n", sa_currentSize());
			cursize = sa_currentSize();
		}
	}

	return 0;
}
