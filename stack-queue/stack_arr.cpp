#include <stdio.h>
#include <stdlib.h>
#include "stack_arr.h"

ar_stack* sa_init(){
	ar_stack* stack = (ar_stack*)malloc(sizeof(stack));
	stack->size = 2;
	stack->top = 0;
	stack->array = NULL;
	return stack;
}

int sa_pop(ar_stack* stack){
	if(stack->top == 0)
		return -1;
	if(stack->top != 1 && stack->size/(stack->top-1) >= 4){
		int newsize = stack->size / 2;
		int* newarray = (int*)malloc(sizeof(int)*newsize);
		for(int i = 0; i < stack->top; i++)
			newarray[i] = stack->array[i];
		free(stack->array);
		stack->array = newarray;
		stack->size = newsize;
	}
	return stack->array[--stack->top];
}

void sa_push(int value, ar_stack* stack){
	if (stack->array == NULL)
		stack->array = (int*)malloc(sizeof(int)*stack->size);
	if (stack->top >= stack->size){
		int newsize = stack->size * 2;
		int* newarray = (int*)malloc(sizeof(int)*newsize);
		for(int i = 0; i < stack->size; i++)
			newarray[i] = stack->array[i];
		free(stack->array);
		stack->array = newarray;
		stack->size = newsize;
	}
	stack->array[stack->top++] = value;
}

void sa_look(ar_stack* stack){
	printf("-------- Size: %d | Top: %d --------\n", stack->size, stack->top);
	for(int i = 0; i < stack->top; i++){
		printf("%d -> %d\n", i, stack->array[i]);
	}
	printf("------------------------------------\n");
}

int sa_size(ar_stack* stack){
	return stack->size;
}
