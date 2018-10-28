#include <stdio.h>
#include <stdlib.h>
#include "circularlist.h"

int main() {
	/*
	node* root = (node*)malloc(sizeof(node));
	root->data = 0;
	root->next = root;

	node* iter = root;

	for(int i = 0; i < 5; i++){
		ekle(iter, (i+1)*10);
		//  ekle()'nin her seferinde listenin sonuna gitmesi için
		// baştan başlayarak bakması yerine, sona yakın bir düğümden
		// bakması ciddi tasarruf sağlamakta.

		// iter = iter->next;
	}
	bastir(root);
	*/
	node* root;
	root = ekleSirali(root, 40);
	root = ekleSirali(root, 10);
	root = ekleSirali(root, 30);
	root = ekleSirali(root, 20);
	root = ekleSirali(root, 50);
	root = ekleSirali(root, -10);
	root = ekleSirali(root, -20);
	root = ekleSirali(root, -30);
	root = ekleSirali(root, 0);
	bastir(root);
	root = sil(root, -30);
	root = sil(root, -20);
	bastir(root);
	root = sil(root, 50);
	root = sil(root, 40);
	bastir(root);
	root = sil(root, 10);
	root = sil(root, -10);
	root = sil(root, 15);
	bastir(root);
	root = sil(root, 20);
	root = sil(root, 0);
	root = sil(root, 25);
	bastir(root);
	root = sil(root, 30);
	bastir(root);
	root = sil(root, -15);
	bastir(root);
}
