#include <stdio.h>
#include <stdlib.h>
#include "bst.h"

const char* bst_trav_names[] = {
	[BST_PREORDER] = "Pre-ordered", 
	[BST_POSTORDER] = "Post-ordered", 
	[BST_INORDER] = "In-ordered", 
	[BST_LEVELORDER] = "Level-ordered"
};

node* bst_init(){
	return NULL;
}

void childKiller(node* leaf){
	leaf->left = NULL;
	leaf->right = NULL;
}

node* bst_add(int value, node* root){
	node* newnode = (node*)malloc(sizeof(node));
	newnode->data = value;
	childKiller(newnode);

	if(root == NULL)
		return newnode;

	node* iter = root;
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

void preorder_trav(node* root){
	printf("%d ", root->data);
	if(root->left != NULL)
		preorder_trav(root->left);
	if(root->right != NULL)
		preorder_trav(root->right);
}

void postorder_trav(node* root){
	if(root->left != NULL)
		postorder_trav(root->left);
	if(root->right != NULL)
		postorder_trav(root->right);
	printf("%d ", root->data);
}

void inorder_trav(node* root){
	if(root->left != NULL)
		inorder_trav(root->left);
	printf("%d ", root->data);
	if(root->right != NULL)
		inorder_trav(root->right);
}

void levelorder_trav(node* root){
	printf("<levelorder-struct>\n");
}

void bst_trav(node* root, bst_trav_type type){
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

int bst_search(int value, node* list){
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