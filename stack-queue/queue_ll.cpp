#include <stdio.h>
#include <stdlib.h>
#include "queue_ll.h"

ll_queue* ql_init(){
	ll_queue* queue = (ll_queue*)malloc(sizeof(ll_queue));
	queue->list = NULL;
	queue->tail = queue->list;
	return queue;
}

void ql_enque(int value, ll_queue* queue){
	node* newnode = (node*)malloc(sizeof(node));
	newnode->data = value;
	newnode->next = NULL;
	if(queue->tail == NULL){
		queue->list = newnode;
		queue->tail = newnode;
	}else{
		queue->tail->next = newnode;
		queue->tail = newnode;
	}
}

int ql_deque(ll_queue* queue){
	if(queue->list == NULL)
		return -1;
	node* trash = queue->list;
	queue->list = queue->list->next;
	if(queue->list == NULL)
		queue->tail = NULL;
	int dequed = trash->data;
	free(trash);
	return dequed;
}

void ql_look(ll_queue* queue){
	if(queue->list == NULL){
		printf("NULL\n\n");
		return;
	}
	node* iter = queue->list;
	for(int i = 0; iter != NULL; i++){
		printf("pos-> %u, i-> %d, next->%u, data->%d\n", iter, i, iter->next, iter->data);
		iter = iter->next;
	}
	printf("tail -> %u, data-> %d\n", queue->tail, queue->tail->data);
}