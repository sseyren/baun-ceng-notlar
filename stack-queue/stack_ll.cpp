#include <stdio.h>
#include <stdlib.h>
#include "stack_ll.h"

node* sl_init(){
	return NULL;
}

void sl_push(int value, node** list){
	node* newnode = (node*)malloc(sizeof(node));
	newnode->data = value;
	newnode->next = *list;
	*list = newnode;
}

void sl_look(node* list){
	if(list == NULL){
		printf("NULL\n\n");
		return;
	}
	for(int i = 0; list != NULL; i++){
		printf("pos-> %u, i-> %d, next->%u, data->%d\n", list, i, list->next, list->data);
		list = list->next;
	}
	printf("\n");
}

int sl_pop(node** list){
	if(*list == NULL)
		return -1;
	node* trash = *list;
	*list = (*list)->next;
	int popped = trash->data;
	free(trash);
	return popped;
}