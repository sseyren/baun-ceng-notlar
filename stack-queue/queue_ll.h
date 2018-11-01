#ifndef _queue_linkedlist
#define _queue_linkedlist

#include "linkedlistnode.h"

struct ll_queue_struct {
	node* list;
	node* tail;
};
typedef ll_queue_struct ll_queue;

ll_queue* ql_init();
void ql_enque(int value, ll_queue* queue);
int ql_deque(ll_queue* queue);
void ql_look(ll_queue* queue);

#endif