WORKDIR=.
FILENAME=main

run: compile
	${WORKDIR}/${FILENAME}.out

compile:
	g++ ${WORKDIR}/${FILENAME}.cpp ${WORKDIR}/stack_arr.cpp ${WORKDIR}/stack_ll.cpp ${WORKDIR}/queue_arr.cpp -o ${WORKDIR}/${FILENAME}.out
