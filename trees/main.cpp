#include <stdio.h>
#include "bst.h"

int main(){
	tnode* tree1 = bst_init();

	tree1 = bst_add(50, tree1);
	tree1 = bst_add(30, tree1);
	tree1 = bst_add(70, tree1);
	tree1 = bst_add(20, tree1);
	tree1 = bst_add(40, tree1);
	tree1 = bst_add(60, tree1);
	tree1 = bst_add(90, tree1);
	tree1 = bst_add(35, tree1);
	tree1 = bst_add(45, tree1);
	tree1 = bst_add(80, tree1);
	tree1 = bst_add(37, tree1);

	bst_trav(tree1, BST_PREORDER);
	bst_trav(tree1, BST_POSTORDER);
	bst_trav(tree1, BST_INORDER);

	printf("\n");

	printf("search %d -> %d\n", 0, bst_search(0, tree1));
	printf("search %d -> %d\n", 10, bst_search(10, tree1));
	printf("search %d -> %d\n", 20, bst_search(20, tree1));
	printf("search %d -> %d\n\n", 30, bst_search(30, tree1));

	printf("max-> %d min -> %d\n\n", bst_max(tree1), bst_min(tree1));

	tree1 = bst_delete(30, tree1);
	bst_trav(tree1, BST_PREORDER);
	tree1 = bst_delete(50, tree1);
	bst_trav(tree1, BST_PREORDER);
	tree1 = bst_delete(60, tree1);
	bst_trav(tree1, BST_PREORDER);
	tree1 = bst_delete(45, tree1);
	bst_trav(tree1, BST_PREORDER);
	tree1 = bst_delete(999, tree1);
	bst_trav(tree1, BST_PREORDER);
	tree1 = bst_delete(40, tree1);
	bst_trav(tree1, BST_PREORDER);
	return 0;
}