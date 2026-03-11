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

void remove_value(struct no *lista, int value)
{
    // Se a lista estiver vazia, não faz nada
    // Percorre a lista nó por nó
    // Verifica se o próximo nó contém o valor desejado
    // Se contiver, faz o nó atual apontar para o próximo do próximo,
    // removendo assim o nó da lista
    // Encerra a função após remover o primeiro valor encontrado

    for (struct no* curr = lista; curr != NULL; curr = curr->prox)
    {
        if(curr->prox->info == value && lista->prox->prox != NULL)
        {
            curr->prox = curr->prox->prox;
            return;
        }
    }
}

int main() {

    struct no * lista = novoNo(2);
    for (int i = 0; i < 20; i++)
    {
        lista = insert_first(lista, i);
    }
    printList(lista);
    printf("\n");
    remove_value(lista,2);

    printList(lista);

    
    return 0;
}