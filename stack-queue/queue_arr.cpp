#include <stdio.h>
#include <stdlib.h>
#include "queue_arr.h"

ar_queue* qa_init(){
	ar_queue* queue = (ar_queue*)malloc(sizeof(ar_queue));
	queue->head = 0;
	queue->tail = 0;
	queue->size = 2;
	queue->array = (int*)malloc(sizeof(int) * queue->size);
}

void qa_enque(int value, ar_queue* queue){
	if (queue->size == queue->tail){
		if(queue->size <= queue->tail - queue->head){
			// tüm elemanlar kullanımda olduğu için daha büyük array
			int newsize = queue->size * 2;
			//printf("newsize: %d\n", newsize);
			int* newarray = (int*)malloc(sizeof(int) * newsize);
			for (int i = 0; i < queue->size; ++i)
				newarray[i] = queue->array[i];
			free(queue->array);
			queue->array = newarray;
			queue->size = newsize;
		}else{
			// dizinin başında yer olduğu için başa taşıma
			int* newarray = (int*)malloc(sizeof(int) * queue->size);
			for (int i = queue->head; i < queue->tail; ++i){
				newarray[i - queue->head] =  queue->array[i];
			}
			free(queue->array);
			queue->tail = queue->tail - queue->head;
			queue->head = 0;
			queue->array = newarray;
		}
	}
	queue->array[queue->tail++] = value;
}

int qa_deque(ar_queue* queue){
	if(queue->head == queue->tail)
		return -1;
	return queue->array[queue->head++];
}

void qa_look(ar_queue* queue){
	if (queue->head == queue->tail){
		printf("EMPTY\n");
		return;
	}
	printf("----- Size: %d\n", queue->size);
	for (int i = queue->head; i < queue->tail; ++i){
		printf("%d -> %d\n", i, queue->array[i]);
	}
}