#ifndef _linkedlist_arr
#define _linkedlist_arr

#include "linkedlistnode.h"

node* sl_init();
void sl_push(int value, node** list);
void sl_look(node* list);
int sl_pop(node** list);

#endif
