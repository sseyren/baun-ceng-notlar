#include <stdio.h>
#include <stdlib.h>
#include "bst.h"

const char* bst_trav_names[] = {
	[BST_PREORDER] = "Pre-ordered", 
	[BST_POSTORDER] = "Post-ordered", 
	[BST_INORDER] = "In-ordered", 
	[BST_LEVELORDER] = "Level-ordered"
};

tnode* bst_init(){
	return NULL;
}

void childKiller(tnode* leaf){
	leaf->left = NULL;
	leaf->right = NULL;
}

tnode* bst_add(int value, tnode* root){
	tnode* newnode = (tnode*)malloc(sizeof(tnode));
	newnode->data = value;
	childKiller(newnode);

	if(root == NULL)
		return newnode;

	tnode* iter = root;
	while(true){
		if(value >= iter->data){
			if(iter->right == NULL){
				iter->right = newnode;
				return root;
			}
			iter = iter->right;
		}else{
			if(iter->left == NULL){
				iter->left = newnode;
				return root;
			}
			iter = iter->left;
		}
	}
}

void preorder_trav(tnode* root){
	printf("%d ", root->data);
	if(root->left != NULL)
		preorder_trav(root->left);
	if(root->right != NULL)
		preorder_trav(root->right);
}

void postorder_trav(tnode* root){
	if(root->left != NULL)
		postorder_trav(root->left);
	if(root->right != NULL)
		postorder_trav(root->right);
	printf("%d ", root->data);
}

void inorder_trav(tnode* root){
	if(root->left != NULL)
		inorder_trav(root->left);
	printf("%d ", root->data);
	if(root->right != NULL)
		inorder_trav(root->right);
}

void levelorder_trav(tnode* root){
	printf("<levelorder-struct>\n");
}

void bst_trav(tnode* root, bst_trav_type type){
	printf("%s: ", bst_trav_names[type]);
	if(root == NULL){
		printf("NULL\n");
		return;
	}
	if (type == BST_PREORDER)
		preorder_trav(root);
	else if (type == BST_POSTORDER)
		postorder_trav(root);
	else if (type == BST_INORDER)
		inorder_trav(root);
	else if (type == BST_LEVELORDER)
		levelorder_trav(root);
	printf("\n");
}

int bst_search(int value, tnode* list){
	while(list != NULL){
		if(list->data == value)
			return 1;
		else if (value >= list->data){
			list = list->right;
		}else{
			list = list->left;
		}
	}
	return -1;
}

int bst_min(tnode* list){
	if (list == NULL)
		return -1;
	while(list->left != NULL)
		list = list->left;
	return list->data;
}

int bst_max(tnode* list){
	if (list == NULL)
		return -1;
	while(list->right != NULL)
		list = list->right;
	return list->data;
}

tnode* bst_delete(int value, tnode* tree){
	if (tree == NULL)
		return NULL;
	if (tree->data == value){
		if (tree->left == NULL && tree->right == NULL){
			free(tree);
			return NULL;
		}
		if (tree->right != NULL){
			int rightMin = bst_min(tree->right);
			tree->data = rightMin;
			tree->right = bst_delete(rightMin, tree->right);
			return tree;
		}
		int leftMax = bst_max(tree->left);
		tree->data = leftMax;
		tree->left = bst_delete(leftMax, tree->left);
		return tree;
	}
	if (tree->data <= value){
		tree->right = bst_delete(value, tree->right);
		return tree;
	}
	tree->left = bst_delete(value, tree->left);
	return tree;
}