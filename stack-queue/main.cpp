#include <stdio.h>
#include "stack_arr.h"
#include "stack_ll.h"
#include "queue_arr.h"

int main(){
	printf("<--------- Array ile stack örneği --------->\n");

	ar_stack* ar_stack1 = sa_init();
	ar_stack* ar_stack2 = sa_init();

	for (int i = 0; i < 10; i++)
		sa_push(i*10, ar_stack1);
	sa_look(ar_stack1);
	for (int i = 0; i < 10; i++)
		sa_push(sa_pop(ar_stack1), ar_stack2);
	sa_look(ar_stack2);
	sa_look(ar_stack1);

	/*
	int loopcount = 268435456;

	int cursize = -1;
	for(int i = 0; i < loopcount; i++){
		sa_push(i, ar_stack1);
		if(sa_size(ar_stack1) != cursize){
			cursize = sa_size(ar_stack1);
			printf("current size -> %d\n", cursize);
		}
	}

	for(int i = 0; i < loopcount; i++){
		sa_pop(ar_stack1);
		if(sa_size(ar_stack1) != cursize){
			cursize = sa_size(ar_stack1);
			printf("current size -> %d\n", cursize);
		}
	}
	*/

	printf("\n\n<--------- Linked list ile stack örneği --------->\n");

	node* ll_stack1 = sl_init();

	sl_push(10, &ll_stack1);
	sl_push(20, &ll_stack1);
	sl_push(30, &ll_stack1);

	sl_look(ll_stack1);

	printf("popped -> %d\n", sl_pop(&ll_stack1));
	printf("popped -> %d\n", sl_pop(&ll_stack1));
	sl_look(ll_stack1);
	sl_push(150, &ll_stack1);
	sl_push(300, &ll_stack1);
	sl_look(ll_stack1);
	printf("popped -> %d\n", sl_pop(&ll_stack1));
	printf("popped -> %d\n", sl_pop(&ll_stack1));
	printf("popped -> %d\n", sl_pop(&ll_stack1));
	printf("popped -> %d\n", sl_pop(&ll_stack1));
	sl_look(ll_stack1);

	sl_push(1, &ll_stack1);
	sl_push(2, &ll_stack1);
	sl_push(3, &ll_stack1);
	sl_look(ll_stack1);
	printf("popped -> %d\n", sl_pop(&ll_stack1));
	printf("popped -> %d\n", sl_pop(&ll_stack1));
	printf("popped -> %d\n", sl_pop(&ll_stack1));
	sl_look(ll_stack1);

	/*
	for(int i = 0; i < 67108864; i++)
		sl_push(i, &ll_stack1);

	for(int i = 0; i < 67108864; i++)
		sl_pop(&ll_stack1);
	*/

	printf("\n\n<--------- Array ile queue örneği --------->\n");

	ar_queue* ar_queue1 = qa_init();

	qa_enque(10, ar_queue1);
	qa_enque(20, ar_queue1);
	qa_look(ar_queue1);
	printf("deque -> %d\n", qa_deque(ar_queue1));
	printf("deque -> %d\n", qa_deque(ar_queue1));
	qa_look(ar_queue1);

	qa_enque(10, ar_queue1);
	qa_enque(20, ar_queue1);
	qa_enque(30, ar_queue1);
	qa_enque(40, ar_queue1);
	qa_look(ar_queue1);
	printf("deque -> %d\n", qa_deque(ar_queue1));
	qa_enque(50, ar_queue1);
	qa_look(ar_queue1);
	qa_enque(60, ar_queue1);
	qa_look(ar_queue1);


	return 0;
}
