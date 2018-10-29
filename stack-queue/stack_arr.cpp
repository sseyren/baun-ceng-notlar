#include <stdio.h>
#include <stdlib.h>

int size = 2, top = 0;
int* array = (int*)malloc(sizeof(int)*size);

int pop(){
	if(top == 0)
		return -1;
	if(top != 1 && size/(top-1) >= 4){
		int newsize = size / 2;
		int* newarray = (int*)malloc(sizeof(int)*newsize);
		for(int i = 0; i < top; i++)
			newarray[i] = array[i];
		free(array);
		array = newarray;
		size = newsize;
	}
	return array[--top];
}

void push(int value){
	if (top >= size){
		int newsize = size * 2;
		int* newarray = (int*)malloc(sizeof(int)*newsize);
		for(int i = 0; i < size; i++)
			newarray[i] = array[i];
		free(array);
		array = newarray;
		size = newsize;
	}
	array[top++] = value;
}

void look(){
	printf("-------- Size: %d | Top: %d --------\n", size, top);
	for(int i = 0; i < top; i++){
		printf("%d -> %d\n", i, array[i]);
	}
	printf("------------------------------------\n");
}

int main(){
	push(10);
	push(20);
	look();
	printf("popped -> %d\n", pop());
	printf("popped -> %d\n", pop());

	push(10);
	push(20);
	push(30);
	push(40);
	push(50);
	push(60);
	look();
	printf("popped -> %d\n", pop());
	look();
	printf("popped -> %d\n", pop());
	look();
	printf("popped -> %d\n", pop());
	look();
	printf("popped -> %d\n", pop());
	look();
	printf("popped -> %d\n", pop());
	look();
	printf("popped -> %d\n", pop());
	look();
	printf("popped -> %d\n", pop());
	look();

	int loopcount = 268435456;

	int cursize = -1;
	for(int i = 0; i < loopcount; i++){
		push(i);
		if(size != cursize){
			printf("current size -> %d\n", size);
			cursize = size;
		}
	}

	for(int i = 0; i < loopcount; i++){
		pop();
		if(size != cursize){
			printf("current size -> %d\n", size);
			cursize = size;
		}
	}

	return 0;
}
