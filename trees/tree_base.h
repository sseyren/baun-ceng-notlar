#ifndef _tree_node_basics
#define _tree_node_basics

struct tnodeStruct {
	int data;
	tnodeStruct* left;
	tnodeStruct* right;
};
typedef tnodeStruct tnode;

enum bst_trav_type { BST_PREORDER, BST_POSTORDER, BST_INORDER, BST_LEVELORDER };

#endif