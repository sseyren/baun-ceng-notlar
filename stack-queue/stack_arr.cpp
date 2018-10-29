#include <stdio.h>
#include <stdlib.h>
#include "stack_arr.h"

int sa_size = 2, sa_top = 0;
int* sa_array = (int*)malloc(sizeof(int)*sa_size);

int sa_pop(){
	if(sa_top == 0)
		return -1;
	if(sa_top != 1 && sa_size/(sa_top-1) >= 4){
		int newsize = sa_size / 2;
		int* newarray = (int*)malloc(sizeof(int)*newsize);
		for(int i = 0; i < sa_top; i++)
			newarray[i] = sa_array[i];
		free(sa_array);
		sa_array = newarray;
		sa_size = newsize;
	}
	return sa_array[--sa_top];
}

void sa_push(int value){
	if (sa_top >= sa_size){
		int newsize = sa_size * 2;
		int* newarray = (int*)malloc(sizeof(int)*newsize);
		for(int i = 0; i < sa_size; i++)
			newarray[i] = sa_array[i];
		free(sa_array);
		sa_array = newarray;
		sa_size = newsize;
	}
	sa_array[sa_top++] = value;
}

void sa_look(){
	printf("-------- Size: %d | Top: %d --------\n", sa_size, sa_top);
	for(int i = 0; i < sa_top; i++){
		printf("%d -> %d\n", i, sa_array[i]);
	}
	printf("------------------------------------\n");
}

int sa_currentSize(){
	return sa_size;
}
