WORKDIR=.
FILENAME=main

default: compile run

compile:
	g++ ${WORKDIR}/${FILENAME}.cpp ${WORKDIR}/bst.cpp ${WORKDIR}/avl.cpp -o ${WORKDIR}/${FILENAME}.out

run:
	${WORKDIR}/${FILENAME}.out