#ifndef _binary_search_tree
#define _binary_search_tree

#include "tree_base.h"

tnode* bst_init();
tnode* bst_add(int value, tnode* root);
void bst_trav(tnode* root, bst_trav_type type);
int bst_search(int value, tnode* list);
int bst_min(tnode* list);
int bst_max(tnode* list);
tnode* bst_delete(int value, tnode* tree);

#endif