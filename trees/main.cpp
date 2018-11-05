#include <stdio.h>
#include "bst.h"

int main(){
	node* tree1 = bst_init();
	tree1 = bst_add(10, tree1);
	tree1 = bst_add(20, tree1);
	tree1 = bst_add(5, tree1);
	bst_trav(tree1, BST_PREORDER);
	bst_trav(tree1, BST_POSTORDER);
	bst_trav(tree1, BST_INORDER);
	return 0;
}