#include<stdio.h>
#include <stdlib.h>
#include "DesafioBase.c"

void printList(struct no * lista)
{
    // for (struct no* curr = lista; curr != NULL; curr = curr->prox)
    // {
    //     printf("%d ",curr->info);
    // }

    //A função vai impririr a lista.
    //Se a lista chegar ao fim ou seja nulo ele retorna nulo
    //Se nao ele chama outra vez a funcao so que dessa vez com a lista sem o elemento impresso

    printf("%d ", lista->info);
    return lista->prox == NULL ? NULL : printList(lista->prox);
    
}

int main() {

    struct no * lista = novoNo(2);
    for (int i = 0; i < 20; i++)
    {
        lista = insert_first(lista, i);
    }
    printList(lista);
    return 0;
}