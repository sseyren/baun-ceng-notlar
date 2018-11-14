#ifndef _avl_tree
#define _avl_tree

#include "tree_base.h"

tnode* avl_init();
void avl_trav(tnode* root, bst_trav_type type);
int avl_search(int value, tnode* list);
int avl_min(tnode* list);
int avl_max(tnode* list);

#endif