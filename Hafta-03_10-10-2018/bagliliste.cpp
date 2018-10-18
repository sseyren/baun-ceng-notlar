#include <stdio.h>
#include <stdlib.h>

struct nodeStruct {
	int data;
	nodeStruct* next;
};
typedef nodeStruct node;

void bastir(node* list){
	node* iter = list;
	for(int i = 0; iter != NULL; i++){
		printf("pos-> %u, i-> %d, next->%u, data->%d\n", iter, i, iter->next, iter->data);
		iter = iter->next;
	}
}

void ekle(node* list, int value){
	while(list->next != NULL){
		list = list->next;
	}
	list->next = (node*)malloc(sizeof(node));
	list->next->data = value;
	list->next->next = NULL;
}

int main() {
	node* root = (node*)malloc(sizeof(node));
	root->data = 500;
	root->next = NULL;

	node* iter = root;

	for(int i = 0; i < 5; i++){
		ekle(iter, i);
		//  ekle()'nin her seferinde listenin sonuna gitmesi için
		// baştan başlayarak bakması yerine, sona yakın bir düğümden
		// bakması ciddi tasarruf sağlamakta.

		// iter = iter->next;
	}

	bastir(root);
}
