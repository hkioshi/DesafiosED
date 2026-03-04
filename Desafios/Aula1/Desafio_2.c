#include<stdio.h>
#include <stdlib.h>
#include "DesafioBase.c"


void printList(struct no * lista)
{
    // for (struct no* curr = lista; curr != NULL; curr = curr->prox)
    // {
    //     printf("%d ",curr->info);
    // }

    printf("%d ", lista->info);
    return lista->prox == NULL ? NULL : printList(lista->prox);
    
}

void RemoveUltimo(struct no * lista)
{
    // Se a lista estiver vazia ele apenas retorna
    // Se a lista tiver 1 elemento ele remove esse elemento
    // Se nao ele percorre a lista mantendo um ponteiro para o nó anterior ao último,
    // até chegar no final. Ao terminar o laço, "antes" estará apontando
    // para o penúltimo nó da lista, então basta fazer antes->prox = NULL
    // para remover o último elemento.
    
    if(lista-> prox == NULL) return;
    if(lista-> prox -> prox == NULL)
    {
        lista->prox = NULL;
        return;

    }

    struct no *antes = lista;
    
    
    for (struct no* curr = lista->prox->prox; curr != NULL; curr = curr->prox)
    {
       antes = antes->prox;
    }
    
    antes->prox = NULL;
    
    
}

int main() {

    struct no * lista = novoNo(2);
    for (int i = 0; i < 20; i++)
    {
        lista = insert_first(lista, i);
    }
    printList(lista);
    printf("\n");
    RemoveUltimo(lista);

    printList(lista);

    
    return 0;
}