#include <stdio.h>
#include <stdlib.h>
#include "linkedlist.h"
#include "circularlist.h"

int main() {
	/*
	node* root = (node*)malloc(sizeof(node));
	root->data = 0;
	root->next = NULL;

	node* iter = root;

	for(int i = 0; i < 5; i++){
		ll_ekle(iter, (i+1)*10);
		//  ll_ekle()'nin her seferinde listenin sonuna gitmesi için
		// baştan başlayarak bakması yerine, sona yakın bir düğümden
		// bakması ciddi tasarruf sağlamakta.

		// iter = iter->next;
	}
	ll_bastir(root);
	*/
	node* root;
	root = ll_ekleSirali(root, 40);
	root = ll_ekleSirali(root, 10);
	root = ll_ekleSirali(root, 30);
	root = ll_ekleSirali(root, 20);
	root = ll_ekleSirali(root, 50);
	root = ll_ekleSirali(root, -10);
	root = ll_ekleSirali(root, -20);
	root = ll_ekleSirali(root, -30);
	root = ll_ekleSirali(root, 0);
	ll_bastir(root);
	root = ll_sil(root, -30);
	root = ll_sil(root, -20);
	ll_bastir(root);
	root = ll_sil(root, 50);
	root = ll_sil(root, 40);
	ll_bastir(root);
	root = ll_sil(root, 10);
	root = ll_sil(root, -10);
	root = ll_sil(root, 15);
	ll_bastir(root);
	root = ll_sil(root, 20);
	root = ll_sil(root, 0);
	root = ll_sil(root, 25);
	ll_bastir(root);
	root = ll_sil(root, 30);
	ll_bastir(root);
	root = ll_sil(root, -15);
	ll_bastir(root);

	printf("-----------------\n");

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
	root = NULL;
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

	return 0;
}
