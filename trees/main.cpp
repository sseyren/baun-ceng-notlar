#include <stdio.h>
#include "bst.h"

int main(){
	tnode* tree1 = bst_init();

	tree1 = bst_add(10, tree1);
	tree1 = bst_add(20, tree1);
	tree1 = bst_add(5, tree1);

	bst_trav(tree1, BST_PREORDER);
	bst_trav(tree1, BST_POSTORDER);
	bst_trav(tree1, BST_INORDER);

	printf("search %d -> %d\n", 0, bst_search(0, tree1));
	printf("search %d -> %d\n", 10, bst_search(10, tree1));
	printf("search %d -> %d\n", 20, bst_search(20, tree1));
	printf("search %d -> %d\n", 30, bst_search(30, tree1));

	printf("max-> %d min -> %d\n", bst_max(tree1), bst_min(tree1));
	return 0;
}