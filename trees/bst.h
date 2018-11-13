#ifndef _binary_search_tree
#define _binary_search_tree

struct tnodeStruct {
	int data;
	tnodeStruct* left;
	tnodeStruct* right;
	tnodeStruct* parent;
};
typedef tnodeStruct tnode;

enum bst_trav_type { BST_PREORDER, BST_POSTORDER, BST_INORDER, BST_LEVELORDER };

tnode* bst_init();
tnode* bst_add(int value, tnode* root);
void bst_trav(tnode* root, bst_trav_type type);
int bst_search(int value, tnode* list);
int bst_min(tnode* list);
int bst_max(tnode* list);

#endif