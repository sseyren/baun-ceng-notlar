#include <stdio.h>
#include <stdlib.h>

struct nodeStruct {
	int data;
	nodeStruct* next;
};
typedef nodeStruct node;

int main() {
	node* root;

	// malloc void tipi döndürdüğünden dolayı (node*'a) tür dönüşümü yaptık
	root = (node*)malloc(sizeof(node));
	root->data = 10;

	root->next = (node*)malloc(sizeof(node));
	root->next->data = 20;

	root->next->next = (node*)malloc(sizeof(node));
	root->next->next->data = 30;

	// Nodelar arasında daha kolay gezinmek için iter pointer'ı tanımladık.
	node* iter;
	iter = root;
	printf("%d\n", iter->data);

	iter = iter->next;
	printf("%d\n", iter->data);

	iter = iter->next;
	printf("%d\n", iter->data);

	iter = root;
	printf("%d\n", iter->data);
	printf("\n%d\n", root->data);
}
