#include <stdio.h>
#include <stdlib.h>
#include "circularlist.h"

void cl_bastir(node* list){
	if(list == NULL){
		printf("NULL\n\n");
		return;
	}
	node* root = list;
	node* iter = list;
	int i = 0;
	do {
		printf("pos-> %u, i-> %d, next->%u, data->%d\n", iter, i, iter->next, iter->data);
		iter = iter->next;
		i++;
	} while(iter != root);
	printf("\n");
}

void cl_ekle(node* list, int value){
	node* root = list;
	while(list->next != root){
		list = list->next;
	}
	list->next = (node*)malloc(sizeof(node));
	list->next->data = value;
	list->next->next = root;
}

node* cl_ekleSirali(node* list, int value){
	if (list == NULL){
		node* newroot = (node*)malloc(sizeof(node));
		newroot->data = value;
		newroot->next = newroot;
		return newroot;
	}
	node* root = list;
	if(root->data > value){
		node* newroot = (node*)malloc(sizeof(node));
		newroot->data = value;
		newroot->next = root;
		while(list->next != root)
			list = list->next;
		list->next = newroot;
		return newroot;
	}
	while(list->next != root && list->next->data < value){
		list = list->next;
	}
	node* newnode = (node*)malloc(sizeof(node));
	newnode->data = value;
	newnode->next = list->next;
	list->next = newnode;
	return root;
}

node* cl_sil(node* list, int value){
	node* root = list;
	if(list == NULL)
		return list;
	else if(root->data == value){
		if(root->next == root){
			free(root);
			return NULL;
		}
		node* newroot = root->next;
		while(list->next != root)
			list = list->next;
		list->next = newroot;
		free(root);
		return newroot;
	}
	while(list->next != root && list->next->data != value)
		list = list->next;
	if(list->next != root){
		node* trash = list->next;
		list->next = list->next->next;
		free(trash);
	}
	return root;
}
