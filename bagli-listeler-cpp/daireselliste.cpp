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
		cl_ekle(iter, (i+1)*10);
		//  cl_ekle()'nin her seferinde listenin sonuna gitmesi için
		// baştan başlayarak bakması yerine, sona yakın bir düğümden
		// bakması ciddi tasarruf sağlamakta.

		// iter = iter->next;
	}
	cl_bastir(root);
	*/
	node* root;
	root = cl_ekleSirali(root, 40);
	root = cl_ekleSirali(root, 10);
	root = cl_ekleSirali(root, 30);
	root = cl_ekleSirali(root, 20);
	root = cl_ekleSirali(root, 50);
	root = cl_ekleSirali(root, -10);
	root = cl_ekleSirali(root, -20);
	root = cl_ekleSirali(root, -30);
	root = cl_ekleSirali(root, 0);
	cl_bastir(root);
	root = cl_sil(root, -30);
	root = cl_sil(root, -20);
	cl_bastir(root);
	root = cl_sil(root, 50);
	root = cl_sil(root, 40);
	cl_bastir(root);
	root = cl_sil(root, 10);
	root = cl_sil(root, -10);
	root = cl_sil(root, 15);
	cl_bastir(root);
	root = cl_sil(root, 20);
	root = cl_sil(root, 0);
	root = cl_sil(root, 25);
	cl_bastir(root);
	root = cl_sil(root, 30);
	cl_bastir(root);
	root = cl_sil(root, -15);
	cl_bastir(root);
}
