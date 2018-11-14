#include <stdio.h>
#include "bst.h"

tnode* avl_init(){
	return bst_init();
}

void avl_trav(tnode* root, bst_trav_type type){
	return bst_trav(root, type);
}

int avl_search(int value, tnode* list){
	return bst_search(value, list);
}

int avl_min(tnode* list){
	return bst_min(list);
}

int avl_max(tnode* list){
	return bst_max(list);
}