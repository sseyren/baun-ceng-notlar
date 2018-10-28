#include <stdio.h>
#include <stdlib.h>
#include "linkedlist.h"

void bastir(node* list){
	if(list == NULL){
		printf("NULL\n\n");
		return;
	}
	node* iter = list;
	for(int i = 0; iter != NULL; i++){
		printf("pos-> %u, i-> %d, next->%u, data->%d\n", iter, i, iter->next, iter->data);
		iter = iter->next;
	}
	printf("\n");
}

void ekle(node* list, int value){
	while(list->next != NULL){
		list = list->next;
	}
	list->next = (node*)malloc(sizeof(node));
	list->next->data = value;
	list->next->next = NULL;
}

node* ekleSirali(node* list, int value){
	node* root = list;
	node* before = list;
	while(list != NULL && list->data < value){
		before = list;
		list = list -> next;
	}
	node* temp = (node*)malloc(sizeof(node));
	temp->data = value;
	temp->next = list;
	if ( before == list )
		return temp;
	before->next = temp;
	return root;
}

node* sil(node* list, int value){
	if(list == NULL)
		return list;
	else if(list->data == value){
		node* newroot = list->next;
		free(list);
		return newroot;
	}
	node* root = list;
	while(list->next != NULL && list->next->data != value)
		list = list->next;
	if(list->next != NULL){
		node* trash = list->next;
		list->next = list->next->next;
		free(trash);
	}
	return root;
}
