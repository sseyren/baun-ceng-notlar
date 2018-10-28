#ifndef _circularlist
#define _circularlist

struct nodeStruct {
    int data;
    nodeStruct* next;
};
typedef nodeStruct node;

void bastir(node*);
void ekle(node*, int);
node* ekleSirali(node*, int);
node* sil(node*, int);

#endif
