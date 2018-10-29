#ifndef _stack_arr
#define _stack_arr

struct array_stack_struct{
	int size;
	int top;
	int* array;
};
typedef array_stack_struct ar_stack;

ar_stack* sa_init();
int sa_pop(ar_stack*);
void sa_push(int value, ar_stack*);
void sa_look(ar_stack*);
int sa_size(ar_stack*);

#endif
