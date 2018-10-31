#ifndef _queue_arr
#define _queue_arr

struct array_queue_struct {
	int head, tail, size;
	int* array;
};
typedef array_queue_struct ar_queue;

ar_queue* qa_init();
void qa_enque(int value, ar_queue* queue);
int qa_deque(ar_queue* queue);
void qa_look(ar_queue* queue);

#endif