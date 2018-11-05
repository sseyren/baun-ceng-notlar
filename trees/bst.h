#ifndef _binary_search_tree
#define _binary_search_tree

struct nodeStruct {
	int data;
	nodeStruct* left;
	nodeStruct* right;
};
typedef nodeStruct node;

enum bst_trav_type { BST_PREORDER, BST_POSTORDER, BST_INORDER, BST_LEVELORDER };

node* bst_init();
node* bst_add(int value, node* root);
void bst_trav(node* root, bst_trav_type type);

#endif