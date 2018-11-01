#ifndef _stack_linkedlist
#define _stack_linkedlist

#include "linkedlistnode.h"

node* sl_init();
void sl_push(int value, node** list);
void sl_look(node* list);
int sl_pop(node** list);

#endif
