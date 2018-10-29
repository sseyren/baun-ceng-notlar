#include <stdio.h>
#include "stack_arr.h"

int main(){
	ar_stack* stack1 = sa_init();
	ar_stack* stack2 = sa_init();

	for (int i = 0; i < 10; i++)
		sa_push(i*10, stack1);
	sa_look(stack1);
	for (int i = 0; i < 10; i++)
		sa_push(sa_pop(stack1), stack2);
	sa_look(stack2);
	sa_look(stack1);


	int loopcount = 268435456;

	int cursize = -1;
	for(int i = 0; i < loopcount; i++){
		sa_push(i, stack1);
		if(sa_size(stack1) != cursize){
			cursize = sa_size(stack1);
			printf("current size -> %d\n", cursize);
		}
	}

	for(int i = 0; i < loopcount; i++){
		sa_pop(stack1);
		if(sa_size(stack1) != cursize){
			cursize = sa_size(stack1);
			printf("current size -> %d\n", cursize);
		}
	}

	return 0;
}
